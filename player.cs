using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public class player
    {
        private Game1.scene curScene = new Game1.scene();
        public int points;
        public bool weatherSat;
        

        public void initialize()
        {
            curScene = Game1.scene.main;
        }

        public void LoadScene(Game1.scene scene)
        {
            curScene = scene;
        }

        public Game1.scene GetScene()
        {
            return curScene;
        }

        public void update()
        {

        }

        public void draw()
        {

        }
    }
}
