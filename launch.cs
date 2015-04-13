using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public class launch
    {
        public bool range = true;
        public bool booster = true;
        public bool prop_1st_stage = true;
        public bool prop_2nd_stage = true;
        public bool avionics = true;
        public bool guidance = true;
        public bool weather = true;
        public int window;

        public bool success;
        public string GameOverText;
    }

    public partial class Game1 : Game
    {
        string str = "s";
        float pi = 3.1415926f;
        float curtime = 0f;
		int counter = 20;
		bool launch = false;
		bool error = false;
        bool played = false;

        Vector2 origin = new Vector2(0, 0);
        Vector2 destination = new Vector2(500, 200);
        float angle = 0.0f;

        void renderLaunch()
        {
            if (curtime >= 1f)
            {
				counter -= 1;
                curtime = 0;
                int i = rand.Next(0, 100) * (int)m_player.composite;
                if (i < 140)
                {
                    //error generated
                    i = rand.Next(0, 7);
                    if (i == 0) { m_launch.range = false; }
                    else if (i == 1) { m_launch.booster = false; }
                    else if (i == 2) { m_launch.prop_1st_stage = false; }
                    else if (i == 3) { m_launch.prop_2nd_stage = false; }
                    else if (i == 4) { m_launch.avionics = false; }
                    else if (i == 5) { m_launch.guidance = false; }
                    else { m_launch.weather = false; }
                }
				
				//every 5 seconds, see if you can solve issues
				if (counter % 5 == 0){
					if (!m_launch.range){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.range = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.booster){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.booster = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.prop_1st_stage){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.prop_1st_stage = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.prop_2nd_stage){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.prop_2nd_stage = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.avionics){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.avionics = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.guidance){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.guidance = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
					if (!m_launch.weather){
						i = rand.Next((int)m_player.composite, 101);
						if (i > 98){
							m_launch.weather = true;
                        }
                        else
                        {
                            error = true;
                        }
					}
				}
            }
			
			//status panels
            if (m_launch.range)
            {
                spriteBatch.Draw(whiteText, rangePanel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, rangePanel, Color.Red);
            }

            if (m_launch.booster)
            {
                spriteBatch.Draw(whiteText, boosterPanel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, boosterPanel, Color.Red);
            }

            if (m_launch.prop_1st_stage)
            {
                spriteBatch.Draw(whiteText, prop1Panel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, prop1Panel, Color.Red);
            }

            if (m_launch.prop_2nd_stage)
            {
                spriteBatch.Draw(whiteText, prop2Panel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, prop2Panel, Color.Red);
            }

            if (m_launch.avionics)
            {
                spriteBatch.Draw(whiteText, avionicsPanel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, avionicsPanel, Color.Red);
            }

            if (m_launch.guidance)
            {
                spriteBatch.Draw(whiteText, guidancePanel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, guidancePanel, Color.Red);
            }

            if (m_launch.weather)
            {
                spriteBatch.Draw(whiteText, weatherPanel, Color.Green);
            }
            else
            {
                spriteBatch.Draw(whiteText, weatherPanel, Color.Red);
            }
            
            spriteBatch.DrawString(defSprite, "Range", new Vector2(10, 10), Color.Black);
            spriteBatch.DrawString(defSprite, "Booster", new Vector2(10, 60), Color.Black);
            spriteBatch.DrawString(defSprite, "Prop 1st", new Vector2(10, 110), Color.Black);
            spriteBatch.DrawString(defSprite, "Prop 2nd", new Vector2(10, 160), Color.Black);
            spriteBatch.DrawString(defSprite, "Avionics", new Vector2(10, 210), Color.Black);
            spriteBatch.DrawString(defSprite, "Guidance", new Vector2(10, 260), Color.Black);
            spriteBatch.DrawString(defSprite, "Weather", new Vector2(10, 310), Color.Black);

            spriteBatch.DrawString(defSprite, "T - Minus : " + counter.ToString(), new Vector2(300, 0), Color.Black);

            if (counter == 10 && !played)
            {
                played = true;
                SFXAMB.Stop();
                SFXInst.Volume = 0.8f;
                SFXInst.Play();
            }

            if (counter == 0)
            {
                error = false;
                //reset error counter
            }

			if (counter < 0){
				if (m_launch.range && m_launch.booster && m_launch.prop_1st_stage && m_launch.prop_2nd_stage && m_launch.avionics && m_launch.guidance && m_launch.weather){
					//launch
                    launch = true;

                    angle += 0.001f;

                    if (counter == -60)
                    {
                        if (m_launch.range && m_launch.booster && m_launch.prop_1st_stage && m_launch.prop_2nd_stage && m_launch.avionics && m_launch.guidance && m_launch.weather)
                        {
                            m_launch.success = true;
                            m_launch.GameOverText = "You successfully deployed your payload.";
                            m_player.points = (int)(m_player.budget - (m_player.delayDays * 2));
                            m_player.LoadScene(scene.post_launch);
                            SFXAMB.Play();
                        }
                        else
                        {
                            m_launch.success = false;
                            m_launch.GameOverText = "You failed tp deployed your payload.";
                            m_player.points = (int)(m_player.budget - (m_player.delayDays * 2)) - 500;
                            m_player.LoadScene(scene.post_launch);
                            SFXAMB.Play();
                        }
                    }

                    if (angle > pi / 2 - 0.5f) { angle = pi / 2 - 0.5f; }
                    if (m_player.rocket == rocket.atlas)
                    {
                        if (counter > -45)
                        {
                            origin = new Vector2(AVFlight.Width / 2, AVFlight.Height / 2);
                            spriteBatch.Draw(AVFlight, destination, null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
                        }
                        else
                        {
                            origin = new Vector2(AVUS.Width / 2, AVUS.Height / 2);
                            spriteBatch.Draw(AVUS, destination, Color.White);
                        }
                    }
                    else if (m_player.rocket == rocket.falcon)
                    {
                        if (counter > -45)
                        {
                            origin = new Vector2(F9Flight.Width / 2, F9Flight.Height / 2);
                            spriteBatch.Draw(F9Flight, destination, null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
                        }
                        else
                        {
                            origin = new Vector2(F9US.Width / 2, F9US.Height / 2);
                            spriteBatch.Draw(F9US, destination, Color.White); ;
                        }
                    }
                    else if (m_player.rocket == rocket.antares)
                    {
                        if (counter > -45)
                        {
                            origin = new Vector2(AntaresFlight.Width / 2, AntaresFlight.Height / 2);
                            spriteBatch.Draw(AntaresFlight, destination, null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
                        }
                        else
                        {
                            origin = new Vector2(AntaresUS.Width / 2, AntaresUS.Height / 2);
                            spriteBatch.Draw(AntaresUS, destination, Color.White);
                        }
                    }
				}else {
                    if (!launch)
                    {
                        if (m_launch.window != 0)
                        {
                            counter = m_launch.window;
                            m_launch.window = 0;
                            m_player.composite += 5;
                            if (m_player.composite > 100) { m_player.composite = 100; }
                        }
                        else
                        {
                            //handle scrub
                            m_player.composite += 10;
                            m_player.errorMess = "Scrub! Try again tomorrow.";
                            m_player.retScene = scene.launch_day;
                            m_player.delayDays -= 1;
                            counter = 20;
                            SFXInst.Stop();
                            played = false;
                            m_player.LoadScene(scene.errorBox);
                        }
                    }
                    else
                    {
                        //if error in flight.
                        if (error)
                        {
                            SFXInst.Stop();
                            m_launch.success = false;
                            m_launch.GameOverText = "You failed tp deployed your payload.";
                            m_player.points = (int)(m_player.budget - (m_player.delayDays * 2));
                            m_player.LoadScene(scene.post_launch);
                            SFXAMB.Play();
                        }
                    }
				}
			}else {
				//draw rocket and ground
				if (m_player.rocket == rocket.atlas)
				{
					spriteBatch.Draw(AVBase, new Vector2(320, 220), Color.White);
					spriteBatch.Draw(whiteText, new Rectangle(0, 450, 600, 200), Color.Green);
				}
				else if (m_player.rocket == rocket.falcon)
				{
					spriteBatch.Draw(F9Base, new Vector2(320, 220), Color.White);
					spriteBatch.Draw(whiteText, new Rectangle(0, 450, 600, 200), Color.Green);
				}
				else if (m_player.rocket == rocket.antares)
				{
					spriteBatch.Draw(AntaresBase, new Vector2(320, 200), Color.White);
					spriteBatch.Draw(whiteText, new Rectangle(0, 450, 600, 200), Color.Green);
				}
			}
		}
    }
}
