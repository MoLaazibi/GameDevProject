using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class CollisionBox
    {
        private Texture2D boxTexture;
        public Rectangle SourceRectangle { get; set; }
        public int Width { get; set; } = 40;
        public int Heigt { get; set; } = 70;
        public CollisionBox(SpriteBatch spriteBatch)
        {
            boxTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            boxTexture.SetData(new[] { Color.White });
        }

    }
}
