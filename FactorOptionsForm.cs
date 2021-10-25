using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class FactorOptionsForm : Form
    {
        public FactorOptionsForm()
        {
            InitializeComponent();
        }

        private void FactorOptionsForm_Load(object sender, EventArgs e)
        {
            factorPictureBox.AllowDrop = true;
            fillListBox();
        }

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //Listbox filling method.
        private void fillListBox()
        {
            factorsListBox.Items.Clear();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from LIGANDS";
            command.Connection = con;

            try
            {
                con.Open(); 
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string sname = (string)dbr["NAME"]; //name is coming from database
                    factorsListBox.Items.Add(sname);
                }
                dbr.Close();
                con.Close();
                if (Application.OpenForms["Form2"] != null)
                {
                    (Application.OpenForms["Form2"] as Form2).fillLigandsList();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("FILL_LISTBOX","Exception");
            }
        }

        //Factor image drag&drop methods.
        private void factorPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if(data != null)
            {
                var fileNames = data as string[];
                if(fileNames.Length > 0)
                {
                    factorPictureBox.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void factorPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Add a factor button method.
        private void addFinishButton_Click(object sender, EventArgs e)
        {
            //--Error checking: Ligand name and image cannot be empty.
            if (factorNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Name field cannot be empty.","Error");
                return;
            }
            if(factorPictureBox.Image == null)
            {
                MessageBox.Show("Ligand image must be given.","Error");
                return;
            }

            //--Error checking: If ligand name exists.
            string ligandName = factorNameTextBox.Text;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT COUNT(*) from LIGANDS WHERE NAME='" + ligandName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                object result = command.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;
                int checker = Convert.ToInt32(result);
                if (checker != 0)
                {
                    MessageBox.Show("Ligand already exists !", "Error");
                    con.Close();
                    return;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred.(LIGANDS)", "Error");
                con.Close();
            }

            MemoryStream ms1 = new MemoryStream();
            factorPictureBox.Image.Save(ms1, factorPictureBox.Image.RawFormat);
            byte[] img = new byte[ms1.Length];
            img = ms1.ToArray();

            command.CommandText = @"INSERT INTO LIGANDS(NAME,IMAGE) VALUES (@n,@i)";
            command.Parameters.AddWithValue("@n", factorNameTextBox.Text.ToString());
            command.Parameters.AddWithValue("@i", img);
            command.Connection = con;
            
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ligand added successfully.", "Message");
                fillListBox();
                factorNameTextBox.Clear();
                factorPictureBox.Image = null;
            }
            catch(Exception)
            {
                MessageBox.Show("An error occured.(INSERT_LIGANDS)", "Error");
            }
        }

        //Remove factor button method.
        private void removeFactorButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no item selected do nothing.
            if(factorsListBox.SelectedItem == null)
            {
                return;
            }

            string ligandName = factorsListBox.SelectedItem.ToString();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"DELETE FROM LIGANDS WHERE NAME='" + ligandName + "'";
            command.Connection = con;

            //SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            try
            {
                con.Open();
                //SDA.SelectCommand.ExecuteNonQuery();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ligand removed successfully.", "Message");
                fillListBox();
            }
            catch(Exception)
            {
                MessageBox.Show("An error occured.(REMOVE_LIGAND)", "Error");
            }
        }

        //Clear button method.
        private void pictureBoxClearButton_Click(object sender, EventArgs e)
        {
            factorNameTextBox.Clear();
            factorPictureBox.Image = null;
        }

    }
}
