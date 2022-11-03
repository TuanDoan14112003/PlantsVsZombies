using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class PlantFactory
    {
        private Texture2D _peashooterTexture;
        private int _peashooterTextureTotalFrames;
        private Texture2D _peashooterProjectileTexture;
        private Texture2D _sunflowerTexture;
        private Texture2D _sunTexture;
        private int _sunflowerTextureTotalFrames;
        private Texture2D _wallnutTexture;
        private int _wallnutTotalFrames;
        private int _plantWidth;
        private int _plantHeight;

        public Texture2D PeashooterTexture { get => _peashooterTexture;  set => _peashooterTexture = value; }
        public int PeashooterTextureTotalFrames { get => _peashooterTextureTotalFrames; set => _peashooterTextureTotalFrames = value; }
        public Texture2D PeashooterProjectileTexture { get => _peashooterProjectileTexture; set => _peashooterProjectileTexture = value; }
        public Texture2D SunflowerTexture { get => _sunflowerTexture; set => _sunflowerTexture = value; }
        public Texture2D SunTexture { get => _sunTexture; set => _sunTexture = value; }
        public int SunflowerTextureTotalFrames { get => _sunflowerTextureTotalFrames; set => _sunflowerTextureTotalFrames = value; }
        public int PlantWidth { get => _plantWidth; set => _plantWidth = value; }
        public int PlantHeight { get => _plantHeight; set => _plantHeight = value; }
        public Texture2D WallnutTexture { get => _wallnutTexture; set => _wallnutTexture = value; }
        public int WallnutTotalFrames { get => _wallnutTotalFrames; set => _wallnutTotalFrames = value; }

        public PlantFactory()
        {
        }

        public Plant CreatePlant(String plantType, Vector2 positionVector )
        {
            if (plantType == "peashooter")
                return new Peashooter(_peashooterTexture, _plantWidth, _plantHeight, _peashooterProjectileTexture, PeashooterTextureTotalFrames, positionVector); // fix total frames
            else if (plantType == "sunflower")
                return new Sunflower(_sunflowerTexture, _plantWidth, _plantHeight, _sunTexture, SunflowerTextureTotalFrames, positionVector);
            else if (plantType == "wallnut")
                return new Wallnut(_wallnutTexture, _plantWidth, _plantHeight, _wallnutTotalFrames, positionVector);

            else return null;
        }
    }
}

