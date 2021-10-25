using System;
using System.Data.SQLite;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class SaveDialogForm : Form
    {
        public SaveDialogForm()
        {
            InitializeComponent();
        }

        //Variable for database connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        private void saveButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If simulation name is not given.
            if (simulationNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Name field cannot be empty.", "Error");
                return;
            }

            string simulationName = simulationNameTextBox.Text;

            //--Error checking: If simulation name exists.
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT COUNT(*) from SIMULATIONS WHERE SIMULATIONNAME='" + simulationName + "'";
            command.Connection = con;
            try 
            {
                con.Open(); 
                object result = command.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;
                int checker = Convert.ToInt32(result);
                if ( checker != 0)
                {
                    MessageBox.Show("Simulation already exists !", "Error");
                    con.Close();
                    return;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred.(SIMULATIONS)", "Error");
                con.Close();
            }

            if (Application.OpenForms["Form2"] != null)
            {
                (Application.OpenForms["Form2"] as Form2).saveSimulation(simulationName);
            }
            this.Dispose();
        }
    }
}
