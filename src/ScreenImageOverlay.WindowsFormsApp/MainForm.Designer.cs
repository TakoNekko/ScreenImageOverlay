
namespace ScreenImageOverlay.WindowsFormsApp
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.largeIncreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.largeDecreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.opaqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clickthroughToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.enableTransparentBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fitWindowToImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inspectModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.navigationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.enableSlideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configureSlideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.goToFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.goToPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableFullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTitleBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.slideshowTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pictureBoxContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AllowDrop = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(381, 76);
			this.label1.TabIndex = 0;
			this.label1.Text = "Drop an image file here.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
			this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
			this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDoubleClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(381, 76);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.WaitOnLoad = true;
			this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
			this.pictureBox1.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pictureBox1_LoadProgressChanged);
			this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
			this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
			this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
			// 
			// pictureBoxContextMenuStrip
			// 
			this.pictureBoxContextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.pictureBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.toolStripSeparator6,
            this.helpToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.pictureBoxContextMenuStrip.Name = "pictureBoxContextMenuStrip";
			this.pictureBoxContextMenuStrip.Size = new System.Drawing.Size(271, 378);
			this.pictureBoxContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.pictureBoxContextMenuStrip_Opening);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.folderToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
			this.fileToolStripMenuItem.Text = "&File...";
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
			// 
			// folderToolStripMenuItem
			// 
			this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
			this.folderToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
			this.folderToolStripMenuItem.Text = "&Folder...";
			this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
			// 
			// opacityToolStripMenuItem
			// 
			this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToToolStripMenuItem,
            this.toolStripSeparator7,
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem,
            this.toolStripSeparator8,
            this.largeIncreaseToolStripMenuItem,
            this.largeDecreaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.opaqueToolStripMenuItem,
            this.clickthroughToolStripMenuItem,
            this.toolStripSeparator13,
            this.enableTransparentBackgroundToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
			this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
			this.opacityToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.opacityToolStripMenuItem.Text = "Op&acity";
			// 
			// changeToToolStripMenuItem
			// 
			this.changeToToolStripMenuItem.Name = "changeToToolStripMenuItem";
			this.changeToToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.changeToToolStripMenuItem.Text = "&Change to...";
			this.changeToToolStripMenuItem.Click += new System.EventHandler(this.changeToToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(420, 6);
			this.toolStripSeparator7.Visible = false;
			// 
			// increaseToolStripMenuItem
			// 
			this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
			this.increaseToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.increaseToolStripMenuItem.Text = "&Increase";
			this.increaseToolStripMenuItem.Visible = false;
			this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
			// 
			// decreaseToolStripMenuItem
			// 
			this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
			this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.decreaseToolStripMenuItem.Text = "&Decrease";
			this.decreaseToolStripMenuItem.Visible = false;
			this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(420, 6);
			this.toolStripSeparator8.Visible = false;
			// 
			// largeIncreaseToolStripMenuItem
			// 
			this.largeIncreaseToolStripMenuItem.Name = "largeIncreaseToolStripMenuItem";
			this.largeIncreaseToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.largeIncreaseToolStripMenuItem.Text = "Large &Increase";
			this.largeIncreaseToolStripMenuItem.Visible = false;
			this.largeIncreaseToolStripMenuItem.Click += new System.EventHandler(this.largeIncreaseToolStripMenuItem_Click);
			// 
			// largeDecreaseToolStripMenuItem
			// 
			this.largeDecreaseToolStripMenuItem.Name = "largeDecreaseToolStripMenuItem";
			this.largeDecreaseToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.largeDecreaseToolStripMenuItem.Text = "Large &Decrease";
			this.largeDecreaseToolStripMenuItem.Visible = false;
			this.largeDecreaseToolStripMenuItem.Click += new System.EventHandler(this.largeDecreaseToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(420, 6);
			// 
			// opaqueToolStripMenuItem
			// 
			this.opaqueToolStripMenuItem.Name = "opaqueToolStripMenuItem";
			this.opaqueToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.opaqueToolStripMenuItem.Text = "Force &Opaque";
			this.opaqueToolStripMenuItem.Click += new System.EventHandler(this.opaqueToolStripMenuItem_Click);
			// 
			// clickthroughToolStripMenuItem
			// 
			this.clickthroughToolStripMenuItem.Name = "clickthroughToolStripMenuItem";
			this.clickthroughToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.clickthroughToolStripMenuItem.Text = "Enable &Click-through";
			this.clickthroughToolStripMenuItem.Click += new System.EventHandler(this.clickthroughToolStripMenuItem_Click);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(420, 6);
			// 
			// enableTransparentBackgroundToolStripMenuItem
			// 
			this.enableTransparentBackgroundToolStripMenuItem.Name = "enableTransparentBackgroundToolStripMenuItem";
			this.enableTransparentBackgroundToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.enableTransparentBackgroundToolStripMenuItem.Text = "Enable &Transparent Background";
			this.enableTransparentBackgroundToolStripMenuItem.Click += new System.EventHandler(this.enableTransparentBackgroundToolStripMenuItem_Click);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(423, 40);
			this.backgroundColorToolStripMenuItem.Text = "&Background Color...";
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
			// 
			// sizeToolStripMenuItem
			// 
			this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.stretchToolStripMenuItem,
            this.autoToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.toolStripSeparator1,
            this.lockToolStripMenuItem,
            this.toolStripSeparator3,
            this.fitWindowToImageToolStripMenuItem1});
			this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
			this.sizeToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.sizeToolStripMenuItem.Text = "&Size";
			// 
			// normalToolStripMenuItem
			// 
			this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
			this.normalToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.normalToolStripMenuItem.Text = "&Normal";
			this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
			// 
			// stretchToolStripMenuItem
			// 
			this.stretchToolStripMenuItem.Name = "stretchToolStripMenuItem";
			this.stretchToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.stretchToolStripMenuItem.Text = "&Stretch";
			this.stretchToolStripMenuItem.Click += new System.EventHandler(this.stretchToolStripMenuItem_Click);
			// 
			// autoToolStripMenuItem
			// 
			this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
			this.autoToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.autoToolStripMenuItem.Text = "&Auto";
			this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
			// 
			// centerToolStripMenuItem
			// 
			this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
			this.centerToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.centerToolStripMenuItem.Text = "&Center";
			this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
			// 
			// zoomToolStripMenuItem
			// 
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			this.zoomToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.zoomToolStripMenuItem.Text = "&Zoom";
			this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(321, 6);
			// 
			// lockToolStripMenuItem
			// 
			this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
			this.lockToolStripMenuItem.Size = new System.Drawing.Size(324, 40);
			this.lockToolStripMenuItem.Text = "Enable &Locking";
			this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(321, 6);
			// 
			// fitWindowToImageToolStripMenuItem1
			// 
			this.fitWindowToImageToolStripMenuItem1.Name = "fitWindowToImageToolStripMenuItem1";
			this.fitWindowToImageToolStripMenuItem1.Size = new System.Drawing.Size(324, 40);
			this.fitWindowToImageToolStripMenuItem1.Text = "&Fit Window to Image";
			this.fitWindowToImageToolStripMenuItem1.Click += new System.EventHandler(this.fitWindowToImageToolStripMenuItem1_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inspectModeToolStripMenuItem,
            this.navigationModeToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// inspectModeToolStripMenuItem
			// 
			this.inspectModeToolStripMenuItem.Name = "inspectModeToolStripMenuItem";
			this.inspectModeToolStripMenuItem.Size = new System.Drawing.Size(292, 40);
			this.inspectModeToolStripMenuItem.Text = "&Inspect Mode";
			this.inspectModeToolStripMenuItem.Click += new System.EventHandler(this.inspectModeToolStripMenuItem_Click);
			// 
			// navigationModeToolStripMenuItem
			// 
			this.navigationModeToolStripMenuItem.Name = "navigationModeToolStripMenuItem";
			this.navigationModeToolStripMenuItem.Size = new System.Drawing.Size(292, 40);
			this.navigationModeToolStripMenuItem.Text = "&Navigation Mode";
			this.navigationModeToolStripMenuItem.Click += new System.EventHandler(this.navigationModeToolStripMenuItem_Click);
			// 
			// playlistToolStripMenuItem
			// 
			this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.wrapToolStripMenuItem,
            this.toolStripSeparator5,
            this.enableSlideshowToolStripMenuItem,
            this.configureSlideshowToolStripMenuItem,
            this.toolStripSeparator9,
            this.goToFirstToolStripMenuItem,
            this.goToLastToolStripMenuItem,
            this.toolStripSeparator10,
            this.goToPreviousToolStripMenuItem,
            this.goToNextToolStripMenuItem,
            this.toolStripSeparator11,
            this.clearToolStripMenuItem});
			this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
			this.playlistToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.playlistToolStripMenuItem.Text = "&Playlist";
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.showToolStripMenuItem.Text = "&Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// wrapToolStripMenuItem
			// 
			this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
			this.wrapToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.wrapToolStripMenuItem.Text = "Enable &Wrapping";
			this.wrapToolStripMenuItem.Click += new System.EventHandler(this.wrapToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(332, 6);
			// 
			// enableSlideshowToolStripMenuItem
			// 
			this.enableSlideshowToolStripMenuItem.Name = "enableSlideshowToolStripMenuItem";
			this.enableSlideshowToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.enableSlideshowToolStripMenuItem.Text = "&Enable Slideshow";
			this.enableSlideshowToolStripMenuItem.Click += new System.EventHandler(this.enableSlideshowToolStripMenuItem_Click);
			// 
			// configureSlideshowToolStripMenuItem
			// 
			this.configureSlideshowToolStripMenuItem.Name = "configureSlideshowToolStripMenuItem";
			this.configureSlideshowToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.configureSlideshowToolStripMenuItem.Text = "&Configure Slideshow...";
			this.configureSlideshowToolStripMenuItem.Click += new System.EventHandler(this.configureSlideshowToolStripMenuItem_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(332, 6);
			// 
			// goToFirstToolStripMenuItem
			// 
			this.goToFirstToolStripMenuItem.Name = "goToFirstToolStripMenuItem";
			this.goToFirstToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.goToFirstToolStripMenuItem.Text = "Go to &First";
			this.goToFirstToolStripMenuItem.Click += new System.EventHandler(this.goToFirstToolStripMenuItem_Click);
			// 
			// goToLastToolStripMenuItem
			// 
			this.goToLastToolStripMenuItem.Name = "goToLastToolStripMenuItem";
			this.goToLastToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.goToLastToolStripMenuItem.Text = "Go to &Last";
			this.goToLastToolStripMenuItem.Click += new System.EventHandler(this.goToLastToolStripMenuItem_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(332, 6);
			// 
			// goToPreviousToolStripMenuItem
			// 
			this.goToPreviousToolStripMenuItem.Name = "goToPreviousToolStripMenuItem";
			this.goToPreviousToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.goToPreviousToolStripMenuItem.Text = "Go to &Previous";
			this.goToPreviousToolStripMenuItem.Click += new System.EventHandler(this.goToPreviousToolStripMenuItem_Click);
			// 
			// goToNextToolStripMenuItem
			// 
			this.goToNextToolStripMenuItem.Name = "goToNextToolStripMenuItem";
			this.goToNextToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.goToNextToolStripMenuItem.Text = "Go to &Next";
			this.goToNextToolStripMenuItem.Click += new System.EventHandler(this.goToNextToolStripMenuItem_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(332, 6);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(335, 40);
			this.clearToolStripMenuItem.Text = "&Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableFullscreenToolStripMenuItem,
            this.showTitleBarToolStripMenuItem,
            this.toolStripSeparator14,
            this.alwaysOnTopToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// enableFullscreenToolStripMenuItem
			// 
			this.enableFullscreenToolStripMenuItem.Name = "enableFullscreenToolStripMenuItem";
			this.enableFullscreenToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
			this.enableFullscreenToolStripMenuItem.Text = "&Enable Full-screen";
			this.enableFullscreenToolStripMenuItem.Click += new System.EventHandler(this.enableFullscreenToolStripMenuItem_Click);
			// 
			// showTitleBarToolStripMenuItem
			// 
			this.showTitleBarToolStripMenuItem.Name = "showTitleBarToolStripMenuItem";
			this.showTitleBarToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
			this.showTitleBarToolStripMenuItem.Text = "Show &Title Bar";
			this.showTitleBarToolStripMenuItem.Click += new System.EventHandler(this.showTitleBarToolStripMenuItem_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(296, 6);
			// 
			// alwaysOnTopToolStripMenuItem
			// 
			this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
			this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
			this.alwaysOnTopToolStripMenuItem.Text = "&Always on Top";
			this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.propertiesToolStripMenuItem.Text = "&Properties";
			this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(267, 6);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linksToolStripMenuItem,
            this.toolStripSeparator12,
            this.shortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// linksToolStripMenuItem
			// 
			this.linksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubToolStripMenuItem});
			this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
			this.linksToolStripMenuItem.Size = new System.Drawing.Size(233, 40);
			this.linksToolStripMenuItem.Text = "&Links";
			// 
			// githubToolStripMenuItem
			// 
			this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
			this.githubToolStripMenuItem.Size = new System.Drawing.Size(208, 40);
			this.githubToolStripMenuItem.Text = "&Github...";
			this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(230, 6);
			// 
			// shortcutsToolStripMenuItem
			// 
			this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
			this.shortcutsToolStripMenuItem.Size = new System.Drawing.Size(233, 40);
			this.shortcutsToolStripMenuItem.Text = "&Shortcuts...";
			this.shortcutsToolStripMenuItem.Click += new System.EventHandler(this.shortcutsToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(233, 40);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBar1.Location = new System.Drawing.Point(0, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(381, 24);
			this.progressBar1.TabIndex = 2;
			this.progressBar1.Visible = false;
			// 
			// slideshowTimer
			// 
			this.slideshowTimer.Interval = 1000;
			this.slideshowTimer.Tick += new System.EventHandler(this.slideshowTimer_Tick);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 76);
			this.ContextMenuStrip = this.pictureBoxContextMenuStrip;
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.Text = "Screen Image Overlay";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pictureBoxContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ContextMenuStrip pictureBoxContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeIncreaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeDecreaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem opaqueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clickthroughToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stretchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem fitWindowToImageToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inspectModeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem navigationModeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wrapToolStripMenuItem;
		private System.Windows.Forms.Timer slideshowTimer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem enableSlideshowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configureSlideshowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showTitleBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enableFullscreenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeToToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem goToFirstToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToLastToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem goToPreviousToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToNextToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem shortcutsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem enableTransparentBackgroundToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
	}
}

