using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class SimulationSelectionForm : Form
    {
        public SimulationSelectionForm()
        {
            InitializeComponent();
        }

        private void SimulationSelectionForm_Load(object sender, EventArgs e)
        {
            fillListBox();
        }

        //Public variables.
        public string simName = "";
        public int areaCount = 0;
        public int eventCount = 0;
        public int aliveInfo = 0;
        public int mitosisInfo = 0;

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //ListBox fill method.
        private void fillListBox()
        {
            simulationsListBox.Items.Clear();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMULATIONS";
            command.Connection = con;
            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string simulationName = (string)dbr["SIMULATIONNAME"]; //name is coming from database
                    simulationsListBox.Items.Add(simulationName);
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        //Remove button method.
        //Collect the selected simulation name from the listbox.
        //Delete simulation objects with that simulationName value from the SIMOBJECTS table.
        //Then delete the simulation from the SIMULATIONS table.
        private void removeButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no item is selected from the list do nothing.
            if (simulationsListBox.SelectedItem == null)
            {
                return;
            }

            string simulationName = simulationsListBox.SelectedItem.ToString();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"DELETE FROM SIMOBJECTS WHERE SIMULATIONNAME='" + simulationName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                fillListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.(SIMOBJECTS)", "Error");
            }

            command.CommandText = @"DELETE FROM SIMEVENTS WHERE SIMULATIONNAME='" + simulationName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                fillListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.(SIMEVENTS)", "Error");
            }

            command.CommandText = @"DELETE FROM SIMULATIONS WHERE SIMULATIONNAME='" + simulationName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Simulation removed successfully.", "Message");
                fillListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.(SIMULATIONS)", "Error");
            }
        }

        //Select button method.
        //Collect the selected simulation information from the database.
        //and send the information to SimulationForm for drawing.
        private void selectButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no item is selected from the list do nothing.
            if(simulationsListBox.SelectedItem == null)
            {
                return;
            }

            //-Selected receptor name, imageID, factors.
            simName = simulationsListBox.SelectedItem.ToString();
            
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMULATIONS WHERE SIMULATIONNAME='" + simName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    aliveInfo = Convert.ToInt32(dbr["ALIVE"]);
                    mitosisInfo = Convert.ToInt32(dbr["MITOSIS"]);
                    areaCount = Convert.ToInt32(dbr["AREACOUNT"]);
                    eventCount = Convert.ToInt32(dbr["EVENTCOUNT"]);
                }
                dbr.Close();
                con.Close();

                SimulationForm simulationWindow = new SimulationForm(simName, aliveInfo, mitosisInfo,areaCount,eventCount);
                simulationWindow.Visible = true;
            }
            catch (Exception es)
            {
                MessageBox.Show("SELECT_BUTTON_SELECTION_FORM");
            }
            this.Dispose();
        }
    }
}
