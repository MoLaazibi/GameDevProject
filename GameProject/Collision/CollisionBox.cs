using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class CollisionBox : Game
    {
        public Texture2D boxTexture;
        public Rectangle SourceRectangle { get; set; }
       
        public CollisionBox(int x, int y)
        {
            SourceRectangle = new Rectangle(x, y, 40, 70);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            boxTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            boxTexture.SetData(new[] { Color.White });
            spriteBatch.Draw(boxTexture, SourceRectangle, Color.Red);
        }

    }
}
