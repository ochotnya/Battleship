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
        private Random randomGenerator = new Random();
        public PlayerBoard()
        {
            InitializeComponent();
            DrawBoard();
            PlaceBoat(5, Color.Black);
            PlaceBoat(4, Color.DarkGreen);
            PlaceBoat(3, Color.DarkOrange);
            PlaceBoat(3, Color.Brown);
            PlaceBoat(2, Color.Navy);
        }

        private void DrawBoard()
        {
            int x = spaceBetweenFields, y = spaceBetweenFields;
            for (char i = 'A'; i < 'K'; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Field newField = new Field(k, i);

                    newField.Width = fieldWidth;
                    newField.Height = fieldHeight;
                    newField.BackColor = Color.YellowGreen;
                    newField.Location = new Point(x, y);

                    panelMain.Controls.Add(newField);

                    x += spaceBetweenFields + fieldWidth;
                }
                x = spaceBetweenFields;
                y += spaceBetweenFields + fieldHeight;
            }
            this.Width = (spaceBetweenFields + fieldWidth) * 10 + spaceBetweenFields;
            this.Height = (spaceBetweenFields + fieldHeight) * 10 + spaceBetweenFields;
        }

        private Field GetField(int X, char Y)
        {
            ControlCollection fieldList = panelMain.Controls;
            foreach (Field field in fieldList)
            {
                if (field.X == X && field.Y == Y) return field;
            }
            return null;
        }

        private bool CheckIfBoatFits(int size, int X, char Y, bool orientation)
        {
            for (int i = 0; i < size; i++)
            {
                Field tempField = GetField(X, Y);
                if (!tempField.isFree()) return false;
                if (orientation) Y++;
                else X++;                
            }
            return true;
        }
        private void PlaceBoat(int size, Color boatColor)
        {
            
            bool orientation = randomGenerator.Next(2) == 0; //0 - horizontal, 1 - vertical
            char maxY='J';
            int maxX=9;

            //define max start positions
            if(orientation) maxY = Convert.ToChar(Convert.ToInt32('J') - size);
            else maxX = 9 - size;

            //find and check if field is available
            char Y = 'A';
            int X = 0;
            bool stopChecking = false;
            while (!stopChecking)
            {
                //generate location
                Y = Convert.ToChar(randomGenerator.Next(Convert.ToInt32('A'), Convert.ToInt32(maxY)));
                X = randomGenerator.Next(0, maxX);
                stopChecking=CheckIfBoatFits(size, X, Y, orientation);
            }
            
            //set boat on fields
            Field tempField;
            for (int i = 0; i < size; i++)
            {
                tempField = GetField(X, Y);
                tempField.SetBoat(boatColor);
                if (orientation) Y++;
                else X++;
            }

        }
        
    }
}
