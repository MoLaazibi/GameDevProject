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
    internal class Mage : Character, IGameObject, ICollidable, IEnemy
    {
        private Texture2D bulletTexture;
        public Vector2 Direction { get; set; }
        public CollisionBox collisionBox;
        public Rectangle CollisionRectangle
        {
            get { return collisionBox.SourceRectangle; }
        }
        public bool IsAlive => Health > 0;
        public int Health { get; set; } = 3;

        public ShootingManager shootingManager;
        public List<Projectile> Projectiles { get; set; }
        public Mage(Texture2D texture, Texture2D bulletTexture) : base(texture)
        {
            Position = new Vector2(325, 200);
            Speed = new Vector2(2, 2);
            Direction = Vector2.UnitX;
            this.bulletTexture = bulletTexture;
            shootingManager = new ShootingManager();
            Projectiles = new List<Projectile>();
            animation.Addframe(new Frame(new Rectangle(96, 172, 96, 86)));
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
            //animation.LoadTextureFrames(DirectionString, texture.Width, texture.Height, 4, 4);
            animation.Update(gameTime);
            collisionBox.Update((int)Position.X, (int)Position.Y);
            shootingManager.UpdateMageProjectile(this, gameTime, graphicsDevice);
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Debug.WriteLine("ENEMY JUST DIED");
            }
        }
        public void FireProjectile(GraphicsDevice graphicsDevice)
        {
                if (Projectiles.Count >= 2) Projectiles.Clear();
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
                Projectile projectile = new Projectile(bulletTexture, graphicsDevice) { Position = this.Position, Speed = speed };
                Projectiles.Add(projectile);
                Debug.WriteLine(Projectiles.Count);
            
        }
    }
}
