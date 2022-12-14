using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ScreenImageOverlay.WindowsFormsApp
{
	public partial class MainForm : Form
	{
		#region Fields

		private const double MinOpacity = 0.01;
		private const double MaxOpacity = 1.0;

		private static readonly Lazy<IReadOnlyCollection<string>> SaveImageFilters = new Lazy<IReadOnlyCollection<string>>(() =>
			new string[]
			{
				"BMP (Bitmap)|*.bmp",
				"EMF (Enhanced Meta File)|*.emf",
				"EXIF (Exchangeable Image File)|*.exif",
				"GIF (Graphics Interchange Format)|*.gif",
				"ICO (Icon)|*.ico",
				"JPEG (Joint Photographic Experts Group)|*.jpeg;*.jpg;*.jfif",
				"PNG (Portable Network Graphics)|*.png",
				"TIFF (Tagged Image File Format)|*.tiff;*.tif",
				"WMF (Windows Metafile)|*.wmf",
				"All Supported Files|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.jfif;*.png;*.tif;*.tiff;*.wmf",
			});

		private readonly Playlist playlist;
		private readonly List<Command> commands;

		private EditMode editMode;
		private bool isForcedVisible;
		private double oldOpacity;
		private bool allowClickThrough;
		private bool transparentBackground;
		private bool isSizeLocked;
		private bool isLoadingImage;
		private bool slideshowBackward;
		private FormBorderStyle borderStyleBeforeFullScreen;
		private bool isRightClickPressed;
		private bool cancelRightClick;

		#endregion

		#region Types

		private enum EditMode
		{
			None,
			Inspect,
			Move,
		}

		private class Command
		{
			public Command(string name, Action execute, Func<bool> canExecute)
			{
				Name = name;
				Execute = execute;
				CanExecute = canExecute;
			}

			public Command(string name, Action execute)
			{
				Name = name;
				Execute = execute;
			}

			public string Name { get; set; }
			public Func<bool> CanExecute { get; set; }
			public Action Execute { get; set; }
			public Keys? KeyCode { get; set; }
			public Keys? Modifiers { get; set; }
		}

		#endregion

		#region Constructors

		public MainForm()
		{
			InitializeComponent();

			if (!DesignMode)
			{
				pictureBox1.AllowDrop = true;
				pictureBox1.Tag = "";
				SetPictureSizeMode(pictureBox1.SizeMode);

				playlist = new Playlist();
				playlist.PropertyChanged += Playlist_PropertyChanged;

				commands = new List<Command>
				{
					new Command("Exit", Exit) { KeyCode = Keys.Escape },
					new Command("Large Decrease Opacity", LargeDecreaseOpacity, CanLargeDecreaseOpacity) { KeyCode = Keys.OemMinus, Modifiers = Keys.Control },
					new Command("Large Increase Opacity", LargeIncreaseOpacity, CanLargeIncreaseOpacity) { KeyCode = Keys.Oemplus, Modifiers = Keys.Control },
					new Command("Small Decrease Opacity", SmallDecreaseOpacity, CanSmallDecreaseOpacity) { KeyCode = Keys.OemMinus },
					new Command("Small Increase Opacity", SmallIncreaseOpacity, CanSmallIncreaseOpacity) { KeyCode = Keys.Oemplus },
					new Command("Resize Window To Image Size", ResizeWindowToImageSize, CanResizeWindowToImageSize) { KeyCode = Keys.R },
					new Command("Toggle Inspect Mode", ToggleInspectMode) { KeyCode = Keys.X },
					new Command("Toggle Move Mode", ToggleMoveMode) { KeyCode = Keys.C },
					new Command("Toggle Forced Visibility", ToggleForcedVisibility) { KeyCode = Keys.Space },
					new Command("Toggle Click Through", ToggleClickThrough) { KeyCode = Keys.G },
					new Command("Toggle Transparent Background", ToggleTransparentBackground) { KeyCode = Keys.B },
					new Command("Open File", OpenFile) { KeyCode = Keys.O, Modifiers = Keys.Control },
					new Command("Open Folder", OpenFolder) { KeyCode = Keys.D, Modifiers = Keys.Control },
					new Command("Playlist Select Previous", PlaylistSelectPrevious, CanPlaylistSelectPrevious) { KeyCode = Keys.PageUp },
					new Command("Playlist Select Next", PlaylistSelectNext, CanPlaylistSelectNext) { KeyCode = Keys.PageDown },
					new Command("Playlist Select First", PlaylistSelectFirst, CanPlaylistSelectFirst) { KeyCode = Keys.Home },
					new Command("Playlist Select Last", PlaylistSelectLast, CanPlaylistSelectLast) { KeyCode = Keys.End },
					new Command("Playlist Toggle", TogglePlaylist, CanTogglePlaylist) { KeyCode = Keys.L },
					new Command("Playlist Toggle Wrap", TogglePlaylistWrap) { KeyCode = Keys.W },
					new Command("Toggle Size Lock", ToggleSizeLock) { KeyCode = Keys.Z },
					new Command("Toggle Slideshow Backward", ToggleSlideshowBackward) { KeyCode = Keys.P, Modifiers = Keys.Shift },
					new Command("Toggle Slideshow", ToggleSlideshow) { KeyCode = Keys.P },
					new Command("Toggle FullScreen", ToggleFullScreen) { KeyCode = Keys.F },
					new Command("Toggle Title Bar", ToggleTitleBar) { KeyCode = Keys.T },
					new Command("Toggle Always On Top", ToggleAlwaysOnTop) { KeyCode = Keys.Y },
					new Command("Show Shortcuts", ShowShortcuts) { KeyCode = Keys.F1 },
				};

				UpdateContextMenu();
				UpdatePlaylistMenu();
				UpdateOpacityMenu();
				UpdatePictureMenu();
			}
		}

		#endregion

		#region Form Event Handlers

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (playlist is null)
			{
				return;
			}

			playlist.PropertyChanged -= Playlist_PropertyChanged;
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Effect == DragDropEffects.Copy)
			{
				var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, autoConvert: true);

				if (fileNames != null && fileNames.Length > 0)
				{
					playlist.BeginUpdate();

					foreach (var fileName in fileNames)
					{
						if (Directory.Exists(fileName))
						{
							foreach (var fileInfo in new DirectoryInfo(fileName)
								.EnumerateFiles("*.*", SearchOption.AllDirectories)
								.Where(x => IsImageFileExtension(x.Extension)))
							{
								playlist.Add(fileInfo.FullName);
							}
						}
						else
						{
							var fileInfo = new FileInfo(fileName);

							if (!IsImageFileExtension(fileInfo.Extension))
							{
								continue;
							}

							playlist.Add(fileInfo.FullName);
						}
					}

					playlist.EndUpdate();

					if (playlist.CanSelectLast())
					{
						playlist.SelectLast();
					}

					UpdatePlaylistMenu();
				}
			}
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			foreach (var command in commands)
			{
				if (command.Execute is null)
				{
					continue;
				}

				if (command.KeyCode != null
					&& command.KeyCode.Value != e.KeyCode)
				{
					continue;
				}

				if (command.Modifiers != null
					&& command.Modifiers.Value != e.Modifiers)
				{
					continue;
				}
				else if (command.Modifiers is null
					&& e.Modifiers != Keys.None)
				{
					continue;
				}

				if (command.CanExecute != null
					&& !command.CanExecute())
				{
					SystemSounds.Beep.Play();
					continue;
				}

				command.Execute();

				break;
			}
		}

		#endregion

		#region Playlist Event Handlers

		private void Playlist_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Playlist.FileNames):
					break;

				case nameof(Playlist.SelectedIndex):
					ApplyImage();
					break;
			}
		}

		#endregion

		#region Label Event Handlers

		private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (ModifierKeys == Keys.Shift)
				{
					OpenFolder();
				}
				else
				{
					OpenFile();
				}
			}
		}

		private void label1_DragDrop(object sender, DragEventArgs e)
		{
			MainForm_DragDrop(sender, e);
		}

		private void label1_DragEnter(object sender, DragEventArgs e)
		{
			MainForm_DragEnter(sender, e);
		}

		#endregion

		#region PictureBox Event Handlers

		private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			progressBar1.Visible = false;
			pictureBox1.Visible = true;
			isLoadingImage = false;
			
			if (!isSizeLocked)
			{
				ResizeWindowToImageSize();
			}
		}

		private void pictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void pictureBox1_DragDrop(object sender, DragEventArgs e)
		{
			MainForm_DragDrop(sender, e);
		}

		private void pictureBox1_DragEnter(object sender, DragEventArgs e)
		{
			MainForm_DragEnter(sender, e);
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				isRightClickPressed = true;
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				isRightClickPressed = false;
			}
		}

		private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (isRightClickPressed)
			{
				cancelRightClick = true;
			}

			if ((ModifierKeys.HasFlag(Keys.Shift))
				|| isRightClickPressed)
			{
				if (ModifierKeys.HasFlag(Keys.Control))
				{
					if (!CanPlaylistSelectFirst())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectFirst();
				}
				else
				{
					if (!CanPlaylistSelectPrevious())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectPrevious();
				}
			}
			else
			{
				if (ModifierKeys.HasFlag(Keys.Control))
				{
					if (!CanPlaylistSelectLast())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectLast();
				}
				else
				{
					if (!CanPlaylistSelectNext())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectNext();
				}
			}
		}

		private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				if (e.Delta < 0)
				{
					if (!CanPlaylistSelectFirst())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectFirst();
				}
				else
				{
					if (!CanPlaylistSelectLast())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectLast();
				}
			}
			else
			{
				if (e.Delta < 0)
				{
					if (!CanPlaylistSelectPrevious())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectPrevious();
				}
				else
				{
					if (!CanPlaylistSelectNext())
					{
						SystemSounds.Beep.Play();
						return;
					}

					PlaylistSelectNext();
				}
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (editMode == EditMode.Inspect)
			{
				UpdateTitle();
			}
		}

		#endregion

		#region Slideshow Timer Event Handlers

		private void slideshowTimer_Tick(object sender, EventArgs e)
		{
			if (slideshowBackward)
			{
				if (!CanPlaylistSelectPrevious())
				{
					return;
				}

				PlaylistSelectPrevious();
			}
			else
			{
				if (!CanPlaylistSelectNext())
				{
					return;
				}

				PlaylistSelectNext();
			}
		}

		#endregion

		#region Context Menu Event Handlers

		private void pictureBoxContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (cancelRightClick)
			{
				cancelRightClick = false;
				e.Cancel = true;
				return;
			}

			UpdateContextMenu();
			UpdatePlaylistMenu();
			UpdateOpacityMenu();
			UpdatePictureMenu();
		}

		#endregion

		#region Menu Event Handlers

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		private void folderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFolder();
		}

		private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SmallIncreaseOpacity();
		}

		private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SmallDecreaseOpacity();
		}

		private void largeIncreaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LargeIncreaseOpacity();
		}

		private void largeDecreaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LargeDecreaseOpacity();
		}

		private void opaqueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleForcedVisibility();
		}

		private void clickthroughToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleClickThrough();
		}

		private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleAlwaysOnTop();
		}

		private void enableTransparentBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleTransparentBackground();
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseBackgroundColor();
		}

		private void normalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPictureSizeMode(PictureBoxSizeMode.Normal);
		}

		private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPictureSizeMode(PictureBoxSizeMode.StretchImage);
		}

		private void autoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPictureSizeMode(PictureBoxSizeMode.AutoSize);
		}

		private void centerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPictureSizeMode(PictureBoxSizeMode.CenterImage);
		}

		private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPictureSizeMode(PictureBoxSizeMode.Zoom);
		}

		private void lockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleSizeLock();
		}

		private void fitWindowToImageToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ResizeWindowToImageSize();
		}

		private void inspectModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleInspectMode();
		}

		private void navigationModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleMoveMode();
		}

		private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePlaylistWrap();
		}

		private void goToFirstToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlaylistSelectFirst();
		}

		private void goToLastToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlaylistSelectLast();
		}

		private void goToPreviousToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlaylistSelectPrevious();
		}

		private void goToNextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlaylistSelectNext();
		}

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePlaylist();
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearPlaylist();
		}

		private void enableSlideshowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleSlideshow();
		}

		private void configureSlideshowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConfigureSlideshow();
		}

		private void showTitleBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleTitleBar();
		}

		private void enableFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleFullScreen();
		}

		private void changeToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowOpacityPrompt();
		}

		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowImageProperties();
		}

		private void githubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenGithubLink();
		}

		private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowShortcuts();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAbout();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Exit();
		}

		#endregion

		#region Commands

		private void OpenFile()
		{
			using (var ofn = new OpenFileDialog
			{
				CheckFileExists = true,
				Multiselect = true,
				Filter = string.Join("|", SaveImageFilters.Value),
				FilterIndex = SaveImageFilters.Value.Count
			})
			{
				if (ofn.ShowDialog(this) == DialogResult.OK)
				{
					playlist.BeginUpdate();
					playlist.AddRange(ofn.FileNames);
					playlist.EndUpdate();

					if (playlist.CanSelectLast())
					{
						playlist.SelectLast();
					}

					UpdatePlaylistMenu();
				}
			}
		}

		private void OpenFolder()
		{
			using (var dialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = true,
			})
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					playlist.BeginUpdate();
					playlist.AddRange(Directory.EnumerateFiles(dialog.SelectedPath));
					playlist.EndUpdate();

					if (playlist.CanSelectLast())
					{
						playlist.SelectLast();
					}

					UpdatePlaylistMenu();
				}
			}
		}

		private void Exit()
		{
			Close();
		}

		private void ToggleTitleBar()
		{
			if (IsTitleBarVisible())
			{
				HideTitleBar();
			}
			else
			{
				ShowTitleBar();
			}
		}

		private bool IsTitleBarVisible()
			=> FormBorderStyle == FormBorderStyle.Sizable;

		private void ShowTitleBar()
		{
			FormBorderStyle = FormBorderStyle.Sizable;
			borderStyleBeforeFullScreen = FormBorderStyle;
		}

		private void HideTitleBar()
		{
			FormBorderStyle = FormBorderStyle.None;
			borderStyleBeforeFullScreen = FormBorderStyle;
		}

		private void ToggleFullScreen()
		{
			if (IsFullScreen())
			{
				LeaveFullScreen();
			}
			else
			{
				EnterFullScreen();
			}
		}

		private bool IsFullScreen()
			=> WindowState == FormWindowState.Maximized
			&& FormBorderStyle == FormBorderStyle.None;

		private void EnterFullScreen()
		{
			borderStyleBeforeFullScreen = FormBorderStyle;
			WindowState = FormWindowState.Maximized;
			FormBorderStyle = FormBorderStyle.None;
		}

		private void LeaveFullScreen()
		{
			WindowState = FormWindowState.Normal;
			FormBorderStyle = borderStyleBeforeFullScreen;
		}

		private void ToggleSizeLock()
		{
			isSizeLocked = !isSizeLocked;
		}

		private void PlaylistSelectFirst()
		{
			playlist.SelectFirst();
			UpdatePlaylistMenu();
		}

		private void PlaylistSelectLast()
		{
			playlist.SelectLast();
			UpdatePlaylistMenu();
		}

		private void PlaylistSelectPrevious()
		{
			playlist.SelectPrevious();
			UpdatePlaylistMenu();
		}

		private void PlaylistSelectNext()
		{
			playlist.SelectNext();
			UpdatePlaylistMenu();
		}

		private bool CanPlaylistSelectFirst()
			=> playlist.CanSelectFirst();

		private bool CanPlaylistSelectLast()
			=> playlist.CanSelectLast();

		private bool CanPlaylistSelectPrevious()
			=> playlist.CanSelectPrevious();

		private bool CanPlaylistSelectNext()
			=> playlist.CanSelectNext();

		private void ToggleClickThrough()
		{
			if (allowClickThrough)
			{
				DisableClickThrough();
			}
			else
			{
				EnableClickThrough();
			}
		}

		private void EnableClickThrough()
		{
			var style = User32.NativeMethods.GetWindowLong(this.Handle, User32.NativeMethods.GWL_EXSTYLE);

			User32.NativeMethods.SetWindowLong(this.Handle, User32.NativeMethods.GWL_EXSTYLE, style | User32.NativeMethods.WS_EX_LAYERED | User32.NativeMethods.WS_EX_TRANSPARENT);

			TopMost = true;
			allowClickThrough = true;
		}

		private void DisableClickThrough()
		{
			var style = User32.NativeMethods.GetWindowLong(this.Handle, User32.NativeMethods.GWL_EXSTYLE);

			User32.NativeMethods.SetWindowLong(this.Handle, User32.NativeMethods.GWL_EXSTYLE, style & ~(User32.NativeMethods.WS_EX_LAYERED | User32.NativeMethods.WS_EX_TRANSPARENT));

			TopMost = false;
			allowClickThrough = false;
		}

		private void ToggleForcedVisibility()
		{
			if (isForcedVisible)
			{
				LeaveForcedVisibility();
			}
			else
			{
				EnterForcedVisibility();
			}
		}

		private void EnterForcedVisibility()
		{
			oldOpacity = Opacity;
			Opacity = 1.0;
			isForcedVisible = true;
		}

		private void LeaveForcedVisibility()
		{
			Opacity = oldOpacity;
			isForcedVisible = false;
		}

		private void ToggleAlwaysOnTop()
		{
			if (TopMost)
			{
				DisableAlwaysOnTop();
			}
			else
			{
				EnableAlwaysOnTop();
			}
		}

		private void EnableAlwaysOnTop()
		{
			TopMost = true;
		}

		private void DisableAlwaysOnTop()
		{
			DisableClickThrough();
			TopMost = false;
		}

		private void ToggleTransparentBackground()
		{
			if (transparentBackground)
			{
				DisableTransparentBackground();
			}
			else
			{
				EnableTransparentBackground();
			}
		}

		private void DisableTransparentBackground()
		{
			AllowTransparency = false;
			transparentBackground = false;
		}

		private void EnableTransparentBackground()
		{
			if (TransparencyKey != BackColor)
			{
				TransparencyKey = BackColor;
			}
			AllowTransparency = true;
			// Changing AllowTransparency somehow makes the caption bar non-clickable, so recreate it, if necessary.
			if (IsTitleBarVisible())
			{
				FormBorderStyle = FormBorderStyle.None;
				FormBorderStyle = FormBorderStyle.Sizable;
			}
			transparentBackground = true;
		}

		private void ChooseBackgroundColor()
		{
			using (var dialog = new ColorDialog
			{
				Color = BackColor,
			})
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					BackColor = dialog.Color;

					if (transparentBackground)
					{
						if (TransparencyKey != BackColor)
						{
							TransparencyKey = BackColor;
						}
					}
				}
			}
		}

		private void ToggleMoveMode()
		{
			if (editMode == EditMode.Move)
			{
				ResetEditMode();
			}
			else
			{
				EnterMoveMode();
			}
		}

		private void EnterMoveMode()
		{
			editMode = EditMode.Move;
			pictureBox1.Cursor = Cursors.Hand;
			UpdateTitle();
		}

		private void ToggleInspectMode()
		{
			if (editMode == EditMode.Inspect)
			{
				ResetEditMode();
			}
			else
			{
				EnterInspectMode();
			}
		}

		private void EnterInspectMode()
		{
			editMode = EditMode.Inspect;
			pictureBox1.Cursor = Cursors.Cross;
			UpdateTitle();
		}

		private void ResetEditMode()
		{
			editMode = EditMode.None;
			pictureBox1.Cursor = Cursors.Default;
			UpdateTitle();
		}

		private void SmallIncreaseOpacity()
			=> IncreaseOpacity(0.01);

		private void SmallDecreaseOpacity()
			=> DecreaseOpacity(0.01);

		private void LargeIncreaseOpacity()
			=> IncreaseOpacity(0.1);

		private void LargeDecreaseOpacity()
			=> DecreaseOpacity(0.1);

		private bool CanSmallIncreaseOpacity()
			=> Opacity < MaxOpacity;

		private bool CanSmallDecreaseOpacity()
			=> Opacity > MinOpacity;

		private bool CanLargeIncreaseOpacity()
			=> Opacity < MaxOpacity;

		private bool CanLargeDecreaseOpacity()
			=> Opacity > MinOpacity;

		private void ShowOpacityPrompt()
		{
			using (var form = new OpacityDialog
			{
				Text = GetFormattedText(),
			})
			{
				var savedOpacity = Opacity;

				form.TrackBar.Minimum = (int)(MinOpacity * 100);
				form.TrackBar.Maximum = (int)(MaxOpacity * 100);
				form.TrackBar.Value = (int)(Opacity * 100.0);
				form.TrackBar.ValueChanged += TrackBar_ValueChanged;

				if (form.ShowDialog(this) != DialogResult.OK)
				{
					if (Opacity != savedOpacity)
					{
						Opacity = savedOpacity;
					}
				}

				void TrackBar_ValueChanged(object sender, EventArgs e)
				{
					Opacity = form.TrackBar.Value / 100.0;
					form.Text = GetFormattedText();
					isForcedVisible = false;
				}
			}

			string GetFormattedText()
			{
				return $"Opacity ({(int)(Opacity * 100)}%)";
			}
		}

		private void ClearPlaylist()
		{
			pictureBox1.Image = null;
			playlist.Clear();
			UpdatePlaylistMenu();
		}

		private bool CanClearPlaylist()
			=> playlist.CanClear();

		private void ShowImageProperties()
		{
			using (var form = new ImagePropertiesDialog
			{
			})
			{
				form.ListView.BeginUpdate();
				form.ListView.Items.AddRange(new ListViewItem[]
				{
					new ListViewItem(new string[] { $"{pictureBox1.Tag as string}", "Path" }),
					new ListViewItem(new string[] { $"{pictureBox1.Image?.Width}", "Width" }),
					new ListViewItem(new string[] { $"{pictureBox1.Image?.Height}", "Height" }),
					new ListViewItem(new string[] { $"{pictureBox1.Image?.HorizontalResolution}", "HorizontalResolution" }),
					new ListViewItem(new string[] { $"{pictureBox1.Image?.VerticalResolution}", "VerticalResolution" }),
					new ListViewItem(new string[] { $"{pictureBox1.Image?.PixelFormat}", "PixelFormat" }),
					new ListViewItem(new string[] { $"{(ImageFlags?)pictureBox1.Image?.Flags}", "Flags" }),
				});
				form.ListView.EndUpdate();
				form.ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				form.ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				form.ListView.AfterLabelEdit += ListView_AfterLabelEdit;

				form.ShowDialog(this);

				void ListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
				{
					e.CancelEdit = true;
				}
			}
		}

		private void TogglePlaylist()
		{
			if (OwnedForms != null
				&& OwnedForms.Any(x => x is PlaylistForm))
			{
				var form = OwnedForms.First(x => x is PlaylistForm);

				if (form.Visible)
				{
					form.Visible = false;
					Activate();
				}
				else
				{
					form.Visible = true;
					form.BringToFront();
				}
			}
			else
			{
				var form = new PlaylistForm(playlist);

				form.Show(this);

				AddOwnedForm(form);
			}
		}

		private bool CanTogglePlaylist()
			=> true;

		private void TogglePlaylistWrap()
		{
			playlist.AllowWrap = !playlist.AllowWrap;
			UpdatePlaylistMenu();
		}

		private void ResizeWindowToImageSize()
		{
			ClientSize = pictureBox1.Image.Size;

			if (WindowState == FormWindowState.Maximized
				&& (pictureBox1.SizeMode == PictureBoxSizeMode.AutoSize
				|| pictureBox1.SizeMode == PictureBoxSizeMode.Zoom
				|| pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage))
			{
				WindowState = FormWindowState.Normal;
				WindowState = FormWindowState.Maximized;
			}
		}

		private bool CanResizeWindowToImageSize()
			=> pictureBox1.Image != null;

		private void SetPictureSizeMode(PictureBoxSizeMode sizeMode)
		{
			pictureBox1.SizeMode = sizeMode;

			if (sizeMode == PictureBoxSizeMode.Normal)
			{
				pictureBox1.Dock = DockStyle.None;
				pictureBox1.AutoSize = true;
				AutoScroll = false;
			}
			else if (sizeMode == PictureBoxSizeMode.AutoSize)
			{
				pictureBox1.Dock = DockStyle.None;
				pictureBox1.AutoSize = true;
				AutoScroll = true;
			}
			else
			{
				pictureBox1.Dock = DockStyle.Fill;
				pictureBox1.AutoSize = false;
				AutoScroll = false;
			}
		}

		private bool CanSetPictureSizeMode(PictureBoxSizeMode sizeMode)
			=> pictureBox1.Image != null
			&& pictureBox1.SizeMode != sizeMode;

		private void ToggleSlideshow()
		{
			slideshowTimer.Enabled = !slideshowTimer.Enabled;
		}

		private void ToggleSlideshowBackward()
		{
			slideshowBackward = !slideshowBackward;
		}

		private void ConfigureSlideshow()
		{
			using (var form = new SlideshowDialog
			{
			})
			{
				var savedInterval = slideshowTimer.Interval;
				var savedReverse = slideshowBackward;

				form.NumericUpDown.Minimum = 1;
				form.NumericUpDown.Maximum = int.MaxValue;
				form.NumericUpDown.Value = slideshowTimer.Interval;
				form.NumericUpDown.ValueChanged += NumericUpDown_ValueChanged;

				form.CheckBox.Checked = slideshowBackward;
				form.CheckBox.CheckedChanged += CheckBox_CheckedChanged;

				if (form.ShowDialog(this) != DialogResult.OK)
				{
					slideshowTimer.Interval = savedInterval;
					slideshowBackward = savedReverse;
				}

				void NumericUpDown_ValueChanged(object sender, EventArgs e)
				{
					slideshowTimer.Interval = (int)form.NumericUpDown.Value;
				}

				void CheckBox_CheckedChanged(object sender, EventArgs e)
				{
					slideshowBackward = form.CheckBox.Checked;
				}
			}
		}

		private void ShowAbout()
		{
			var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

			MessageBox.Show(this, $"{"Screen Image Overlay"} {fileVersionInfo.FileVersion}", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void OpenGithubLink()
		{
			try
			{
				using (var process = Process.Start("Explorer", "https://github.com/TakoNekko/ScreenImageOverlay"))
				{
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
			}
		}

		private void ShowShortcuts()
		{
			using (var form = new ShortcutsDialog
			{
			})
			{
				var mouseCommands = new string[][]
				{
					new string[] { "Playlist Select First", "Mouse Left Double Click", "Shift, Control" },
					new string[] { "Playlist Select First", "Mouse Left Double Click", "Shift, Mouse Right Button" },
					new string[] { "Playlist Select Last", "Mouse Left Double Click", "Control" },
					new string[] { "Playlist Select Previous", "Mouse Left Double Click", "Shift" },
					new string[] { "Playlist Select Previous", "Mouse Left Double Click", "Mouse Right Button" },
					new string[] { "Playlist Select Next", "Mouse Left Double Click", "" },
				};

				var mouseWheelCommands = new string[][]
				{
					new string[] { "Playlist Select First", "Mouse Wheel Down", "Control" },
					new string[] { "Playlist Select Last", "Mouse Wheel Up", "Control" },
					new string[] { "Playlist Select Previous", "Mouse Wheel Down", "" },
					new string[] { "Playlist Select Next", "Mouse Wheel Up", "" },
				};

				var listViewItems = new List<ListViewItem>();

				foreach (var command in mouseCommands)
				{
					listViewItems.Add(new ListViewItem(new string[]
					{
						command[0],
						command[1],
						command[2]
					}, form.MouseListViewGroup));
				}

				foreach (var command in mouseWheelCommands)
				{
					listViewItems.Add(new ListViewItem(new string[]
					{
						command[0],
						command[1],
						command[2]
					}, form.MouseWheelListViewGroup));
				}

				foreach (var command in commands)
				{
					if (command.KeyCode != null
						&& command.KeyCode != Keys.None)
					{
						listViewItems.Add(new ListViewItem(new string[]
						{
							$"{command.Name}",
							$"{command.KeyCode}",
							$"{command.Modifiers}"
						}, form.KeyListViewGroup));
					}
				}

				form.ListView.BeginUpdate();
				form.ListView.Items.AddRange(listViewItems.ToArray());
				form.ListView.EndUpdate();
				form.ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				form.ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

				form.ShowDialog(this);
			}
		}

		#endregion

		#region Implementation

		private bool IsImageFileExtension(string extension)
			=> SaveImageFilters.Value.Any(x => x.Split(new char[] { '|' })[1]
				.Split(new char[] { ';' })
				.Select(y => y.Substring(1))
				.Any(z => z.Equals(extension.ToLower())));

		private void ApplyImage()
		{
			var path = playlist.SelectedItem;

			if (string.IsNullOrEmpty(path))
			{
				label1.Enabled = true;
				label1.Visible = true;
				progressBar1.Visible = false;
				pictureBox1.Visible = false;
				pictureBox1.Tag = "";
			}
			else
			{
				label1.Enabled = false;
				label1.Visible = false;

				progressBar1.Visible = true;
				progressBar1.Value = 0;

				if (isLoadingImage)
				{
					pictureBox1.CancelAsync();
				}

				isLoadingImage = true;

				pictureBox1.Tag = path;
				pictureBox1.LoadAsync(path);
			}

			UpdateTitle();
			UpdatePictureMenu();
		}

		private void UpdateTitle()
		{
			var path = playlist.SelectedItem;
			var parts = new List<string>();

			if (!string.IsNullOrEmpty(path)
				&& playlist.FileNames.Count > 1)
			{
				parts.Add($"{playlist.SelectedIndex + 1}/{playlist.FileNames.Count}");
			}

			if (!string.IsNullOrEmpty(path))
			{
				parts.Add($"{Path.GetFileName(path)}");
			}

			if (editMode == EditMode.Inspect)
			{
				var pixelPosition = pictureBox1.PointToClient(Cursor.Position);
				var bitmap = pictureBox1.Image as Bitmap;

				if (bitmap != null)
				{
					try
					{
						var color = bitmap.GetPixel(pixelPosition.X, pixelPosition.Y);

						parts.Add($"(X={pixelPosition.X},Y={pixelPosition.Y}) (A={color.A},R={color.R},G={color.G},B={color.B})");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
			}

			parts.Add("Screen Image Overlay");

			Text = string.Join(" - ", parts);
		}

		private void UpdateContextMenu()
		{
			opaqueToolStripMenuItem.Checked = isForcedVisible;
			clickthroughToolStripMenuItem.Checked = allowClickThrough;
			enableTransparentBackgroundToolStripMenuItem.Checked = transparentBackground;
			alwaysOnTopToolStripMenuItem.Checked = TopMost;

			normalToolStripMenuItem.Checked = pictureBox1.SizeMode == PictureBoxSizeMode.Normal;
			stretchToolStripMenuItem.Checked = pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage;
			autoToolStripMenuItem.Checked = pictureBox1.SizeMode == PictureBoxSizeMode.AutoSize;
			centerToolStripMenuItem.Checked = pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage;
			zoomToolStripMenuItem.Checked = pictureBox1.SizeMode == PictureBoxSizeMode.Zoom;

			lockToolStripMenuItem.Checked = isSizeLocked;

			inspectModeToolStripMenuItem.Checked = editMode == EditMode.Inspect;
			navigationModeToolStripMenuItem.Checked = editMode == EditMode.Move;

			showToolStripMenuItem.Checked = OwnedForms.Any(x => x is PlaylistForm playlist && playlist.Visible);
			wrapToolStripMenuItem.Checked = playlist.AllowWrap;
			enableSlideshowToolStripMenuItem.Checked = slideshowTimer.Enabled;

			showTitleBarToolStripMenuItem.Checked = IsTitleBarVisible();
			enableFullscreenToolStripMenuItem.Checked = IsFullScreen();
		}

		private void UpdatePlaylistMenu()
		{
			goToFirstToolStripMenuItem.Enabled = CanPlaylistSelectFirst();
			goToLastToolStripMenuItem.Enabled = CanPlaylistSelectLast();
			goToPreviousToolStripMenuItem.Enabled = CanPlaylistSelectPrevious();
			goToNextToolStripMenuItem.Enabled = CanPlaylistSelectNext();
			clearToolStripMenuItem.Enabled = CanClearPlaylist();
		}

		private void UpdateOpacityMenu()
		{
			increaseToolStripMenuItem.Enabled = CanSmallIncreaseOpacity();
			decreaseToolStripMenuItem.Enabled = CanSmallDecreaseOpacity();
			largeIncreaseToolStripMenuItem.Enabled = CanLargeIncreaseOpacity();
			largeDecreaseToolStripMenuItem.Enabled = CanLargeDecreaseOpacity();
		}

		private void UpdatePictureMenu()
		{
			normalToolStripMenuItem.Enabled = CanSetPictureSizeMode(PictureBoxSizeMode.Normal);
			stretchToolStripMenuItem.Enabled = CanSetPictureSizeMode(PictureBoxSizeMode.StretchImage);
			autoToolStripMenuItem.Enabled = CanSetPictureSizeMode(PictureBoxSizeMode.AutoSize);
			centerToolStripMenuItem.Enabled = CanSetPictureSizeMode(PictureBoxSizeMode.CenterImage);
			zoomToolStripMenuItem.Enabled = CanSetPictureSizeMode(PictureBoxSizeMode.Zoom);
			fitWindowToImageToolStripMenuItem1.Enabled = CanResizeWindowToImageSize();
		}

		private void IncreaseOpacity(double value)
		{
			Opacity = Math.Min(Opacity + value, MaxOpacity);
			UpdateOpacityMenu();
		}

		private void DecreaseOpacity(double value)
		{
			Opacity = Math.Max(Opacity - value, MinOpacity);
			UpdateOpacityMenu();
		}

		#endregion

		private static partial class User32
		{
			public static partial class NativeMethods
			{
				public const int GWL_EXSTYLE = -20;
				public const int WS_EX_LAYERED = 0x80000;
				public const int WS_EX_TRANSPARENT = 0x20;

				[DllImport("User32.dll", SetLastError = true)]
				public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

				[DllImport("User32.dll", SetLastError = true)]
				public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
			}
		}
	}
}
