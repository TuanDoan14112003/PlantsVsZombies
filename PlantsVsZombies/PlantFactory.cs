using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlantsVsZombies
{
    public class PlantFactory
    {
        private static Texture2D _peashooterTexture;
        private static int _peashooterTextureTotalFrames;
        private static Texture2D _peashooterProjectileTexture;
        private static Texture2D _sunflowerTexture;
        private static Texture2D _sunTexture;
        private static int _sunflowerTextureTotalFrames;
        private static Texture2D _wallnutTexture;
        private static int _wallnutTotalFrames;
        private static int _plantWidth;
        private static int _plantHeight;

        public static Texture2D PeashooterTexture { get => _peashooterTexture;  set => _peashooterTexture = value; }
        public static int PeashooterTextureTotalFrames { get => _peashooterTextureTotalFrames; set => _peashooterTextureTotalFrames = value; }
        public static Texture2D PeashooterProjectileTexture { get => _peashooterProjectileTexture; set => _peashooterProjectileTexture = value; }
        public static Texture2D SunflowerTexture { get => _sunflowerTexture; set => _sunflowerTexture = value; }
        public static Texture2D SunTexture { get => _sunTexture; set => _sunTexture = value; }
        public static int SunflowerTextureTotalFrames { get => _sunflowerTextureTotalFrames; set => _sunflowerTextureTotalFrames = value; }
        public static int PlantWidth { get => _plantWidth; set => _plantWidth = value; }
        public static int PlantHeight { get => _plantHeight; set => _plantHeight = value; }
        public static Texture2D WallnutTexture { get => _wallnutTexture; set => _wallnutTexture = value; }
        public static int WallnutTotalFrames { get => _wallnutTotalFrames; set => _wallnutTotalFrames = value; }

        public PlantFactory()
        {
        }

        public static Plant CreatePlant(GameTime gametime,String plantType, Vector2 positionVector )
        {
            if (plantType == "peashooter")
                return new Peashooter(gametime,_peashooterTexture, _plantWidth, _plantHeight, _peashooterProjectileTexture, PeashooterTextureTotalFrames, positionVector); // fix total frames
            else if (plantType == "sunflower")
                return new Sunflower(gametime,_sunflowerTexture, _plantWidth, _plantHeight, _sunTexture, SunflowerTextureTotalFrames, positionVector);
            else if (plantType == "wallnut")
                return new Wallnut(gametime,_wallnutTexture, _plantWidth, _plantHeight, _wallnutTotalFrames, positionVector);

            else return null;
        }
    }
}

