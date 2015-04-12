using System;
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
        Texture2D F9Base, F9Flight, AVBase, AVFlight, AntaresBase, AntaresFlight, F9US, AVUS, AntaresUS;
        SpriteFont defSprite;
        Rectangle playRect, optionRect, weatherSatRect, lunarSatRect, MarsLanderRect, errorButton;
        Rectangle rangePanel, boosterPanel, prop1Panel, prop2Panel, avionicsPanel, guidancePanel, weatherPanel;
        int x, y;
        bool justPress = false;
        bool rocketSelect = false;
		events m_event;
		Random rand;

        public enum scene
        {
            main, mission_select, weather_1, pre_management, launch_dialog, launch_day, post_launch, events, errorBox
        }

        public enum rocket
        {
            atlas, falcon, antares
        }

        public player m_player = new player();
        public payload m_payload = new payload();
        public launch m_launch = new launch();

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

            //graphics.PreferredBackBufferWidth = 600;
            //graphics.PreferredBackBufferHeight = 500;
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
			
			rand = new Random();

            m_launch.window = rand.Next(90, 120);

            // TODO: use this.Content to load your game content here
            whiteText = new Texture2D(GraphicsDevice, 1, 1);
            whiteText.SetData(new Color[] { Color.LightGray });
            defSprite = Content.Load<SpriteFont>("defFont");

            F9Base = Content.Load<Texture2D>("baseF9");
            F9Flight = Content.Load<Texture2D>("flightF9");
            AVBase = Content.Load<Texture2D>("baseAV");
            AntaresBase = Content.Load<Texture2D>("AntaresBase");
            
            //define all geometric areas 
            playRect = new Rectangle(24, 24, 225, 40);
            optionRect = new Rectangle(24, 68, 225, 40);
            
            weatherSatRect = new Rectangle(25, 70, 230, 250);
            lunarSatRect = new Rectangle(280, 70, 230, 250);
            MarsLanderRect = new Rectangle(535, 70, 230, 250);

            desk = new Rectangle(20, 65, 740, 400);
            constructionWindow = new Rectangle(40, 90, 200, 300);
            testingWindow = new Rectangle(300, 90, 200, 300);
            incBudget = new Rectangle(70, 335, 50, 50);
            decBudget = new Rectangle(150, 335, 50, 50);
            incTBudget = new Rectangle(330, 335, 50, 50);
            decTBudget = new Rectangle(410, 335, 50, 50);
            AdvanceQuarter = new Rectangle(330, 428, 200, 34);

            PayButton = new Rectangle(50, 360, 150, 40);
            DelayButton = new Rectangle(230, 360, 150, 40);
            PerfButton = new Rectangle(390, 360, 150, 40);
            selectButton = new Rectangle(170, 410, 150, 50);
            errorButton = new Rectangle(170, 210, 150, 50);

            rangePanel = new Rectangle(10, 10, 200, 50);
            boosterPanel = new Rectangle(10, 60, 200, 50);
            prop1Panel = new Rectangle(10, 110, 200, 50);
            prop2Panel = new Rectangle(10, 160, 200, 50);
            avionicsPanel = new Rectangle(10, 210, 200, 50);
            guidancePanel = new Rectangle(10, 260, 200, 50);
            weatherPanel = new Rectangle(10, 310, 200, 50);
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
            curtime += (float)gameTime.ElapsedGameTime.TotalSeconds;

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
                        m_payload.description = "A medium sized weather satellite. It monitors clouds,";
                        m_payload.description2 = "winds, and precipitation to allow better storm tracking.";
                        m_player.budget = 2456.0;
                    }
                    //lunar probe
                    else if (lunarSatRect.Contains(x, y))
                    {
                        m_payload.setProperties(950.0, 3.1, 1.8, 1.8);
                        m_payload.description = "Small satellite to observe and analyze the Lunar ";
                        m_payload.description2 = " Atmosphere and surface.";
                        m_player.budget = 2875.0;
                    }
                    //Mars lander
                    else if (MarsLanderRect.Contains(x, y))
                    {
                        m_payload.setProperties(4670.0, 7, 3.2, 3.2);
                        m_payload.description = "Mars Lander. Carriers a rover that will explore and";
                        m_payload.description2 = "unlock the secrets of Mars and the Solar System.";
                        m_player.budget = 5213.5;
                    }
                    else if (backButtonMS.Contains(x, y))
                    {
                        m_payload.setProperties(0, 0, 0, 0);
                        m_payload.description = "";
                        m_payload.description2 = "";
                        m_player.LoadScene(scene.main);
                        
                    }
                    else if (continueButtonMS.Contains(x, y))
                    {
                        if (m_payload.mass != 0)
                        {
                            m_player.LoadScene(scene.pre_management);
                        }
                    }
                }
                else if (m_player.GetScene() == scene.pre_management)
                {
                    if (incBudget.Contains(x, y))
                    {
                        m_player.constBudget += 3.0;
                    }
                    else if (decBudget.Contains(x, y))
                    {
                        if (m_player.constBudget >= 3)
                        {
                            m_player.constBudget -= 3.0;
                        }
                    }
                    else if (incTBudget.Contains(x, y))
                    {
                        m_player.testBudget += 1.0;
                    }
                    else if (decTBudget.Contains(x, y))
                    {
                        if (m_player.testBudget >= 1)
                        {
                            m_player.testBudget -= 1.0;
                        }
                    }
                    else if (AdvanceQuarter.Contains(x, y))
                    {
                        if (!justPress)
                        {
                            justPress = true;
                            advancePreLaunchTurn(m_player.constBudget, 20);
                        }
                    }
                }
                else if (m_player.GetScene() == scene.events)
                {
                    if (PayButton.Contains(x, y))
                    {
                        m_player.budget -= m_event.budgetMod;
                        m_player.LoadScene(scene.pre_management);
                    }
                    else if (DelayButton.Contains(x, y))
                    {
                        m_player.tminusDays -= (int)m_event.delay;
                        m_player.LoadScene(scene.pre_management);
                    }
                    else if (PerfButton.Contains(x, y))
                    {
                        m_player.constProgress -= (int)m_event.constructionMod;
                        m_player.testProg -= (int)m_event.testMod;
                        m_player.LoadScene(scene.pre_management);
                    }
                    else if (weatherSatRect.Contains(x, y))
                    {
                        m_player.rocket = rocket.atlas;
                    }
                    else if (lunarSatRect.Contains(x, y))
                    {
                        m_player.rocket = rocket.falcon;
                    }
                    else if (MarsLanderRect.Contains(x, y))
                    {
                        m_player.rocket = rocket.antares;
                    }
                    else if (selectButton.Contains(x, y))
                    {
                        if (m_player.rocket == rocket.atlas || m_player.rocket == rocket.falcon || m_player.rocket == rocket.antares)
                        {
                            if (m_player.rocket == rocket.atlas)
                            {
                                m_player.budget -= 400;
                                m_player.LoadScene(scene.pre_management);
                            }
                            else if (m_player.rocket == rocket.falcon)
                            {
                                if (m_payload.mass == 4670.0)
                                {
                                    //if user attempts to launch lander on F9 then complain.
                                    m_player.errorMess = "Payload too Large for rocket!";
                                    rocketSelect = false;
                                    m_player.LoadScene(scene.errorBox);
                                }
                                else
                                {
                                    m_player.budget -= 200;
                                    m_player.LoadScene(scene.pre_management);
                                }
                            }
                            else if (m_player.rocket == rocket.antares)
                            {
                                if (m_payload.mass == 4670.0 || m_payload.mass == 950.0)
                                {
                                    m_player.errorMess = "Payload too large for rocket!";
                                    rocketSelect = false;
                                    m_player.LoadScene(scene.errorBox);
                                }
                                else
                                {
                                    m_player.budget -= 300;
                                    m_player.LoadScene(scene.pre_management);
                                }
                            }
                        }
                    }
                }
                else if (m_player.GetScene() == scene.launch_dialog)
                {
                    if (PayButton.Contains(x, y))
                    {
                        m_player.LoadScene(scene.launch_day);
                    }
                    else if (DelayButton.Contains(x, y))
                    {
                        m_player.tminusDays += 40;
                        m_player.delayDays += 40;
                        m_player.LoadScene(scene.pre_management);
                    }
                }
                else if (m_player.GetScene() == scene.launch_day)
                {
                    //launch GUI options

                }
                else if (m_player.GetScene() == scene.errorBox)
                {
                    if (errorButton.Contains(x, y))
                    {
                        m_player.LoadScene(scene.pre_management);
                    }
                }
            }
            else
            {
                justPress = false;
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
            else if (m_player.GetScene() == scene.pre_management)
            {
                pre_launch_render();
            }
            else if (m_player.GetScene() == scene.events)
            {
                renderEvent(m_event);
            }
            else if (m_player.GetScene() == scene.launch_dialog)
            {
                LaunchDialogRender();
            }
            else if (m_player.GetScene() == scene.launch_day)
            {
                renderLaunch();
            }
            else if (m_player.GetScene() == scene.errorBox)
            {
                ErrorBoxRender();
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
