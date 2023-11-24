using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.inputReader.ReadInput(movable);
            //Debug.WriteLine(movable.DirectionString);
            if (direction == Vector2.Zero) movable.DirectionString = "still";
            Debug.WriteLine("Direction: " + direction.X + "" + direction.Y);
            var toekomstigePositie = movable.Position + movable.Speed * direction;
            Debug.WriteLine("ToekomstigePos: " + toekomstigePositie);
            
            if (
              (toekomstigePositie.X < (800 - 122)
               && toekomstigePositie.X > 0) &&
               (toekomstigePositie.Y < 480 - 145
               && toekomstigePositie.Y > 0)
            )
            {
                movable.Position = toekomstigePositie;
            }
            Debug.WriteLine("Position: " + movable.Position);
        }
    }
}
