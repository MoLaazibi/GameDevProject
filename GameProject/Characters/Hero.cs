
using GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Hero : IGameObject
    {
        private Texture2D heroTexture;
        //public Rectangle deelRectangle;
        private Vector2 position = new Vector2(0, 0);
        Animation animation;
        private int schuifOpX = 0;
        public Hero(Texture2D texture)
        {
            this.heroTexture = texture;
            animation = new Animation();
            animation.Addframe(new Frame(new Rectangle(0, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(122, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(244, 0, 122, 145)));
            animation.Addframe(new Frame(new Rectangle(366, 0, 122, 145)));

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            
        }
    }
}
