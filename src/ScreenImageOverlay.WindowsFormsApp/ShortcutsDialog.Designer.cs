
namespace ScreenImageOverlay.WindowsFormsApp
{
	partial class ShortcutsDialog
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Mouse", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Mouse Wheel", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Key", System.Windows.Forms.HorizontalAlignment.Left);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			listViewGroup1.Header = "Mouse";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Mouse Wheel";
			listViewGroup2.Name = "listViewGroup2";
			listViewGroup3.Header = "Key";
			listViewGroup3.Name = "listViewGroup3";
			this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(792, 352);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Command";
			this.columnHeader1.Width = 240;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Input";
			this.columnHeader2.Width = 280;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Modifiers";
			this.columnHeader3.Width = 268;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label1.Location = new System.Drawing.Point(12, 364);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(792, 12);
			this.label1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button1.Location = new System.Drawing.Point(12, 376);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(792, 48);
			this.button1.TabIndex = 2;
			this.button1.Text = "&OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button2.Location = new System.Drawing.Point(12, 424);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(792, 0);
			this.button2.TabIndex = 3;
			this.button2.TabStop = false;
			this.button2.Text = "&Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// ShortcutsDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(816, 436);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "ShortcutsDialog";
			this.Padding = new System.Windows.Forms.Padding(12);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Shortcuts";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}