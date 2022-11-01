using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Zombie : GameObject
    {


        //private int _currentFrame;
        //private int _totalFrames;


        private ZombieState _state;
        public override Texture2D Texture { get => _state.StateTexture; }
        private Texture2D _zombieEatingTexture;
        private float _damage;
        private Tuple<int,int> _eatingLocation;
        public float Damage { get => _damage; }
        public Tuple<int,int> EatingLocation { get => _eatingLocation; set => _eatingLocation = value; }
        public ZombieState State { get => _state; set => _state = value; }
        public Zombie( Texture2D texture,Texture2D zombieEatingTexture,int width,int height, int totalFrames, Vector2 positionVector, float damage) : base(new string("zombie"), new string("zombie"), texture,width,height, totalFrames, positionVector)
        {
            _damage = damage;
            _state = new ZombieMovingState(texture);
        }

      

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _state.Update(gameTime,this);
            //_positionVector.X -= (float)0.5;
            //Console.WriteLine(this.Hp);
        }

        public bool isCollided(GameObject anotherObject)
        {
            //Console.Write("collide");

            return (anotherObject.Rectangle.X + anotherObject.Rectangle.Width >= this.Rectangle.Center.X
                && this.Rectangle.Center.X >= anotherObject.Rectangle.Center.X
                && Math.Abs(this.Rectangle.Top - anotherObject.Rectangle.Top) <= 120
                && Math.Abs(this.Rectangle.Bottom - anotherObject.Rectangle.Bottom) <= 120);


        }



        //public override void Draw(SpriteBatch spriteBatch) // remove this
        //{
        //    base.Draw(spriteBatch);
        //    Texture2D rect = new Texture2D(_graphics.GraphicsDevice, Rectangle.Width, 200);

        //    Color[] data = new Color[Rectangle.Width * 200];
        //    for (int i = 0; i < data.Length; ++i) data[i] = Color.Blue;
        //    rect.SetData(data);

        //    Vector2 coor = new Vector2(Rectangle.X, Rectangle.Y);
        //    spriteBatch.Draw(rect, coor, Color.White);

        //}





    }
}

