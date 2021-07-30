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
            for (char c = 'A'; c < 'K'; c++)
            {
                dgvPlayer1Map.Rows.Add();
                dgvPlayer1Map.Rows[dgvPlayer1Map.Rows.Count - 1].HeaderCell.Value = c;
            }
            dgvPlayer1Map.RowHeadersWidth = 45;
            dgvPlayer1Map.RowTemplate.Height = 45;
        }
    }
}
