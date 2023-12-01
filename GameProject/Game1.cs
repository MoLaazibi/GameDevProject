
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;
        Hero hero;
        Enemy enemy1;
        //private Rectangle rectangle;
        //private int schuifOpX = 0;

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
            hero.Draw(_spriteBatch);
            enemy1.Draw(_spriteBatch);
            _spriteBatch.End();
            //hero.Update();
            //schuifOpX += 122;
            //if (schuifOpX > 366) schuifOpX = 0;
            //else rectangle.X = schuifOpX;
            base.Draw(gameTime);
        }
    }
}