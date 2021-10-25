namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainHeader = new System.Windows.Forms.Label();
            this.simulateButton = new System.Windows.Forms.Button();
            this.designButton = new System.Windows.Forms.Button();
            this.yeditepeIconPictureBox = new System.Windows.Forms.PictureBox();
            this.instructionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.yeditepeIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainHeader
            // 
            this.mainHeader.AutoSize = true;
            this.mainHeader.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mainHeader.ForeColor = System.Drawing.Color.Black;
            this.mainHeader.Location = new System.Drawing.Point(109, 36);
            this.mainHeader.Margin = new System.Windows.Forms.Padding(0);
            this.mainHeader.Name = "mainHeader";
            this.mainHeader.Size = new System.Drawing.Size(540, 45);
            this.mainHeader.TabIndex = 1;
            this.mainHeader.Text = "Simulator of Mechanisms of Toxicity";
            // 
            // simulateButton
            // 
            this.simulateButton.BackColor = System.Drawing.Color.SteelBlue;
            this.simulateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.simulateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simulateButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.simulateButton.Location = new System.Drawing.Point(526, 109);
            this.simulateButton.Margin = new System.Windows.Forms.Padding(0);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(140, 48);
            this.simulateButton.TabIndex = 3;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.UseVisualStyleBackColor = false;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // designButton
            // 
            this.designButton.BackColor = System.Drawing.Color.SeaGreen;
            this.designButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.designButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.designButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.designButton.Location = new System.Drawing.Point(526, 168);
            this.designButton.Margin = new System.Windows.Forms.Padding(0);
            this.designButton.Name = "designButton";
            this.designButton.Size = new System.Drawing.Size(140, 48);
            this.designButton.TabIndex = 2;
            this.designButton.Text = "Design";
            this.designButton.UseVisualStyleBackColor = false;
            this.designButton.Click += new System.EventHandler(this.designButton_Click);
            // 
            // yeditepeIconPictureBox
            // 
            this.yeditepeIconPictureBox.BackColor = System.Drawing.Color.White;
            this.yeditepeIconPictureBox.Image = global::Simulator_Of_Mechanisms_Of_Toxicity.Properties.Resources.YeditepeLogo;
            this.yeditepeIconPictureBox.Location = new System.Drawing.Point(9, 9);
            this.yeditepeIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.yeditepeIconPictureBox.Name = "yeditepeIconPictureBox";
            this.yeditepeIconPictureBox.Size = new System.Drawing.Size(100, 100);
            this.yeditepeIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.yeditepeIconPictureBox.TabIndex = 0;
            this.yeditepeIconPictureBox.TabStop = false;
            // 
            // instructionButton
            // 
            this.instructionButton.BackColor = System.Drawing.Color.Orange;
            this.instructionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.instructionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.instructionButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instructionButton.Location = new System.Drawing.Point(9, 168);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(212, 48);
            this.instructionButton.TabIndex = 4;
            this.instructionButton.Text = "Instruction Manual";
            this.instructionButton.UseVisualStyleBackColor = false;
            this.instructionButton.Click += new System.EventHandler(this.manualButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 225);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.mainHeader);
            this.Controls.Add(this.designButton);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.yeditepeIconPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(830, 312);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulator of Mechanisms of Toxicity";
            ((System.ComponentModel.ISupportInitialize)(this.yeditepeIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox yeditepeIconPictureBox;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Button designButton;
        private System.Windows.Forms.Label mainHeader;
        private System.Windows.Forms.Button instructionButton;
    }
}