using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelBoards.Controls.Add(new PlayerBoard());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
    public enum FieldState
    {
        Free,
        Boat,
        Hit
    }

}
