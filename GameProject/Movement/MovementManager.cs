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
        public void MovePlayer(IMovable movable, ICollidable collidable)
        {
            var direction = movable.inputReader.ReadInput(movable);
            if (direction == Vector2.Zero) movable.DirectionString = "still";
            direction.Normalize();
            var futurePosition = movable.Position + movable.Speed * direction;
            if (CheckCollision(futurePosition, collidable))
            { 
                movable.Position = futurePosition;
            }
        }
        public void MoveEnemy(Enemy enemy, Texture2D texture)
        {
            var direction = GetEnemyDirection(enemy.Direction, enemy);
            var futurePosition = enemy.Position + enemy.Speed * direction;
            if (CheckCollision(futurePosition, enemy))
            {
                enemy.Position = futurePosition;
            }
            else
            {
                enemy.Direction = GetEnemyDirection(enemy.Direction, enemy);
            }
        }
        public bool CheckCollision(Vector2 futurePosition, ICollidable collidable)
        {
            Rectangle futureRectangle = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, collidable.CollisionRectangle.Width, collidable.CollisionRectangle.Height);

            // Controleer of de toekomstige rechthoek binnen de grenzen van het scherm ligt
            bool withinScreenBounds = (futureRectangle.Left >= 0 && futureRectangle.Right <= 800 &&
                                       futureRectangle.Top >= 0 && futureRectangle.Bottom <= 480);

            // Controleer op overlap met andere collidable objecten
            //bool collidesWithOthers = CheckCollidesWithOtherCollidables(futureRectangle, collidable);

            return withinScreenBounds;
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
