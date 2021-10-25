using System;
using System.Collections;
using System.Windows.Forms;

/*
 * Berk KARAMAN - 2020
 */

namespace Simulator_Of_Mechanisms_Of_Toxicity
{
    public partial class DefineEventForm : Form
    {
        private string eventMoleculeName = "";
        private string eventListDisplay = "";
        private string eventListRemove = "";
        private string eventListInhibate = "";
        private int aliveInfo = 0;
        private int mitosisInfo = 0;

        public DefineEventForm(string moleculeName, ArrayList ligandControls, ArrayList receptorControls, ArrayList objectControls)
        {
            InitializeComponent();
            //Place simulation objects.
            foreach (Control obj in ligandControls)
            {
                ligandsDrawPanel.Controls.Add(obj);
            }

            foreach (Control obj in receptorControls)
            {
                cellWallDrawPanel.Controls.Add(obj);
            }

            foreach (Control obj in objectControls)
            {
                insideCellDrawPanel.Controls.Add(obj);
            }

            //Assign name variable. Change information label.
            eventMoleculeName = moleculeName;
            informationLabel.Text = "Use right click to define if an object should displayed or removed " +
                "when \n'" + moleculeName + "' exist in the simulation.";

            //Assign contextMenu to each object inside cell.
            foreach (Control obj in insideCellDrawPanel.Controls)
            {
                obj.ContextMenuStrip = displayNotDisplayMenu;
            }

        }

        private void displayMethod(object sender, EventArgs e)
        {
            //Get selected object name.
            string selectedObjectName = "";
            ToolStripItem item = (sender as ToolStripItem);
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                selectedObjectName = owner.SourceControl.Name.ToString();
            }

            //Add object to display object string. Seperate each name with "*".
            eventListDisplay = eventListDisplay + selectedObjectName + "*";

        }

        private void removeMethod(object sender, EventArgs e)
        {
            //Get selected object name.
            string selectedObjectName = "";
            ToolStripItem item = (sender as ToolStripItem);
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                selectedObjectName = owner.SourceControl.Name.ToString();
            }

            //Add object to remove object string. Seperate each name with "*".
            eventListRemove = eventListRemove + selectedObjectName + "*";
        }

        private void finishMethod(object sender, EventArgs e)
        {
            //--Obtain alive information.
            if (!aliveNoRadioButton.Checked)
            {
                aliveInfo = 1;
            }

            //--Obtain mitosis information.
            if (!mitosisNoRadioButton.Checked)
            {
                mitosisInfo = 1;
            }

            string aliveMitosis = aliveInfo.ToString() + "*" + mitosisInfo.ToString();

            //--Error checking: If no display selected.
            if(eventListDisplay.Equals(""))
            {
                eventListDisplay = "EMPTY";
            }
            //--Error checking: If no remove selected.
            if (eventListRemove.Equals(""))
            {
                eventListRemove = "EMPTY";
            }
            //--Error checking: If no inhibate selected.
            if (eventListRemove.Equals(""))
            {
                eventListInhibate = "EMPTY";
            }

            if (Application.OpenForms["Form2"] != null)
            {
                (Application.OpenForms["Form2"] as Form2).saveEvent(eventMoleculeName, eventListDisplay, eventListRemove, eventListInhibate, aliveMitosis);
            }

            this.Dispose();
        }

        private void inhibateMethod(object sender, EventArgs e)
        {
            //Get selected object name.
            string selectedObjectName = "";
            ToolStripItem item = (sender as ToolStripItem);
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                selectedObjectName = owner.SourceControl.Name.ToString();
            }

            //Add object to inhibate object string. Seperate each name with "*".
            eventListInhibate = eventListInhibate + selectedObjectName + "*";
        }
    }
}
