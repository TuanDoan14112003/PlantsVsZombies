using System;
using Microsoft.Xna.Framework;

namespace PlantsVsZombies
{
    public class Sunflower : Plant
    {

        private Texture2D _sunTexture;
        public Sunflower(int row, int column, GameTime gametime,Texture2D texture, Texture2D sunTexture, int width, int height , int totalFrames, Vector2 positionVector) : base(row,column,gametime,new String("Sunflower"), texture, width, height, totalFrames, positionVector,50)
        {
            _sunTexture = sunTexture;
        }


        public Sun GenerateSun(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds - _lastGameTime.TotalGameTime.TotalSeconds >= 10)
            {
                Vector2 sunPositionVector = new Vector2(this.Rectangle.Center.X + 20, this.Rectangle.Center.Y - 50);
                Sun newSun = new Sun(_sunTexture, 50, 50, sunPositionVector);
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

