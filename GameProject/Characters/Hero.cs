
using GameProject.Interfaces;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Hero : Character, IGameObject, IMovable
    {
        public IInputReader inputReader { get; set; }
        public Rectangle CollisionBox { get; set; }

        public CollisionBox collisionBox;
        public Hero(Texture2D texture,IInputReader inputReader) : base(texture)
        {
            this.inputReader = inputReader;
            Position = new Vector2(1, 1);
            Speed = new Vector2(3, 3);
            collisionBox = new CollisionBox((int)Position.X, (int)Position.Y);
        }
        public override void Draw(SpriteBatch spriteBatch)
        { 
            Debug.WriteLine($"Drawing frame: {animation.CurrentFrame.SourceRectangle}");
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            UpdateAnimationFrames();
            animation.Update(gameTime);

        }
        private void UpdateAnimationFrames()
        {
            if (DirectionString != "still")
            {
                animation.LoadTextureFrames(DirectionString, texture.Width, texture.Height, 4, 4);
            }
            else
            {
                animation.Addframe(new Frame(new Rectangle(0, 0, texture.Width / 4, texture.Height / 4)));
            }
        }
        public override void Move()
        {
            movementManager.MovePlayer(this, texture);
        }
    }
}
