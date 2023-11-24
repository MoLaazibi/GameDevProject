
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
    internal class Hero : IGameObject, IMovable
    {
        private Texture2D heroTexture;
        //public Rectangle deelRectangle;
        private MovementManager movementManager;
        //public Vector2 Position { get; set; }
        //public Vector2 Speed { get; set; }
        Animation animation;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader inputReader { get; set; }
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            animation = new Animation();
            movementManager = new MovementManager();
            animation.Addframe(new Frame(new Rectangle(0, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(122, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(244, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(366, 0, 122, 145)));
            Position = new Vector2(1, 1);
            Speed = new Vector2(3, 3);
            this.inputReader = inputReader;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
       

        }
        public void Move()
        {
            movementManager.Move(this);
           
        }
    }
}
