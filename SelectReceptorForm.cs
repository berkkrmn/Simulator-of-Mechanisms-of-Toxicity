using System;
using System.Data.SQLite;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class ReceptorOptionsForm : Form
    {
        //static value for selected receptor.
        public static string selectedReceptor;

        public ReceptorOptionsForm()
        {
            InitializeComponent();
        }

        private void ReceptorOptionsForm_Load(object sender, EventArgs e)
        {
            fillListBox();
        }

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //ListBox fill method.
        private void fillListBox()
        {
            receptorsListBox.Items.Clear();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from RECEPTORS";
            command.Connection = con;
            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string receptorName = (string)dbr["NAME"]; //name is coming from database
                    receptorsListBox.Items.Add(receptorName);
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        //Select button method.
        //Collect the selected receptor information from the database.
        //and send the information to Form2 for drawing.
        private void selectButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no receptor is selected do nothing.
            if (receptorsListBox.SelectedItem == null)
            {
                return;
            }

            //Send selected receptor name.
            selectedReceptor = receptorsListBox.SelectedItem.ToString();
            if (Application.OpenForms["Form2"] != null)
            {
                (Application.OpenForms["Form2"] as Form2).drawReceptor(selectedReceptor);
            }
            this.Dispose();
        }

        //Remove button method.
        //Collect the selected receptor information from the listbox.
        //and delete from the database.
        private void removeReceptorButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no receptor is selected do nothing.
            if (receptorsListBox.SelectedItem == null)
            {
                return;
            }

            string receptorName = receptorsListBox.SelectedItem.ToString();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"DELETE FROM RECEPTORS WHERE NAME='" + receptorName + "'";
            command.Connection = con;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Receptor removed successfully.", "Message");
                fillListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.", "Error");
            }
        }
    }
}
