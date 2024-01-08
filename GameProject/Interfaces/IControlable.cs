﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interfaces
{
    internal interface IControlable
    {
        public  Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader inputReader { get; set; }
        public string DirectionString { get; set; }
        public void Move();
    }
}
