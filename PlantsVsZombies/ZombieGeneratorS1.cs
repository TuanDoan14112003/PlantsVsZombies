using System;
namespace PlantsVsZombies
{
    public class ZombieGeneratorS1 : ZombieGeneratorStrategy
    {
        public ZombieGeneratorS1()
        {
        }

        public override List<Zombie> GenerateZombies()
        {
            List<Zombie> zombies = new List<Zombie>();

            Random rnd = new Random();
            int row = rnd.Next(0, 5);

            Vector2 positionVector = new Vector2(1066, _rowCoordinates[row]);
            Zombie onlyZombie = new Zombie(_zombieTexture, _zombieEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _zombieTextureTotalFrames, positionVector, _zombieDamage);
            zombies.Add(onlyZombie);
            return zombies;


          
        }
    }
}

