using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class CollisionBox
    {
        public Texture2D BoxTexture;
        public Rectangle SourceRectangle { get; set; }
        public int Width { get; set; } = 40;
        public int Height { get; set; } = 70;
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public CollisionBox(GraphicsDevice graphicsDevice ,int x, int y)
        {
            XPosition = x;
            YPosition = y;
            SourceRectangle = new Rectangle(XPosition + 15, YPosition + 6, Width, Height);
            BoxTexture = new Texture2D(graphicsDevice, 1, 1);
            BoxTexture.SetData(new[] { Color.White });
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BoxTexture, SourceRectangle, Color.Transparent);
        }
        public void Update(int newX, int newY)
        {
            XPosition = newX;
            YPosition = newY;

            SourceRectangle = new Rectangle(XPosition + 15, YPosition + 6, Width, Height);
            Debug.WriteLine($"CollisionBox Position: ({XPosition}, {YPosition})");
        }

    }
}
