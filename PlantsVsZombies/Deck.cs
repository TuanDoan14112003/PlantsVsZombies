using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace PlantsVsZombies
{
    public class Deck
    {
        private Dictionary<string, Tuple<Texture2D,Vector2>> _items;
        public Deck(Dictionary<string,Texture2D> plantList)
        {
            Vector2 location = new Vector2(20, 170);
            _items = new Dictionary<string, Tuple<Texture2D, Vector2>>();
            foreach (KeyValuePair<string, Texture2D> entry in plantList)
            {
                _items.Add(entry.Key, new Tuple<Texture2D, Vector2>(entry.Value, location));
                location.Y += 80;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Tuple<Texture2D, Vector2>> entry in _items)
            {
                spriteBatch.Draw(entry.Value.Item1, entry.Value.Item2, Color.White);
            }

        }

        public String getSelectedPlant(int x, int y)
        {
            foreach (KeyValuePair<string, Tuple<Texture2D, Vector2>> entry in _items)
            {
                Vector2 positionVector = entry.Value.Item2;
                Texture2D texture = entry.Value.Item1;
                if (x > positionVector.X  && x < positionVector.X + texture.Width 
                    && y > positionVector.Y && y < positionVector.Y + texture.Height)
                {
                    return entry.Key;
                }
            }
            return null;
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}

