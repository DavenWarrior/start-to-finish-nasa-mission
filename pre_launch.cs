using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public partial class Game1 : Game
    {
        Rectangle desk, constructionWindow, testingWindow, AdvanceQuarter, incBudget, decBudget, incTBudget, decTBudget;

        public void pre_launch_render()
        {
            //set up GUI for pre_launch
            spriteBatch.Draw(whiteText, new Rectangle(0, 0, 750, 55), Color.White);
            string preLaunchText = "Pre Mission : T-Minus " + m_player.tminusDays.ToString() + " days";
            spriteBatch.DrawString(defSprite, preLaunchText, new Vector2(140, 10), Color.Black);

            spriteBatch.Draw(whiteText, desk, Color.Orange); //replace with sprite later on

            //construction
            spriteBatch.Draw(whiteText, constructionWindow, Color.LightGray);
            spriteBatch.DrawString(defSprite, "Construction", new Vector2(45, 94), Color.Black);
            spriteBatch.DrawString(defSprite, " Progress : ", new Vector2(45, 134), Color.Black);
            spriteBatch.DrawString(defSprite, m_player.constProgress.ToString() + "%", new Vector2(95, 174), Color.Black);
            spriteBatch.DrawString(defSprite, "Construction", new Vector2(45, 220), Color.Black);
            spriteBatch.DrawString(defSprite, "  Budget : ", new Vector2(45, 260), Color.Black);
            spriteBatch.DrawString(defSprite, "$" + m_player.constBudget.ToString(), new Vector2(95, 300), Color.Black);

            //increment/decrement buttons
            spriteBatch.Draw(whiteText, incBudget, Color.Teal);
            spriteBatch.DrawString(defSprite, "+", new Vector2(90, 345), Color.Black);
            spriteBatch.Draw(whiteText, decBudget, Color.Teal);
            spriteBatch.DrawString(defSprite, "-", new Vector2(160, 345), Color.Black);

            //testing
            spriteBatch.Draw(whiteText, testingWindow, Color.LightGray);
            spriteBatch.DrawString(defSprite, " Testing", new Vector2(305, 94), Color.Black);
            spriteBatch.DrawString(defSprite, "Progress : ", new Vector2(305, 134), Color.Black);
            spriteBatch.DrawString(defSprite, m_player.testProg.ToString() + "%", new Vector2(335, 174), Color.Black);
            spriteBatch.DrawString(defSprite, "Testing ", new Vector2(305, 220), Color.Black);
            spriteBatch.DrawString(defSprite, " Budget : ", new Vector2(305, 260), Color.Black);
            spriteBatch.DrawString(defSprite, "$" + m_player.testBudget.ToString(), new Vector2(355, 300), Color.Black);

            //increment/decrement buttons
            spriteBatch.Draw(whiteText, incTBudget, Color.Teal);
            spriteBatch.DrawString(defSprite, "+", new Vector2(350, 345), Color.Black);
            spriteBatch.Draw(whiteText, decTBudget, Color.Teal);
            spriteBatch.DrawString(defSprite, "-", new Vector2(430, 345), Color.Black);

            spriteBatch.DrawString(defSprite, "Budget : " + m_player.budget.ToString(), new Vector2(50, 430), Color.Black);

            spriteBatch.Draw(whiteText, AdvanceQuarter, Color.Ivory);
            spriteBatch.DrawString(defSprite, "Advance Turn", new Vector2(330, 430), Color.Black);

        }

        void advancePreLaunchTurn(double budget, int days)
        {

            //OPTIMIZATIONS NEEDED HERE!

            if (m_payload.mass == 2620.0)
            {
                //if weather sat
                m_player.constProgress += (int)Math.Ceiling(m_player.constBudget / ((m_player.tminusDays + 1) / 4) * 1.32);
                m_player.testProg += (int)Math.Ceiling(m_player.testBudget / ((m_player.tminusDays + 1) / 2) * 1.5);
            }
            else if (m_payload.mass == 950.0)
            {
                //if lunar probe
                m_player.constProgress += (int)Math.Ceiling(m_player.constBudget / ((m_player.tminusDays + 1) / 4) * 1.05);
                m_player.testProg += (int)Math.Ceiling(m_player.testBudget / ((m_player.tminusDays + 1) / 2) * 1.2);
            }
            else if (m_payload.mass == 4670.0)
            {
                //if Mars lander
                m_player.constProgress += (int)Math.Ceiling(m_player.constBudget / ((m_player.tminusDays + 1) / 4) * 0.86);
                m_player.testProg += (int)Math.Ceiling(m_player.testBudget / ((m_player.tminusDays + 1) / 2) * 0.95);
            }

            if (m_player.constProgress > 100)
            {
                m_player.constProgress = 100;
            }
            if (m_player.testProg > 100)
            {
                m_player.testProg = 100;
            }

            m_player.budget -= budget;
            m_player.tminusDays -= days;

            if (m_player.tminusDays == 0)
            {
                //call launch here
            }
        }
    }
}
