using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal static class CollisionManager
    {
        public static bool CheckWindowCollision(Vector2 futurePosition, ICollidable collidable)
        {
            Rectangle futureRectangle = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, collidable.CollisionRectangle.Width, collidable.CollisionRectangle.Height);

            bool withinScreenBounds = (futureRectangle.Left >= 0 && futureRectangle.Right <= 800 &&
                                       futureRectangle.Top >= 0 && futureRectangle.Bottom <= 480);

            return withinScreenBounds;
        }
        public static bool CheckCollisionWithCollider(ICollidable collider1, ICollidable collider2)
        {
            return collider1.CollisionRectangle.Intersects(collider2.CollisionRectangle);
        }
    }
}
