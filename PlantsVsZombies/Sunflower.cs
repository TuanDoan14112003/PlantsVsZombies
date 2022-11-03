using System;
namespace PlantsVsZombies
{
    public class Sunflower : Plant
    {
        private GameTime _lastGameTime;
        private List<Sun> _suns;
        public Sunflower(Texture2D texture, int width, int height, Texture2D projectileTexture, int totalFrames, Vector2 positionVector) : base(new String("Sunflower"), new String("Sunflower"), texture, width, height, projectileTexture, totalFrames, positionVector)
        {
            Cost = 50;
            _lastGameTime = new GameTime();
            _suns = new List<Sun>();
        }
        public List<Sun> Suns { get => _suns; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (gameTime.TotalGameTime.TotalSeconds - _lastGameTime.TotalGameTime.TotalSeconds >= 10)
            {
                GenerateSun();
                _lastGameTime.TotalGameTime = gameTime.TotalGameTime;

            };
            for (int i = _suns.Count - 1; i >= 0; i--)
            {
                _suns[i].Update(gameTime);
                if (_suns[i].IsRemoved) _suns.RemoveAt(i);
            }


        }

        public void GenerateSun()
        {
            Vector2 sunPositionVector = new Vector2(this.Rectangle.Center.X+20,this.Rectangle.Center.Y-50);
            Sun newSun = new Sun(_projectileTextuture,50,50,sunPositionVector);
            _suns.Add(newSun);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //Console.WriteLine(_suns.Count);
            foreach (Sun sun in _suns)
            {
                sun.Draw(spriteBatch);
            }
        }
    }
}

