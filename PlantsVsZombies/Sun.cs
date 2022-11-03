using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Sun : GameObject
    {
        public Sun(Texture2D texture, int width, int height, Vector2 positionVector) : base(new String("sun"), new String("sun"), texture,  width,  height,  1,  positionVector, 100)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}

