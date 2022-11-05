using System;
namespace PlantsVsZombies
{
    public class Plant : GameObject
    {
        private int _cost;
        protected GameTime _lastGameTime;
        private int _row;
        private int _column;


        public int Row { get => _row; }
        public int Column { get => _column; }
        public int Cost { get => _cost; }
       

        public Plant(int row, int column, GameTime gameTime,String name, Texture2D texture,int width, int height, int totalFrames, Vector2 positionVector,int cost,int hp = 100) : base(name,texture,width,height,totalFrames,positionVector, hp)
        {
            _row = row;
            _column = column;
            _lastGameTime = new GameTime();
            _lastGameTime.TotalGameTime = gameTime.TotalGameTime;
            _cost = cost;

        }


    }
}

