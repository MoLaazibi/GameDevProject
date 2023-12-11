
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Diagnostics;
using System.Xml.Serialization;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;
        private Texture2D _blokTexture;
        Rectangle box;
        Vector2 position = new Vector2(20, 20);
        Hero hero;
        Enemy enemy1;
       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
          
            base.Initialize();
          
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Load hero content
            _heroTexture = Content.Load<Texture2D>("Hero");
            IInputReader keyboardReader = new KeyboardReader();
            hero = new Hero(_heroTexture, keyboardReader);
            //Load enemy1 content
            _enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemy1 = new Enemy(_enemyTexture);
            //HeroBox content
            hero.collisionBox = new CollisionBox(GraphicsDevice, (int)hero.Position.X, (int)hero.Position.Y);
            //EmemyBox Content
            enemy1.collisionBox = new CollisionBox(GraphicsDevice, (int)enemy1.Position.X, (int)enemy1.Position.Y);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);
            enemy1.Update(gameTime);
            if (hero.CollisionRectangle.Intersects(enemy1.CollisionRectangle)) Debug.WriteLine("BOTSING");
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CadetBlue);
            
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.Draw(_texture, new Vector2(0, 0), rectangle,Color.White);
            //_spriteBatch.Draw(_blokTexture, box, Color.Red);
            hero.Draw(_spriteBatch);
            enemy1.Draw(_spriteBatch);
            hero.collisionBox.Draw(_spriteBatch);
            enemy1.collisionBox.Draw(_spriteBatch);
            //_spriteBatch.Draw(_blokTexture, box, Color.Red);
            _spriteBatch.End();
            //hero.Update();
            //schuifOpX += 122;
            //if (schuifOpX > 366) schuifOpX = 0;
            //else rectangle.X = schuifOpX;
            base.Draw(gameTime);
        }
    }
}