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
        private double mageLifeTime = 2.0;
        private int counter = 0;
        public void UpdateHeroProjectile(Hero hero, GameTime gameTime, GraphicsDevice graphicsDevice)
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

        public void UpdateMageProjectile(Mage mage, GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            //if (mage.Projectiles.Count >= 2)mage.Projectiles.Clear();
            string[] directionStrings = { "right", "left", "down", "up" };
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            //Debug.WriteLine("elapsed time:" + elapsedTime);
            if (elapsedTime >= timeBetweenShots + 2)
            {
                mage.DirectionString = directionStrings[counter];
                mage.FireProjectile(graphicsDevice);
                elapsedTime = 0.0;
                counter++;
            }
            foreach (var projectile in mage.Projectiles)
            {
                projectile.UpdatePosition();
            }
            if (elapsedTime >= mageLifeTime && mage.Projectiles.Count != 0)
            {
                mage.Projectiles.Clear();
            }
            if (counter >= 4) counter = 0;
            
        }
    }
}
