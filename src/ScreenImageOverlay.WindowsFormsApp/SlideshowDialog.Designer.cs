
namespace ScreenImageOverlay.WindowsFormsApp
{
	partial class SlideshowDialog
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
			this.groupBox1.Size = new System.Drawing.Size(412, 82);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&Interval:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDown1.Location = new System.Drawing.Point(12, 34);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(388, 29);
			this.numericUpDown1.TabIndex = 0;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(24, 100);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(12);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(110, 29);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "&Reverse";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Location = new System.Drawing.Point(12, 144);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(409, 40);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Location = new System.Drawing.Point(157, 0);
			this.button1.MinimumSize = new System.Drawing.Size(120, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "&OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Dock = System.Windows.Forms.DockStyle.Right;
			this.button2.Location = new System.Drawing.Point(289, 0);
			this.button2.MinimumSize = new System.Drawing.Size(120, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 40);
			this.button2.TabIndex = 2;
			this.button2.Text = "&Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Location = new System.Drawing.Point(277, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// SlideshowDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(436, 196);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(310, 260);
			this.Name = "SlideshowDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Slideshow Settings";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}