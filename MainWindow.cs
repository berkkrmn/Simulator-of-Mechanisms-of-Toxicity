using System;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void designButton_Click(object sender, EventArgs e)
        {
            Form2 designWindow = new Form2();
            designWindow.Visible = true;
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            SimulationSelectionForm simulationWindow = new SimulationSelectionForm();
            simulationWindow.Visible = true;
        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            string filename = "manual.pdf";
            System.Diagnostics.Process.Start(filename);
        }
    }   
}
