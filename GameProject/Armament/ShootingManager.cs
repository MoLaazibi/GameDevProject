using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class ShootingManager
    {
        public void UpdateProjectile(Hero hero)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
            {
                hero.FireProjectile();
            }
            foreach (var projectile in hero.Projectiles)
            {
                projectile.UpdatePosition();
            }
        }
    }
}
