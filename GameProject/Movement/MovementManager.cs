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
            if (direction == Vector2.Zero) movable.DirectionString = "still";
            direction.Normalize();
            var futurePosition = movable.Position + movable.Speed * direction;
            if (CheckCollision(futurePosition, texture))
            { 
                movable.Position = futurePosition;
            }
        }
        public void MoveEnemy(Enemy enemy, Texture2D texture)
        {
            var direction = GetEnemyDirection(enemy.Direction, enemy);
            var futurePosition = enemy.Position + enemy.Speed * direction;
            if (CheckCollision(futurePosition, texture))
            {
                enemy.Position = futurePosition;
            }
            else
            {
                enemy.Direction = GetEnemyDirection(enemy.Direction, enemy);
            }
        }
        public bool CheckCollision(Vector2 futurePosition, Texture2D texture)
        {
            return (futurePosition.X < (800 - (texture.Width / 4)) && futurePosition.X > 0) &&
                   (futurePosition.Y < 480 - (texture.Height / 4) && futurePosition.Y > 0);
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
