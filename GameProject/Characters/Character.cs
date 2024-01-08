using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal abstract class Character : IGameObject
    {
        protected Texture2D texture;
        protected Animation animation;
        protected MovementManager movementManager;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public string DirectionString { get; set; }

        protected Character(Texture2D texture)
        {
            this.texture = texture;
            animation = new Animation();
            movementManager = new MovementManager();
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime, GraphicsDevice graphicsDevice);
    }
}
