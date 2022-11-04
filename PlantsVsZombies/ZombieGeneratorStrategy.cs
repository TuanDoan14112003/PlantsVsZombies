using System;
namespace PlantsVsZombies
{
    public abstract class ZombieGeneratorStrategy
    {
        protected static Dictionary<int, int> _rowCoordinates;

        protected static int _zombieTextureWidth;
        protected static int _zombieTextureHeight;

        protected static Texture2D _normalWalkingTexture; 
        protected static Texture2D _normalEatingTexture;
        protected static int _normalTotalFrames;


        public static void LoadContent(int width, int height, Texture2D normalWalkingTexture, Texture2D normalEatingTexture, int normalTotalFrames)
        {
            _zombieTextureWidth = width;
            _zombieTextureHeight = height;
            _normalWalkingTexture = normalWalkingTexture;
            _normalEatingTexture = normalEatingTexture;
            _normalTotalFrames = normalTotalFrames;
            _rowCoordinates = new Dictionary<int, int>() { { 0, 150 }, { 1, 259 }, { 2, 350 }, { 3, 450 }, { 4, 550 } };
        }

        public abstract List<Zombie> GenerateZombies();

        
    }
}

