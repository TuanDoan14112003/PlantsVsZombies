using System;
namespace PlantsVsZombies
{
    public class Plant : GameObject
    {
        static private int _cost;
        protected Texture2D _projectileTextuture;
       

        public int Cost { get => _cost; set => _cost = value; }
        protected GameTime _lastGameTime;


        public List<Projectile> Projectiles { get => _projectiles; }
        protected List<Projectile> _projectiles;


        public Plant(GameTime gameTime,String name, String description, Texture2D texture,int width, int height, Texture2D projectileTexture, int totalFrames, Vector2 positionVector,int hp = 100) : base(name,description,texture,width,height,totalFrames,positionVector, hp)
        {
            _lastGameTime = new GameTime();
            _lastGameTime.TotalGameTime = gameTime.TotalGameTime;
            _projectileTextuture = projectileTexture;

        }

        //public override void Draw(SpriteBatch spriteBatch) // remove this
        //{
        //    base.Draw(spriteBatch);
        //    Texture2D rect = new Texture2D(_graphics.GraphicsDevice, Rectangle.Width, Rectangle.Height);

        //    Color[] data = new Color[Rectangle.Width * Rectangle.Height];
        //    for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
        //    rect.SetData(data);

        //    Vector2 coor = new Vector2(Rectangle.X, Rectangle.Y);
        //    spriteBatch.Draw(rect, coor, Color.White);

        //}

    }
}

