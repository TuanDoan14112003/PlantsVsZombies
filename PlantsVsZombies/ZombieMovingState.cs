using System;
namespace PlantsVsZombies
{
    public class ZombieMovingState : ZombieState
    {
        private static Texture2D _stateTexture;
        public Texture2D StateTexture { get => _stateTexture; set => _stateTexture = value; }

        public ZombieMovingState(Texture2D texture)
        {
            _stateTexture = texture;
        }
        public void Update(GameTime gameTime, Zombie zombie)
        {
            zombie.PositionVector = new Vector2(zombie.PositionVector.X - (float)0.5, zombie.PositionVector.Y);
        }
    }
}

