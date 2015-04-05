using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public partial class Game1 : Game
    {
        public void missionSelect_render()
        {
            //render black rectangle
            spriteBatch.Draw(whiteText, new Rectangle(20, 50, 750, 350), Color.DarkGray);
            //weather sat
            spriteBatch.Draw(whiteText, weatherSatRect, Color.DarkOrange);
            spriteBatch.DrawString(defSprite, "  Weather Sat", new Vector2(25, 270), Color.Black);
            //Solar Observation Sat
        }
    }
}
