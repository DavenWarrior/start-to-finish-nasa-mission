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
    }

    public partial class Game1 : Game
    {
        string str = "s";
        float curtime = 0f;

        void renderLaunch()
        {
            if (curtime >= 1f)
            {
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

            //draw rocket
            if (m_player.rocket == rocket.atlas)
            {
                spriteBatch.Draw(AVBase, new Vector2(320, 200), Color.White);
            }
            else if (m_player.rocket == rocket.falcon)
            {
                spriteBatch.Draw(F9Base, new Vector2(320, 200), Color.White);
            }
            else if (m_player.rocket == rocket.antares)
            {
                spriteBatch.Draw(AntaresBase, new Vector2(320, 200), Color.White);
            }
        }
    }
}
