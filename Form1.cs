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
        Player player1 = new Player();
        Player player2 = new Player();
        public Form1()
        {
            InitializeComponent();
            player1.Reset();
            player2.Reset();
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
            player1.Reset();
            player2.Reset();
            RefreshBoards();
        }
        
        
        private void btnP1Fire_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FieldData target = player1.Shot((PlayerBoard)panelBoards.Controls[1]);
            richTextBox1.Text += target.X.ToString() + target.Y + "\n";
            if (player1.RemainingMoves() == 0) timer.Enabled = false;
        }
    }
    public enum FieldState
    {
        Free,
        Boat,
        Hit
    }
    public struct FieldData
    {
        public char Y;
        public int X;
        public FieldState state;
    }

}
