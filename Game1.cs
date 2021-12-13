using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D OutHouseintroScreen;
        Texture2D runningTexture;
        Vector2 shrekSpeed;
        Rectangle shRektangle;
        Texture2D reachingTexture;
        Texture2D standingThereTexture;
        Texture2D YouDied;
        SoundEffect deathSoundeffect;
        SoundEffect screamSound;

        MouseState mouseState;
        Texture2D currentShrek;

        SoundEffectInstance screamInstance;
        SoundEffectInstance deathInstance;
        




        Screen CurrentScreen;
        enum Screen
        {
            Intro,
            Death,
            StandingThere 

        }



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            if (CurrentScreen == Screen.Intro)
            {
                this.Window.Title = "Click to go Next";
            }
            
                

            shRektangle = new Rectangle(150, 150, 200, 100);
            shrekSpeed = new Vector2(10, 10);


            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();



            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            runningTexture = Content.Load<Texture2D>("ShrekRunning");
            reachingTexture = Content.Load<Texture2D>("ShrekReaching");

            YouDied = Content.Load<Texture2D>("NewDarksoulsDeath");
            standingThereTexture = Content.Load<Texture2D>("StandingThere_");
            OutHouseintroScreen = Content.Load<Texture2D>("ShrekOuthouse");

            deathSoundeffect = Content.Load<SoundEffect>("DarkSoulsYouDiedSound");
            screamSound = Content.Load<SoundEffect>("SCREAM_4");
            screamInstance = screamSound.CreateInstance();
            deathInstance = deathSoundeffect.CreateInstance();
            currentShrek = runningTexture;

            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();



            if (CurrentScreen == Screen.Intro)
            {

            }
            else if (CurrentScreen == Screen.StandingThere)
            {
                shRektangle.X += (int)shrekSpeed.X;
                if (shRektangle.Right >= _graphics.PreferredBackBufferWidth || shRektangle.Left <= 0)
                    shrekSpeed.X = 0;

                shRektangle.Y += (int)shrekSpeed.Y;
                if (shRektangle.Bottom > _graphics.PreferredBackBufferHeight || shRektangle.Top < 0)
                {
                    currentShrek = reachingTexture;
                    shrekSpeed.X = 0;
                    shrekSpeed.Y = 0;
                    shRektangle = new Rectangle(-300, 0, 1500, _graphics.PreferredBackBufferHeight);
                    screamInstance.Play();
                    if (screamInstance.State == SoundState.Stopped)
                    {
                        CurrentScreen = Screen.Death;

                    }
                    if (CurrentScreen == Screen.Death)
                    {
                        
                    }

                }
                    



            }



                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if (CurrentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(OutHouseintroScreen, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    CurrentScreen = Screen.StandingThere;
                    screamInstance.Play();
                } 
                    
            }
            else if (CurrentScreen == Screen.StandingThere)
            {
                
                _spriteBatch.Draw(standingThereTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.Draw(currentShrek, shRektangle, Color.White);
                if (screamInstance.State == SoundState.Stopped)
                {
                    deathInstance.Play();
                    CurrentScreen = Screen.Death;
                }
            }
            else if (CurrentScreen == Screen.Death)
            {
                _spriteBatch.Draw(YouDied, new Rectangle(0, 0, 800, 500), Color.White);
                
                if (deathInstance.State == SoundState.Stopped)
                    Exit();
            }


                base.Draw(gameTime);
                _spriteBatch.End();
        }
    } 
}
