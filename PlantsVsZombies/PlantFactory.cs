using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class PlantFactory
    {
        public PlantFactory()
        {
        }

        public Plant CreatePlant(String plantType,Texture2D plantTexture,int plantTextureWidth, int plantTextureHeight,  Texture2D projectileTexture, Vector2 positionVector )
        {
            if (plantType == "peashooter")
                return new Peashooter(plantTexture, plantTextureWidth, plantTextureHeight, projectileTexture, positionVector);
            else if (plantType == "sunflower")
                return new Sunflower(plantTexture, plantTextureWidth, plantTextureHeight,projectileTexture, 48, positionVector,20,20);
                return null;
        }
    }
}

