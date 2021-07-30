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
        private Random randomGenerator = new Random();
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

        private void Fire(PlayerBoard target)
        {
            //generate location
            char Y = Convert.ToChar(randomGenerator.Next(Convert.ToInt32('A'), Convert.ToInt32('K')));
            int X = randomGenerator.Next(0, 10);
            target.CheckHit(X, Y);
        }
        private void btnP1Fire_Click(object sender, EventArgs e)
        {
            Fire((PlayerBoard)panelBoards.Controls[0]);
        }
    }
    public enum FieldState
    {
        Free,
        Boat,
        Hit
    }

}
