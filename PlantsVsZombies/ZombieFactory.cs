using System;
namespace PlantsVsZombies
{
    public class ZombieFactory
    {
        private static int _numberofZombieStage1;
        private static int _numberofZombieStage2;
        private static int _zombieTextureWidth;
        private static int _zombieTextureHeight;
        private static Texture2D _zombieTexture;
        private static int _zombieTextureTotalFrames;
        private static Texture2D _zombieEatingTexture;
        private static float _zombieDamage;
        private static Dictionary<int, int> _rowAndPosition;
        public ZombieFactory(int numberOfZombieStage1, int numberOfZombieStage2, int textureWidth, int textureHeight, Texture2D zombieTexture,
            Texture2D zombieEatingTexture, int zombieTextureTotalFrames, float zombieDamage)
        {
      
            _numberofZombieStage1 = numberOfZombieStage1;
            _numberofZombieStage2 = numberOfZombieStage2;
            _zombieTextureWidth = textureWidth;
            _zombieTextureHeight = textureHeight;
            _zombieTexture = zombieTexture;
            _zombieEatingTexture = zombieEatingTexture;
            _zombieTextureTotalFrames = zombieTextureTotalFrames;
            _zombieDamage = zombieDamage;
            _rowAndPosition = new Dictionary<int, int>();
            _rowAndPosition.Add(0, 150);
            _rowAndPosition.Add(1, 259);
            _rowAndPosition.Add(2, 350);
            _rowAndPosition.Add(3, 450);
            _rowAndPosition.Add(4, 550);
        }

        public static List<Zombie> GenerateZombies(int stage)
        {
            
            List<Zombie> zombies = new List<Zombie>();
            
            if (stage == 0)
            {

                Random rnd = new Random();
                int row = rnd.Next(0, 5);

                Vector2 positionVector = new Vector2(1066, _rowAndPosition[row]);
                Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
                zombies.Add(onlyZombie);
            }
            else if (stage == 1)
            {
    
                for (int i = 0; i < _numberofZombieStage1; i++)
                {
                    Random rnd = new Random();
                    int row = rnd.Next(0, 5);
                    int x = rnd.Next(1000, 1500);

                    Vector2 positionVector = new Vector2(x, _rowAndPosition[row]);
                    Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
                    zombies.Add(onlyZombie);
                }
            }
            else if (stage == 2)
            {

                for (int i = 0; i < _numberofZombieStage2; i++)
                {
                    Random rnd = new Random();
                    int row = rnd.Next(0, 5);
                    int x = rnd.Next(1000, 1500);

                    Vector2 positionVector = new Vector2(x, _rowAndPosition[row]);
                    Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
                    zombies.Add(onlyZombie);
                }
            }


            return zombies;
            
          
        }
    }
}

