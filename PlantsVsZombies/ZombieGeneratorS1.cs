using System;
namespace PlantsVsZombies
{
    public class ZombieGeneratorS1 : ZombieGeneratorStrategy
    {

  
        public override List<Zombie> GenerateZombies()
        {
                List<Zombie> zombies = new List<Zombie>();

            Random rnd = new Random();
            int row = rnd.Next(0, 5);

            Vector2 positionVector = new Vector2(1066, _rowCoordinates[row]);
            Zombie onlyZombie = new Zombie(_normalWalkingTexture, _normalEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _normalTotalFrames, positionVector, (float)0.5,(float)0.5);
            zombies.Add(onlyZombie);
            return zombies;



        }
    }
}

