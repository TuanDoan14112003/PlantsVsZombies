using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Zombie : GameObject
    {


        private ZombieState _state;
        public override Texture2D Texture { get => _state.GetTexture(this); }
        private Texture2D _eatingTexture;
        private Texture2D _walkingTexture;
        private float _damage;
        private float _speed;
        private Tuple<int,int> _eatingLocation;
        private static SoundEffect _eatingSoundEffect;
        private SoundEffectInstance _soundInstance; 


        public Texture2D EatingTexture { get => _eatingTexture; }
        public Texture2D WalkingTexture { get => _walkingTexture; }
        public float Damage { get => _damage; }
        public float Speed { get => _speed; }

        public SoundEffectInstance SoundInstance { get => _soundInstance; }
        public static SoundEffect EatingSoundEffect { get => _eatingSoundEffect; set => _eatingSoundEffect = value; }
        public Tuple<int,int> EatingLocation { get => _eatingLocation; set => _eatingLocation = value; }
        public ZombieState State { get => _state; set => _state = value; }

        public Zombie(Texture2D zombieWalkingTexture, Texture2D zombieEatingTexture, int width, int height, int totalFrames, Vector2 positionVector, float damage, float speed, int hp = 100) : base(new string("zombie"), zombieWalkingTexture, width, height, totalFrames, positionVector, hp)
        {
            _speed = speed;
            _damage = damage;
            _eatingTexture = zombieEatingTexture;
            _walkingTexture = zombieWalkingTexture;
            _soundInstance = Zombie.EatingSoundEffect.CreateInstance();
            _state = new ZombieMovingState();
        }
      

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _state.Update(gameTime,this);

        }

        public bool isCollided(GameObject anotherObject)
        {

            return (anotherObject.Rectangle.X + anotherObject.Rectangle.Width >= this.Rectangle.Center.X
                && this.Rectangle.Center.X >= anotherObject.Rectangle.Center.X
                && Math.Abs(this.Rectangle.Top - anotherObject.Rectangle.Top) <= 120
                && Math.Abs(this.Rectangle.Bottom - anotherObject.Rectangle.Bottom) <= 120);


        }





    }
}

