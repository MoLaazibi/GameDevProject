
using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    internal class Hero : Character, IGameObject, IMovable, ICollidable, IPlayer
    {
        public IInputReader inputReader { get; set; }
        private Texture2D bulletTexture;

        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public ShootingManager shootingManager;
        public List<Projectile> Projectiles { get; set; }
        public Hero(Texture2D texture,Texture2D bulletTexture, IInputReader inputReader) : base(texture)
        {
            this.inputReader = inputReader;
            Position = new Vector2(50, 50);
            Speed = new Vector2(3, 3);
            this.bulletTexture = bulletTexture;
            shootingManager = new ShootingManager();
            Projectiles = new List<Projectile>();
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
            shootingManager.UpdateProjectile(this);
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
        public void FireProjectile()
        {
            if (DirectionString != "still")
            {
                Vector2 speed = Vector2.Zero;
                switch (DirectionString)
                {
                    case "right":
                        speed.X += 5;
                        break;
                    case "left":
                        speed.X -= 5;
                        break;
                    case "down":
                        speed.Y += 5;
                        break;
                    case "up":
                        speed.Y -= 5;
                        break;
                }
                Projectile projectile = new Projectile(bulletTexture) { Position = this.Position, Speed = speed };
                Projectiles.Add(projectile);
            }
        }
    }
}
