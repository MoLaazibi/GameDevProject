﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interfaces
{
    internal interface IPlayer : ICollidable
    {
        public int Health { get; set; }
        public bool IsAlive { get; }
        void TakeDamage(int damage);
    }
}
