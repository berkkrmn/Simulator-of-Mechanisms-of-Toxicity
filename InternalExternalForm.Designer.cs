namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class InternalExternalForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.internalButton = new System.Windows.Forms.Button();
            this.externalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.Location = new System.Drawing.Point(46, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(201, 25);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Select Molecule Type";
            // 
            // internalButton
            // 
            this.internalButton.BackColor = System.Drawing.Color.DarkOrange;
            this.internalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.internalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.internalButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.internalButton.Location = new System.Drawing.Point(12, 52);
            this.internalButton.Name = "internalButton";
            this.internalButton.Size = new System.Drawing.Size(135, 39);
            this.internalButton.TabIndex = 1;
            this.internalButton.Text = "Endogenous";
            this.internalButton.UseVisualStyleBackColor = false;
            this.internalButton.Click += new System.EventHandler(this.internalButton_Click);
            // 
            // externalButton
            // 
            this.externalButton.BackColor = System.Drawing.Color.ForestGreen;
            this.externalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.externalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.externalButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.externalButton.Location = new System.Drawing.Point(153, 52);
            this.externalButton.Name = "externalButton";
            this.externalButton.Size = new System.Drawing.Size(137, 39);
            this.externalButton.TabIndex = 2;
            this.externalButton.Text = "Exogenous";
            this.externalButton.UseVisualStyleBackColor = false;
            this.externalButton.Click += new System.EventHandler(this.externalButton_Click);
            // 
            // InternalExternalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(302, 103);
            this.Controls.Add(this.externalButton);
            this.Controls.Add(this.internalButton);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(320, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 150);
            this.Name = "InternalExternalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selection";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button internalButton;
        private System.Windows.Forms.Button externalButton;
    }
}