
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
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
            //Load box content
            _blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blokTexture.SetData(new[] { Color.White });
            box = new Rectangle((int)position.X, (int)position.Y, 40, 70);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);
            enemy1.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.Draw(_texture, new Vector2(0, 0), rectangle,Color.White);
            //_spriteBatch.Draw(_blokTexture, box, Color.Red);
            hero.Draw(_spriteBatch);
            enemy1.Draw(_spriteBatch);
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