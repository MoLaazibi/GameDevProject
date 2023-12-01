using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    internal class MovementManager
    {
        public void MovePlayer(IMovable movable, Texture2D texture)
        {
            var direction = movable.inputReader.ReadInput(movable);
            //direction.Normalize();
            //Debug.WriteLine(movable.DirectionString);
            if (direction == Vector2.Zero) movable.DirectionString = "still";
            direction.Normalize();
            //Debug.WriteLine("Direction: " + direction.X + "" + direction.Y);
            var futurePosition = movable.Position + movable.Speed * direction;
            //Debug.WriteLine("ToekomstigePos: " + futurePosition);
            //Debug.WriteLine("TextureHeight:" + texture.Height + "TextureWidth:" + texture.Width);
            if (
              (futurePosition.X < (800 - (texture.Width / 4))
               && futurePosition.X > 0) &&
               (futurePosition.Y < 480 - (texture.Height / 4)
               && futurePosition.Y > 0)
            )
            {
                movable.Position = futurePosition;
            }
            //Debug.WriteLine("Position: " + movable.Position);
        }
        public void MoveEnemy(Enemy enemy, Texture2D texture)
        {

            // Calculate the future position based on the current position and speed
            var direction = GetEnemyDirection(enemy.Direction, enemy);
            //enemy.DirectionString = "right";
            var futurePosition = enemy.Position + enemy.Speed * direction;

            // Check for window collisions
            if (
                (futurePosition.X < (800 - (texture.Width / 4)) && futurePosition.X > 0) &&
                (futurePosition.Y < 480 - (texture.Height / 4) && futurePosition.Y > 0)
            )
            {
                // Update the enemy's position
                enemy.Position = futurePosition;
            }
            else
            {
                // Reverse the direction when hitting the window boundaries
                enemy.Direction = GetEnemyDirection(enemy.Direction, enemy);
            }
            

        }
        public Vector2 GetEnemyDirection(Vector2 currentDirection, Enemy enemy)
        {
            if (currentDirection == Vector2.Zero) currentDirection.X += 1;
            else currentDirection.X *= -1;
            switch (currentDirection.X)
            {
                case 1:
                    enemy.DirectionString = "right";
                    break;
                case -1:
                    enemy.DirectionString = "left";
                    break;
            }
            return currentDirection;
        }
    }
}
