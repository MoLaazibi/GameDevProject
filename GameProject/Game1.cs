
using GameProject.UI;
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
        private Texture2D _healthBarTexture;
        private Texture2D _bulletTexture;
        Rectangle bullet;
        HealthBar healthBar;
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

            _heroTexture = Content.Load<Texture2D>("Hero");
            IInputReader keyboardReader = new KeyboardReader();
            hero = new Hero(_heroTexture, keyboardReader);
            hero.collisionBox = new CollisionBox(GraphicsDevice, (int)hero.Position.X, (int)hero.Position.Y);

            _enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemy1 = new Enemy(_enemyTexture);
            enemy1.collisionBox = new CollisionBox(GraphicsDevice, (int)enemy1.Position.X, (int)enemy1.Position.Y);

            _healthBarTexture = Content.Load<Texture2D>("HealthBar");
            healthBar = new HealthBar(_healthBarTexture);

            _bulletTexture = Content.Load<Texture2D>("RedBullet");
            bullet = new Rectangle(0, 0, _bulletTexture.Width, _bulletTexture.Height);
           
        }
        private void HandleCollisions()
        {
            CollisionOutcome collisionOutcome = CollisionManager.CheckCollisionWithCollider(hero, enemy1);
            if (collisionOutcome.DidCollide)
            {
                Debug.WriteLine("BOTSING");
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            HandleCollisions();
            hero.Update(gameTime);
            enemy1.Update(gameTime);
            
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CadetBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            healthBar.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            enemy1.Draw(_spriteBatch);
            hero.collisionBox.Draw(_spriteBatch);
            enemy1.collisionBox.Draw(_spriteBatch);
            _spriteBatch.Draw(_bulletTexture, new Vector2(50, 50), bullet, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}