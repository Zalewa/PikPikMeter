namespace PikPikMeter
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.okButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.appearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.resetDefaultBackgroundColorButton = new System.Windows.Forms.Button();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.graphBackgroundColorLabel = new System.Windows.Forms.Label();
            this.borderColorButton = new System.Windows.Forms.Button();
            this.graphBackgroundColorButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resetDefaultBorderColorButton = new System.Windows.Forms.Button();
            this.resetGraphBackgroundColorButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.appearanceGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(3, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.resetButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 150);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(84, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.AccessibleDescription = "";
            this.resetButton.Location = new System.Drawing.Point(165, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.toolTip.SetToolTip(this.resetButton, "Reset settings to the previously saved.");
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backgroundColorButton.Location = new System.Drawing.Point(134, 3);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(75, 23);
            this.backgroundColorButton.TabIndex = 2;
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(3, 8);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(94, 13);
            this.backgroundColorLabel.TabIndex = 3;
            this.backgroundColorLabel.Text = "Background color:";
            // 
            // appearanceGroupBox
            // 
            this.appearanceGroupBox.AutoSize = true;
            this.appearanceGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.appearanceGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.appearanceGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearanceGroupBox.Location = new System.Drawing.Point(3, 3);
            this.appearanceGroupBox.Name = "appearanceGroupBox";
            this.appearanceGroupBox.Size = new System.Drawing.Size(253, 106);
            this.appearanceGroupBox.TabIndex = 4;
            this.appearanceGroupBox.TabStop = false;
            this.appearanceGroupBox.Text = "Appearance";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.backgroundColorLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.backgroundColorButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.borderColorLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.borderColorButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.graphBackgroundColorLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.graphBackgroundColorButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.resetDefaultBackgroundColorButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.resetDefaultBorderColorButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.resetGraphBackgroundColorButton, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(247, 87);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // resetDefaultBackgroundColorButton
            // 
            this.resetDefaultBackgroundColorButton.BackgroundImage = global::PikPikMeter.Properties.Resources.rotate_left;
            this.resetDefaultBackgroundColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetDefaultBackgroundColorButton.ImageIndex = 0;
            this.resetDefaultBackgroundColorButton.Location = new System.Drawing.Point(215, 3);
            this.resetDefaultBackgroundColorButton.Name = "resetDefaultBackgroundColorButton";
            this.resetDefaultBackgroundColorButton.Size = new System.Drawing.Size(22, 22);
            this.resetDefaultBackgroundColorButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.resetDefaultBackgroundColorButton, "Reset to default color.");
            this.resetDefaultBackgroundColorButton.UseVisualStyleBackColor = true;
            this.resetDefaultBackgroundColorButton.Click += new System.EventHandler(this.resetDefaultBackgroundColorButton_Click);
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(3, 37);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(67, 13);
            this.borderColorLabel.TabIndex = 3;
            this.borderColorLabel.Text = "Border color:";
            // 
            // graphBackgroundColorLabel
            // 
            this.graphBackgroundColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.graphBackgroundColorLabel.AutoSize = true;
            this.graphBackgroundColorLabel.Location = new System.Drawing.Point(3, 66);
            this.graphBackgroundColorLabel.Name = "graphBackgroundColorLabel";
            this.graphBackgroundColorLabel.Size = new System.Drawing.Size(125, 13);
            this.graphBackgroundColorLabel.TabIndex = 3;
            this.graphBackgroundColorLabel.Text = "Graph background color:";
            // 
            // borderColorButton
            // 
            this.borderColorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.borderColorButton.Location = new System.Drawing.Point(134, 32);
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(75, 23);
            this.borderColorButton.TabIndex = 2;
            this.borderColorButton.UseVisualStyleBackColor = true;
            this.borderColorButton.Click += new System.EventHandler(this.borderColorButton_Click);
            // 
            // graphBackgroundColorButton
            // 
            this.graphBackgroundColorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.graphBackgroundColorButton.Location = new System.Drawing.Point(134, 61);
            this.graphBackgroundColorButton.Name = "graphBackgroundColorButton";
            this.graphBackgroundColorButton.Size = new System.Drawing.Size(75, 23);
            this.graphBackgroundColorButton.TabIndex = 2;
            this.graphBackgroundColorButton.UseVisualStyleBackColor = true;
            this.graphBackgroundColorButton.Click += new System.EventHandler(this.graphBackgroundColorButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.appearanceGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 150);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // resetDefaultBorderColorButton
            // 
            this.resetDefaultBorderColorButton.BackgroundImage = global::PikPikMeter.Properties.Resources.rotate_left;
            this.resetDefaultBorderColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetDefaultBorderColorButton.ImageIndex = 0;
            this.resetDefaultBorderColorButton.Location = new System.Drawing.Point(215, 32);
            this.resetDefaultBorderColorButton.Name = "resetDefaultBorderColorButton";
            this.resetDefaultBorderColorButton.Size = new System.Drawing.Size(22, 22);
            this.resetDefaultBorderColorButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.resetDefaultBorderColorButton, "Reset to default color.");
            this.resetDefaultBorderColorButton.UseVisualStyleBackColor = true;
            this.resetDefaultBorderColorButton.Click += new System.EventHandler(this.resetDefaultBorderColorButton_Click);
            // 
            // resetGraphBackgroundColorButton
            // 
            this.resetGraphBackgroundColorButton.BackgroundImage = global::PikPikMeter.Properties.Resources.rotate_left;
            this.resetGraphBackgroundColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetGraphBackgroundColorButton.ImageIndex = 0;
            this.resetGraphBackgroundColorButton.Location = new System.Drawing.Point(215, 61);
            this.resetGraphBackgroundColorButton.Name = "resetGraphBackgroundColorButton";
            this.resetGraphBackgroundColorButton.Size = new System.Drawing.Size(22, 22);
            this.resetGraphBackgroundColorButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.resetGraphBackgroundColorButton, "Reset to default color.");
            this.resetGraphBackgroundColorButton.UseVisualStyleBackColor = true;
            this.resetGraphBackgroundColorButton.Click += new System.EventHandler(this.resetGraphBackgroundColorButton_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(259, 179);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PikPikMeter Settings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.appearanceGroupBox.ResumeLayout(false);
            this.appearanceGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.GroupBox appearanceGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.Label graphBackgroundColorLabel;
        private System.Windows.Forms.Button borderColorButton;
        private System.Windows.Forms.Button graphBackgroundColorButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button resetDefaultBackgroundColorButton;
        private System.Windows.Forms.Button resetDefaultBorderColorButton;
        private System.Windows.Forms.Button resetGraphBackgroundColorButton;
    }
}