namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class DefineEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefineEventForm));
            this.simulationPanel = new System.Windows.Forms.Panel();
            this.cellWallDrawPanel = new System.Windows.Forms.Panel();
            this.insideCellDrawPanel = new System.Windows.Forms.Panel();
            this.ligandsDrawPanel = new System.Windows.Forms.Panel();
            this.informationPanel = new System.Windows.Forms.Panel();
            this.informationLabel = new System.Windows.Forms.Label();
            this.displayNotDisplayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ınhibateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.mitosisPanel = new System.Windows.Forms.Panel();
            this.mitosisNoRadioButton = new System.Windows.Forms.RadioButton();
            this.mitosisYesRadioButton = new System.Windows.Forms.RadioButton();
            this.mitosisLabel = new System.Windows.Forms.Label();
            this.alivePanel = new System.Windows.Forms.Panel();
            this.aliveNoRadioButton = new System.Windows.Forms.RadioButton();
            this.aliveYesRadioButton = new System.Windows.Forms.RadioButton();
            this.aliveLabel = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.simulationPanel.SuspendLayout();
            this.informationPanel.SuspendLayout();
            this.displayNotDisplayMenu.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.mitosisPanel.SuspendLayout();
            this.alivePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // simulationPanel
            // 
            this.simulationPanel.Controls.Add(this.cellWallDrawPanel);
            this.simulationPanel.Controls.Add(this.insideCellDrawPanel);
            this.simulationPanel.Controls.Add(this.ligandsDrawPanel);
            this.simulationPanel.Location = new System.Drawing.Point(0, 71);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(972, 557);
            this.simulationPanel.TabIndex = 5;
            // 
            // cellWallDrawPanel
            // 
            this.cellWallDrawPanel.Location = new System.Drawing.Point(4, 85);
            this.cellWallDrawPanel.Name = "cellWallDrawPanel";
            this.cellWallDrawPanel.Size = new System.Drawing.Size(962, 85);
            this.cellWallDrawPanel.TabIndex = 3;
            // 
            // insideCellDrawPanel
            // 
            this.insideCellDrawPanel.Location = new System.Drawing.Point(3, 171);
            this.insideCellDrawPanel.Name = "insideCellDrawPanel";
            this.insideCellDrawPanel.Size = new System.Drawing.Size(963, 383);
            this.insideCellDrawPanel.TabIndex = 2;
            // 
            // ligandsDrawPanel
            // 
            this.ligandsDrawPanel.Location = new System.Drawing.Point(4, 4);
            this.ligandsDrawPanel.Name = "ligandsDrawPanel";
            this.ligandsDrawPanel.Size = new System.Drawing.Size(962, 81);
            this.ligandsDrawPanel.TabIndex = 1;
            // 
            // informationPanel
            // 
            this.informationPanel.BackColor = System.Drawing.Color.DarkCyan;
            this.informationPanel.Controls.Add(this.informationLabel);
            this.informationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationPanel.Location = new System.Drawing.Point(0, 0);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(981, 65);
            this.informationPanel.TabIndex = 6;
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.informationLabel.ForeColor = System.Drawing.Color.White;
            this.informationLabel.Location = new System.Drawing.Point(12, 10);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(37, 20);
            this.informationLabel.TabIndex = 0;
            this.informationLabel.Text = "test";
            // 
            // displayNotDisplayMenu
            // 
            this.displayNotDisplayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.displayNotDisplayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.ınhibateToolStripMenuItem});
            this.displayNotDisplayMenu.Name = "displayNotDisplayMenu";
            this.displayNotDisplayMenu.Size = new System.Drawing.Size(211, 104);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayMethod);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeMethod);
            // 
            // ınhibateToolStripMenuItem
            // 
            this.ınhibateToolStripMenuItem.Name = "ınhibateToolStripMenuItem";
            this.ınhibateToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ınhibateToolStripMenuItem.Text = "Inhibit";
            this.ınhibateToolStripMenuItem.Click += new System.EventHandler(this.inhibateMethod);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.DarkCyan;
            this.optionsPanel.Controls.Add(this.optionsLabel);
            this.optionsPanel.Controls.Add(this.mitosisPanel);
            this.optionsPanel.Controls.Add(this.alivePanel);
            this.optionsPanel.Controls.Add(this.finishButton);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsPanel.Location = new System.Drawing.Point(0, 632);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(981, 65);
            this.optionsPanel.TabIndex = 7;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.optionsLabel.ForeColor = System.Drawing.Color.White;
            this.optionsLabel.Location = new System.Drawing.Point(12, 7);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(225, 40);
            this.optionsLabel.TabIndex = 5;
            this.optionsLabel.Text = "Choose the cell status when \r\nthis event occurs.";
            // 
            // mitosisPanel
            // 
            this.mitosisPanel.Controls.Add(this.mitosisNoRadioButton);
            this.mitosisPanel.Controls.Add(this.mitosisYesRadioButton);
            this.mitosisPanel.Controls.Add(this.mitosisLabel);
            this.mitosisPanel.Location = new System.Drawing.Point(571, 3);
            this.mitosisPanel.Name = "mitosisPanel";
            this.mitosisPanel.Size = new System.Drawing.Size(278, 59);
            this.mitosisPanel.TabIndex = 4;
            // 
            // mitosisNoRadioButton
            // 
            this.mitosisNoRadioButton.AutoSize = true;
            this.mitosisNoRadioButton.Checked = true;
            this.mitosisNoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mitosisNoRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mitosisNoRadioButton.Location = new System.Drawing.Point(203, 15);
            this.mitosisNoRadioButton.Name = "mitosisNoRadioButton";
            this.mitosisNoRadioButton.Size = new System.Drawing.Size(58, 29);
            this.mitosisNoRadioButton.TabIndex = 4;
            this.mitosisNoRadioButton.TabStop = true;
            this.mitosisNoRadioButton.Text = "No";
            this.mitosisNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // mitosisYesRadioButton
            // 
            this.mitosisYesRadioButton.AutoSize = true;
            this.mitosisYesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mitosisYesRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mitosisYesRadioButton.Location = new System.Drawing.Point(116, 15);
            this.mitosisYesRadioButton.Name = "mitosisYesRadioButton";
            this.mitosisYesRadioButton.Size = new System.Drawing.Size(67, 29);
            this.mitosisYesRadioButton.TabIndex = 4;
            this.mitosisYesRadioButton.Text = "Yes";
            this.mitosisYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // mitosisLabel
            // 
            this.mitosisLabel.AutoSize = true;
            this.mitosisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mitosisLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mitosisLabel.Location = new System.Drawing.Point(3, 15);
            this.mitosisLabel.Name = "mitosisLabel";
            this.mitosisLabel.Size = new System.Drawing.Size(107, 29);
            this.mitosisLabel.TabIndex = 4;
            this.mitosisLabel.Text = "Mitosis : ";
            // 
            // alivePanel
            // 
            this.alivePanel.Controls.Add(this.aliveNoRadioButton);
            this.alivePanel.Controls.Add(this.aliveYesRadioButton);
            this.alivePanel.Controls.Add(this.aliveLabel);
            this.alivePanel.Location = new System.Drawing.Point(278, 3);
            this.alivePanel.Name = "alivePanel";
            this.alivePanel.Size = new System.Drawing.Size(264, 59);
            this.alivePanel.TabIndex = 2;
            // 
            // aliveNoRadioButton
            // 
            this.aliveNoRadioButton.AutoSize = true;
            this.aliveNoRadioButton.Checked = true;
            this.aliveNoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aliveNoRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aliveNoRadioButton.Location = new System.Drawing.Point(180, 15);
            this.aliveNoRadioButton.Name = "aliveNoRadioButton";
            this.aliveNoRadioButton.Size = new System.Drawing.Size(58, 29);
            this.aliveNoRadioButton.TabIndex = 3;
            this.aliveNoRadioButton.TabStop = true;
            this.aliveNoRadioButton.Text = "No";
            this.aliveNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // aliveYesRadioButton
            // 
            this.aliveYesRadioButton.AutoSize = true;
            this.aliveYesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aliveYesRadioButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aliveYesRadioButton.Location = new System.Drawing.Point(96, 15);
            this.aliveYesRadioButton.Name = "aliveYesRadioButton";
            this.aliveYesRadioButton.Size = new System.Drawing.Size(67, 29);
            this.aliveYesRadioButton.TabIndex = 2;
            this.aliveYesRadioButton.Text = "Yes";
            this.aliveYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // aliveLabel
            // 
            this.aliveLabel.AutoSize = true;
            this.aliveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aliveLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aliveLabel.Location = new System.Drawing.Point(3, 15);
            this.aliveLabel.Name = "aliveLabel";
            this.aliveLabel.Size = new System.Drawing.Size(77, 29);
            this.aliveLabel.TabIndex = 1;
            this.aliveLabel.Text = "Alive :";
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.finishButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.finishButton.ForeColor = System.Drawing.Color.White;
            this.finishButton.Location = new System.Drawing.Point(855, 0);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(126, 65);
            this.finishButton.TabIndex = 2;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = false;
            this.finishButton.Click += new System.EventHandler(this.finishMethod);
            // 
            // DefineEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 697);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.informationPanel);
            this.Controls.Add(this.simulationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(999, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(999, 674);
            this.Name = "DefineEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define an Event";
            this.simulationPanel.ResumeLayout(false);
            this.informationPanel.ResumeLayout(false);
            this.informationPanel.PerformLayout();
            this.displayNotDisplayMenu.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.mitosisPanel.ResumeLayout(false);
            this.mitosisPanel.PerformLayout();
            this.alivePanel.ResumeLayout(false);
            this.alivePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel simulationPanel;
        private System.Windows.Forms.Panel cellWallDrawPanel;
        private System.Windows.Forms.Panel insideCellDrawPanel;
        private System.Windows.Forms.Panel ligandsDrawPanel;
        private System.Windows.Forms.Panel informationPanel;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.ContextMenuStrip displayNotDisplayMenu;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Panel alivePanel;
        private System.Windows.Forms.RadioButton aliveNoRadioButton;
        private System.Windows.Forms.RadioButton aliveYesRadioButton;
        private System.Windows.Forms.Label aliveLabel;
        private System.Windows.Forms.Panel mitosisPanel;
        private System.Windows.Forms.RadioButton mitosisNoRadioButton;
        private System.Windows.Forms.RadioButton mitosisYesRadioButton;
        private System.Windows.Forms.Label mitosisLabel;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.ToolStripMenuItem ınhibateToolStripMenuItem;
    }
}