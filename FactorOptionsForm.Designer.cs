namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class FactorOptionsForm
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
            this.addPanel = new System.Windows.Forms.Panel();
            this.pictureBoxClearButton = new System.Windows.Forms.Button();
            this.addFinishButton = new System.Windows.Forms.Button();
            this.factorNameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addFactorInformationLabel = new System.Windows.Forms.Label();
            this.addPanelHeaderLabel = new System.Windows.Forms.Label();
            this.factorPictureBox = new System.Windows.Forms.PictureBox();
            this.removePanel = new System.Windows.Forms.Panel();
            this.removeFactorButton = new System.Windows.Forms.Button();
            this.factorsListBox = new System.Windows.Forms.ListBox();
            this.removeFactorInformationLabel = new System.Windows.Forms.Label();
            this.removePanelHeader = new System.Windows.Forms.Label();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factorPictureBox)).BeginInit();
            this.removePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPanel
            // 
            this.addPanel.Controls.Add(this.pictureBoxClearButton);
            this.addPanel.Controls.Add(this.addFinishButton);
            this.addPanel.Controls.Add(this.factorNameTextBox);
            this.addPanel.Controls.Add(this.nameLabel);
            this.addPanel.Controls.Add(this.addFactorInformationLabel);
            this.addPanel.Controls.Add(this.addPanelHeaderLabel);
            this.addPanel.Controls.Add(this.factorPictureBox);
            this.addPanel.Location = new System.Drawing.Point(313, 12);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(258, 429);
            this.addPanel.TabIndex = 0;
            // 
            // pictureBoxClearButton
            // 
            this.pictureBoxClearButton.BackColor = System.Drawing.Color.Orange;
            this.pictureBoxClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pictureBoxClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pictureBoxClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxClearButton.Location = new System.Drawing.Point(137, 365);
            this.pictureBoxClearButton.Name = "pictureBoxClearButton";
            this.pictureBoxClearButton.Size = new System.Drawing.Size(104, 47);
            this.pictureBoxClearButton.TabIndex = 6;
            this.pictureBoxClearButton.Text = "Clear";
            this.pictureBoxClearButton.UseVisualStyleBackColor = false;
            this.pictureBoxClearButton.Click += new System.EventHandler(this.pictureBoxClearButton_Click);
            // 
            // addFinishButton
            // 
            this.addFinishButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.addFinishButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFinishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addFinishButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addFinishButton.Location = new System.Drawing.Point(20, 365);
            this.addFinishButton.Name = "addFinishButton";
            this.addFinishButton.Size = new System.Drawing.Size(110, 47);
            this.addFinishButton.TabIndex = 5;
            this.addFinishButton.Text = "Add";
            this.addFinishButton.UseVisualStyleBackColor = false;
            this.addFinishButton.Click += new System.EventHandler(this.addFinishButton_Click);
            // 
            // factorNameTextBox
            // 
            this.factorNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.factorNameTextBox.Location = new System.Drawing.Point(21, 335);
            this.factorNameTextBox.Name = "factorNameTextBox";
            this.factorNameTextBox.Size = new System.Drawing.Size(220, 27);
            this.factorNameTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(18, 315);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(184, 17);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Enter a name for the ligand:";
            // 
            // addFactorInformationLabel
            // 
            this.addFactorInformationLabel.AutoSize = true;
            this.addFactorInformationLabel.Location = new System.Drawing.Point(5, 25);
            this.addFactorInformationLabel.Name = "addFactorInformationLabel";
            this.addFactorInformationLabel.Size = new System.Drawing.Size(210, 51);
            this.addFactorInformationLabel.TabIndex = 2;
            this.addFactorInformationLabel.Text = "Drag and drop the image of the \r\nligand into the box below.\r\n(Only \".png\" files !" +
    ")";
            // 
            // addPanelHeaderLabel
            // 
            this.addPanelHeaderLabel.AutoSize = true;
            this.addPanelHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addPanelHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.addPanelHeaderLabel.Name = "addPanelHeaderLabel";
            this.addPanelHeaderLabel.Size = new System.Drawing.Size(128, 25);
            this.addPanelHeaderLabel.TabIndex = 1;
            this.addPanelHeaderLabel.Text = "Add a Ligand";
            // 
            // factorPictureBox
            // 
            this.factorPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.factorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.factorPictureBox.Location = new System.Drawing.Point(20, 88);
            this.factorPictureBox.Name = "factorPictureBox";
            this.factorPictureBox.Size = new System.Drawing.Size(220, 220);
            this.factorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.factorPictureBox.TabIndex = 0;
            this.factorPictureBox.TabStop = false;
            this.factorPictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.factorPictureBox_DragDrop);
            this.factorPictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.factorPictureBox_DragEnter);
            // 
            // removePanel
            // 
            this.removePanel.Controls.Add(this.removeFactorButton);
            this.removePanel.Controls.Add(this.factorsListBox);
            this.removePanel.Controls.Add(this.removeFactorInformationLabel);
            this.removePanel.Controls.Add(this.removePanelHeader);
            this.removePanel.Location = new System.Drawing.Point(12, 12);
            this.removePanel.Name = "removePanel";
            this.removePanel.Size = new System.Drawing.Size(295, 429);
            this.removePanel.TabIndex = 2;
            // 
            // removeFactorButton
            // 
            this.removeFactorButton.BackColor = System.Drawing.Color.Maroon;
            this.removeFactorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeFactorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.removeFactorButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeFactorButton.Location = new System.Drawing.Point(81, 365);
            this.removeFactorButton.Name = "removeFactorButton";
            this.removeFactorButton.Size = new System.Drawing.Size(110, 47);
            this.removeFactorButton.TabIndex = 6;
            this.removeFactorButton.Text = "Remove";
            this.removeFactorButton.UseVisualStyleBackColor = false;
            this.removeFactorButton.Click += new System.EventHandler(this.removeFactorButton_Click);
            // 
            // factorsListBox
            // 
            this.factorsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.factorsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.factorsListBox.FormattingEnabled = true;
            this.factorsListBox.ItemHeight = 20;
            this.factorsListBox.Location = new System.Drawing.Point(8, 73);
            this.factorsListBox.Name = "factorsListBox";
            this.factorsListBox.Size = new System.Drawing.Size(267, 282);
            this.factorsListBox.TabIndex = 7;
            // 
            // removeFactorInformationLabel
            // 
            this.removeFactorInformationLabel.AutoSize = true;
            this.removeFactorInformationLabel.Location = new System.Drawing.Point(5, 25);
            this.removeFactorInformationLabel.Name = "removeFactorInformationLabel";
            this.removeFactorInformationLabel.Size = new System.Drawing.Size(272, 34);
            this.removeFactorInformationLabel.TabIndex = 6;
            this.removeFactorInformationLabel.Text = "Select the ligand you want to remove from\r\nthe list below. Then press remove butt" +
    "on.";
            // 
            // removePanelHeader
            // 
            this.removePanelHeader.AutoSize = true;
            this.removePanelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.removePanelHeader.Location = new System.Drawing.Point(3, 0);
            this.removePanelHeader.Name = "removePanelHeader";
            this.removePanelHeader.Size = new System.Drawing.Size(164, 25);
            this.removePanelHeader.TabIndex = 6;
            this.removePanelHeader.Text = "Remove a Ligand";
            // 
            // FactorOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.removePanel);
            this.Controls.Add(this.addPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "FactorOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ligands";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FactorOptionsForm_Load);
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factorPictureBox)).EndInit();
            this.removePanel.ResumeLayout(false);
            this.removePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.Button addFinishButton;
        private System.Windows.Forms.TextBox factorNameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label addFactorInformationLabel;
        private System.Windows.Forms.Label addPanelHeaderLabel;
        private System.Windows.Forms.PictureBox factorPictureBox;
        private System.Windows.Forms.Panel removePanel;
        private System.Windows.Forms.Label removeFactorInformationLabel;
        private System.Windows.Forms.Label removePanelHeader;
        private System.Windows.Forms.Button removeFactorButton;
        private System.Windows.Forms.ListBox factorsListBox;
        private System.Windows.Forms.Button pictureBoxClearButton;
    }
}