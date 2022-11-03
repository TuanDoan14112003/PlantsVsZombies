using System;
namespace PlantsVsZombies
{
    public class Projectile : GameObject
    {
        
        private int _damage;
        
        public int Damage { get => _damage; }


        public Projectile(String name, String description, Texture2D texture,int width,int height, Vector2 positionVector, int damage) : base(name, description, texture,width,height, 1, positionVector, 100)
        {
            
            _damage = damage;
        }

        public void Update()
        {
            _positionVector.X += 3;
            if (PositionVector.X >= 1000) IsRemoved = true;
        }

        

        //public override void Draw(SpriteBatch spriteBatch, int size) // remove this
        //{
        //    base.Draw(spriteBatch, size);
        //    Texture2D rect = new Texture2D(_graphics.GraphicsDevice, Rectangle.Width, Rectangle.Height);

        //    Color[] data = new Color[Rectangle.Width * Rectangle.Height];
        //    for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
        //    rect.SetData(data);

        //    Vector2 coor = new Vector2(Rectangle.X, Rectangle.Y);
        //    spriteBatch.Draw(rect, coor, Color.White);

        //}
    }
}

