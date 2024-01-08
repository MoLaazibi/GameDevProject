using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interfaces
{
    internal interface IEnemy : ICollidable
    {
        public Vector2 Direction { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public string DirectionString { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get; }
        void TakeDamage(int damage);
    }
}
