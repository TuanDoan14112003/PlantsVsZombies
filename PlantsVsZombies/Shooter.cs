using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Shooter : Plant
    {

        private Texture2D _projectileTextuture;
        private int _projectileDamage;
        private List<Projectile> _projectiles;
        private int _projectileSize;

        public Texture2D ProjectileTexture { get => _projectileTextuture; }
        public List<Projectile> Projectiles { get => _projectiles; }
        public Shooter(int row, int column, GameTime gametime, String name, Texture2D texture,Texture2D projectileTexture,int width, int height,int projectileSize,int projectileDamage, int totalFrames, Vector2 positionVector,int cost,int hp = 100) : base(row,column,gametime,name, texture,width,height, totalFrames, positionVector,cost,hp)
        {
            _projectileTextuture = projectileTexture;
            _projectiles = new List<Projectile>();
            _projectileSize = projectileSize;
            _projectileDamage = projectileDamage;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (gameTime.TotalGameTime.TotalSeconds - _lastGameTime.TotalGameTime.TotalSeconds >= 2)
            {
                Shoot();
                _lastGameTime.TotalGameTime = gameTime.TotalGameTime;
            };

            for (int i = _projectiles.Count - 1; i >= 0; i--)
            {
                _projectiles[i].Update();
                if (_projectiles[i].IsRemoved) _projectiles.RemoveAt(i);
            }
        }


        public void Shoot()
        {
            Vector2 projectilePositionVector;
            projectilePositionVector.X = PositionVector.X + 50;
            projectilePositionVector.Y = PositionVector.Y + 30;
            _projectiles.Add(new Projectile("projectile",_projectileTextuture,_projectileSize,_projectileSize, projectilePositionVector,_projectileDamage));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (Projectile proj in _projectiles)
            {
                proj.Draw(spriteBatch);
            }
        }


    }
}

