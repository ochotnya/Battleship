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
        Player player1;
        Player player2;
        private int maxScore = 17;
        private int turn = 1;
        public Form1()
        {
            InitializeComponent();
            player1 = new Player(randomGenerator);
            player2 = new Player(randomGenerator);
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
            player1.Reset();
            player2.Reset();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            RefreshBoards();
            btnManual.Enabled = true;
            btnStart.Enabled = true;
        }

        private void UpdateStatusBox(string text)
        {
            statusBox.Text += text;
            statusBox.SelectionStart = statusBox.Text.Length;
            statusBox.ScrollToCaret();
        }
        
        //set active player, execute game logic and switch player for next round
        private void timer_Tick(object sender, EventArgs e)
        {
            Player activePlayer = turn == 1 ? player1 : player2;
            PlayerBoard targetBoard = turn == 1 ? (PlayerBoard)panelBoards.Controls[1] : (PlayerBoard)panelBoards.Controls[0];
            FieldData target = activePlayer.Shot(targetBoard);
            UpdateStatusBox("Player " + turn.ToString() +" fires at " + target.Y + target.X.ToString() + "\n");
            
            if (activePlayer.RemainingMoves() == 0) timer.Enabled = false; 
            if(activePlayer.GetScore() == maxScore)
            {
                UpdateStatusBox("Player " + turn.ToString() + " wins in " + activePlayer.GetMovesCount().ToString() + " moves" + "\n");
                timer.Enabled = false;
                btnRefresh.Enabled = true;
            }
            turn = turn == 1 ? 2 : 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnStart.Enabled = false;
            btnManual.Enabled = false;
            timer.Enabled = true;
        }


        private void btnManual_Click(object sender, EventArgs e)
        {
            player1.Shot((PlayerBoard)panelBoards.Controls[1]);
            btnStart.Enabled = false;
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
        public static bool operator ==(FieldData c1, FieldData c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(FieldData c1, FieldData c2)
        {
            return !c1.Equals(c2);
        }
    }

}
