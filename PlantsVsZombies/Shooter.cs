using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class Shooter : Plant
    {

        private int _projectileDamage;

        private int _projectileSize;
        public Shooter(GameTime gametime, String name, String description, Texture2D texture,int width, int height, Texture2D projectileTexture,int projectileSize,int projectileDamage, int totalFrames, Vector2 positionVector) : base(gametime,name, description, texture,width,height, projectileTexture, totalFrames, positionVector)
        {
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
            _projectiles.Add(new Projectile("projectile","bullet",_projectileTextuture,_projectileSize,_projectileSize, projectilePositionVector,_projectileDamage));
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

