using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace start_to_finish_nasa_mission
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D whiteText;
        SpriteFont defSprite;
        Rectangle playRect, optionRect, weatherSatRect;
        int x, y;

        public enum scene
        {
            main, mission_select, weather_1, pre_management, launch_day, post_launch
        }

        public player m_player = new player();
        public payload m_payload = new payload();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // set up begining configuration for player; 0 points, no missions launched
            this.IsMouseVisible = true;
            m_player.points = 0;
            m_player.weatherSat = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            whiteText = new Texture2D(GraphicsDevice, 1, 1);
            whiteText.SetData(new Color[] { Color.LightGray });
            defSprite = Content.Load<SpriteFont>("defFont");
            playRect = new Rectangle(24, 24, 225, 40);
            optionRect = new Rectangle(24, 68, 225, 40);
            weatherSatRect = new Rectangle(25, 70, 250, 250);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            x = Mouse.GetState().X;
            y = Mouse.GetState().Y;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //while in main scene
                if (m_player.GetScene() == scene.main)
                {
                    //if player clicks play
                    if (playRect.Contains(x, y))
                    {
                        m_player.LoadScene(scene.mission_select);
                    }
                        //if player clicks options
                    else if (optionRect.Contains(x, y))
                    {
                        //gapfiller
                    }
                }

                else if (m_player.GetScene() == scene.mission_select)
                {
                    //if player selects weather sat
                    if (weatherSatRect.Contains(x, y))
                    {
                        m_payload.setProperties(2620.0, 4.12, 2.1, 2.1);
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //main scene
            if (m_player.GetScene() == scene.main)
            {
                mainScene_render();
            }
            //mission select screen
            else if (m_player.GetScene() == scene.mission_select)
            {
                missionSelect_render();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
