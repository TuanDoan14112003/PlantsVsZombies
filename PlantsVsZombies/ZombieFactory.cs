using System;
namespace PlantsVsZombies
{
    public class ZombieFactory
    {
        private int _numberofZombieStage1;
        private int _numberofZombieStage2;
        private int _zombieTextureWidth;
        private int _zombieTextureHeight;
        private Texture2D _zombieTexture;
        private int _zombieTextureTotalFrames;
        private Texture2D _zombieEatingTexture;
        private float _zombieDamage;
        private Dictionary<int, int> _rowAndPosition;
        public ZombieFactory(int numberOfZombieStage1, int numberOfZombieStage2, int textureWidth, int textureHeight, Texture2D zombieTexture,
            Texture2D zombieEatingTexture, int zombieTextureTotalFrames, float zombieDamage)
        {
            Console.WriteLine(zombieTexture);
            _numberofZombieStage1 = numberOfZombieStage1;
            _numberofZombieStage2 = numberOfZombieStage2;
            _zombieTextureWidth = textureWidth;
            _zombieTextureHeight = textureHeight;
            _zombieTexture = zombieTexture;
            _zombieEatingTexture = zombieEatingTexture;
            _zombieTextureTotalFrames = zombieTextureTotalFrames;
            _zombieDamage = zombieDamage;
            _rowAndPosition = new Dictionary<int, int>();
            _rowAndPosition.Add(0, 250);
            _rowAndPosition.Add(1, 359);
            _rowAndPosition.Add(2, 450);
            _rowAndPosition.Add(3, 550);
            _rowAndPosition.Add(4, 650);
        }

        public List<Zombie> GenerateZombies(int stage)
        {
            
            List<Zombie> zombies = new List<Zombie>();
            
                
                Random rnd = new Random();
                int row = rnd.Next(0, 5);
                
            //    Vector2 positionVector = new Vector2(1066, _rowAndPosition[row]-100);
            //    Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            //zombies.Add(onlyZombie);

            Vector2 positionVector = new Vector2(1066, _rowAndPosition[4] - 100);
            Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            zombies.Add(onlyZombie);
            // positionVector = new Vector2(1066, _rowAndPosition[1] - 100);
            // onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            //zombies.Add(onlyZombie);
            //positionVector = new Vector2(1066, _rowAndPosition[2] - 100);
            //onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            //zombies.Add(onlyZombie);
            //positionVector = new Vector2(1066, _rowAndPosition[3] - 100);
            //onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            //zombies.Add(onlyZombie);
            //positionVector = new Vector2(1066, _rowAndPosition[4] - 100);
            //onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            //zombies.Add(onlyZombie);


            return zombies;
            
          
        }
    }
}

