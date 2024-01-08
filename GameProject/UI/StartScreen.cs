using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.UI
{
    internal class StartScreen
    {
        private Texture2D buttonTexture;
        private Rectangle button;
        private bool startButtonPressed = false;
        public string GameState { get; set; } = "not started";
        public Vector2 Position { get; set; }
        public StartScreen(Texture2D buttonTexture)
        {
            this.buttonTexture = buttonTexture;
            button = new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height);
            Position = new Vector2(200, 50);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, Position, button, Color.White);
            
        }
        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                startButtonPressed = true;
            }
            if (startButtonPressed) GameState = "started";
        }
    }
}
