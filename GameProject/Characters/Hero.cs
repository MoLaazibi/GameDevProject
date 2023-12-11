
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
    internal class Hero : Character, IGameObject, IMovable, ICollidable, IPlayer
    {
        public IInputReader inputReader { get; set; }

        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public Hero(Texture2D texture,IInputReader inputReader) : base(texture)
        {
            this.inputReader = inputReader;
            Position = new Vector2(50, 50);
            Speed = new Vector2(3, 3);
        }
        public override void Draw(SpriteBatch spriteBatch)
        { 
            
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            UpdateAnimationFrames();
            animation.Update(gameTime);
            collisionBox.Update((int)Position.X, (int)Position.Y);
            
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
            movementManager.MovePlayer(this, this);
        }
    }
}
