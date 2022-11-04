using System;
namespace PlantsVsZombies
{
    public class ZombieGeneratorS3 : ZombieGeneratorStrategy
    {
        public override List<Zombie> GenerateZombies()
        {
            List<Zombie> zombies = new List<Zombie>();
            for (int i = 0; i < 15; i++)
            {
                Random rnd = new Random();
                int row = rnd.Next(0, 5);
                int x = rnd.Next(1000, 1500);

                Vector2 positionVector = new Vector2(x, _rowCoordinates[row]);
                Zombie onlyZombie = new Zombie(_normalWalkingTexture, _normalEatingTexture, _zombieTextureWidth, _zombieTextureHeight, _normalTotalFrames, positionVector, (float)0.5,(float)1);
                zombies.Add(onlyZombie);
            }

            return zombies;


        }
    }
}
