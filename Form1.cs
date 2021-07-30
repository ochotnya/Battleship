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
            RefreshBoards();
        }

        private void RefreshBoards()
        {
            panelBoards.Controls.Clear();
            PlayerBoard board1 = new PlayerBoard();
            PlayerBoard board2 = new PlayerBoard();
            board1.Location = new Point(5, 5);
            board2.Location = new Point(board1.Location.X + board1.Width + 20, 5);
            panelBoards.Controls.Add(board1);
            panelBoards.Controls.Add(board2);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBoards();
        }
    }
    public enum FieldState
    {
        Free,
        Boat,
        Hit
    }

}
