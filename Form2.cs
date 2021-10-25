using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 * 
 * In some areas of the code the ligands are misspelled as "factors"
 * and also molecules are misspelled as "factors" due to the change 
 * of the design in the implementation phase.
 * 
 * Correct one should be "LIGANDS" for left panel, "MOLECULES" for right panel.
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class Form2 : Form
    {
        //Graphics variables.
        public Graphics gFactors;
        public Graphics gCellWall;
        public Graphics gInside;

        //Variables for drag&drop features of the arrows&factors.
        private Control activeControl;
        private Point previousPosition;

        //Dictionary & list variables.
        private Dictionary<string, Control> factors = new Dictionary<string, Control>();
        private Dictionary<string, Control> molecules = new Dictionary<string, Control>();
        private Dictionary<string, Control> objects = new Dictionary<string, Control>();
        private Dictionary<string, Control> receptors = new Dictionary<string, Control>();
        private Dictionary<string, int> receptorImages = new Dictionary<string, int>();
        private Dictionary<string, string> receptorLigands = new Dictionary<string, string>();

        //--Dictionary & list variables for events.
        private ArrayList eventsList = new ArrayList();
        private Dictionary<string, string> displayEvents = new Dictionary<string, string>();
        private Dictionary<string, string> removeEvents = new Dictionary<string, string>();
        private Dictionary<string, string> inhibateEvents = new Dictionary<string, string>();
        private Dictionary<string, string> aliveMitosisEvents = new Dictionary<string, string>();

        //--List variables for checkboxes and displaying on the panel.
        private ArrayList ligandsNames = new ArrayList();
        private ArrayList internalMoleculesNames = new ArrayList();
        private ArrayList externalMoleculesNames = new ArrayList();
        private ArrayList receptorNames = new ArrayList();

    
        //Objects variables.
        private int arrowID = 0;
        private int plusPID = 0;
        private int minusPID = 0;


        //Receptor and border variables.
        private int receptorNumber = 0;
        private int border1 = 0;
        private int border2 = 0;
        private int border3 = 0;
        private int border4 = 0;
        private int border5 = 0;

        //Variable for database connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //Form constructor & load methods.
        public Form2()
        {
            InitializeComponent();
            gFactors = factorsDrawPanel.CreateGraphics();
            gCellWall = cellWallDrawPanel.CreateGraphics();
            gInside = insideCellDrawPanel.CreateGraphics();
            insideCellDrawPanel.ContextMenuStrip = moleculesContextMenuStrip;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillLigandsList();
            fillMoleculesList();

            var cellWallStaticPanel = new Panel();
            cellWallStaticPanel.Name = "cell_wall";
            cellWallStaticPanel.Location = new Point(0, 33);
            cellWallStaticPanel.Size = new Size(966, 13);
            cellWallStaticPanel.BackgroundImage = Properties.Resources.cell_wall;
            cellWallStaticPanel.BackgroundImageLayout = ImageLayout.Stretch;
            cellWallDrawPanel.Controls.Add(cellWallStaticPanel);
            cellWallStaticPanel.Visible = true;
        }

        /*********************************************/

        //Factor & Molecule list filler methods.
        //These methods connect to the database and fill the lists.
        public void fillLigandsList()
        {
            factorsFlowLayoutPanel.Controls.Clear();
            ligandsNames.Clear();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from LIGANDS";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string ligandName = (string)dbr["NAME"]; 
                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = ligandName;
                    newCheckBox.Checked = false;
                    newCheckBox.Enabled = false;
                    newCheckBox.ForeColor = Color.White;
                    newCheckBox.CheckedChanged += new EventHandler(ligandsCheckBoxChecked);
                    factorsFlowLayoutPanel.Controls.Add(newCheckBox);
                    ligandsNames.Add(ligandName);
                }
                dbr.Close();
                con.Close();
            }

            catch (Exception es)
            {
                MessageBox.Show("FILL_LIGANDS_LIST", "Exception");
            }

            //--Display "no ligands" if no ligands are saved.
            if (factorsFlowLayoutPanel.Controls.Count == 0)
            {
                var noLigandsLabel = new Label();
                noLigandsLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                noLigandsLabel.Text = "No Ligands";
                noLigandsLabel.ForeColor = Color.White;
                factorsFlowLayoutPanel.Controls.Add(noLigandsLabel);
            }
        }

        public void fillMoleculesList()
        {
            //Clear the list and panel.
            moleculesFlowLayoutPanel.Controls.Clear();
            internalMoleculesNames.Clear();
            externalMoleculesNames.Clear();

            //Fill internal molecules first.
            var internalLabel = new Label();
            internalLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            internalLabel.Text = "Endogenous";
            internalLabel.ForeColor = Color.White;
            moleculesFlowLayoutPanel.Controls.Add(internalLabel);

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from INTMOLECULES";
            command.Connection = con;

            try
            {   
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string moleculeName = (string)dbr["NAME"];

                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = moleculeName;
                    newCheckBox.ForeColor = Color.White;
                    newCheckBox.Checked = false;
                    newCheckBox.CheckedChanged += new EventHandler(moleculesCheckBoxChecked);
                    moleculesFlowLayoutPanel.Controls.Add(newCheckBox);
                    internalMoleculesNames.Add(moleculeName);
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("FILL_INT_MOLECULES(FORM_2)", "Exception");
            }

            //Fill external molecules second.
            var externalLabel = new Label();
            externalLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            externalLabel.Text = "Exogenous";
            externalLabel.ForeColor = Color.White;
            moleculesFlowLayoutPanel.Controls.Add(externalLabel);

            SQLiteCommand extcommand = new SQLiteCommand();
            extcommand.CommandText = @"SELECT * from EXTMOLECULES";
            extcommand.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = extcommand.ExecuteReader();
                while (dbr.Read())
                {
                    string moleculeName = (string)dbr["NAME"];
                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = moleculeName;
                    newCheckBox.ForeColor = Color.White;
                    newCheckBox.Checked = false;
                    newCheckBox.CheckedChanged += new EventHandler(moleculesCheckBoxChecked);
                    moleculesFlowLayoutPanel.Controls.Add(newCheckBox);
                    externalMoleculesNames.Add(moleculeName);
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("FILL_EXT_MOLECULES", "Exception");
            }
            
            //--Display "no molecules" if no molecules are saved.
            if(moleculesFlowLayoutPanel.Controls.Count == 2)
            {
                externalLabel.Visible = false;
                internalLabel.Visible = false;
                var noMoleculesLabel = new Label();
                noMoleculesLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                noMoleculesLabel.Text = "No Molecules";
                noMoleculesLabel.ForeColor = Color.White;
                moleculesFlowLayoutPanel.Controls.Add(noMoleculesLabel);
            }
            else
            {
                externalLabel.Visible = true;
                internalLabel.Visible = true;
            }
        }

        /***********************************************/

        //Method for enable selected ligands.************
        private void ligandsCheckBoxEnable(string factorName)
        {
            foreach (CheckBox ligandCheckbox in factorsFlowLayoutPanel.Controls)
            {
                if (ligandCheckbox.Text.Equals(factorName))
                {
                    ligandCheckbox.Enabled = true;
                }
            }
        }

        /***********************************************/

        //Factor & Molecule drawing methods.*************
        //Method for creating factor images on the canvas.
        private void ligandsCheckBoxChecked(object sender, EventArgs e)
        {
            //Obtain image of the factor from dataset.
            var checkBoxed = sender as CheckBox;

            if (checkBoxed.Checked)
            {
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = @"SELECT IMAGE FROM LIGANDS WHERE NAME='" + checkBoxed.Text.ToString() + "'";
                command.Connection = con;

                try
                {
                    con.Open();
                    SQLiteDataReader dbr = command.ExecuteReader();
                    while (dbr.Read())
                    {
                        byte[] imgAsByte = (byte[])dbr["IMAGE"];
                        MemoryStream ms1 = new MemoryStream(imgAsByte);
                        ms1.Seek(0, SeekOrigin.Begin);

                        //Create an image of the factor as a panel
                        //and assign drag&drop methods to the image of the factor.
                        var newControl = new Panel();
                        newControl.Name = checkBoxed.Text.ToString();
                        newControl.Location = new Point(10, 10);
                        newControl.Size = new Size(50, 50);
                        newControl.BackgroundImage = Image.FromStream(ms1);
                        newControl.BackgroundImageLayout = ImageLayout.Zoom;
                        newControl.MouseDown += new MouseEventHandler(Controls_MouseDown);
                        newControl.MouseMove += new MouseEventHandler(Controls_MouseMove);
                        newControl.MouseUp += new MouseEventHandler(Controls_MouseUp);

                        factors.Add(checkBoxed.Text.ToString(), newControl);

                        factorsDrawPanel.Controls.Add(newControl);
                        newControl.Visible = true;
                        newControl.BringToFront();
                    }
                    dbr.Close();
                    con.Close();
                }
                catch (Exception es)
                {
                    MessageBox.Show("LIGAND_CHECKED", "Exception");
                }
            }
            else
            {
                factors[checkBoxed.Text.ToString()].Dispose();
                factors.Remove(checkBoxed.Text.ToString());
            }
        }

        //Method for creating molecule images on the canvas.
        private void moleculesCheckBoxChecked(object sender, EventArgs e)
        {
            var checkBoxed = sender as CheckBox;

            if (checkBoxed.Checked)
            {
                //--Find the name of the molecule inside name lists.
                //then obtain image of the molecule from dataset.

                SQLiteCommand command = new SQLiteCommand();

                if (internalMoleculesNames.Contains(checkBoxed.Text.ToString()))
                {
                    command.CommandText = @"SELECT IMAGE FROM INTMOLECULES WHERE NAME='" + checkBoxed.Text.ToString() + "'";
                    command.Connection = con;
                }
                else if(externalMoleculesNames.Contains(checkBoxed.Text.ToString()))
                {
                    command.CommandText = @"SELECT IMAGE FROM EXTMOLECULES WHERE NAME='" + checkBoxed.Text.ToString() + "'";
                    command.Connection = con;
                }

                try
                {
                    con.Open();
                    SQLiteDataReader dbr = command.ExecuteReader();
                    while (dbr.Read())
                    {
                        byte[] imgAsByte = (byte[])dbr["IMAGE"];
                        MemoryStream ms1 = new MemoryStream(imgAsByte);
                        ms1.Seek(0, SeekOrigin.Begin);

                        //Create an image of the molecule as a panel
                        var newControl = new Panel();
                        newControl.Name = checkBoxed.Text.ToString();
                        newControl.Location = new Point(10, 10);
                        newControl.Size = new Size(50, 50);
                        newControl.BackgroundImage = Image.FromStream(ms1);
                        newControl.BackgroundImageLayout = ImageLayout.Stretch;

                        //Assign drag&drop method to the image of the molecule.
                        ControlMoverOrResizer.Init(newControl);

                        //Assign event defining method to the molecule.
                        newControl.ContextMenuStrip = eventMenuStrip;

                        molecules.Add(checkBoxed.Text.ToString(), newControl);
                        insideCellDrawPanel.Controls.Add(newControl);
                        newControl.Visible = true;
                        newControl.BringToFront();
                    }
                    dbr.Close();
                    con.Close();
                }
                catch (Exception es)
                {
                    MessageBox.Show("MOLECULE_CHECKED","Exception");
                }
            }
            else
            {
                molecules[checkBoxed.Text.ToString()].Dispose();
                molecules.Remove(checkBoxed.Text.ToString());
            }
        }

        //Method for evaluating and drawing receptors.
        public void drawReceptor(string selectedReceptor)
        {
            //--Obtain current receptor info from database.
            int imageID = 0;
            string factorsColumn = "";

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from RECEPTORS WHERE NAME='" + selectedReceptor + "'";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    imageID = Convert.ToInt32(dbr["IMAGEID"]);
                    factorsColumn = (string)dbr["FACTORS"];
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("DRAW_RECEPTOR","Exception");
            }

            //--Get ligand names.
            string[] substrings = factorsColumn.Split(new Char[] { '*' });

            //--Error checking: If receptor already drawn.
            if(receptorNames.Contains(selectedReceptor))
            {
                MessageBox.Show("Receptor already used !", "Error");
                return;
            }

            //--Error checking: If ligand does not exists.
            foreach (string s in substrings)
            {
                if (s.Trim() != "")
                {
                    if (!ligandsNames.Contains(s))
                    {
                        string message = "Unable to load receptor becouse the following ligand cannot found: " + s +
                            "\nPlease add the ligand to the application in order to use the receptor.";
                        MessageBox.Show(message, "Error");
                        return;
                    }
                }
            }

            //--If no other receptors present use all of the draw panel with no borders.
            if(receptorNumber == 0)
            {
                //--For each ligand, call these methods to enable their checkboxes.
                foreach (string s in substrings)
                {
                    if (s.Trim() != "")
                    {
                        ligandsCheckBoxEnable(s);
                        factorOptionButtonCheckEnabled();
                    }
                }
                
                //--Put the receptor to the middle of the panel.
                int coordinate = cellWallDrawPanel.Size.Width / 2;
                placeReceptor(selectedReceptor, imageID, factorsColumn, coordinate);

            }
            else if (receptorNumber == 1)
            {
                //--If there are more than 1 receptors in the simulation, 
                //--split the drawPanel according to the number of receptors using border variables.

                //--Obtain the present receptor information and clear simulation.
                string receptor1Name = receptorNames[0].ToString();
                int receptor1image = receptorImages[receptor1Name];
                string receptor1ligands = receptorLigands[receptor1Name];
                clearSimulation();

                //--Set borders.
                border1 = 0;
                border2 = cellWallDrawPanel.Size.Width / 2;
                border3 = cellWallDrawPanel.Size.Width;

                //--Place previous receptor to border2 / 2 coordinate.
                int coordinate1 = border2 / 2;
                placeReceptor(receptor1Name, receptor1image, receptor1ligands, coordinate1);

                //--Place current selected receptor.
                int coordinateCurrent = ((border3 - border2) / 2) + border2;
                placeReceptor(selectedReceptor, imageID, factorsColumn, coordinateCurrent);
            }
            else if(receptorNumber == 2)
            {
                //--Obtain the present receptors information and clear simulation.
                string receptor1Name = receptorNames[0].ToString();
                int receptor1image = receptorImages[receptor1Name];
                string receptor1ligands = receptorLigands[receptor1Name];

                string receptor2Name = receptorNames[1].ToString();
                int receptor2image = receptorImages[receptor2Name];
                string receptor2ligands = receptorLigands[receptor2Name];
                clearSimulation();

                //--Set borders.
                border1 = 0;
                border2 = cellWallDrawPanel.Size.Width / 3;
                border3 = (cellWallDrawPanel.Size.Width / 3) * 2;
                border4 = cellWallDrawPanel.Size.Width;

                //--Draw borders (optional)

                //--Place previous receptors.
                int coordinate1 = border2 / 2;
                placeReceptor(receptor1Name, receptor1image, receptor1ligands, coordinate1);
                
                int coordinate2 = ((border3 - border2) / 2) + border2;
                placeReceptor(receptor2Name, receptor2image, receptor2ligands, coordinate2);

                //--Place current selected receptor.
                int coordinateCurrent = ((border4 - border3) / 2) + border3;
                placeReceptor(selectedReceptor, imageID, factorsColumn, coordinateCurrent);

            }
            else if(receptorNumber == 3)
            {
                //--Obtain the present receptors information and clear simulation.
                string receptor1Name = receptorNames[0].ToString();
                int receptor1image = receptorImages[receptor1Name];
                string receptor1ligands = receptorLigands[receptor1Name];

                string receptor2Name = receptorNames[1].ToString();
                int receptor2image = receptorImages[receptor2Name];
                string receptor2ligands = receptorLigands[receptor2Name];

                string receptor3Name = receptorNames[2].ToString();
                int receptor3image = receptorImages[receptor3Name];
                string receptor3ligands = receptorLigands[receptor3Name];
                clearSimulation();

                //--Set borders.
                border1 = 0;
                border2 = cellWallDrawPanel.Size.Width / 4;
                border3 = (cellWallDrawPanel.Size.Width / 4) * 2;
                border4 = (cellWallDrawPanel.Size.Width / 4) * 3;
                border5 = cellWallDrawPanel.Size.Width;

                //--Draw borders (optional)

                //--Place previous receptors.
                int coordinate1 = border2 / 2;
                placeReceptor(receptor1Name, receptor1image, receptor1ligands, coordinate1);

                int coordinate2 = ((border3 - border2) / 2) + border2;
                placeReceptor(receptor2Name, receptor2image, receptor2ligands, coordinate2);
                
                int coordinate3 = ((border4 - border3) / 2) + border3;
                placeReceptor(receptor3Name, receptor3image, receptor3ligands, coordinate3);

                //--Place current selected receptor.
                int coordinateCurrent = ((border5 - border4) / 2) + border4;
                placeReceptor(selectedReceptor, imageID, factorsColumn, coordinateCurrent);

            }
        }

        //Place receptor on the cell wall method.
        private void placeReceptor(string receptorName, int imageID, string ligands,int coordinate)
        {
            //--Create a panel object.
            var newReceptor = new Panel();
            newReceptor.Name = receptorName;
            newReceptor.Location = new Point(coordinate, 5);
            newReceptor.Size = new Size(25, 61);

            //--Set image.
            if (imageID == 1)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (imageID == 2)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor2;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (imageID == 3)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor3;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (imageID == 4)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor4;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (imageID == 5)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor5;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (imageID == 6)
            {
                newReceptor.BackgroundImage = Properties.Resources.receptor6;
                newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
            }

            //--For each ligand, call these methods to enable their checkboxes.
            string[] substrings = ligands.Split(new Char[] { '*' });
            foreach (string s in substrings)
            {
                if (s.Trim() != "")
                {
                    ligandsCheckBoxEnable(s);
                    factorOptionButtonCheckEnabled();
                }
            }

            //Add receptor information to the necessary dictionary.(object, image, ligands)
            //Name the receptor.
            //Increment the number of receptors in the simulation.
            newReceptor.Name = receptorName;
            receptors.Add(receptorName, newReceptor);
            receptorImages.Add(receptorName, imageID);
            receptorLigands.Add(receptorName, ligands);
            receptorNames.Add(receptorName);
            cellWallDrawPanel.Controls.Add(newReceptor);
            newReceptor.Visible = true;
            newReceptor.BringToFront();
            receptorNumber++;
        }
        /*********************************************/

        //Toolstrip methods.**************************
        private void defineANewReceptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ligandsNames.Count > 0)
            {
                AddReceptorForm newWindow = new AddReceptorForm();
                newWindow.Visible = true;
            }else
            {
                MessageBox.Show("No ligands found. Please define some ligands first.", "Error");
            }
        }

        private void useADefinedReceptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //--Error checking : If maximum receptor number is reached (4)
            if(receptorNumber == 4)
            {
                MessageBox.Show("Maximum receptor number reached.", "Error");
                return;
            }
            else
            {
                ReceptorOptionsForm newWindow = new ReceptorOptionsForm();
                newWindow.Visible = true;
            }
            
        }

        /*********************************************/

        //Drag and drop methods.*************************

        //Factor methods for drag&drop feature.
        private void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
        }

        private void Controls_MouseMove(object sender, MouseEventArgs e)
        {
            if(activeControl == null || activeControl != sender)
            {
                return;
            }
            var location = activeControl.Location;
            location.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
            activeControl.Location = location;
        }

        private void Controls_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }
        /****************************************************/

        //Add arrow and P molecule to the canvas methods.
        private void drawArrow(int arrowType, int arrowDirection, int stOrDotted)
        {
            //--Create arrow object.
            string name = "arrow"+ arrowID.ToString();
            var newArrow = new Panel();
            newArrow.Name = name;
            newArrow.Location = new Point(20, 20);

            //--Set arrow size and image according to the arrow informaiton.
            //--If arrow is standard or not. ( 1 - STANDARD / 2 - INHIBITOR )
            if(arrowType == 1)
            {
                //--Choose arrow direction. ( 1 - UP / 2 - DOWN / 3 - LEFT / 4 - RIGHT )
                if(arrowDirection == 1)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED )
                    if(stOrDotted == 1)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Up_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if(stOrDotted == 2)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Up_Dotted_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }else if(arrowDirection == 2)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Down_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Down_Dotted_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else if (arrowDirection == 3)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Arrow_Left;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Dotted_Arrow_Left;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else if (arrowDirection == 4)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Arrow_Right;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Dotted_Arrow_Right;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            else if(arrowType == 2)
            {
                //--Choose arrow direction. ( 1 - NORTH / 2 - SOUTH / 3 - WEST / 4 - EAST )
                if (arrowDirection == 1)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Vertical_Up_Inhibator_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Vertical_Up_Inhibator_Dotted_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
                else if (arrowDirection == 2)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Vertical_Down_Inhibator_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(20, 80);
                        newArrow.BackgroundImage = Properties.Resources.Vertical_Down_Inhibator_Dotted_Arrow;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else if (arrowDirection == 3)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Inhibator_Arrow_Left;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Inhibator_Dotted_Arrow_Left;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else if (arrowDirection == 4)
                {
                    //--Choose arrow type ( 1 - STRAIGHT / 2 - DOTTED)
                    if (stOrDotted == 1)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Inhibator_Arrow_Right;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (stOrDotted == 2)
                    {
                        newArrow.Size = new Size(80, 20);
                        newArrow.BackgroundImage = Properties.Resources.Horizontal_Inhibator_Dotted_Arrow_Right;
                        newArrow.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            
            //--Apply ControlMoverOrResizer to this object in order to make it draggable & resizable.

            ControlMoverOrResizer.Init(newArrow);
            objects.Add(name, newArrow);
            insideCellDrawPanel.Controls.Add(newArrow);
            newArrow.Visible = true;
            newArrow.BringToFront();
            arrowID++;
        }

        //--Straight arrow UP.
        private void addStraightArrowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,1,1);
        }

        //--Dotted arrow UP.
        private void addDottedArrowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,1,2);
        }

        //--Straight arrow DOWN.
        private void addStraightArrowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,2,1);
        }

        //--Dotted arrow DOWN.
        private void addDottedArrowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,2,2);
        }

        //--Straight arrow LEFT.
        private void addStraightArrowLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,3,1);
        }

        //--Dotted arrow LEFT.
        private void addDottedArrowLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,3,2);
        }

        //--Straight arrow RIGHT.
        private void addStraightArrowRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,4,1);
        }

        //--Dotted arrow RIGHT.
        private void addDottedArrowRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(1,4,2);
        }

        //--Straight inhibitor arrow UP.
        private void addStraightInhibitorArrowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,1,1);
        }

        //--Dotted inhibitor arrow UP.
        private void addDottedInhibitorArrowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,1,2);
        }

        //--Straight inhibitor arrow DOWN.
        private void addStraightInhibitorArrowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,2,1);
        }

        //--Dotted inhibitor arrow DOWN.
        private void addDottedInhibitorArrowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,2,2);
        }

        //--Straight inhibitor arrow LEFT.
        private void addStraightInhibitorArrowLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,3,1);
        }

        //--Dotted inhibitor arrow LEFT.
        private void addDottedInhibitorArrowLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,3,2);
        }

        //--Straight inhibitor arrow RIGHT.
        private void addStraightInhibitorArrowRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,4,1);
        }

        //--Dotted inhibitor arrow RIGHT.
        private void addDottedInhibitorArrowRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawArrow(2,4,2);
        }

        private void addPlusP_Click(object sender, EventArgs e)
        {
            string name = "plusP" + plusPID.ToString();
            var newObject = new Panel();
            newObject.Name = name;
            newObject.Location = new Point(20, 20);
            newObject.Size = new Size(25, 25);
            newObject.BackgroundImage = Properties.Resources.plusPUpdated;
            newObject.BackgroundImageLayout = ImageLayout.Stretch;

            ControlMoverOrResizer.Init(newObject);
            objects.Add(name, newObject);
            insideCellDrawPanel.Controls.Add(newObject);
            newObject.Visible = true;
            newObject.BringToFront();
            plusPID++;
        }

        private void addMinusP_Click(object sender, EventArgs e)
        {
            string name = "minusP" + minusPID.ToString();
            var newObject = new Panel();
            newObject.Name = name;
            newObject.Location = new Point(20, 20);
            newObject.Size = new Size(25, 25);
            newObject.BackgroundImage = Properties.Resources.minusPUpdated;
            newObject.BackgroundImageLayout = ImageLayout.Stretch;

            ControlMoverOrResizer.Init(newObject);
            objects.Add(name, newObject);
            insideCellDrawPanel.Controls.Add(newObject);
            newObject.Visible = true;
            newObject.BringToFront();
            minusPID++;
        }


        /*************************************************/

        //Ligands & Molecules option form button methods.****
        private void factorOptionsButton_Click(object sender, EventArgs e)
        {
            FactorOptionsForm newWindow = new FactorOptionsForm();
            newWindow.Visible = true;
        }

        private void moleculesOptionButton_Click(object sender, EventArgs e)
        {
            InternalExternalForm newWindow = new InternalExternalForm();
            newWindow.Visible = true;
        }

        //--Factor options method enable = false method.
        public void factorOptionButtonCheckEnabled()
        {
            foreach(Button tmp in factorsPanel.Controls)
            {
                if(tmp.Name.Equals("factorOptionsButton"))
                {
                    tmp.BackColor = Color.Gray;
                    tmp.Enabled = false;
                    tmp.Text = "Selected";
                    break;
                }
            }

            foreach (var tmp in moleculesPanel.Controls)
            {
                Button tmpButton = new Button();
                if (tmp.GetType().Equals(tmpButton.GetType()))
                {
                    tmpButton = tmp as Button;
                    if (tmpButton.Name.Equals("moleculesOptionButton"))
                    {
                        tmpButton.BackColor = Color.Gray;
                        tmpButton.Enabled = false;
                        tmpButton.Text = "Selected";
                        break;
                    }
                }
                
            }
        }

        //--Factor options method enable = true method.
        public void factorOptionButtonCheckNotEnabled()
        {
            foreach (Button tmp in factorsPanel.Controls)
            {
                if (tmp.Name.Equals("factorOptionsButton"))
                {
                    tmp.BackColor = Color.SteelBlue;
                    tmp.Enabled = true;
                    tmp.Text = "Add / Remove";
                    break;
                }
            }

            foreach (var tmp in moleculesPanel.Controls)
            {
                Button tmpButton = new Button();
                if (tmp.GetType().Equals(tmpButton.GetType()))
                {
                    tmpButton = tmp as Button;
                    if (tmpButton.Name.Equals("moleculesOptionButton"))
                    {
                        tmpButton.BackColor = Color.SteelBlue;
                        tmpButton.Enabled = true;
                        tmpButton.Text = "Add / Remove";
                        break;
                    }
                }

            }
        }

        /************************************************/

        //Main button methods.***************************

        //Clear button method.
        private void clearButton_Click(object sender, EventArgs e)
        {
            clearSimulation();
        }

        //Save button method.
        private void saveButton_Click(object sender, EventArgs e)
        {
            //--Error checking: If there is no receptors or factors added.
            if(receptors.Count == 0 || factors.Count == 0)
            {
                MessageBox.Show("Please add at least one receptor and one factor to the simulation.", "Save Simulation");
                return;
            }

            //--Error checking: If there is no objects inside the cell.
            if(objects.Count == 0 && molecules.Count == 0)
            {
                MessageBox.Show("Please add at least one molecule or sign to the simulation.", "Save Simulation");
                return;
            }

            //--If no errors found open SaveDialogForm.
            SaveDialogForm toolWindow = new SaveDialogForm();
            toolWindow.Visible = true;
        }

        /*******************************************************/

        //Clear simulation method.
        public void clearSimulation()
        {
            //--If there is at least one receptor selected then the control number should be > 1.(With the cell wall)
            //--In that situation clear ligament checkboxes, enable "ligament adding/removing button".
            if (cellWallDrawPanel.Controls.Count != 1)
            {
                foreach (CheckBox ligamentCheckbox in factorsFlowLayoutPanel.Controls)
                {
                    ligamentCheckbox.Enabled = false;
                    ligamentCheckbox.Checked = false;
                }
                factorOptionButtonCheckNotEnabled();
            }

            //--If there is at least one object inside the cell wall
            //--Set all molecule checkboxes as not checked.
            if (insideCellDrawPanel.Controls.Count != 0)
            {
                //----If there is only "molecule" objects on the insideCellDrawPanel.
                if (objects.Count == 0 && molecules.Count != 0)
                {
                    //----Clear "molecule" checkboxes.
                    foreach (var molecule in moleculesFlowLayoutPanel.Controls)
                    {
                        CheckBox moleculeCheckbox = new CheckBox();
                        if (molecule.GetType().Equals(moleculeCheckbox.GetType()))
                        {
                            moleculeCheckbox = molecule as CheckBox;
                        }
                        moleculeCheckbox.Checked = false;
                    }
                }
                else
                {
                    //----If there are both molecules and objects on the insideCellDrawPanel
                    //----Set all molecule checkboxes as not checked.
                    foreach (var molecule in moleculesFlowLayoutPanel.Controls)
                    {
                        CheckBox moleculeCheckbox = new CheckBox();
                        if (molecule.GetType().Equals(moleculeCheckbox.GetType()))
                        {
                            moleculeCheckbox = molecule as CheckBox;
                        }
                        moleculeCheckbox.Checked = false;
                    }
                }
            }

            //----Clear dictionary and lists.
            receptors.Clear();
            receptorImages.Clear();
            receptorLigands.Clear();
            receptorNames.Clear();
            molecules.Clear();
            objects.Clear();
            factors.Clear();
            displayEvents.Clear();
            removeEvents.Clear();
            aliveMitosisEvents.Clear();
            
            //----Set objectID's to 0.
            receptorNumber = 0;
            arrowID = 0;
            plusPID = 0;
            minusPID = 0;

            //----Clear draw panels.
            cellWallDrawPanel.Controls.Clear();
            insideCellDrawPanel.Controls.Clear();
            factorsDrawPanel.Controls.Clear();

            //----Add cell wall to the panel.
            var cellWallStaticPanel = new Panel();
            cellWallStaticPanel.Name = "cell_wall";
            cellWallStaticPanel.Location = new Point(0, 33);
            cellWallStaticPanel.Size = new Size(966, 13);
            cellWallStaticPanel.BackgroundImage = Properties.Resources.cell_wall;
            cellWallStaticPanel.BackgroundImageLayout = ImageLayout.Stretch;
            cellWallDrawPanel.Controls.Add(cellWallStaticPanel);
            cellWallStaticPanel.Visible = true;
            
        }

        //Save simulation method.
        public void saveSimulation(string simulationName)
        {
            int aliveInfo = 0;
            int mitosisInfo = 0;

            SQLiteCommand command = new SQLiteCommand();

            //--Save receptors into SIMOBJECTS table.
            foreach (Panel panelControl in cellWallDrawPanel.Controls)
            {
                //----Skip cell_wall.
                if(!panelControl.Name.Equals("cell_wall") )
                {
                    //TypeField = 0 means "receptor".
                    string name = panelControl.Name.ToString();
                    int typeField = 0;
                    int sizeX = panelControl.Size.Width;
                    int sizeY = panelControl.Size.Height;
                    int locationX = panelControl.Location.X;
                    int locationY = panelControl.Location.Y;

                    //Set area variable according to the location of the object & number of receptors.
                    int area = 0;
                    if (receptorNumber == 1)
                    {
                        area = 1;
                    }
                    else if (receptorNumber == 2)
                    {
                        if (border1 <= locationX && border2 >= locationX)
                        {
                            area = 1;
                        }
                        else
                        {
                            area = 2;
                        }
                    }
                    else if (receptorNumber == 3)
                    {
                        if (border1 <= locationX && border2 >= locationX)
                        {
                            area = 1;
                        }
                        else if (border2 <= locationX && border3 >= locationX)
                        {
                            area = 2;
                        }
                        else
                        {
                            area = 3;
                        }
                    }
                    else if (receptorNumber == 4)
                    {
                        if (border1 <= locationX && border2 >= locationX)
                        {
                            area = 1;
                        }
                        else if (border2 <= locationX && border3 >= locationX)
                        {
                            area = 2;
                        }
                        else if (border3 <= locationX && border4 >= locationX)
                        {
                            area = 3;
                        }
                        else
                        {
                            area = 4;
                        }
                    }
                    Image bckImg = panelControl.BackgroundImage;

                    MemoryStream ms1 = new MemoryStream();
                    bckImg.Save(ms1, bckImg.RawFormat);
                    byte[] img = new byte[ms1.Length];
                    img = ms1.ToArray();

                    
                    command.CommandText = @"INSERT INTO SIMOBJECTS(NAME,SIMULATIONNAME,TYPE,SIZEX,SIZEY,LOCATIONX,LOCATIONY,AREA,IMAGE) VALUES ('" + name + "','" + simulationName + "','"
                        + typeField + "','" + sizeX + "','" + sizeY + "','" + locationX + "','" + locationY + "','" + area + "',@i)";
                    command.Parameters.AddWithValue("@i", img);
                    command.Connection = con;

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occured.(RECEPTORS)", "Error");
                    }
                }
                
            }
            
            //--Obtain alive information.
            if(!aliveNoRadioButton.Checked)
            {
                aliveInfo = 1;
            }

            //--Obtain mitosis information.
            if (!mitosisNoRadioButton.Checked)
            {
                mitosisInfo = 1;
            }

            //--Save ligands into SIMOBJECTS table.
            foreach (Panel panelControl in factorsDrawPanel.Controls)
            {
                //TypeField = 1 means ligand.
                string name = panelControl.Name.ToString();
                int typeField = 1;
                int sizeX = panelControl.Size.Width;
                int sizeY = panelControl.Size.Height;
                int locationX = panelControl.Location.X;
                int locationY = panelControl.Location.Y;

                //Set area variable according to the location of the object & number of receptors.
                int area = 0;
                if(receptorNumber == 1)
                {
                    area = 1;
                }
                else if(receptorNumber == 2)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }else
                    {
                        area = 2;
                    }
                }
                else if(receptorNumber == 3)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }
                    else if(border2 <= locationX && border3 >= locationX)
                    {
                        area = 2;
                    }else
                    {
                        area = 3;
                    }
                }
                else if(receptorNumber == 4)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }
                    else if (border2 <= locationX && border3 >= locationX)
                    {
                        area = 2;
                    }
                    else if(border3 <= locationX && border4 >= locationX)
                    {
                        area = 3;
                    }else
                    {
                        area = 4;
                    }
                }
                
                //Get image variable.
                Image bckImg = panelControl.BackgroundImage;
                MemoryStream ms1 = new MemoryStream();
                bckImg.Save(ms1, bckImg.RawFormat);
                byte[] img = new byte[ms1.Length];
                img = ms1.ToArray();

                command.CommandText = @"INSERT INTO SIMOBJECTS(NAME,SIMULATIONNAME,TYPE,SIZEX,SIZEY,LOCATIONX,LOCATIONY,AREA,IMAGE) VALUES ('" + name + "','" + simulationName + "','"
                    + typeField + "','" + sizeX + "','" + sizeY + "','" + locationX + "','" + locationY + "','" + area + "',@i)";
                command.Parameters.AddWithValue("@i", img);
                command.Connection = con;

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured.(LIGANDS)", "Error");
                }
            }

            //--Save objects into SIMOBJECTS table.
            foreach (Panel panelControl in insideCellDrawPanel.Controls)
            {
                //TypeField = 2 means objects inside cell.
                string name = panelControl.Name.ToString();
                int typeField = 2;
                int sizeX = panelControl.Size.Width;
                int sizeY = panelControl.Size.Height;
                int locationX = panelControl.Location.X;
                int locationY = panelControl.Location.Y;

                //Set area variable according to the location of the object & number of receptors.
                int area = 0;
                if (receptorNumber == 1)
                {
                    area = 1;
                }
                else if (receptorNumber == 2)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }
                    else
                    {
                        area = 2;
                    }
                }
                else if (receptorNumber == 3)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }
                    else if (border2 <= locationX && border3 >= locationX)
                    {
                        area = 2;
                    }
                    else
                    {
                        area = 3;
                    }
                }
                else if (receptorNumber == 4)
                {
                    if (border1 <= locationX && border2 >= locationX)
                    {
                        area = 1;
                    }
                    else if (border2 <= locationX && border3 >= locationX)
                    {
                        area = 2;
                    }
                    else if (border3 <= locationX && border4 >= locationX)
                    {
                        area = 3;
                    }
                    else
                    {
                        area = 4;
                    }
                }

                Image bckImg = panelControl.BackgroundImage;

                MemoryStream ms1 = new MemoryStream();
                bckImg.Save(ms1, bckImg.RawFormat);
                byte[] img = new byte[ms1.Length];
                img = ms1.ToArray();

                command.CommandText = @"INSERT INTO SIMOBJECTS(NAME,SIMULATIONNAME,TYPE,SIZEX,SIZEY,LOCATIONX,LOCATIONY,AREA,IMAGE) VALUES ('" + name + "','" + simulationName + "','"
                    + typeField + "','" + sizeX + "','" + sizeY + "','" + locationX + "','" + locationY + "','" + area + "',@i)";
                command.Parameters.AddWithValue("@i", img);
                command.Connection = con;

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured.(OBJECTS)", "Error");
                }
            }

            int eventCount = 0;
            //--Insert the events to SIMEVENTS table if exists.
            if(eventsList.Count != 0)
            {
                eventCount = eventsList.Count;

                //--For each event saved for this simulation.
                foreach (var kvp in eventsList)
                {
                    //--Obtain event information.
                    string molName = kvp.ToString();
                    string displayE = displayEvents[molName];
                    string removeE = removeEvents[molName];
                    string inhibateE = inhibateEvents[molName];
                    string aliveMito = aliveMitosisEvents[molName];

                    //--Save event information to SIMEVENTS table
                    command.CommandText = @"INSERT INTO SIMEVENTS(SIMULATIONNAME,MOLECULENAME,DISPLAYEVENTS,REMOVEEVENTS,INHIBATEEVENTS,ALIVEMITOSIS) VALUES ('" + simulationName +
                        "','" + molName + "','" + displayE + "','" + removeE + "','" + inhibateE + "','" + aliveMito + "')";
                    command.Connection = con;

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occured.(SIMEVENTS)", "Error");
                    }
                }
                 
            }else
            {
                eventCount = 0;
            }

            //--Insert obtained information to SIMULATIONS table.

            command.CommandText = @"INSERT INTO SIMULATIONS(SIMULATIONNAME,ALIVE,MITOSIS,AREACOUNT,EVENTCOUNT) VALUES (@s,@a,@m,@c,@e)";
            command.Parameters.AddWithValue("@s", simulationName);
            command.Parameters.AddWithValue("@a", aliveInfo);
            command.Parameters.AddWithValue("@m", mitosisInfo);
            command.Parameters.AddWithValue("@c", receptorNumber);
            command.Parameters.AddWithValue("@e", eventCount);
            command.Connection = con;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.(SIMULATION)", "Error");
            }
            MessageBox.Show("Simulation saved successfully.", "Message");
            this.Dispose();
        }

        //Open event definition window method.
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //--Get molecule name for assigning the event.
            string selectedMoleculeName = "";
            ToolStripItem item = (sender as ToolStripItem);
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                selectedMoleculeName = owner.SourceControl.Name.ToString();
            }

            //--Algorithm: Copy each object on the simulation to a new form.
            ArrayList ligandsArray = new ArrayList();
            ArrayList receptorsArray = new ArrayList();
            ArrayList objectsArray = new ArrayList();

            foreach (Control obj in factorsDrawPanel.Controls)
            {
                var tmpVar = new Panel();
                tmpVar.Name = obj.Name;
                tmpVar.Size = obj.Size;
                tmpVar.Location = obj.Location;
                tmpVar.BackgroundImage = obj.BackgroundImage;
                tmpVar.BackgroundImageLayout = obj.BackgroundImageLayout;
               
                ligandsArray.Add(tmpVar);
            }

            foreach (Control obj in cellWallDrawPanel.Controls)
            {
                var tmpVar = new Panel();
                tmpVar.Name = obj.Name;
                tmpVar.Size = obj.Size;
                tmpVar.Location = obj.Location;
                tmpVar.BackgroundImage = obj.BackgroundImage;
                tmpVar.BackgroundImageLayout = obj.BackgroundImageLayout;

                receptorsArray.Add(tmpVar);
            }

            foreach (Control obj in insideCellDrawPanel.Controls)
            {
                var tmpVar = new Panel();
                tmpVar.Name = obj.Name;
                tmpVar.Size = obj.Size;
                tmpVar.Location = obj.Location;
                tmpVar.BackgroundImage = obj.BackgroundImage;
                tmpVar.BackgroundImageLayout = obj.BackgroundImageLayout;

                objectsArray.Add(tmpVar);
            }

            //--Open DefineEventForm for event defining.
            DefineEventForm newWindow = new DefineEventForm(selectedMoleculeName,ligandsArray,receptorsArray,objectsArray);
            newWindow.Visible = true;
        }

        public void saveEvent(string moleculeName, string displayE, string removeE, string inhibateE, string aliveMitosis)
        {
            eventsList.Add(moleculeName);
            displayEvents.Add(moleculeName, displayE);
            removeEvents.Add(moleculeName, removeE);
            inhibateEvents.Add(moleculeName, inhibateE);
            aliveMitosisEvents.Add(moleculeName, aliveMitosis);
        }
    }
}
