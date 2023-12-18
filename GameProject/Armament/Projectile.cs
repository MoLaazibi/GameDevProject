using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject { 
    internal class Projectile
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Projectile(Texture2D texture)
        {
            this.texture = texture;
            SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Position = position;
            spriteBatch.Draw(texture, Position, SourceRectangle, Color.White);
        }
        public void UpdatePosition()
        {
            Position += Speed;
        }
    }
}
