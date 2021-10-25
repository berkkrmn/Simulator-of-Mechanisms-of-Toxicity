using System;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class InternalExternalForm : Form
    {
        public InternalExternalForm()
        {
            InitializeComponent();
        }

        private void internalButton_Click(object sender, EventArgs e)
        {
            MoleculesOptionsForm newWindow = new MoleculesOptionsForm(1);
            newWindow.Visible = true;
            this.Dispose();
        }

        private void externalButton_Click(object sender, EventArgs e)
        {
            MoleculesOptionsForm newWindow = new MoleculesOptionsForm(2);
            newWindow.Visible = true;
            this.Dispose();
        }
    }
}
