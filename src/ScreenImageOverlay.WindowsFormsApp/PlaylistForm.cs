using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScreenImageOverlay.WindowsFormsApp
{
	public partial class PlaylistForm : Form
	{
		#region Fields

		private readonly Playlist playlist;

		#endregion

		#region Constructors

		public PlaylistForm()
		{
			InitializeComponent();
		}

		public PlaylistForm(Playlist playlist)
			: this()
		{
			this.playlist = playlist;
			
			RefreshItems();

			playlist.PropertyChanged += Playlist_PropertyChanged;
		}

		#endregion

		#region Form Event Handlers

		private void PlaylistForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (playlist is null)
			{
				return;
			}

			playlist.PropertyChanged -= Playlist_PropertyChanged;
		}

		private void PlaylistForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				Visible = false;
				Owner.Activate();
				e.Cancel = true;
			}
		}

		#endregion

		#region Playlist Event Handlers

		private void Playlist_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Playlist.SelectedIndex):
					listView1.SelectedIndices.Clear();
					if (playlist.SelectedIndex != -1)
					{
						listView1.SelectedIndices.Add(playlist.SelectedIndex);
					}
					break;

				case nameof(Playlist.FileNames):
					RefreshItems();
					break;
			}
		}

		#endregion

		#region ListView Event Handlers

		private void listView1_ItemActivate(object sender, EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
			{
				playlist.SelectedIndex = listView1.SelectedIndices[0];
			}
		}

		#endregion

		#region Clear Button Event Handlers

		private void clearButton_Click(object sender, EventArgs e)
		{
			Clear();
		}

		#endregion

		#region Commands

		private void Clear()
		{
			playlist.Clear();
		}

		private bool CanClear()
			=> playlist.CanClear();

		#endregion

		#region Implementation

		private void RefreshItems()
		{
			listView1.BeginUpdate();
			listView1.Items.Clear();
			listView1.Items.AddRange(playlist.FileNames
					.Select(item => new ListViewItem(new string[] { Path.GetFileName(item), Path.GetDirectoryName(item) }))
					.ToArray());
			listView1.EndUpdate();
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

			clearButton.Enabled = CanClear();
		}

		#endregion
	}
}
