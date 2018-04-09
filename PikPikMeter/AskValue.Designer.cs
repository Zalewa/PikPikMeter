namespace PikPikMeter
{
	partial class AskValue
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
			this.LabelTitle = new System.Windows.Forms.Label();
			this.ButtonOk = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.TextBoxValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LabelTitle
			// 
			this.LabelTitle.AutoSize = true;
			this.LabelTitle.Location = new System.Drawing.Point(9, 13);
			this.LabelTitle.Name = "LabelTitle";
			this.LabelTitle.Size = new System.Drawing.Size(30, 13);
			this.LabelTitle.TabIndex = 0;
			this.LabelTitle.Text = "Title:";
			// 
			// ButtonOk
			// 
			this.ButtonOk.Location = new System.Drawing.Point(233, 58);
			this.ButtonOk.Name = "ButtonOk";
			this.ButtonOk.Size = new System.Drawing.Size(75, 23);
			this.ButtonOk.TabIndex = 1;
			this.ButtonOk.Text = "&Ok";
			this.ButtonOk.UseVisualStyleBackColor = true;
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Location = new System.Drawing.Point(314, 58);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 1;
			this.ButtonCancel.Text = "&Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// TextBoxValue
			// 
			this.TextBoxValue.Location = new System.Drawing.Point(12, 29);
			this.TextBoxValue.Name = "TextBoxValue";
			this.TextBoxValue.Size = new System.Drawing.Size(377, 20);
			this.TextBoxValue.TabIndex = 2;
			// 
			// AskValue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 93);
			this.Controls.Add(this.TextBoxValue);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonOk);
			this.Controls.Add(this.LabelTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AskValue";
			this.Text = "AskValue";
			this.Load += new System.EventHandler(this.AskValue_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelTitle;
		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.TextBox TextBoxValue;
	}
}