
using GameProject.Characters;
using GameProject.Interfaces;
using GameProject.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;
        private Texture2D _mageTexture;
        private Texture2D _doctorTexture;
        private Texture2D _healthBarTexture;
        private Texture2D _greenBulletTexture;
        private Texture2D _redBulletTexture;
        private Texture2D _startButtonTexture;
        private Texture2D _wintexture;
        private Texture2D _defeatTexture;
        EndScreen endScreen;
        StartScreen button;
        HealthBar healthBar;
        Hero hero;
        Enemy enemy1;
        Mage mage;
        Doctor doctorEnemy;
        private string gameState = "not started";
       

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
            if(gameState == "not started")
            {
                _startButtonTexture = Content.Load<Texture2D>("StartButton");
                button = new StartScreen(_startButtonTexture);
            }

            _defeatTexture = Content.Load<Texture2D>("GameOver");
            endScreen = new EndScreen(_defeatTexture);
            


        }
        private void HandleCollisions()
        {
            
            if (gameState == "started")
            {
                CollisionOutcome heroAndenemy = CollisionManager.CheckCollisionWithCollider(hero, enemy1);
                if (heroAndenemy.DidCollide)
                {
                    Debug.WriteLine("BOTSING");
                    if (hero.IsAlive) hero.TakeDamage(1);
                }
                CollisionOutcome heroAndmage = CollisionManager.CheckCollisionWithCollider(hero, mage);
                if (heroAndmage.DidCollide)
                {
                    Debug.WriteLine("BOTSING");
                    if (hero.IsAlive) hero.TakeDamage(1);
                }
                CollisionOutcome heroAnddoctor = CollisionManager.CheckCollisionWithCollider(hero, doctorEnemy);
                if (heroAnddoctor.DidCollide)
                {
                    Debug.WriteLine("BOTSING");
                    if (hero.IsAlive) hero.TakeDamage(1);

                }

                if (hero.Projectiles.Count != 0 && mage.Projectiles.Count != 0)
                {
                    CollisionOutcome bulletAndenemy = CollisionManager.CheckCollisionWithCollider(hero.Projectiles.First(), enemy1);
                    CollisionOutcome bulletAndmage = CollisionManager.CheckCollisionWithCollider(hero.Projectiles.First(), mage);
                    CollisionOutcome bulletAnddoctor = CollisionManager.CheckCollisionWithCollider(hero.Projectiles.First(), doctorEnemy);
                    CollisionOutcome bulletAndhero = CollisionManager.CheckCollisionWithCollider(mage.Projectiles.First(), hero);


                    if (bulletAndenemy.DidCollide)
                    {
                        Debug.WriteLine("ENEMY HIT");
                        enemy1.TakeDamage(1);
                        hero.Projectiles.Clear();
                    }
                    if (bulletAndmage.DidCollide)
                    {
                        Debug.WriteLine("ENEMY HIT");
                        mage.TakeDamage(1);
                        hero.Projectiles.Clear();
                    }
                    if (bulletAnddoctor.DidCollide)
                    {
                        doctorEnemy.TakeDamage(1);
                        hero.Projectiles.Clear();
                    }
                    if (bulletAndhero.DidCollide)
                    {
                        Debug.WriteLine("YOU GOT HIT");
                        hero.TakeDamage(1);
                        mage.Projectiles.Clear();
                    }


                }
            }


           
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //HandleCollisions();
            if(gameState == "not started")
            {
                button.Update();
                gameState = button.GameState;
                if (gameState == "started")
                {

                    IInputReader keyboardReader = new KeyboardReader();
                    _greenBulletTexture = Content.Load<Texture2D>("GreenBullet");
                    _redBulletTexture = Content.Load<Texture2D>("RedBullet");

                    _heroTexture = Content.Load<Texture2D>("Hero");
                    hero = new Hero(_heroTexture, _greenBulletTexture, keyboardReader);
                    hero.collisionBox = new CollisionBox(GraphicsDevice, (int)hero.Position.X, (int)hero.Position.Y);

                    _enemyTexture = Content.Load<Texture2D>("Enemy1");
                    enemy1 = new Enemy(_enemyTexture);
                    enemy1.collisionBox = new CollisionBox(GraphicsDevice, (int)enemy1.Position.X, (int)enemy1.Position.Y);

                    _mageTexture = Content.Load<Texture2D>("Mage");
                    mage = new Mage(_mageTexture, _redBulletTexture);
                    mage.collisionBox = new CollisionBox(GraphicsDevice, (int)mage.Position.X, (int)mage.Position.Y);

                    _doctorTexture = Content.Load<Texture2D>("DoctorEnemy");
                    doctorEnemy = new Doctor(_doctorTexture);
                    doctorEnemy.collisionBox = new CollisionBox(GraphicsDevice, (int)doctorEnemy.Position.X, (int)doctorEnemy.Position.Y);

                    _healthBarTexture = Content.Load<Texture2D>("HealthBar");
                    healthBar = new HealthBar(_healthBarTexture);
                }
                
               
            }
            
            if (gameState == "started")
            {
                
                if (hero.IsAlive) hero.Update(gameTime, GraphicsDevice);
                if (enemy1.IsAlive) enemy1.Update(gameTime, GraphicsDevice);
                if (mage.IsAlive) mage.Update(gameTime, GraphicsDevice);
                doctorEnemy.Update(gameTime, GraphicsDevice);
                HandleCollisions();
            }
          



            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (gameState == "not started") button.Draw(_spriteBatch);
            if (gameState == "started")
            {
                if (!hero.IsAlive) gameState = "ended";
                if (hero.IsAlive)
                {
                    healthBar.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    hero.collisionBox.Draw(_spriteBatch);
                    foreach (var projectile in hero.Projectiles)
                    {
                        projectile.Draw(_spriteBatch, projectile.Position);
                    }
                }
                if (enemy1.IsAlive)
                {
                    enemy1.Draw(_spriteBatch);
                    enemy1.collisionBox.Draw(_spriteBatch);
                }
                if (mage.IsAlive)
                {
                    mage.Draw(_spriteBatch);
                    mage.collisionBox.Draw(_spriteBatch);
                    foreach (var projectile in mage.Projectiles)
                    {
                        projectile.Draw(_spriteBatch, projectile.Position);
                    }
                }

                doctorEnemy.Draw(_spriteBatch);
                doctorEnemy.collisionBox.Draw(_spriteBatch);
            }
            if (gameState == "ended") 
            {
                endScreen.Draw(_spriteBatch);
            }
           
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}