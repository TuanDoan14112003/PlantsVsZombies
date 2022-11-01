using System;
namespace PlantsVsZombies
{
    public class Row
    {
        private List<Tile> _tiles;
        public List<Tile> Tiles { get => _tiles; }
        public Tile GetTile(int tileNumber)
        {
            return _tiles[tileNumber];
        }
        public Row()
        {
            _tiles = new List<Tile>();
            for (int i = 0; i < 9; i++)
            {
                _tiles.Add(new Tile());
            }
        }

    }
}

