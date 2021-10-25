using System;
using System.Data.SQLite;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class AddReceptorForm : Form
    {
        public AddReceptorForm()
        {
            InitializeComponent();
        }

        private int selectedReceptor = 0;

        private void AddReceptorForm_Load(object sender, EventArgs e)
        {
            fillLigandsListBox();
        }

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //List filling method.
        private void fillLigandsListBox()
        {
            factorsFlowLayoutPanel.Controls.Clear();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from LIGANDS";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string factorName = (string)dbr["NAME"]; //name is coming from database
                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = factorName;
                    newCheckBox.Checked = false;
                    factorsFlowLayoutPanel.Controls.Add(newCheckBox);
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("ADD_RECEPTOR_FILL_LIGANDS","Exception");
            }
        }

        //Receptor image selection & update method.
        private void updatePictureBox(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            receptorPreviewPictureBox.Image = pb.Image;

            if (pb.Name.Equals("receptor1PictureBox"))
            {
                selectedReceptor = 1;
            }else if (pb.Name.Equals("receptor2PictureBox"))
            {
                selectedReceptor = 2;
            }
            else if (pb.Name.Equals("receptor3PictureBox"))
            {
                selectedReceptor = 3;
            }
            else if (pb.Name.Equals("receptor4PictureBox"))
            {
                selectedReceptor = 4;
            }
            else if (pb.Name.Equals("receptor5PictureBox"))
            {
                selectedReceptor = 5;
            }
            else if (pb.Name.Equals("receptor6PictureBox"))
            {
                selectedReceptor = 6;
            }
        }

        //Clear button method.
        private void pictureBoxClearButton_Click(object sender, EventArgs e)
        {
            selectedReceptor = 0;
            receptorNameTextBox.Clear();
            receptorPreviewPictureBox.Image = null;
            factorsFlowLayoutPanel.Controls.Clear();
            fillLigandsListBox();
        }

        //Add a receptor button method.
        private void addFinishButton_Click(object sender, EventArgs e)
        {
            //--Error checking: Name field and image cannot be empty.
            if (receptorNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Name field cannot be empty.", "Error");
                return;
            }
            if (receptorPreviewPictureBox.Image == null)
            {
                MessageBox.Show("Receptor image must be selected.", "Error");
                return;
            }

            //--Error checking: If receptor name exists.
            string recName = receptorNameTextBox.Text;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT COUNT(*) from RECEPTORS WHERE NAME='" + recName + "'";
            command.Connection = con;

            try
            {
                con.Open(); 
                object result = command.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;
                int checker = Convert.ToInt32(result);
                if (checker != 0)
                {
                    MessageBox.Show("Receptor already exists !", "Error");
                    con.Close();
                    return;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred.(RECEPTROS)", "Error");
                con.Close();
            }

            string factorsString = "";
            
            foreach (Control ct in factorsFlowLayoutPanel.Controls)
            {
                CheckBox tmp = ct as CheckBox;
                if (tmp.Checked)
                {
                    factorsString = factorsString + tmp.Text + "*";
                }
            }

            //--Error checking: At least one ligand must be selected.
            if (factorsString.Equals(""))
            {
                MessageBox.Show("Please select ligands.", "Message");
                return;
            }

            command.CommandText = @"INSERT INTO RECEPTORS(NAME,IMAGEID,FACTORS) VALUES (@n,@i,@f)";
            command.Parameters.AddWithValue("@n", receptorNameTextBox.Text.ToString());
            command.Parameters.AddWithValue("@i", selectedReceptor);
            command.Parameters.AddWithValue("@f", factorsString);
            command.Connection = con;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Receptor added successfully.", "Message");
                selectedReceptor = 0;
                receptorNameTextBox.Clear();
                receptorPreviewPictureBox.Image = null;
                factorsFlowLayoutPanel.Controls.Clear();
                fillLigandsListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("ADD_BUTTON_INSERT_RECEPTOR", "Error");
            }
        }
    }
}
