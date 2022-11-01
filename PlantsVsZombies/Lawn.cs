using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Lawn 
    {
        private static Lawn _lawnInstance;
        Texture2D _texture;
        public Texture2D Texture { get => _texture; set => _texture = value; }

        private List<Row> _rows;


        public Row GetRow(int rowNumber)
        {
            return _rows[rowNumber];
        }

        public List<Row> Rows { get => _rows; }

        private Lawn(Texture2D texture)
        {
            Texture = texture;
            _rows = new List<Row>();
            for (int i = 0; i < 5; i++)
            {
                _rows.Add(new Row());
            }   


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

