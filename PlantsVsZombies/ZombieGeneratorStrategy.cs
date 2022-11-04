using System;
namespace PlantsVsZombies
{
    public abstract class ZombieGeneratorStrategy
    {
        protected static Dictionary<int, int> _rowCoordinates;
        public ZombieGeneratorStrategy()
        {
            _rowCoordinates = new Dictionary<int, int>() { { 0, 150 },{ 1, 259 },{ 2, 350 },{ 3, 450 },{ 4, 550 } };
        }
        public abstract List<Zombie> GenerateZombies();
    }
}

