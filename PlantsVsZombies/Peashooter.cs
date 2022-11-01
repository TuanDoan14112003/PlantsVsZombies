using System;
namespace PlantsVsZombies
{
    public class Peashooter : Shooter
    {
        public Peashooter(Texture2D texture,int width, int height, Texture2D projectileTexture, Vector2 positionVector) : base(new string("peashooter"), new string("peashooter"),  texture, width,height, projectileTexture,20,20, 49,  positionVector, 20, 30)
        {
        }
    }
}

