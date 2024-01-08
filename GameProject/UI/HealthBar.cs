using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.UI
{
    internal class HealthBar
    {
        private Texture2D texture;
        private Rectangle rectangle;
        public HealthBar(Texture2D texture)
        {
            this.texture = texture;
            rectangle = new Rectangle(0, 0, texture.Width / 5, 69);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, -10), rectangle, Color.White);
        }
    }
}
