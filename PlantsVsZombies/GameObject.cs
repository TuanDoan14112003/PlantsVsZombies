using System;
using Microsoft.VisualBasic;

namespace PlantsVsZombies
{
    public abstract class GameObject
    {
        static public GraphicsDeviceManager _graphics; // remove this

        private float _hp;
        private String _name;
        private String _description;
        private Texture2D _texture;
        private int _width;
        private int _height;
        private bool _isRemoved;
        public virtual Texture2D Texture { get => _texture; set => _texture = value; }
        public Rectangle Rectangle { get => new Rectangle((int)_positionVector.X, (int)_positionVector.Y, _width, _height); }
        public bool IsRemoved { get => _isRemoved; set => _isRemoved = value; }
        public float Hp
        {
            get => _hp;
            set {
                if (value >= 0) _hp = value;
                else _hp = 0;
                }
        }

        protected int _currentFrame;
        protected int _totalFrames;
        protected Vector2 _positionVector;

        public String Name { get => _name; set => _name = value; }
        public String Description { get => _name; set => _name = value; }
        public Vector2 PositionVector { get => _positionVector; set => _positionVector = value; }


        public GameObject(String name, String description, Texture2D texture,int width, int height, int totalFrames, Vector2 positionVector, int hp)
        {
            IsRemoved = false;
            _name = name;
            _description = description;
            Hp = hp;
            Texture = texture;
            _positionVector = positionVector;
            _currentFrame = 0;
            _totalFrames = totalFrames;
            _width = width;
            _height = height;
        }

        public void gotHit(float damage)
        {
            this.Hp -= damage;
        }


        public static void SetGraphic (GraphicsDeviceManager graphics) // remove this
        {
            _graphics = graphics;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            


            if (_totalFrames == 1)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)_positionVector.X, (int)_positionVector.Y, _width, _height), Color.White);
            }
            else
            {
                int width = Texture.Width / _totalFrames;
                int height = Texture.Height / 1;
                int row = _currentFrame / _totalFrames;
                int column = _currentFrame % _totalFrames;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)PositionVector.X, (int)PositionVector.Y, _width, _height);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            }


       



        }

        public virtual void Update(GameTime gameTime)
        {
            _currentFrame++;

            if (_currentFrame == _totalFrames)
                _currentFrame = 0;
            if (Hp == 0) IsRemoved = true;
        }

    }
}

