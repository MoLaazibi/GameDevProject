using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject { 
    internal class Projectile : ICollidable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public Rectangle CollisionRectangle
        {
            get
            {
                return collisionBox.SourceRectangle;
            }
        }
        private CollisionBox collisionBox;

        public Projectile(Texture2D texture, GraphicsDevice graphicsDevice)
        {
            this.texture = texture;
            SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            collisionBox = new CollisionBox(graphicsDevice, (int)Position.X, (int)Position.Y);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Position = position;
            spriteBatch.Draw(texture, Position, SourceRectangle, Color.White);
            collisionBox.Draw(spriteBatch);
        }
        public void UpdatePosition()
        {
            Position += Speed;
            collisionBox.Update((int)Position.X, (int)Position.Y);
        }
    }
}
