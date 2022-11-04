using System;
namespace PlantsVsZombies
{
    public class ZombieMovingState : ZombieState
    {
        public Texture2D GetTexture(Zombie zombie) { return zombie.WalkingTexture; }
        public void Update(GameTime gameTime, Zombie zombie)
        {
            zombie.PositionVector = new Vector2(zombie.PositionVector.X - zombie.Speed, zombie.PositionVector.Y);
        }
    }
}

