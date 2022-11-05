using System;
namespace PlantsVsZombies
{
    public class Projectile : GameObject
    {
        
        private int _damage;
        
        public int Damage { get => _damage; }


        public Projectile(String name, Texture2D texture,int width,int height, Vector2 positionVector, int damage) : base(name, texture,width,height, 1, positionVector, 100)
        {
            
            _damage = damage;
        }

        public void Update()
        {
            _positionVector.X += 3;
            if (PositionVector.X >= 1000) IsRemoved = true;
        }

        

    }
}

