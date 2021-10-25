using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class SimulationForm : Form
    {
        //Simulation information variables.
        public string simName = "";
        public int aliveI = 0;
        public int mitosisI = 0;

        //Dictionary & list variables for events.
        private ArrayList eventsList = new ArrayList();
        private ArrayList displayEventsList = new ArrayList();
        private Dictionary<string, bool> eventsActivated = new Dictionary<string, bool>();
        private Dictionary<string, string> displayEvents = new Dictionary<string, string>();
        private Dictionary<string, string> removeEvents = new Dictionary<string, string>();
        private Dictionary<string, string> inhibateEvents = new Dictionary<string, string>();
        private Dictionary<string, string> aliveMitosisEvents = new Dictionary<string, string>();

        //Variables for areas.
        private Dictionary<string, int> ligandsAreas = new Dictionary<string, int>();
        
        bool area1Activated = false;
        bool area2Activated = false;
        bool area3Activated = false;
        bool area4Activated = false;

        //Variable for play button.
        private bool simulationPlayed = false;

        //Variables for animations.
        private Panel tmpPanel;
        private int startingX;
        private int finishingX;

        static bool exitFlag = false;

        //Variables for events and areas.
        private int areaNumber = 0;
        private int eventNumber = 0;

        //Variable for connection.
        SQLiteConnection con = new SQLiteConnection(@"Data Source=Database.db");

        //Constructor method.
        public SimulationForm(string simulationName, int aliveInfo, int mitosisInfo, int areaCount, int eventCount)
        {
            InitializeComponent();

            //Assign variables.
            simName = simulationName;
            aliveI = aliveInfo;
            mitosisI = mitosisInfo;
            areaNumber = areaCount;
            eventNumber = eventCount;

            prepareSim(simulationName, aliveInfo, mitosisInfo);
        }

        //Prepare simulation method.
        private void prepareSim(string simulationName, int aliveInfo, int mitosisInfo)
        {
            //--Set simulation name.
            var nameLabel = new Label();
            nameLabel.Name = simulationName + "Label";
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.Text = simulationName;
            nameLabel.Location = new Point(0, 0);
            simulationMainPanel.Controls.Add(nameLabel);
            nameLabel.Visible = true;
            nameLabel.AutoSize = true;
            nameLabel.BringToFront();

            //--Set alive/mitosis informations.
            cellStatusLabel.Visible = false;
            mitosisLabel.Visible = false;

            if (aliveInfo == 0)
            {
                setNotAlive();
            }
            else
            {
                setAlive();
            }
            if (mitosisInfo == 0 || aliveInfo == 0)
            {
                setNoMitosis();
            }
            else
            {
                setMitosis();
            }

            //--Draw static cell wall panel.
            drawCellWall();

            //--Draw receptors onto cell wall.
            //--Set areas according to the area count.
            drawReceptors(simulationName);

            //--Fill listboxes.
            fillLigandsList(simulationName);
            fillMoleculesList(simulationName);
        }

        /************************************************/

        /*Alive & Mitosis setters.*/

        private void setAlive()
        {
            aliveInfoLabel.Text = "ALIVE";
            aliveInfoPictureBox.Image = Properties.Resources.alive;
            aliveInfoPictureBox.BackColor = Color.FromArgb(0, 192, 0);
            aliveInfoLabel.Visible = false;
            aliveInfoPictureBox.Visible = false;
        }

        private void setNotAlive()
        {
            aliveInfoLabel.Text = "DEAD";
            aliveInfoPictureBox.Image = Properties.Resources.dead;
            aliveInfoPictureBox.BackColor = Color.Maroon;
            aliveInfoLabel.Visible = false;
            aliveInfoPictureBox.Visible = false;
        }

        private void setMitosis()
        {
            mitosisInfoLabel.Text = "MITOSIS";
            mitosisInfoPictureBox.Image = Properties.Resources.mitosis; //mitosis.
            mitosisInfoPictureBox.BackColor = Color.FromArgb(0, 192, 0);
            mitosisInfoLabel.Visible = false;
            mitosisInfoPictureBox.Visible = false;
        }

        private void setNoMitosis()
        {
            mitosisInfoLabel.Text = "NO MITOSIS";
            mitosisInfoPictureBox.Image = Properties.Resources.nomitosis; // no mitosis.
            mitosisInfoPictureBox.BackColor = Color.Gray;
            mitosisInfoLabel.Visible = false;
            mitosisInfoPictureBox.Visible = false;
        }
        /************************************************/


        //Show alive/mitosis method.
        private void showAliveMitosis()
        {
            //--Show panels using BUNIFU transformation.
            cellStatusLabel.Visible = true;
            mitosisLabel.Visible = true;

            aliveInfoPanel.BackColor = aliveInfoPictureBox.BackColor;
            aliveInfoLabel.Visible = true;
            aliveInfoPictureBox.Visible = true;
            mitosisInfoPanel.BackColor = mitosisInfoPictureBox.BackColor;
            mitosisInfoLabel.Visible = true;
            mitosisInfoPictureBox.Visible = true;

            aliveInfoPanel.Visible = false;
            mitosisInfoPanel.Visible = false;
            aliveMitosisTransition.Show(aliveInfoPanel);
            aliveMitosisTransition.Show(mitosisInfoPanel);
        }
        /************************************************/

        /*Draw Methods*/

        //Draw cell wall method.
        private void drawCellWall()
        {
            var cellWallStaticPanel = new Panel();
            cellWallStaticPanel.Name = "cell_wall";
            cellWallStaticPanel.Location = new Point(0, 33);
            cellWallStaticPanel.Size = new Size(1249, 13);
            cellWallStaticPanel.BackgroundImage = Properties.Resources.cell_wall;
            cellWallStaticPanel.BackgroundImageLayout = ImageLayout.Stretch;
            cellWallDrawPanel.Controls.Add(cellWallStaticPanel);
            cellWallStaticPanel.Visible = true;
        }

        //Draw receptors method.
        private void drawReceptors(string simulationName)
        {
            //Read receptors from database.
            //TYPE = 0 means receptor.

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMOBJECTS WHERE SIMULATIONNAME='" + simulationName + "' AND TYPE='0'";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    //--Obtain size and coordinates from database.
                    int sizeX = Convert.ToInt32(dbr["SIZEX"]);
                    int sizeY = Convert.ToInt32(dbr["SIZEY"]);
                    int locX = Convert.ToInt32(dbr["LOCATIONX"]);
                    int locY = Convert.ToInt32(dbr["LOCATIONY"]);
                    byte[] imgAsByte = (byte[])dbr["IMAGE"];
                    MemoryStream ms1 = new MemoryStream(imgAsByte);
                    ms1.Seek(0, SeekOrigin.Begin);

                    //--Create a new "panel" object and draw it.
                    var newReceptor = new Panel();
                    newReceptor.Location = new Point(locX, locY);
                    newReceptor.Size = new Size(sizeX, sizeY);
                    newReceptor.BackgroundImage = Image.FromStream(ms1);
                    newReceptor.BackgroundImageLayout = ImageLayout.Stretch;
                    cellWallDrawPanel.Controls.Add(newReceptor);
                    newReceptor.Visible = true;
                    newReceptor.BringToFront();
                }
                dbr.Close();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An exception occured.(DRAW_RECEPTORS)", "Error");
            }
        }

        //Draw ligands method.
        private void drawLigands(string simulationName)
        {
            //Read ligands from database. Draw it on the simulation panel.
            //TYPE = 1 means ligand.

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMOBJECTS WHERE SIMULATIONNAME='" + simulationName + "' AND TYPE='1' ORDER BY OBJECTID DESC";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {                    
                    //--Obtain size, coordinates and area information from database.
                    int sizeX = Convert.ToInt32(dbr["SIZEX"]);
                    int sizeY = Convert.ToInt32(dbr["SIZEY"]);
                    int locX = Convert.ToInt32(dbr["LOCATIONX"]);
                    int locY = Convert.ToInt32(dbr["LOCATIONY"]);
                    int area = Convert.ToInt32(dbr["AREA"]);
                    byte[] imgAsByte = (byte[])dbr["IMAGE"];
                    MemoryStream ms1 = new MemoryStream(imgAsByte);
                    ms1.Seek(0, SeekOrigin.Begin);

                    //--Check if area is activated. If not do not draw.
                    if (area == 1)
                    {
                        if(!area1Activated)
                        {
                            continue;
                        }
                    }
                    else if (area == 2)
                    {
                        if (!area2Activated)
                        {
                            continue;
                        }
                    }
                    else if (area == 3)
                    {
                        if (!area3Activated)
                        {
                            continue;
                        }
                    }
                    else if (area == 4)
                    {
                        if (!area4Activated)
                        {
                            continue;
                        }
                    }

                    //--Create a new "panel" object at location (50, locY).
                    var newLigand = new Panel();
                    newLigand.Location = new Point(50, locY);
                    newLigand.Size = new Size(sizeX, sizeY);
                    newLigand.BackgroundImage = Image.FromStream(ms1);
                    newLigand.BackgroundImageLayout = ImageLayout.Zoom;
                    ligandsDrawPanel.Controls.Add(newLigand);
                    newLigand.Visible = false;

                    //--Draw it using "BUNIFU transformaiton". (Animation)
                    createPanelTransition.ShowSync(newLigand);

                    //--Calculate difference in order speed up the animation.
                    int difference = locX % 5;
                    
                    //--Assign variables for animation timer.
                    tmpPanel = newLigand;
                    startingX = 50 + difference;
                    finishingX = locX;

                    //--Animation timer flag.
                    exitFlag = false;

                    //--Start timer and also the animation. Wait until the timer finishes.
                    movementTimer.Enabled = true;
                    while (exitFlag == false)
                    {
                        Application.DoEvents();
                    }

                }
                dbr.Close();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An exception occured.(DRAW_LIGANDS)","Error");
            }
        }

        //Draw objects method.
        private void drawObjects(string simulationName)
        {
            //Draw each object according to the each area.
            for (int area = 1; area <= areaNumber; area++)
            {
                //--Check if area is activated.
                if (area == 1)
                {
                    if (!area1Activated)
                    {
                        continue;
                    }
                }
                else if (area == 2)
                {
                    if (!area2Activated)
                    {
                        continue;
                    }
                }
                else if (area == 3)
                {
                    if (!area3Activated)
                    {
                        continue;
                    }
                }
                else if (area == 4)
                {
                    if (!area4Activated)
                    {
                        continue;
                    }
                }

                //Read objects from database. where area = index.
                //TYPE = 2 means "object"
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = @"SELECT * from SIMOBJECTS WHERE SIMULATIONNAME='" + simulationName + "' AND TYPE='2' AND AREA='" + area + "' ORDER BY OBJECTID DESC";
                command.Connection = con;
                try
                {
                    con.Open();
                    SQLiteDataReader dbr = command.ExecuteReader();
                    while (dbr.Read())
                    {
                        //--Obtain name from database.
                        string objName = (string)dbr["NAME"];

                        //--Obtain size and coordinates information from database.
                        int sizeX = Convert.ToInt32(dbr["SIZEX"]);
                        int sizeY = Convert.ToInt32(dbr["SIZEY"]);
                        int locX = Convert.ToInt32(dbr["LOCATIONX"]);
                        int locY = Convert.ToInt32(dbr["LOCATIONY"]);
                        byte[] imgAsByte = (byte[])dbr["IMAGE"];
                        MemoryStream ms1 = new MemoryStream(imgAsByte);
                        ms1.Seek(0, SeekOrigin.Begin);

                        //--Create a new "panel" object.
                        var newObject = new Panel();
                        newObject.Name = objName;
                        newObject.Location = new Point(locX, locY);
                        newObject.Size = new Size(sizeX, sizeY);
                        newObject.BackgroundImage = Image.FromStream(ms1);
                        newObject.BackgroundImageLayout = ImageLayout.Stretch;
                        insideCellDrawPanel.Controls.Add(newObject);
                        newObject.Visible = false;
                        newObject.BringToFront();

                        //--If object has event or displayed in an event, do not draw it.
                        if (eventsList.Contains(objName) || displayEventsList.Contains(objName))
                        {
                            continue;
                        }else
                        {
                            //--Draw it using "BUNIFU transformaiton". (Animation)
                            createPanelTransition.ShowSync(newObject);
                        }
                    }
                    dbr.Close();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An exception occured.(DRAW_OBJECTS)", "Error");
                }
            }
            
        }

        /*******************************************************/

        /*Button Methods*/
        //Play button method.
        private void playButtonMethod(object sender, EventArgs e)
        {
            //--Error checking: At least one ligand must be selected.
            bool errorCheck = false;
            foreach (Control ct in ligandsFlowLayoutPanel.Controls)
            {
                CheckBox tmp = ct as CheckBox;
                if (tmp.Checked)
                {
                    errorCheck = true;
                    break;
                }
            }
            if(!errorCheck)
            {
                return;
            }

            //--Error checking: If simulation already played do nothing.
            if (simulationPlayed == false)
            {
                string simulationName = simName;
                drawLigands(simulationName);
                drawObjects(simulationName);
                evaluateEvents();
                showAliveMitosis();
                playButton.BackColor = Color.Gray;
                playButton.Enabled = false;
                simulationPlayed = true;
            }
            else
            {
                return;
            }
        }

        //Restart button method.
        private void restartButtonMethod(object sender, EventArgs e)
        {
            area1Activated = false;
            area2Activated = false;
            area3Activated = false;
            area4Activated = false;

            //Clear panels.
            cellWallDrawPanel.Controls.Clear();
            ligandsDrawPanel.Controls.Clear();
            insideCellDrawPanel.Controls.Clear();

            //Reset alive&mitosis panels.
            cellStatusLabel.Visible = false;
            mitosisLabel.Visible = false;
            aliveInfoLabel.Visible = false;
            aliveInfoPictureBox.Visible = false;
            mitosisInfoLabel.Visible = false;
            mitosisInfoPictureBox.Visible = false;

            aliveInfoPanel.BackColor = Color.SteelBlue;
            mitosisInfoPanel.BackColor = Color.SteelBlue;

            prepareSim(simName, aliveI, mitosisI);

            //Ready the simulation for play button.
            simulationPlayed = false;
            playButton.BackColor = Color.Purple;
            playButton.Enabled = true;

        }

        //Timer method for movement animation.
        private void movementTimer_Tick(object sender, EventArgs e)
        {
            if (startingX < finishingX)
            {
                tmpPanel.Location = new Point(tmpPanel.Location.X + 5, tmpPanel.Location.Y);
                startingX = tmpPanel.Location.X;
            }
            else
            {
                movementTimer.Enabled = false;
                exitFlag = true;
            }
        }

        /************************************************/
        
        /*List filling methods*/
        
        public void fillLigandsList(string simulationName)
        {
            ligandsFlowLayoutPanel.Controls.Clear();
            ligandsAreas.Clear();

            //Read ligands from database.
            //TYPE = 1 means ligand.

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMOBJECTS WHERE SIMULATIONNAME='" + simulationName + "' AND TYPE='1'";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string ligandName = (string)dbr["NAME"];
                    int area = Convert.ToInt32(dbr["AREA"]);

                    //--Add ligand to dictionary.
                    ligandsAreas.Add(ligandName, area);

                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = ligandName;
                    newCheckBox.Checked = false;
                    newCheckBox.ForeColor = Color.White;
                    newCheckBox.CheckedChanged += new EventHandler(ligandChecked);
                    ligandsFlowLayoutPanel.Controls.Add(newCheckBox);

                }
                dbr.Close();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An exception occured.(FILL_LIGANDS)", "Error");
            }
        }

        private void fillMoleculesList(string simulationName)
        {
            moleculesFlowLayoutPanel.Controls.Clear();
            eventsList.Clear();
            eventsActivated.Clear();
            displayEvents.Clear();
            inhibateEvents.Clear();
            removeEvents.Clear();
            aliveMitosisEvents.Clear();

            //Read events from database.
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = @"SELECT * from SIMEVENTS WHERE SIMULATIONNAME='" + simulationName + "'";
            command.Connection = con;

            try
            {
                con.Open();
                SQLiteDataReader dbr = command.ExecuteReader();
                while (dbr.Read())
                {
                    string moleculeName = (string)dbr["MOLECULENAME"];
                    string displayE = (string)dbr["DISPLAYEVENTS"];
                    string removeE = (string)dbr["REMOVEEVENTS"];
                    string inhibateE = (string)dbr["INHIBATEEVENTS"];
                    string aliveMito = (string)dbr["ALIVEMITOSIS"];

                    eventsList.Add(moleculeName);
                    eventsActivated.Add(moleculeName, false);
                    displayEvents.Add(moleculeName, displayE);
                    removeEvents.Add(moleculeName, removeE);
                    inhibateEvents.Add(moleculeName, inhibateE);
                    aliveMitosisEvents.Add(moleculeName, aliveMito);

                    //--Get object names inside display events and add object names to displayEventsList.
                    string[] substrings = displayE.Split(new Char[] { '*' });
                    foreach (string s in substrings)
                    {
                        if (s.Trim() != "")
                        {
                            displayEventsList.Add(s);
                        }
                    }

                    var newCheckBox = new CheckBox();
                    newCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newCheckBox.Text = moleculeName;
                    newCheckBox.Checked = false;
                    newCheckBox.ForeColor = Color.White;
                    newCheckBox.CheckedChanged += new EventHandler(moleculeChecked);
                    moleculesFlowLayoutPanel.Controls.Add(newCheckBox);

                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An exception occured.(FILL_MOLECULES)", "Error");
            }
        }

        /************************************************/

        /*Checkbox methods*/
        private void ligandChecked(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if(obj.Checked)
            {
                string ligandName = obj.Text.ToString();

                int area = ligandsAreas[ligandName];

                if (area == 1)
                {
                    area1Activated = true;
                }
                else if (area == 2)
                {
                    area2Activated = true;
                }
                else if (area == 3)
                {
                    area3Activated = true;
                }
                else if (area == 4)
                {
                    area4Activated = true;
                }
            }
            else
            {
                string ligandName = obj.Text.ToString();

                int area = ligandsAreas[ligandName];

                if (area == 1)
                {
                    area1Activated = false;
                }
                else if (area == 2)
                {
                    area2Activated = false;
                }
                else if (area == 3)
                {
                    area3Activated = false;
                }
                else if (area == 4)
                {
                    area4Activated = false;
                }
            }
            
        }

        private void moleculeChecked(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            string moleculeName = obj.Text.ToString();

            if (obj.Checked)
            {
                eventsActivated[moleculeName] = true;
            }else
            {
                eventsActivated[moleculeName] = false;
            }

        }

        /************************************************/

        //Evaluate events method.
        private void evaluateEvents()
        {
            //Algorithm: 
            //-- For each event in eventlist
            //---- Display each object inside the displayEvents list.
            //---- Remove each object inside removeEvents list.
            //---- Evaluate inhibators inside inhibateEvents list.
            //-- evaluate alive mitosis status.
            foreach (string mol in eventsList)
            {
                if (eventsActivated[mol])
                {
                    //--Obtain displayList, removeList, inhibateList,alive&mitosis information.
                    string displayList = displayEvents[mol];
                    string removeList = removeEvents[mol];
                    string inhibateList = inhibateEvents[mol];
                    string aliveAndMitosis = aliveMitosisEvents[mol];

                    //--Show molecule which has event.
                    foreach (Control tmpObj in insideCellDrawPanel.Controls)
                    {
                        if (tmpObj.Name.Equals(mol))
                        {
                            createPanelTransition.ShowSync(tmpObj);
                            break;
                        }
                    }

                    //--Get object names inside display events.
                    string[] substrings = displayList.Split(new Char[] { '*' });

                    //--For each name in display event list, find the object from the panel and show.
                    foreach (string s in substrings)
                    {
                        eventsDisplay(s);
                    }

                    //--Get object names inside remove events.
                    substrings = removeList.Split(new Char[] { '*' });

                    //--For each name in remove event list, find the object from the drawPanel and remove.
                    foreach (string s in substrings)
                    {
                        eventsRemove(s);
                    }

                    //--Get object names inside inhibate events.
                    substrings = inhibateList.Split(new char[] { '*' });

                    //--For each name inside inhibate events, call evaluateInhibators method.
                    foreach (string inMolName in substrings)
                    {
                        evaluateInhibators(inMolName);
                    }

                    //--Evaluate alive & mitosis status.
                    substrings = aliveAndMitosis.Split(new char[] { '*' });

                    if (substrings[0].Equals("1"))
                    {
                        setAlive();
                        if (substrings[1].Equals("1"))
                        {
                            setMitosis();
                        }
                        else
                        {
                            setNoMitosis();
                        }
                    }
                    else
                    {
                        setNotAlive();
                        setNoMitosis();
                    }
                }
            }
        }
        /************************************************/

        //Display, remove, inhibate event methods.
        
        //Display event method.
        //--Algorithm:
        //--Find the object which has name as 'objectName'.
        //--Display the object using BUNIFU transform.
        private void eventsDisplay(string objectName)
        {
            if (objectName.Trim() != "")
            {
                foreach (Control tmpObj in insideCellDrawPanel.Controls)
                {
                    if (tmpObj.Name.Equals(objectName))
                    {
                        createPanelTransition.ShowSync(tmpObj);
                        break;
                    }
                }
            }
        }

        //Remove event method.
        //--Algorithm:
        //--Find the object which has name as 'objectName'.
        //--Remove the object using BUNIFU transform.
        private void eventsRemove(string objectName)
        {
            if (objectName.Trim() != "")
            {
                foreach (Control tmpObj in insideCellDrawPanel.Controls)
                {
                    if (tmpObj.Name.Equals(objectName))
                    {
                        createPanelTransition.HideSync(tmpObj);
                        break;
                    }
                }
            }
        }
        //Evaluate inhibators event method.
        //--Algorithm:
        //--Find the display events of the 'molName'. Then call remove method for each object inside display events.
        //--Find the remove events of the 'molName'. Then call display method for each object inside remove events.
        //--Find the inhibator events of the 'molName'. Then call evaluateInhibators recursively for each event inside inhibator events.
        private void evaluateInhibators(string molName)
        {
            if (molName.Trim() != "")
            {
                if (eventsActivated[molName])
                {
                    string inDisplayList = displayEvents[molName];
                    string inRemoveList = removeEvents[molName];
                    string inInhibatorList = inhibateEvents[molName];

                    //--For each name in display event list call remove events.
                    string[] inSubstrings = inDisplayList.Split(new Char[] { '*' });
                    foreach (string s in inSubstrings)
                    {
                        eventsRemove(s);
                    }

                    //--For each name in remove event list call display events.
                    inSubstrings = inRemoveList.Split(new char[] { '*' });
                    foreach(string s in inSubstrings)
                    {
                        eventsDisplay(s);
                    }

                    //--For each name inside inhibate events, call evaluateInhibators method.
                    inSubstrings = inInhibatorList.Split(new char[] { '*' });
                    foreach (string inMolName in inSubstrings)
                    {
                        evaluateInhibators(inMolName);
                    }
                }
            }
        }
    }
}
