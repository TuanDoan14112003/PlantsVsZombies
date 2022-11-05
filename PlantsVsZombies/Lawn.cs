using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Lawn 
    {
        private static Lawn _lawnInstance;
        Texture2D _texture;
        public Texture2D Texture { get => _texture; set => _texture = value; }

        private List<List<Plant>> _tiles;

        private int _numberOfRow;
        private int _numberOfColumn;
        public int NumberOfColumn { get => _numberOfColumn; }
        public int NumberOfRow { get => _numberOfRow; }

        private Lawn(Texture2D texture)
        {
            Texture = texture;
            _numberOfRow = 5;
            _numberOfColumn = 9;
            _tiles = new List<List<Plant>>();
            for (int i = 0; i < 5; i++)
            {
                _tiles.Add(new List<Plant>());
                for (int j = 0; j< 9; j++)
                {
                    _tiles[i].Add(null);
                }
            }
        }

        public Plant GetPlant(int row, int column)
        {
            return _tiles[row][column];
        }

        public void SetPlant(int row, int column, Plant plant)
        {
            _tiles[row][column] = plant;
        }


        public static Lawn GetInstance(Texture2D texture = null)
        {
            if (_lawnInstance == null)
            {
                _lawnInstance = new Lawn(texture);
            }

            return _lawnInstance;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
            spriteBatch.Draw(Texture, location,Color.White);

            
        }
    }
}

