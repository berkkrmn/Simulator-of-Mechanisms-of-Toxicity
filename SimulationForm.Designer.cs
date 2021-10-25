namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    partial class SimulationForm
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            this.cellStatusPanel = new System.Windows.Forms.Panel();
            this.reloadButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.mitosisInfoPanel = new System.Windows.Forms.Panel();
            this.mitosisInfoLabel = new System.Windows.Forms.Label();
            this.mitosisLabel = new System.Windows.Forms.Label();
            this.mitosisInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.aliveInfoPanel = new System.Windows.Forms.Panel();
            this.aliveInfoLabel = new System.Windows.Forms.Label();
            this.aliveInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.cellStatusLabel = new System.Windows.Forms.Label();
            this.simulationMainPanel = new System.Windows.Forms.Panel();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.moleculesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ligandsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.moleculesLabel = new System.Windows.Forms.Label();
            this.ligandsLabel = new System.Windows.Forms.Label();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.insideCellDrawPanel = new System.Windows.Forms.Panel();
            this.cellWallDrawPanel = new System.Windows.Forms.Panel();
            this.ligandsDrawPanel = new System.Windows.Forms.Panel();
            this.createPanelTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.movementTimer = new System.Windows.Forms.Timer(this.components);
            this.aliveMitosisTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.cellStatusPanel.SuspendLayout();
            this.mitosisInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mitosisInfoPictureBox)).BeginInit();
            this.aliveInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aliveInfoPictureBox)).BeginInit();
            this.simulationMainPanel.SuspendLayout();
            this.selectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellStatusPanel
            // 
            this.cellStatusPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.cellStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cellStatusPanel.Controls.Add(this.reloadButton);
            this.cellStatusPanel.Controls.Add(this.playButton);
            this.cellStatusPanel.Controls.Add(this.mitosisInfoPanel);
            this.cellStatusPanel.Controls.Add(this.aliveInfoPanel);
            this.aliveMitosisTransition.SetDecoration(this.cellStatusPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.cellStatusPanel, BunifuAnimatorNS.DecorationType.None);
            this.cellStatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cellStatusPanel.Location = new System.Drawing.Point(0, 585);
            this.cellStatusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.cellStatusPanel.Name = "cellStatusPanel";
            this.cellStatusPanel.Size = new System.Drawing.Size(1262, 88);
            this.cellStatusPanel.TabIndex = 0;
            // 
            // reloadButton
            // 
            this.reloadButton.BackColor = System.Drawing.Color.Orange;
            this.createPanelTransition.SetDecoration(this.reloadButton, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.reloadButton, BunifuAnimatorNS.DecorationType.None);
            this.reloadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.reloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reloadButton.Image = global::Simulator_Of_Mechanisms_Of_Toxicity.Properties.Resources.Restart;
            this.reloadButton.Location = new System.Drawing.Point(1100, 0);
            this.reloadButton.Margin = new System.Windows.Forms.Padding(0);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(80, 86);
            this.reloadButton.TabIndex = 5;
            this.reloadButton.UseVisualStyleBackColor = false;
            this.reloadButton.Click += new System.EventHandler(this.restartButtonMethod);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Purple;
            this.createPanelTransition.SetDecoration(this.playButton, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.playButton, BunifuAnimatorNS.DecorationType.None);
            this.playButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton.Image = global::Simulator_Of_Mechanisms_Of_Toxicity.Properties.Resources.Play;
            this.playButton.Location = new System.Drawing.Point(1180, 0);
            this.playButton.Margin = new System.Windows.Forms.Padding(0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(80, 86);
            this.playButton.TabIndex = 0;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButtonMethod);
            // 
            // mitosisInfoPanel
            // 
            this.mitosisInfoPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.mitosisInfoPanel.Controls.Add(this.mitosisInfoLabel);
            this.mitosisInfoPanel.Controls.Add(this.mitosisLabel);
            this.mitosisInfoPanel.Controls.Add(this.mitosisInfoPictureBox);
            this.aliveMitosisTransition.SetDecoration(this.mitosisInfoPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.mitosisInfoPanel, BunifuAnimatorNS.DecorationType.None);
            this.mitosisInfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mitosisInfoPanel.Location = new System.Drawing.Point(511, 0);
            this.mitosisInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mitosisInfoPanel.Name = "mitosisInfoPanel";
            this.mitosisInfoPanel.Size = new System.Drawing.Size(592, 86);
            this.mitosisInfoPanel.TabIndex = 3;
            // 
            // mitosisInfoLabel
            // 
            this.mitosisInfoLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.mitosisInfoLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.mitosisInfoLabel, BunifuAnimatorNS.DecorationType.None);
            this.mitosisInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mitosisInfoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mitosisInfoLabel.Location = new System.Drawing.Point(327, 24);
            this.mitosisInfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.mitosisInfoLabel.Name = "mitosisInfoLabel";
            this.mitosisInfoLabel.Size = new System.Drawing.Size(178, 32);
            this.mitosisInfoLabel.TabIndex = 2;
            this.mitosisInfoLabel.Text = "NO MITOSIS";
            // 
            // mitosisLabel
            // 
            this.mitosisLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.mitosisLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.mitosisLabel, BunifuAnimatorNS.DecorationType.None);
            this.mitosisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mitosisLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mitosisLabel.Location = new System.Drawing.Point(25, 22);
            this.mitosisLabel.Margin = new System.Windows.Forms.Padding(0);
            this.mitosisLabel.Name = "mitosisLabel";
            this.mitosisLabel.Size = new System.Drawing.Size(125, 36);
            this.mitosisLabel.TabIndex = 2;
            this.mitosisLabel.Text = "Mitosis :";
            // 
            // mitosisInfoPictureBox
            // 
            this.createPanelTransition.SetDecoration(this.mitosisInfoPictureBox, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.mitosisInfoPictureBox, BunifuAnimatorNS.DecorationType.None);
            this.mitosisInfoPictureBox.Location = new System.Drawing.Point(170, 0);
            this.mitosisInfoPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mitosisInfoPictureBox.Name = "mitosisInfoPictureBox";
            this.mitosisInfoPictureBox.Size = new System.Drawing.Size(84, 84);
            this.mitosisInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mitosisInfoPictureBox.TabIndex = 2;
            this.mitosisInfoPictureBox.TabStop = false;
            // 
            // aliveInfoPanel
            // 
            this.aliveInfoPanel.Controls.Add(this.aliveInfoLabel);
            this.aliveInfoPanel.Controls.Add(this.aliveInfoPictureBox);
            this.aliveInfoPanel.Controls.Add(this.cellStatusLabel);
            this.aliveMitosisTransition.SetDecoration(this.aliveInfoPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.aliveInfoPanel, BunifuAnimatorNS.DecorationType.None);
            this.aliveInfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.aliveInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.aliveInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.aliveInfoPanel.Name = "aliveInfoPanel";
            this.aliveInfoPanel.Size = new System.Drawing.Size(511, 86);
            this.aliveInfoPanel.TabIndex = 2;
            // 
            // aliveInfoLabel
            // 
            this.aliveInfoLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.aliveInfoLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.aliveInfoLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aliveInfoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aliveInfoLabel.Location = new System.Drawing.Point(335, 24);
            this.aliveInfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aliveInfoLabel.Name = "aliveInfoLabel";
            this.aliveInfoLabel.Size = new System.Drawing.Size(95, 32);
            this.aliveInfoLabel.TabIndex = 0;
            this.aliveInfoLabel.Text = "ALIVE";
            // 
            // aliveInfoPictureBox
            // 
            this.aliveInfoPictureBox.BackColor = System.Drawing.Color.SteelBlue;
            this.createPanelTransition.SetDecoration(this.aliveInfoPictureBox, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.aliveInfoPictureBox, BunifuAnimatorNS.DecorationType.None);
            this.aliveInfoPictureBox.Location = new System.Drawing.Point(195, 0);
            this.aliveInfoPictureBox.Name = "aliveInfoPictureBox";
            this.aliveInfoPictureBox.Size = new System.Drawing.Size(84, 84);
            this.aliveInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aliveInfoPictureBox.TabIndex = 1;
            this.aliveInfoPictureBox.TabStop = false;
            // 
            // cellStatusLabel
            // 
            this.cellStatusLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.cellStatusLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.cellStatusLabel, BunifuAnimatorNS.DecorationType.None);
            this.cellStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cellStatusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cellStatusLabel.Location = new System.Drawing.Point(3, 21);
            this.cellStatusLabel.Name = "cellStatusLabel";
            this.cellStatusLabel.Size = new System.Drawing.Size(174, 36);
            this.cellStatusLabel.TabIndex = 0;
            this.cellStatusLabel.Text = "Cell Status :";
            // 
            // simulationMainPanel
            // 
            this.simulationMainPanel.BackColor = System.Drawing.Color.White;
            this.simulationMainPanel.Controls.Add(this.selectionPanel);
            this.simulationMainPanel.Controls.Add(this.insideCellDrawPanel);
            this.simulationMainPanel.Controls.Add(this.cellWallDrawPanel);
            this.simulationMainPanel.Controls.Add(this.ligandsDrawPanel);
            this.aliveMitosisTransition.SetDecoration(this.simulationMainPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.simulationMainPanel, BunifuAnimatorNS.DecorationType.None);
            this.simulationMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.simulationMainPanel.Location = new System.Drawing.Point(0, 0);
            this.simulationMainPanel.Name = "simulationMainPanel";
            this.simulationMainPanel.Size = new System.Drawing.Size(1262, 587);
            this.simulationMainPanel.TabIndex = 1;
            // 
            // selectionPanel
            // 
            this.selectionPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectionPanel.Controls.Add(this.moleculesFlowLayoutPanel);
            this.selectionPanel.Controls.Add(this.ligandsFlowLayoutPanel);
            this.selectionPanel.Controls.Add(this.moleculesLabel);
            this.selectionPanel.Controls.Add(this.ligandsLabel);
            this.selectionPanel.Controls.Add(this.selectionLabel);
            this.aliveMitosisTransition.SetDecoration(this.selectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.selectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectionPanel.Location = new System.Drawing.Point(1102, 0);
            this.selectionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(160, 587);
            this.selectionPanel.TabIndex = 0;
            // 
            // moleculesFlowLayoutPanel
            // 
            this.moleculesFlowLayoutPanel.AutoScroll = true;
            this.moleculesFlowLayoutPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.createPanelTransition.SetDecoration(this.moleculesFlowLayoutPanel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.moleculesFlowLayoutPanel, BunifuAnimatorNS.DecorationType.None);
            this.moleculesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.moleculesFlowLayoutPanel.Location = new System.Drawing.Point(8, 342);
            this.moleculesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.moleculesFlowLayoutPanel.Name = "moleculesFlowLayoutPanel";
            this.moleculesFlowLayoutPanel.Size = new System.Drawing.Size(145, 232);
            this.moleculesFlowLayoutPanel.TabIndex = 3;
            this.moleculesFlowLayoutPanel.WrapContents = false;
            // 
            // ligandsFlowLayoutPanel
            // 
            this.ligandsFlowLayoutPanel.AutoScroll = true;
            this.ligandsFlowLayoutPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.createPanelTransition.SetDecoration(this.ligandsFlowLayoutPanel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.ligandsFlowLayoutPanel, BunifuAnimatorNS.DecorationType.None);
            this.ligandsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ligandsFlowLayoutPanel.Location = new System.Drawing.Point(8, 85);
            this.ligandsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ligandsFlowLayoutPanel.Name = "ligandsFlowLayoutPanel";
            this.ligandsFlowLayoutPanel.Size = new System.Drawing.Size(145, 222);
            this.ligandsFlowLayoutPanel.TabIndex = 2;
            this.ligandsFlowLayoutPanel.WrapContents = false;
            // 
            // moleculesLabel
            // 
            this.moleculesLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.moleculesLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.moleculesLabel, BunifuAnimatorNS.DecorationType.None);
            this.moleculesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.moleculesLabel.ForeColor = System.Drawing.Color.White;
            this.moleculesLabel.Location = new System.Drawing.Point(8, 317);
            this.moleculesLabel.Name = "moleculesLabel";
            this.moleculesLabel.Size = new System.Drawing.Size(101, 25);
            this.moleculesLabel.TabIndex = 3;
            this.moleculesLabel.Text = "Molecules";
            // 
            // ligandsLabel
            // 
            this.ligandsLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.ligandsLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.ligandsLabel, BunifuAnimatorNS.DecorationType.None);
            this.ligandsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ligandsLabel.ForeColor = System.Drawing.Color.White;
            this.ligandsLabel.Location = new System.Drawing.Point(8, 57);
            this.ligandsLabel.Name = "ligandsLabel";
            this.ligandsLabel.Size = new System.Drawing.Size(81, 25);
            this.ligandsLabel.TabIndex = 2;
            this.ligandsLabel.Text = "Ligands";
            // 
            // selectionLabel
            // 
            this.selectionLabel.AutoSize = true;
            this.createPanelTransition.SetDecoration(this.selectionLabel, BunifuAnimatorNS.DecorationType.None);
            this.aliveMitosisTransition.SetDecoration(this.selectionLabel, BunifuAnimatorNS.DecorationType.None);
            this.selectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectionLabel.ForeColor = System.Drawing.Color.White;
            this.selectionLabel.Location = new System.Drawing.Point(29, 3);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(108, 50);
            this.selectionLabel.TabIndex = 0;
            this.selectionLabel.Text = "Simulation \r\nOptions";
            this.selectionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // insideCellDrawPanel
            // 
            this.aliveMitosisTransition.SetDecoration(this.insideCellDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.insideCellDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.insideCellDrawPanel.Location = new System.Drawing.Point(4, 172);
            this.insideCellDrawPanel.Name = "insideCellDrawPanel";
            this.insideCellDrawPanel.Size = new System.Drawing.Size(1100, 415);
            this.insideCellDrawPanel.TabIndex = 2;
            // 
            // cellWallDrawPanel
            // 
            this.aliveMitosisTransition.SetDecoration(this.cellWallDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.cellWallDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.cellWallDrawPanel.Location = new System.Drawing.Point(3, 85);
            this.cellWallDrawPanel.Name = "cellWallDrawPanel";
            this.cellWallDrawPanel.Size = new System.Drawing.Size(1101, 85);
            this.cellWallDrawPanel.TabIndex = 1;
            // 
            // ligandsDrawPanel
            // 
            this.aliveMitosisTransition.SetDecoration(this.ligandsDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this.ligandsDrawPanel, BunifuAnimatorNS.DecorationType.None);
            this.ligandsDrawPanel.Location = new System.Drawing.Point(3, 3);
            this.ligandsDrawPanel.Name = "ligandsDrawPanel";
            this.ligandsDrawPanel.Size = new System.Drawing.Size(1101, 81);
            this.ligandsDrawPanel.TabIndex = 0;
            // 
            // createPanelTransition
            // 
            this.createPanelTransition.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic;
            this.createPanelTransition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 20;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.createPanelTransition.DefaultAnimation = animation1;
            this.createPanelTransition.MaxAnimationTime = 3000;
            // 
            // movementTimer
            // 
            this.movementTimer.Interval = 1;
            this.movementTimer.Tick += new System.EventHandler(this.movementTimer_Tick);
            // 
            // aliveMitosisTransition
            // 
            this.aliveMitosisTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.aliveMitosisTransition.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.aliveMitosisTransition.DefaultAnimation = animation2;
            this.aliveMitosisTransition.MaxAnimationTime = 4500;
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.simulationMainPanel);
            this.Controls.Add(this.cellStatusPanel);
            this.aliveMitosisTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.createPanelTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "SimulationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulate a Simulation";
            this.cellStatusPanel.ResumeLayout(false);
            this.mitosisInfoPanel.ResumeLayout(false);
            this.mitosisInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mitosisInfoPictureBox)).EndInit();
            this.aliveInfoPanel.ResumeLayout(false);
            this.aliveInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aliveInfoPictureBox)).EndInit();
            this.simulationMainPanel.ResumeLayout(false);
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cellStatusPanel;
        private System.Windows.Forms.Panel simulationMainPanel;
        private System.Windows.Forms.Panel ligandsDrawPanel;
        private System.Windows.Forms.Panel cellWallDrawPanel;
        private System.Windows.Forms.Panel insideCellDrawPanel;
        private System.Windows.Forms.Label cellStatusLabel;
        private System.Windows.Forms.Panel aliveInfoPanel;
        private System.Windows.Forms.Label aliveInfoLabel;
        private System.Windows.Forms.PictureBox aliveInfoPictureBox;
        private System.Windows.Forms.Panel mitosisInfoPanel;
        private System.Windows.Forms.Label mitosisInfoLabel;
        private System.Windows.Forms.Label mitosisLabel;
        private System.Windows.Forms.PictureBox mitosisInfoPictureBox;
        private BunifuAnimatorNS.BunifuTransition createPanelTransition;
        private System.Windows.Forms.Timer movementTimer;
        private BunifuAnimatorNS.BunifuTransition aliveMitosisTransition;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label moleculesLabel;
        private System.Windows.Forms.Label ligandsLabel;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.FlowLayoutPanel moleculesFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel ligandsFlowLayoutPanel;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Button playButton;
    }
}