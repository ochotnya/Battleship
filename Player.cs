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
        private Random randomGenerator;
        private Orientation targetOrientation=Orientation.Undefined; //0 - horizontal, 1 - vertical, 2 - undefined
        private List<FieldData> usedTargets = new List<FieldData>();
        private List<FieldData> availableMoves = new List<FieldData>();
        private FieldData attackCenter = new FieldData(); //first field that has boat. Player will look around this field for next hit to determine target orientation
        private int score = 0;

        public Player(Random gen)
        {
            randomGenerator = gen;
        }
        private enum Orientation
        {
            Horizontal,
            Vertical,
            Undefined
        }
        public void Reset()
        {
            usedTargets.Clear();
            GenerateMovesList();
            score = 0;          
            attackCenter.X = -1;
            targetOrientation = Orientation.Undefined;
        }

        public int GetScore()
        {
            return score;
        }

        private void GenerateMovesList()
        {
            availableMoves.Clear();
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

        public int GetMovesCount()
        {
            return usedTargets.Count();
        }


        private void Fire(PlayerBoard targetBoard, FieldData targetField)
        {
            if (targetBoard.CheckHit(targetField.X, targetField.Y))
            {
                targetField.state = FieldState.Hit;
                score++;
                if(attackCenter.X == -1) attackCenter = targetField; //if this is the first hit in the series, save this field as attack center, to focus around it in next move
            }
            else //if player miss and already got target orientation, it means he reach to the end of the target boat and can reset orientation and attack center
            {
                targetField.state = FieldState.Free;
                if (targetOrientation != Orientation.Undefined)
                {
                    targetOrientation = Orientation.Undefined;
                    attackCenter.X = -1;
                }
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
                    if (targetCount > 1 && usedTargets.ElementAt(targetCount - 1).state == FieldState.Hit && usedTargets.ElementAt(targetCount - 1) != attackCenter)
                    {
                        //check coordiantes of last two targets to define boat orientation
                        if (usedTargets.ElementAt(targetCount - 1).X == attackCenter.X) targetOrientation = Orientation.Vertical;
                        else if (usedTargets.ElementAt(targetCount - 1).Y == attackCenter.Y) targetOrientation = Orientation.Horizontal;
                        else targetOrientation = Orientation.Undefined;
                    }
                }

                //generate target near attackCenter based on orientation. If none of this moves is available, generate random target
                if (targetOrientation == Orientation.Undefined)
                {
                    newTarget = PickNearTarget(attackCenter, 'N');
                    if (!availableMoves.Contains(newTarget)) newTarget = PickNearTarget(attackCenter, 'E');
                    if (!availableMoves.Contains(newTarget)) newTarget = PickNearTarget(attackCenter, 'W');
                    if (!availableMoves.Contains(newTarget)) newTarget = PickNearTarget(attackCenter, 'S');
                    if (!availableMoves.Contains(newTarget))
                    {
                        newTarget = availableMoves.ElementAt(randomGenerator.Next(0, availableMoves.Count));
                        targetOrientation = Orientation.Undefined;
                        attackCenter.X = -1;
                    }
                }
                else if (targetOrientation == Orientation.Horizontal)
                {
                    newTarget = PickNearTarget(usedTargets.ElementAt(targetCount - 1), 'E');
                    if (!availableMoves.Contains(newTarget)) newTarget = PickNearTarget(usedTargets.ElementAt(targetCount - 1), 'W');
                    if (!availableMoves.Contains(newTarget))
                    {
                        newTarget = availableMoves.ElementAt(randomGenerator.Next(0, availableMoves.Count));
                        targetOrientation = Orientation.Undefined;
                        attackCenter.X = -1;
                    }
                }
                else if (targetOrientation == Orientation.Vertical)
                {
                    newTarget = PickNearTarget(usedTargets.ElementAt(targetCount - 1), 'N');
                    if (!availableMoves.Contains(newTarget)) newTarget = PickNearTarget(usedTargets.ElementAt(targetCount - 1), 'S');
                    if (!availableMoves.Contains(newTarget))
                    {
                        newTarget = availableMoves.ElementAt(randomGenerator.Next(0, availableMoves.Count));
                        targetOrientation = Orientation.Undefined;
                        attackCenter.X = -1;
                    }
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
