namespace PikPikMeter
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelEgg = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.CopyrightBox = new System.Windows.Forms.TextBox();
            this.LabelBackLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IconBox.Image = global::PikPikMeter.Properties.Resources.pikpikmeter_png;
            this.IconBox.InitialImage = global::PikPikMeter.Properties.Resources.pikpikmeter_png;
            this.IconBox.Location = new System.Drawing.Point(451, 12);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(32, 32);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelName.Location = new System.Drawing.Point(7, 5);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(321, 25);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "Soft gets made when existing";
            // 
            // LabelEgg
            // 
            this.LabelEgg.AutoSize = true;
            this.LabelEgg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelEgg.ForeColor = System.Drawing.Color.Maroon;
            this.LabelEgg.Location = new System.Drawing.Point(13, 337);
            this.LabelEgg.Name = "LabelEgg";
            this.LabelEgg.Size = new System.Drawing.Size(105, 13);
            this.LabelEgg.TabIndex = 2;
            this.LabelEgg.Text = "Got you, my man!";
            this.LabelEgg.Visible = false;
            // 
            // ButtonClose
            // 
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonClose.Location = new System.Drawing.Point(408, 327);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "&Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // CopyrightBox
            // 
            this.CopyrightBox.BackColor = System.Drawing.SystemColors.Window;
            this.CopyrightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CopyrightBox.Location = new System.Drawing.Point(12, 50);
            this.CopyrightBox.MaxLength = 327670;
            this.CopyrightBox.Multiline = true;
            this.CopyrightBox.Name = "CopyrightBox";
            this.CopyrightBox.ReadOnly = true;
            this.CopyrightBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CopyrightBox.Size = new System.Drawing.Size(471, 271);
            this.CopyrightBox.TabIndex = 5;
            this.CopyrightBox.Text = "soft pisses you off.";
            // 
            // LabelBackLink
            // 
            this.LabelBackLink.AutoSize = true;
            this.LabelBackLink.Location = new System.Drawing.Point(13, 30);
            this.LabelBackLink.Name = "LabelBackLink";
            this.LabelBackLink.Size = new System.Drawing.Size(197, 13);
            this.LabelBackLink.TabIndex = 6;
            this.LabelBackLink.TabStop = true;
            this.LabelBackLink.Text = "https://github.com/Zalewa/PikPikMeter";
            this.LabelBackLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelBackLink_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonClose;
            this.ClientSize = new System.Drawing.Size(495, 362);
            this.Controls.Add(this.LabelBackLink);
            this.Controls.Add(this.CopyrightBox);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.LabelEgg);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.IconBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelEgg;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox CopyrightBox;
        private System.Windows.Forms.LinkLabel LabelBackLink;
    }
}