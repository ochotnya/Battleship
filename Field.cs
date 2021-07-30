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
        public char Y { get; private set; }
        public int X { get; private set; }
        private FieldState state = FieldState.Free;
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

        public void SetBoat(Color boatColor)
        {
            state = FieldState.Boat;
            this.BackColor = boatColor;
            this.ForeColor = Color.White;
        }

        public bool isFree()
        {
            return state == FieldState.Free;
        }

    }
}
