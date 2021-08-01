using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Battleship
{
    public class Player
    {
        private Random randomGenerator = new Random();
        private bool attackingBoat = false;
        private Orientation targetOrientation=Orientation.Undefined; //0 - horizontal, 1 - vertical, 2 - undefined
        private List<FieldData> usedTargets = new List<FieldData>();
        private List<FieldData> availableMoves = new List<FieldData>();
        private FieldData attackCenter = new FieldData();
        public int score = 0;
        private int maxScore = 20;

        private enum Orientation
        {
            Horizontal,
            Vertical,
            Undefined
        }
        public void Reset()
        {
            usedTargets.Clear();
            attackingBoat = false;
            score = 0;
            maxScore = 20;
            GenerateMovesList();
            attackCenter.X = -1;
        }
        public void SetMaxScore(int max)
        {
            maxScore = max;
        }

        private void GenerateMovesList()
        {
            for (char i = 'A'; i < 'K'; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    FieldData move = new FieldData();
                    move.X = k;
                    move.Y = i;
                    availableMoves.Add(move);
                }
            }
        }
        private void Fire(PlayerBoard targetBoard, FieldData targetField)
        {
            if (targetBoard.CheckHit(targetField.X, targetField.Y))
            {
                targetField.state = FieldState.Hit;
                score++;
                attackingBoat = true;
                attackCenter = targetField;
            }
            else
            {
                targetField.state = FieldState.Free;
                attackingBoat = false;
            }
            usedTargets.Add(targetField);
        }

        public FieldData Shot(PlayerBoard targetBoard)
        {
            FieldData target = new FieldData();
            if(availableMoves.Count>0) target = GenerateNewTarget();
            else
            {
                MessageBox.Show("Sorry, I tried everything");
                return target;
            }

            Fire(targetBoard, target);
            return target;

        }

        public int RemainingMoves()
        {
            return availableMoves.Count;
        }

        //create target at N,E,W or S from given center
        private FieldData PickNearTarget(FieldData center, char direction)
        {
            FieldData newTarget = new FieldData();
            switch (direction)
            {
                case 'N':
                    newTarget.X = center.X;
                    newTarget.Y = Convert.ToChar(Convert.ToInt32(center.Y) - 1);
                    break;
                case 'W':
                    newTarget.X = center.X - 1;
                    newTarget.Y = center.Y;
                    break;
                case 'E':
                    newTarget.X = center.X + 1;
                    newTarget.Y = center.Y;
                    break;
                case 'S':
                    newTarget.X = center.X;
                    newTarget.Y = Convert.ToChar(Convert.ToInt32(center.Y) + 1);
                    break;
                default:
                    break;
            }

            //dirList.Remove(direction);
            return newTarget;
        }

        private FieldData GenerateNewTarget()
        {
            FieldData newTarget = new FieldData();
            int targetCount = usedTargets.Count;
            //continue attack near last hit or generate random target
            if (attackCenter.X != -1) //X=-1 means that player don't know where where enemy's boat can be
            {
                if (targetOrientation == Orientation.Undefined)
                {
                    if (targetCount>1 && usedTargets.ElementAt(targetCount - 1).state == FieldState.Hit && usedTargets.ElementAt(targetCount - 2).state == FieldState.Hit)
                    {
                        //check coordiantes of last two targets to define boat orientation
                        if (usedTargets.ElementAt(targetCount - 1).X == usedTargets.ElementAt(targetCount - 2).X) targetOrientation = Orientation.Horizontal;
                        if (usedTargets.ElementAt(targetCount - 1).Y == usedTargets.ElementAt(targetCount - 2).Y) targetOrientation = Orientation.Vertical;
                    }
                }

                //generate target near attackCenter based on orientation. If none of this moves is available, generate random target
                if(targetOrientation != Orientation.Horizontal) newTarget = PickNearTarget(attackCenter, 'N');
                if (!availableMoves.Contains(newTarget) || targetOrientation != Orientation.Vertical) newTarget = PickNearTarget(attackCenter, 'E');
                if (!availableMoves.Contains(newTarget) || targetOrientation != Orientation.Vertical) newTarget = PickNearTarget(attackCenter, 'W');
                if (!availableMoves.Contains(newTarget) || targetOrientation != Orientation.Horizontal) newTarget = PickNearTarget(attackCenter, 'S');
                if (!availableMoves.Contains(newTarget))
                {
                    newTarget = availableMoves.ElementAt(randomGenerator.Next(0, availableMoves.Count));
                    attackCenter.X = -1; 
                }
            }
            else
            {
                newTarget = availableMoves.ElementAt(randomGenerator.Next(0, availableMoves.Count));
            }
            availableMoves.Remove(newTarget);
            
            return newTarget;
        }
    }
}
