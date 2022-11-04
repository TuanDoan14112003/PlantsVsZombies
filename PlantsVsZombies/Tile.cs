using System;
namespace PlantsVsZombies
{
    public class Tile
    {
        private Plant _plant;

        public Plant Plant { get => _plant ; set { if (Plant == null) _plant = value; }  }

        public Tile()
        {
        }

        public void Update()
        {
            if (_plant != null && _plant.IsRemoved)
            {
                _plant = null;
            }
            
        }
    }
}

