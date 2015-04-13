using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public class events
    {
        //random event code here
		public string eventDisc;
		public string effectDisc;
		public double budgetMod, constructionMod, testMod, delay;
		public bool active = true;
    }

    public partial class Game1 : Game
    {
        Rectangle PayButton, DelayButton, PerfButton, selectButton;

		events generateEvent()
		{
			events _event_ = new events();
			int rnd = rand.Next(0, 100);

            if (m_player.tminusDays < 180 && !rocketSelect)
            {
                rocketSelect = true;
                _event_.active = true;
                _event_.eventDisc = "Select Rocket for mission!";
                return _event_;
            }

			if (rnd <= 50){
				_event_.eventDisc = "";
				_event_.active = false;
				return _event_;
			}else if (rnd > 50 && rnd <= 55){
				_event_.eventDisc = "Engine reliability Issue.";
				_event_.budgetMod = 125.0;
				_event_.delay = 20.0;
				_event_.constructionMod = 6;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.constructionMod.ToString() + " construction";
				_event_.active = true;
			}else if(rnd > 55 && rnd <= 60){
				_event_.eventDisc = "Upper Stage Engine Explodes";
				_event_.budgetMod = 85.0;
				_event_.delay = 20.0;
				_event_.constructionMod = 4;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.constructionMod.ToString() + " construction";
				_event_.active = true;
			}else if(rnd > 60 && rnd <= 65){
				_event_.eventDisc = "Test failure.";
				_event_.budgetMod = 45.0;
				_event_.delay = 40.0;
				_event_.testMod = 5;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.testMod.ToString() + " testing";
				_event_.active = true;
			}else if(rnd > 65 && rnd <= 70){
				_event_.eventDisc = "Computer Bugs";
				_event_.budgetMod = 200.0;
				_event_.delay = 40.0;
				_event_.constructionMod = 11;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.constructionMod.ToString() + " construction";
				_event_.active = true;
			}else if(rnd > 70 && rnd <= 75){
				_event_.eventDisc = "Requirements change!";
				_event_.budgetMod = 300.0;
				_event_.delay = 40.0;
				_event_.testMod = 13;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.testMod.ToString() + " testing";
				_event_.active = true;
			}else if(rnd > 75 && rnd <= 80){
				_event_.eventDisc = "Performance Overestimated";
				_event_.budgetMod = 100.0;
				_event_.delay = 20.0;
				_event_.constructionMod = 2;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.constructionMod.ToString() + " construction";
				_event_.active = true;
			}else if(rnd > 80 && rnd <= 85){
				_event_.eventDisc = "Budget Overrun";
				_event_.budgetMod = 125.0;
				_event_.delay = 20.0;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + " or delay " + _event_.delay.ToString();
				_event_.active = true;
			}else if(rnd > 85 && rnd <= 90){
				_event_.eventDisc = "Defective parts.";
				_event_.budgetMod = 380.0;
				_event_.delay = 20.0;
				_event_.constructionMod = 17;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + ", delay " + _event_.delay.ToString() + ", or suffer -" + _event_.constructionMod.ToString() + " construction";
				_event_.active = true;
			}else if(rnd > 90 && rnd <= 95){
				_event_.eventDisc = "Sub-Contractor delay";
				_event_.budgetMod = 125.0;
				_event_.delay = 20.0;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + " or delay " + _event_.delay.ToString();
				_event_.active = true;
			}else if(rnd > 95 && rnd <= 100){
				_event_.eventDisc = "Congressional Oversight";
				_event_.budgetMod = 300.0;
				_event_.delay = 20.0;
				_event_.effectDisc = "Pay $" +  _event_.budgetMod.ToString() + " or delay " + _event_.delay.ToString();
				_event_.active = true;
			}
			return _event_;
		}
		
		void renderEvent(events _event){
			spriteBatch.Draw(whiteText, new Rectangle(20, 65, 755, 400), Color.White);
			spriteBatch.DrawString(defSprite, _event.eventDisc, new Vector2(30, 25), Color.Black);
			
			//handle rocket select
            if (_event.eventDisc == "Select Rocket for mission!")
            {
                //note : we use same rectangles as mission select, but we are actually selecting rocket
                spriteBatch.Draw(whiteText, weatherSatRect, Color.Green);
                spriteBatch.DrawString(defSprite, "Atlas V 551", new Vector2(30, 75), Color.Black);
                spriteBatch.Draw(AVBase, new Vector2(70, 80), Color.White);

                spriteBatch.DrawString(defSprite, "Cost 400", new Vector2(30, 275), Color.Black);

                spriteBatch.Draw(whiteText, lunarSatRect, Color.Green);
                spriteBatch.DrawString(defSprite, "Falcon 9 v1.1", new Vector2(285, 75), Color.Black);
                spriteBatch.Draw(F9Base, new Vector2(325, 80), Color.White);

                spriteBatch.DrawString(defSprite, "Cost 200", new Vector2(285, 275), Color.Black);

                spriteBatch.Draw(whiteText, MarsLanderRect, Color.Green);
                spriteBatch.DrawString(defSprite, "Antares Rocket", new Vector2(540, 75), Color.Black);
                spriteBatch.Draw(AntaresBase, new Vector2(580, 80), Color.White);

                spriteBatch.DrawString(defSprite, "Cost 300", new Vector2(540, 275), Color.Black);

                spriteBatch.Draw(whiteText, selectButton, Color.LightBlue);
                spriteBatch.DrawString(defSprite, "Select", new Vector2(172, 410), Color.Black);

                if (m_player.rocket == rocket.atlas)
                {
                    spriteBatch.DrawString(defSprite, "Atlas V with 5m fairing and 5 Solid Boosters.", new Vector2(30, 330), Color.Black);
                    spriteBatch.DrawString(defSprite, "For large payloads and Beyond Earth missions.", new Vector2(30, 370), Color.Black);
                }
                else if (m_player.rocket == rocket.falcon)
                {
                    spriteBatch.DrawString(defSprite, "Falcon 9 rocket. Cheap and reliable. It is ", new Vector2(30, 330), Color.Black);
                    spriteBatch.DrawString(defSprite, "best for medium sized payloads / missions.", new Vector2(30, 370), Color.Black);
                }
                else if (m_player.rocket == rocket.antares)
                {
                    spriteBatch.DrawString(defSprite, "The Antares rocket is a small, efficient", new Vector2(30, 330), Color.Black);
                    spriteBatch.DrawString(defSprite, "rocket for small missions.", new Vector2(30, 370), Color.Black);
                }
            }
            else
            {
                //continue
                spriteBatch.DrawString(defSprite, _event.effectDisc, new Vector2(30, 110), Color.Black);

                spriteBatch.Draw(whiteText, PayButton, Color.Gray);
                spriteBatch.DrawString(defSprite, "Pay Extra", new Vector2(50, 360), Color.Black);

                spriteBatch.Draw(whiteText, DelayButton, Color.Gray);
                spriteBatch.DrawString(defSprite, "Lose Time", new Vector2(230, 360), Color.Black);

                if (_event.constructionMod != 0 || _event.testMod != 0)
                {
                    spriteBatch.Draw(whiteText, PerfButton, Color.Gray);
                    spriteBatch.DrawString(defSprite, "Lose Perf.", new Vector2(390, 360), Color.Black);
                }
            }
		}

        void LaunchDialogRender()
        {
            spriteBatch.Draw(whiteText, new Rectangle(20, 65, 755, 400), Color.White);
            spriteBatch.DrawString(defSprite, "Ready to Launch?", new Vector2(30, 25), Color.Black);

            spriteBatch.DrawString(defSprite, "Reliability : " + m_player.composite.ToString(), new Vector2(30, 100), Color.Black);

            spriteBatch.Draw(whiteText, PayButton, Color.Gray);
            spriteBatch.DrawString(defSprite, "Launch!", new Vector2(50, 360), Color.Black);

            spriteBatch.Draw(whiteText, DelayButton, Color.Gray);
            spriteBatch.DrawString(defSprite, "Delay!", new Vector2(230, 360), Color.Black);
        }

        void ErrorBoxRender()
        {
            spriteBatch.DrawString(defSprite, "Error : " + m_player.errorMess, new Vector2(30, 30), Color.Black);
            spriteBatch.Draw(whiteText, errorButton, Color.LightGreen);
            spriteBatch.DrawString(defSprite, "Back", new Vector2(errorButton.X, errorButton.Y), Color.Black);
            spriteBatch.Draw(whiteText, AdvanceQuarter, Color.LightGreen);
            spriteBatch.DrawString(defSprite, "Main Menu", new Vector2(330, 428), Color.Black);
        }

        void optionRender()
        {
            spriteBatch.DrawString(defSprite, "Images - NASA, SpaceX", new Vector2(50, 10), Color.Black);
            spriteBatch.DrawString(defSprite, "SoundFX - Freesound.org; user Timbre.", new Vector2(50, 40), Color.Black);
            spriteBatch.DrawString(defSprite, "Music - Kevin Macleod - Incompetech", new Vector2(50, 70), Color.Black);

            spriteBatch.Draw(whiteText, AdvanceQuarter, Color.LightGray);
            spriteBatch.DrawString(defSprite, "Back.", new Vector2(AdvanceQuarter.X, AdvanceQuarter.Y), Color.Black);
        }
    }
}
