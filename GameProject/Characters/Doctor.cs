using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Interfaces;

namespace GameProject.Characters
{
    internal class Doctor : Character, IMovingCharacter, IEnemy
    {
        public Vector2 Direction { get; set; }
        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public bool IsAlive => Health > 0;
        public int Health { get; set; } = 3;
        public Doctor(Texture2D texture) : base(texture)
        {
            Position = new Vector2(1, 400);
            Speed = new Vector2(4, 4);
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
        public void Move()
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
