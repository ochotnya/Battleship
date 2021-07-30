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
    public partial class Field : UserControl
    {
        private char Y;
        private int X;
        public Field(int x, char y)
        {
            InitializeComponent();
            SetCoords(x, y);
        }

        public void SetCoords(int x, char y)
        {
            Y = y;
            X = x;
            labelCoords.Text = Y + X.ToString();
        }
    }
}
