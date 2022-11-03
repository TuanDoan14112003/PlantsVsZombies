using System;
namespace PlantsVsZombies
{
    public class Peashooter : Shooter
    {
        public Peashooter(Texture2D texture,int width, int height, Texture2D projectileTexture,int totalFrames, Vector2 positionVector) : base(new string("peashooter"), new string("peashooter"),  texture, width,height, projectileTexture,20,20, totalFrames,  positionVector)
        {
            Cost = 100;
        }
    }
}

