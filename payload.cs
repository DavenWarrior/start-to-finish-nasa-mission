using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace start_to_finish_nasa_mission
{
    public class payload
    {
        public double mass, volume, height, length, width;
        public string description = ""; //line 1 of sat description
        public string description2 = ""; //line 2 of sat description

        public void setProperties(double Mass, double Height, double Width, double Length) {
            mass = Mass;
            height = Height;
            width = Width;
            length = Length;
            volume = Height * Width * Length;
        }
    }
}
