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
    internal class Enemy : Character, IGameObject, ICollidable, IEnemy
    {
        public Vector2 Direction { get; set; }
        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public Enemy(Texture2D texture) : base(texture)
        {
            Position = new Vector2(1, 50);
            Speed = new Vector2(2, 2);
            Direction = Vector2.UnitX;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            animation.LoadTextureFrames(DirectionString, texture.Width, texture.Height, 4, 4);
            animation.Update(gameTime);
            collisionBox.Update((int)Position.X, (int)Position.Y);
        }
        public override void Move()
        {
            movementManager.MoveEnemy(this);
        }
    }
}
