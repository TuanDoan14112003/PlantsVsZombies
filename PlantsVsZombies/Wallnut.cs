using System;
namespace PlantsVsZombies
{
    public class Wallnut : Plant
    {
        public Wallnut(Texture2D texture, int width, int height, int totalFrames, Vector2 positionVector) : base(new string("wallnut"),new string("wallnut"),texture,width,height,null,totalFrames,positionVector,150) 
        {
            Cost = 50;
        }
    }
}

