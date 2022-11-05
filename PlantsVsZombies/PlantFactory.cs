using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class PlantFactory
    {

        private Dictionary<String,Tuple<Texture2D,Texture2D,int>> _plantDictionary;
        public static int plantWidth;
        public static int plantHeight;
        public PlantFactory()
        {
            _plantDictionary = new Dictionary<String, Tuple<Texture2D, Texture2D, int>>();
        }

        public void AddPlant(String plantName, Texture2D plantTexture, Texture2D projectileTexture, int totalFrames)
        {
            _plantDictionary.Add( plantName, new Tuple<Texture2D,Texture2D,int>(plantTexture,projectileTexture,totalFrames) );
        }

        public Plant CreatePlant(int row, int column, GameTime gametime,String plantType, Vector2 positionVector )
        {
            if (plantType == "peashooter")
                return new Peashooter(row, column, gametime, _plantDictionary["peashooter"].Item1, _plantDictionary["peashooter"].Item2, plantWidth, plantHeight, _plantDictionary["peashooter"].Item3, positionVector);
            else if (plantType == "sunflower")
                return new Sunflower(row, column,gametime, _plantDictionary["sunflower"].Item1, _plantDictionary["sunflower"].Item2, plantWidth, plantHeight, _plantDictionary["sunflower"].Item3, positionVector);
            else if (plantType == "wallnut")
                return new Wallnut(row, column,gametime, _plantDictionary["wallnut"].Item1, plantWidth, plantHeight, _plantDictionary["wallnut"].Item3, positionVector);

            else return null;
        }
    }
}

