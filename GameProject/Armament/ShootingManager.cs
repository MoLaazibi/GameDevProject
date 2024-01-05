using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class ShootingManager
    {
        private double elapsedTime = 1.0;
        private double timeBetweenShots = 1.0;
        private double lifeTime = 1.0;
        public void UpdateProjectile(Hero hero, GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();
            //Debug.WriteLine("elapsed time:" + elapsedTime);
            if (state.IsKeyDown(Keys.Space) && elapsedTime >= timeBetweenShots)
            {
                hero.FireProjectile(graphicsDevice);
                elapsedTime = 0.0;
            }
            foreach (var projectile in hero.Projectiles)
            {
                projectile.UpdatePosition();
            }
            if(elapsedTime >= lifeTime)
            {
                hero.Projectiles.Clear();
            }
            
        }
    }
}
