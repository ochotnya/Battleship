using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        private Random randomGenerator = new Random();
        private bool attackingBoat = false;
        private List<FieldData> usedTargets = new List<FieldData>();
        public void Reset()
        {
            usedTargets.Clear();
            attackingBoat = false;
        }
        private bool Fire(PlayerBoard targetBoard, FieldData targetField)
        {
            bool shotFired = false;
            if (targetBoard.CheckHit(targetField.X, targetField.Y))
            {
                targetField.state = FieldState.Hit;
                attackingBoat = true;
                shotFired = true;
            }
            else
            {
                targetField.state = FieldState.Free;
                attackingBoat = false;
            }
            usedTargets.Add(targetField);
            return shotFired;
        }

        public void Shot(PlayerBoard targetBoard)
        {
            FieldData target = GenerateNewTarget();
            while(checkIfTargetsUsed(target))
            {
                target = GenerateNewTarget();
            }
            Fire(targetBoard, target);

        }

        private bool checkIfTargetsUsed(FieldData target)
        {
            foreach (FieldData item in usedTargets)
            {
                if (item.X == target.X && item.Y == target.Y) return true;
            }
            return false;
        }
       /* public Field GetField(int X, char Y, ControlCollection panelControls)
        {
            foreach (Field field in panelControls)
            {
                if (field.X == X && field.Y == Y) return field;
            }
            return null;
        }*/
        public FieldData GenerateNewTarget()
        {
            FieldData newTarget = new FieldData();
            newTarget.Y = Convert.ToChar(randomGenerator.Next(Convert.ToInt32('A'), Convert.ToInt32('K')));
            newTarget.X = randomGenerator.Next(0, 10);
            return newTarget;
        }
    }
}
