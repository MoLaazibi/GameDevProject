using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Frame
    {
        public Rectangle SourceRectangle { get; set; }
        public Frame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }
}
