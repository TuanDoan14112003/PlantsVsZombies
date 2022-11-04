using System;
using Microsoft.Xna.Framework;

namespace PlantsVsZombies
{
    public class Sunflower : Plant
    {

 
        public Sunflower(GameTime gametime,Texture2D texture, int width, int height, Texture2D projectileTexture, int totalFrames, Vector2 positionVector) : base(gametime,new String("Sunflower"), new String("Sunflower"), texture, width, height, projectileTexture, totalFrames, positionVector)
        {
            Cost = 50;
           
        }


        public Sun GenerateSun(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds - _lastGameTime.TotalGameTime.TotalSeconds >= 10)
            {
                Vector2 sunPositionVector = new Vector2(this.Rectangle.Center.X + 20, this.Rectangle.Center.Y - 50);
                Sun newSun = new Sun(_projectileTextuture, 50, 50, sunPositionVector);
                _lastGameTime.TotalGameTime = gameTime.TotalGameTime;
                return newSun;

            };
            return null;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
    

        }
    }
}

