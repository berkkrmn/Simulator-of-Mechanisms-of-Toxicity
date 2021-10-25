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
    public partial class MoleculesOptionsForm : Form
    {
        public int selectionId = 0;
        public MoleculesOptionsForm(int selection)
        {
            selectionId = selection;
            InitializeComponent();
        }

        private void MoleculesOptionsForm_Load(object sender, EventArgs e)
        {
            moleculePictureBox.AllowDrop = true;
            if(selectionId == 1)
            {
                this.Text = "Endogenous Molecules";
                fillListBoxInternal();
            }
            else if(selectionId == 2)
            {
                this.Text = "Exogenous Molecules";
                fillListBoxExternal();
            }
        }

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //Internal listbox filling method.
        private void fillListBoxInternal()
        {
            moleculesListBox.Items.Clear();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from INTMOLECULES";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string sname = (string)dbr["NAME"];
                    moleculesListBox.Items.Add(sname);
                }
                dbr.Close();
                con.Close();
                if (Application.OpenForms["Form2"] != null)
                {
                    (Application.OpenForms["Form2"] as Form2).fillMoleculesList();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("FILL_LIST_BOX","Exception");
            }
        }

        //External listbox filling method.
        private void fillListBoxExternal()
        {
            moleculesListBox.Items.Clear();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from EXTMOLECULES";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string sname = (string)dbr["NAME"];
                    moleculesListBox.Items.Add(sname);
                }
                dbr.Close();
                con.Close();
                if (Application.OpenForms["Form2"] != null)
                {
                    (Application.OpenForms["Form2"] as Form2).fillMoleculesList();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        //Molecule image drag&drop methods.
        private void moleculePictureBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    moleculePictureBox.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void moleculePictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        //Add a molecule button method.
        private void addFinishButton_Click(object sender, EventArgs e)
        {
            //--Error checking: Name and image cannot be empty.
            if (moleculeNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Name field cannot be empty.", "Error");
                return;
            }
            if (moleculePictureBox.Image == null)
            {
                MessageBox.Show("Molecule image must be given.", "Error");
                return;
            }

            //--Error checking: Molecules cannot have the same name.
            string moleculeName = moleculeNameTextBox.Text;

            SQLiteCommand command = new SQLiteCommand();
            
            if (selectionId == 1)
            {
                command.CommandText = @"SELECT COUNT(*) from INTMOLECULES WHERE NAME='" + moleculeName + "'";
                command.Connection = con;
            }
            else if (selectionId == 2)
            {
                command.CommandText = @"SELECT COUNT(*) from EXTMOLECULES WHERE NAME='" + moleculeName + "'";
                command.Connection = con;
            }

            try
            {
                con.Open();
                object result = command.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;
                int checker = Convert.ToInt32(result);
                if (checker != 0)
                {
                    MessageBox.Show("Molecule already exists !", "Error");
                    con.Close();
                    return;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred.(MOLECULES)", "Error");
                con.Close();
            }

            MemoryStream ms1 = new MemoryStream();
            moleculePictureBox.Image.Save(ms1, moleculePictureBox.Image.RawFormat);
            byte[] img = new byte[ms1.Length];
            img = ms1.ToArray();

            if (selectionId == 1)
            {
                command.CommandText = @"INSERT INTO INTMOLECULES(NAME,IMAGE) VALUES (@n,@i)";
                command.Connection = con;
                command.Parameters.AddWithValue("@n", moleculeNameTextBox.Text.ToString());
                command.Parameters.AddWithValue("@i", img);
            }
            else if(selectionId == 2)
            {
                command.CommandText = @"INSERT INTO EXTMOLECULES(NAME,IMAGE) VALUES (@n,@i)";
                command.Connection = con;
                command.Parameters.AddWithValue("@n", moleculeNameTextBox.Text.ToString());
                command.Parameters.AddWithValue("@i", img);
            }

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Molecule added successfully.", "Message");
                if (selectionId == 1)
                {
                    fillListBoxInternal();
                }
                else if (selectionId == 2)
                {
                    fillListBoxExternal();
                }
                moleculeNameTextBox.Clear();
                moleculePictureBox.Image = null;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.", "Error");
            }
        }

        //Remove molecule button method.
        private void removeMoleculeButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If no item selected do nothing.
            if (moleculesListBox.SelectedItem == null)
            {
                return;
            }

            string moleculeName = moleculesListBox.SelectedItem.ToString();

            SQLiteCommand command = new SQLiteCommand();
            
            if (selectionId == 1)
            {
                command.CommandText = @"DELETE FROM INTMOLECULES WHERE NAME='" + moleculeName + "'";
                command.Connection = con;
            }
            else if (selectionId == 2)
            {
                command.CommandText = @"DELETE FROM EXTMOLECULES WHERE NAME = '" + moleculeName + "'";
                command.Connection = con;
            }
            
            //SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            try
            {
                con.Open();
                //SDA.SelectCommand.ExecuteNonQuery();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Molecule removed successfully.", "Message");
                if (selectionId == 1)
                {
                    fillListBoxInternal();
                }
                else if (selectionId == 2)
                {
                    fillListBoxExternal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.", "Error");
            }
        }

        //Clear button method.
        private void pictureBoxClearButton_Click(object sender, EventArgs e)
        {
            moleculeNameTextBox.Clear();
            moleculePictureBox.Image = null;
        }

    }
}
