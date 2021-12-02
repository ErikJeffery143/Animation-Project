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
            shRektangle = new Rectangle(150, 150, 200, 100);
            shrekSpeed = new Vector2(10, 10);






            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            runningTexture = Content.Load<Texture2D>("ShrekRunning");
            reachingTexture = Content.Load<Texture2D>("ShrekReaching");

            YouDied = Content.Load<Texture2D>("DarkSouls_Death");
            standingThereTexture = Content.Load<Texture2D>("StandingThere_");
            OutHouseintroScreen = Content.Load<Texture2D>("ShrekOuthouse");

            deathSoundeffect = Content.Load<SoundEffect>("DarkSoulsYouDiedSound");
            screamSound = Content.Load<SoundEffect>("SCREAM_4");
            screamInstance = screamSound.CreateInstance();

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
                    shRektangle = new Rectangle(150, 150, 200+600, 100+300);
                    screamSound.Play();


                }
                    



            }



                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            if (CurrentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(OutHouseintroScreen, new Rectangle(0, 0, 800, 500), Color.White);
                if (mouseState.LeftButton == ButtonState.Pressed) 
                    CurrentScreen = Screen.StandingThere;
              
            }
            else if (CurrentScreen == Screen.StandingThere)
            {
                _spriteBatch.Draw(standingThereTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.Draw(currentShrek, shRektangle, Color.White);
                
            }


                base.Draw(gameTime);
                _spriteBatch.End();
        }
    } 
}
