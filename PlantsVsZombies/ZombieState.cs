using System;
namespace PlantsVsZombies
{
    public interface ZombieState 
    {
        public Texture2D GetTexture(Zombie zombie);
        public void Update(GameTime gameTime, Zombie zombie);
    }
}

