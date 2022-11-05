using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlantsVsZombies
{
    public class Sun : GameObject
    {
        public Sun(Texture2D texture, int width, int height, Vector2 positionVector) : base(new String("sun"), texture,  width,  height,  1,  positionVector, 100)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public bool GetClickedOn (int MouseX, int MouseY)
        {
            return this.Rectangle.Left < MouseX && this.Rectangle.Right > MouseX && this.Rectangle.Top < MouseY && this.Rectangle.Bottom > MouseY;
        }
    }
}

