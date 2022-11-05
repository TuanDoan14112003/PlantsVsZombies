using System;
namespace PlantsVsZombies
{
    public class Peashooter : Shooter
    {
        public Peashooter(int row, int column, GameTime gametime,Texture2D texture, Texture2D projectileTexture,int width, int height,int totalFrames, Vector2 positionVector) : base(row,column,gametime,new string("peashooter"), texture, projectileTexture, width,height ,20,20, totalFrames,  positionVector,100)
        {
        }
    }
}

