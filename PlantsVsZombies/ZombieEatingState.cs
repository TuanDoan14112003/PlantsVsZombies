using System;
namespace PlantsVsZombies
{
    public class ZombieEatingState : ZombieState
    {
        private static Texture2D _stateTexture;
        public Texture2D StateTexture { get => _stateTexture; set => _stateTexture = value; }
        public ZombieEatingState(Texture2D texture)
        {
            _stateTexture = texture;
        }


        public void Update(GameTime gameTime, Zombie zombie)
        {

            if (zombie._soundInstance.State != SoundState.Playing)
                zombie._soundInstance.Play();
            
        }
    }
}

