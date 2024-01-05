using GameProject.Interfaces;
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
    internal class Enemy : Character, IGameObject, ICollidable, IEnemy
    {
        public Vector2 Direction { get; set; }
        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public bool IsAlive => Health > 0;
        public int Health { get; set; } = 3;
        public Enemy(Texture2D texture) : base(texture)
        {
            Position = new Vector2(1, 50);
            Speed = new Vector2(2, 2);
            Direction = Vector2.UnitX;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
            }
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
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
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Debug.WriteLine("ENEMY JUST DIED");
            }
        }
    }
}
