namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class MoleculesOptionsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeFactorButton = new System.Windows.Forms.Button();
            this.moleculesListBox = new System.Windows.Forms.ListBox();
            this.removeMoleculeInformationLabel = new System.Windows.Forms.Label();
            this.removePanelHeader = new System.Windows.Forms.Label();
            this.addPanel = new System.Windows.Forms.Panel();
            this.pictureBoxClearButton = new System.Windows.Forms.Button();
            this.addFinishButton = new System.Windows.Forms.Button();
            this.moleculeNameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.moleculePictureBox = new System.Windows.Forms.PictureBox();
            this.addMoleculeInformationLabel = new System.Windows.Forms.Label();
            this.addPanelHeaderLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moleculePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeFactorButton);
            this.panel1.Controls.Add(this.moleculesListBox);
            this.panel1.Controls.Add(this.removeMoleculeInformationLabel);
            this.panel1.Controls.Add(this.removePanelHeader);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 429);
            this.panel1.TabIndex = 0;
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
            this.removeFactorButton.TabIndex = 7;
            this.removeFactorButton.Text = "Remove";
            this.removeFactorButton.UseVisualStyleBackColor = false;
            this.removeFactorButton.Click += new System.EventHandler(this.removeMoleculeButton_Click);
            // 
            // moleculesListBox
            // 
            this.moleculesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moleculesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.moleculesListBox.FormattingEnabled = true;
            this.moleculesListBox.ItemHeight = 20;
            this.moleculesListBox.Location = new System.Drawing.Point(8, 79);
            this.moleculesListBox.Name = "moleculesListBox";
            this.moleculesListBox.Size = new System.Drawing.Size(267, 282);
            this.moleculesListBox.TabIndex = 8;
            // 
            // removeMoleculeInformationLabel
            // 
            this.removeMoleculeInformationLabel.AutoSize = true;
            this.removeMoleculeInformationLabel.Location = new System.Drawing.Point(5, 25);
            this.removeMoleculeInformationLabel.Name = "removeMoleculeInformationLabel";
            this.removeMoleculeInformationLabel.Size = new System.Drawing.Size(262, 51);
            this.removeMoleculeInformationLabel.TabIndex = 7;
            this.removeMoleculeInformationLabel.Text = "Select the molecule you want to remove \r\nfrom the list below. Then press remove \r" +
    "\nbutton.";
            // 
            // removePanelHeader
            // 
            this.removePanelHeader.AutoSize = true;
            this.removePanelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.removePanelHeader.Location = new System.Drawing.Point(3, 0);
            this.removePanelHeader.Name = "removePanelHeader";
            this.removePanelHeader.Size = new System.Drawing.Size(184, 25);
            this.removePanelHeader.TabIndex = 7;
            this.removePanelHeader.Text = "Remove a Molecule";
            // 
            // addPanel
            // 
            this.addPanel.Controls.Add(this.pictureBoxClearButton);
            this.addPanel.Controls.Add(this.addFinishButton);
            this.addPanel.Controls.Add(this.moleculeNameTextBox);
            this.addPanel.Controls.Add(this.nameLabel);
            this.addPanel.Controls.Add(this.moleculePictureBox);
            this.addPanel.Controls.Add(this.addMoleculeInformationLabel);
            this.addPanel.Controls.Add(this.addPanelHeaderLabel);
            this.addPanel.Location = new System.Drawing.Point(313, 12);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(258, 429);
            this.addPanel.TabIndex = 1;
            // 
            // pictureBoxClearButton
            // 
            this.pictureBoxClearButton.BackColor = System.Drawing.Color.Orange;
            this.pictureBoxClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pictureBoxClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pictureBoxClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxClearButton.Location = new System.Drawing.Point(136, 367);
            this.pictureBoxClearButton.Name = "pictureBoxClearButton";
            this.pictureBoxClearButton.Size = new System.Drawing.Size(104, 47);
            this.pictureBoxClearButton.TabIndex = 8;
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
            this.addFinishButton.Location = new System.Drawing.Point(20, 367);
            this.addFinishButton.Name = "addFinishButton";
            this.addFinishButton.Size = new System.Drawing.Size(110, 47);
            this.addFinishButton.TabIndex = 7;
            this.addFinishButton.Text = "Add";
            this.addFinishButton.UseVisualStyleBackColor = false;
            this.addFinishButton.Click += new System.EventHandler(this.addFinishButton_Click);
            // 
            // moleculeNameTextBox
            // 
            this.moleculeNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.moleculeNameTextBox.Location = new System.Drawing.Point(20, 334);
            this.moleculeNameTextBox.Name = "moleculeNameTextBox";
            this.moleculeNameTextBox.Size = new System.Drawing.Size(220, 27);
            this.moleculeNameTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(17, 314);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(202, 17);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Enter a name for the molecule:";
            // 
            // moleculePictureBox
            // 
            this.moleculePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.moleculePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.moleculePictureBox.Location = new System.Drawing.Point(20, 88);
            this.moleculePictureBox.Name = "moleculePictureBox";
            this.moleculePictureBox.Size = new System.Drawing.Size(220, 220);
            this.moleculePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.moleculePictureBox.TabIndex = 4;
            this.moleculePictureBox.TabStop = false;
            this.moleculePictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.moleculePictureBox_DragDrop);
            this.moleculePictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.moleculePictureBox_DragEnter);
            // 
            // addMoleculeInformationLabel
            // 
            this.addMoleculeInformationLabel.AutoSize = true;
            this.addMoleculeInformationLabel.Location = new System.Drawing.Point(5, 25);
            this.addMoleculeInformationLabel.Name = "addMoleculeInformationLabel";
            this.addMoleculeInformationLabel.Size = new System.Drawing.Size(210, 51);
            this.addMoleculeInformationLabel.TabIndex = 3;
            this.addMoleculeInformationLabel.Text = "Drag and drop the image of the \r\nmolecule into the box below.\r\n(Only \".png\" files" +
    " !)";
            // 
            // addPanelHeaderLabel
            // 
            this.addPanelHeaderLabel.AutoSize = true;
            this.addPanelHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addPanelHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.addPanelHeaderLabel.Name = "addPanelHeaderLabel";
            this.addPanelHeaderLabel.Size = new System.Drawing.Size(148, 25);
            this.addPanelHeaderLabel.TabIndex = 2;
            this.addPanelHeaderLabel.Text = "Add a Molecule";
            // 
            // MoleculesOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.addPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MoleculesOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Molecules Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MoleculesOptionsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moleculePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label removePanelHeader;
        private System.Windows.Forms.Label removeMoleculeInformationLabel;
        private System.Windows.Forms.ListBox moleculesListBox;
        private System.Windows.Forms.Button removeFactorButton;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.Label addPanelHeaderLabel;
        private System.Windows.Forms.Label addMoleculeInformationLabel;
        private System.Windows.Forms.PictureBox moleculePictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox moleculeNameTextBox;
        private System.Windows.Forms.Button addFinishButton;
        private System.Windows.Forms.Button pictureBoxClearButton;
    }
}