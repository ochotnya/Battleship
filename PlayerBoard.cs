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
    public partial class PlayerBoard : UserControl
    {
        private int spaceBetweenFields = 5;
        private int fieldHeight = 40;
        private int fieldWidth = 40;

        public PlayerBoard()
        {
            InitializeComponent();
            int x = spaceBetweenFields, y = spaceBetweenFields;
            for (char i = 'A'; i < 'K'; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Field newField = new Field(k, i);
                    
                    newField.Width = fieldWidth;
                    newField.Height = fieldHeight;
                    newField.BackColor = Color.YellowGreen;
                    newField.Location = new Point(x,y);

                    panelMain.Controls.Add(newField);

                    x += spaceBetweenFields+fieldWidth;
                }
                x = spaceBetweenFields;
                y += spaceBetweenFields+fieldHeight;
            }
            this.Width = (spaceBetweenFields + fieldWidth) * 10 + spaceBetweenFields;
            this.Height = (spaceBetweenFields + fieldHeight) * 10 + spaceBetweenFields;
        }
        
    }
}
