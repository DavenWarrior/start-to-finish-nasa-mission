using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public partial class Game1 : Game
    {
        void PostLaunchRender()
        {
            spriteBatch.Draw(whiteText, new Rectangle(10, 10, 600, 200), Color.Orange);
            spriteBatch.DrawString(defSprite, m_launch.GameOverText, new Vector2(20, 20), Color.Black);

            spriteBatch.DrawString(defSprite, "Points -> " + m_player.points, new Vector2(20, 100), Color.Black);

            spriteBatch.Draw(whiteText, AdvanceQuarter, Color.LightGray);
            spriteBatch.DrawString(defSprite, "Back", new Vector2(AdvanceQuarter.X, AdvanceQuarter.Y), Color.Black);
        }
    }
}
