using System;
namespace PlantsVsZombies
{
    public interface ZombieState 
    {
        private static Texture2D _stateTexture;
        public Texture2D StateTexture { get => _stateTexture; set => _stateTexture = value; }
        public void Update(GameTime gameTime, Zombie zombie);
    }
}

