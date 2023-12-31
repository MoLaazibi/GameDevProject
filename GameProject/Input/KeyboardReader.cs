﻿using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput(IControlable movable)
        {
            KeyboardState state = Keyboard.GetState();
            var direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
                movable.DirectionString = "left";
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
                movable.DirectionString = "right";
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
                movable.DirectionString = "up";
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
                movable.DirectionString = "down";
            }
            return direction;
        }
    }
}

