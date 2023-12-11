using GameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class CollisionOutcome
    {
        public bool DidCollide { get; }
        public ICollidable Collidable1 { get; }
        public ICollidable Collidable2 { get; }
        public static CollisionOutcome NotCollision { get; } = new CollisionOutcome(false, null, null);
        public CollisionOutcome(bool didCollide, ICollidable collidable1, ICollidable collidable2)
        {
            DidCollide = didCollide;
            Collidable1 = collidable1;
            Collidable2 = collidable2;
        }
    }
}
