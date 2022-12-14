
namespace ScreenImageOverlay.WindowsFormsApp
{
	partial class PlaylistForm
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clearButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Margin = new System.Windows.Forms.Padding(6);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(552, 552);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Path";
			this.columnHeader2.Width = 348;
			// 
			// clearButton
			// 
			this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clearButton.Location = new System.Drawing.Point(0, 12);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(552, 48);
			this.clearButton.TabIndex = 1;
			this.clearButton.Text = "&Clear";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(12, 12);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(0, 0);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.TabStop = false;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.clearButton);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(12, 504);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.panel1.Size = new System.Drawing.Size(552, 60);
			this.panel1.TabIndex = 3;
			// 
			// PlaylistForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(576, 576);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.listView1);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "PlaylistForm";
			this.Padding = new System.Windows.Forms.Padding(12);
			this.Text = "Playlist";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlaylistForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlaylistForm_FormClosed);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Panel panel1;
	}
}