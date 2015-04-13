using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public class player
    {
        private Game1.scene curScene = new Game1.scene();
        public int points;
        public bool weatherSat, lunarSat, marsProbe;
        public double budget = 0.0;
		public double overRun, delayDays = 0.0;

        public int tminusDays = 360;

        public int constProgress = 0;
        public double constBudget = 0.0;
        public double composite = 0.0;

        public int testProg = 0;
        public double testBudget = 0.0;

        public string errorMess = "";
		public Game1.scene retScene;

        public Game1.rocket rocket = new Game1.rocket();
        

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
