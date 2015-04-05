using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public partial class Game1 : Game
    {
        public void mainScene_render()
        {
            //render main rectangle
            spriteBatch.Draw(whiteText, new Rectangle(20, 15, 300, 400), Color.Gray);
            //play button
            spriteBatch.Draw(whiteText, playRect, Color.Beige);
            spriteBatch.DrawString(defSprite, "     Play", new Vector2(22, 25), Color.Black);

            //options button
            spriteBatch.Draw(whiteText, optionRect, Color.Beige);
            spriteBatch.DrawString(defSprite, "     Options", new Vector2(24, 68), Color.Black);
        }
    }
}
