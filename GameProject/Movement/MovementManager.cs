using GameProject;
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

        public void MovePlayer(IControlable movable, ICollidable collidable)
        {
            var direction = movable.inputReader.ReadInput(movable);
            if (direction == Vector2.Zero) movable.DirectionString = "still";
            direction.Normalize();
            var futurePosition = movable.Position + movable.Speed * direction;
            if (CollisionManager.CheckWindowCollision(futurePosition, collidable))
            { 
                movable.Position = futurePosition;
            }
        }
        public void MoveEnemy(IEnemy enemy)
        {
            var direction = GetEnemyDirection(enemy.Direction, enemy);
            var futurePosition = enemy.Position + enemy.Speed * direction;
            if (CollisionManager.CheckWindowCollision(futurePosition, enemy))
            {
                enemy.Position = futurePosition;
            }
            else
            {
                enemy.Direction = GetEnemyDirection(enemy.Direction, enemy);
            }
        }
        public Vector2 GetEnemyDirection(Vector2 currentDirection, IEnemy enemy)
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
