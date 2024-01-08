using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.UI
{
    internal class EndScreen
    {

        private Texture2D defeatTexture;
        private Rectangle defeatText;
       
        public string GameState { get; set; } = "ended";
        public Vector2 Position { get; set; }
        public EndScreen(Texture2D defeatTexture)
        {
            this.defeatTexture = defeatTexture;
            defeatText = new Rectangle(0, 0, defeatTexture.Width, defeatTexture.Height);
            Position = new Vector2(175, 100);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(defeatTexture, Position, defeatText, Color.White);

        }
    }
}
