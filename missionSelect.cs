using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public partial class Game1 : Game
    {
        Rectangle backButtonMS = new Rectangle(10, 10, 74, 28);
        Rectangle continueButtonMS = new Rectangle(220, 330, 140, 30);

        public void missionSelect_render()
        {
            //render black rectangle
            spriteBatch.Draw(whiteText, new Rectangle(20, 50, 750, 350), Color.DarkGray);
            
            //weather sat, Lunar Sat, Mars Lander
            spriteBatch.Draw(whiteText, weatherSatRect, Color.DarkOrange);
            spriteBatch.Draw(whiteText, lunarSatRect, Color.DarkOrange);
            spriteBatch.Draw(whiteText, MarsLanderRect, Color.DarkOrange);

            spriteBatch.DrawString(defSprite, "  Weather Sat", new Vector2(25, 270), Color.Black);
            spriteBatch.Draw(WeatherSat, new Vector2(25, 75), Color.White);
            spriteBatch.DrawString(defSprite, "   Lunar Sat", new Vector2(280, 270), Color.Black);
            spriteBatch.Draw(Ladee, new Vector2(280, 75), Color.White);
            spriteBatch.DrawString(defSprite, "  Mars Lander", new Vector2(535, 270), Color.Black);
            spriteBatch.Draw(MSL, new Rectangle(537, 75, 220, 162), Color.White);
            
            spriteBatch.DrawString(defSprite, m_payload.description, new Vector2(10, 410), Color.Black);
            spriteBatch.DrawString(defSprite, m_payload.description2, new Vector2(10, 441), Color.Black);
            
            //back button
            spriteBatch.Draw(whiteText, backButtonMS, Color.Ivory);
            spriteBatch.DrawString(defSprite, "Menu", new Vector2(10, 10), Color.Black);

            //continue button
            spriteBatch.Draw(whiteText, continueButtonMS, Color.Ivory);
            spriteBatch.DrawString(defSprite, "Continue", new Vector2(230, 330), Color.Black);
        }
    }
}
