
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

using SpriteFontPlus;
namespace PlantsVsZombies;

public class PvZ : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private String _contentPath;

    private MouseState lastMouseState = new MouseState();

    private string _currentPlant;
    private Lawn _lawn;

    //might be able to delete all this and use local variables
    private Texture2D _wallnutTexture;
    private Texture2D _wallnutIconTexture;
    private Texture2D _peashooterTexture;
    
    private Texture2D _peaTexture;
    private Texture2D _peaIconTexture;
    private Texture2D _sunflowerTexture;
    private Texture2D _sunflowerIconTexture;
    private Texture2D _sunTexture;
    private Texture2D _zombieTexture;
    private Texture2D _zombieEatingTexture;
    private List<Zombie> _zombies;
    private List<Plant> _plants;
    private PlantFactory _plantFactory;
    private ZombieFactory _zombieFactory;
    private int _stage;
    Texture2D _sunCounterTexture;
    private Deck _deck;
    private int _sun;
    private List<Sun> _sunList;
    private SpriteFont font;
    private String _message;
    private bool _gameOver;
    private SoundEffect _eatingSound;
    private SoundEffectInstance _ingameSong;

    private static PvZ _PvZInstance;

    private PvZ()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 1400;
        _graphics.PreferredBackBufferHeight = 900;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _contentPath = "/Users/tuandoan/CODE/OOP/PlantsVsZombies/PlantsVsZombies/Content/";

        GameObject.SetGraphic(_graphics); // remove this
    }

    public static PvZ GetInstance()
    {
        if (_PvZInstance == null)
        {
            _PvZInstance = new PvZ();
        }
        return _PvZInstance;
    }



    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _plantFactory = new PlantFactory();
        
        _zombies = new List<Zombie>();
        _currentPlant = null;
        _plants = new List<Plant>();
        _sun = 0;
        _sunList = new List<Sun>();
        _message = null;
        _stage = 0;
        _gameOver = false;
        base.Initialize();

    }

    protected override void LoadContent()
    {

        var fontBakeResult = TtfFontBaker.Bake(File.ReadAllBytes(_contentPath + "font.ttf"),
                                                25,
                                                1024,
                                                1024,
                                                new[]
                                                {
                                                    CharacterRange.BasicLatin,
                                                    CharacterRange.Latin1Supplement,
                                                    CharacterRange.LatinExtendedA,
                                                    CharacterRange.Cyrillic
                                                }
                                               );

        font = fontBakeResult.CreateSpriteFont(GraphicsDevice);
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        FileStream lawnFileStream = new FileStream(_contentPath + "lawn.png", FileMode.Open);
        Texture2D lawnTexture = Texture2D.FromStream(GraphicsDevice, lawnFileStream);
        _lawn = Lawn.GetInstance(lawnTexture);


        FileStream peashooterFileStream = new FileStream(_contentPath + "plant.png", FileMode.Open);
        _peashooterTexture = Texture2D.FromStream(GraphicsDevice, peashooterFileStream);
        //_plantTextureWidth = 100;
        //_plantTextureHeight = 100;

        FileStream sunflowerFileStream = new FileStream(_contentPath + "sunflower.png", FileMode.Open);
        _sunflowerTexture = Texture2D.FromStream(GraphicsDevice, sunflowerFileStream);


        FileStream peaFileStream = new FileStream(_contentPath + "pea.png", FileMode.Open);
        _peaTexture = Texture2D.FromStream(GraphicsDevice, peaFileStream);
        FileStream peashooterIconFileStream = new FileStream(_contentPath + "peashooter_icon.png", FileMode.Open);
        _peaIconTexture = Texture2D.FromStream(GraphicsDevice, peashooterIconFileStream);

        FileStream zombieFileStream = new FileStream(_contentPath + "zombie.png", FileMode.Open);
        _zombieTexture = Texture2D.FromStream(GraphicsDevice, zombieFileStream);

        FileStream zombieEatingFileStream = new FileStream(_contentPath + "zombie_eating.png", FileMode.Open);
        _zombieEatingTexture = Texture2D.FromStream(GraphicsDevice, zombieEatingFileStream);

        FileStream sunFileStream = new FileStream(_contentPath + "sun.png", FileMode.Open);
        _sunTexture = Texture2D.FromStream(GraphicsDevice, sunFileStream);

        FileStream wallnutFileStream = new FileStream(_contentPath + "wallnut.png", FileMode.Open);
        _wallnutTexture = Texture2D.FromStream(GraphicsDevice, wallnutFileStream);

        FileStream wallnutIconFileStream = new FileStream(_contentPath + "wallnut_icon.png", FileMode.Open);
        _wallnutIconTexture = Texture2D.FromStream(GraphicsDevice, wallnutIconFileStream);


        FileStream sunflowerIconFileStream = new FileStream(_contentPath + "sunflower_icon.png", FileMode.Open);
        _sunflowerIconTexture = Texture2D.FromStream(GraphicsDevice, sunflowerIconFileStream);

        FileStream sunCounterFileStream = new FileStream(_contentPath + "suncounter.png", FileMode.Open);
        _sunCounterTexture = Texture2D.FromStream(GraphicsDevice, sunCounterFileStream);

        FileStream _eatingSoundFileStream = new FileStream(_contentPath + "/sounds/chomp.wav", FileMode.Open);
        _eatingSound = SoundEffect.FromStream(_eatingSoundFileStream);
        Zombie.EatingSoundEffect = _eatingSound;

        FileStream _ingameSongFileStream = new FileStream(_contentPath + "/sounds/ingame.wav", FileMode.Open);
        SoundEffect song = SoundEffect.FromStream(_ingameSongFileStream);
        _ingameSong = song.CreateInstance();


        _zombieFactory = new ZombieFactory(4, 15, 355, 200, _zombieTexture, _zombieEatingTexture, 24, (float)0.6);

 
        PlantFactory.PeashooterTexture = _peashooterTexture;
        PlantFactory.PeashooterTextureTotalFrames = 49;
        PlantFactory.PeashooterProjectileTexture = _peaTexture;
        PlantFactory.SunflowerTexture = _sunflowerTexture;
        PlantFactory.SunTexture = _sunTexture;
        PlantFactory.SunflowerTextureTotalFrames = 48; //fixxx this
        PlantFactory.WallnutTexture = _wallnutTexture;
        PlantFactory.WallnutTotalFrames = 17;
        PlantFactory.PlantWidth = 100;
        PlantFactory.PlantHeight = 100;

        Dictionary<string,Texture2D> plantList =  new Dictionary<string, Texture2D>();
        plantList.Add( "peashooter", _peaIconTexture);
        plantList.Add("sunflower", _sunflowerIconTexture);
        plantList.Add("wallnut", _wallnutIconTexture);
        _deck = new Deck(plantList);
    

    }

    private Tuple<int, int> GetRowAndTile(int x, int y)
    {
        int row;
        int tile;
        if (y < 236 || y > 720 || x < 254 || x > 977) return Tuple.Create(-1, -1);
        if (y < 329) row = 0;
        else if (y < 421) row = 1;
        else if (y < 526) row = 2;
        else if (y < 619) row = 3;
        else row = 4;

        if (x < 335) tile = 0;
        else if (x < 404) tile = 1;
        else if (x < 495) tile = 2;
        else if (x < 572) tile = 3;
        else if (x < 651) tile = 4;
        else if (x < 731) tile = 5;
        else if (x < 805) tile = 6;
        else if (x < 890) tile = 7;
        else tile = 8;
        return Tuple.Create(row, tile);
    }

    protected override void Update(GameTime gameTime)
    {

        // Get the mouse state relevant for this frame
        if (_ingameSong.State != SoundState.Playing)
        {
            _ingameSong.Play();
        }
        MouseState currentMouseState = Mouse.GetState();
        if (_zombies.Count == 0)
        {
            if (gameTime.TotalGameTime.TotalSeconds >= 35) _stage = 1;
            if (gameTime.TotalGameTime.TotalSeconds >= 90) _stage = 2;
            _zombies = ZombieFactory.GenerateZombies(_stage);
        }
 

        if (_sunList.Count == 0)
        {
            Random rnd = new Random();
            if (rnd.Next(1,100) == 1)
            {
                int x = rnd.Next(200,700);
                int y = rnd.Next(300, 700);
                

                Sun newSun = new Sun(_sunTexture, 50, 50, new Vector2(x,y));
                _sunList.Add(newSun);
            }
        }
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
 
        if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
        {
            int MouseX = Mouse.GetState().X;
            int MouseY = Mouse.GetState().Y;
            Console.WriteLine(MouseX);
            Console.WriteLine(MouseY);

            String newPlant = _deck.getSelectedPlant(MouseX, MouseY);
            if (newPlant != null) _currentPlant = newPlant;
            bool clickOnSun = false;


            for (int sunIndex = _sunList.Count - 1; sunIndex >= 0; sunIndex--)
            {
                Sun sun = _sunList[sunIndex];
                if (sun.Rectangle.Left < MouseX && sun.Rectangle.Right > MouseX && sun.Rectangle.Top < MouseY && sun.Rectangle.Bottom > MouseY)
                {
                    _sunList.RemoveAt(sunIndex);
                    clickOnSun = true;
                    _sun += 25;
                    break;
                }
            }
            if (!clickOnSun)
            {
                Tuple<int, int> location = GetRowAndTile(MouseX, MouseY);

                if (location.Item1 != -1 && location.Item2 != -1)
                {

                    if (Lawn.GetInstance().Rows[location.Item1].Tiles[location.Item2].Plant == null)
                    {
                        Plant plant = PlantFactory.CreatePlant(gameTime, _currentPlant, new Vector2(254 + 81 * location.Item2, 236 + 93 * location.Item1));
                        if (plant != null)
                        {
                            if (_sun >= plant.Cost)
                            {
                                Lawn.GetInstance().GetRow(location.Item1).GetTile(location.Item2).Plant = plant;
                                _plants.Add(plant);
                                _sun -= plant.Cost;
                                _message = null;
                            }
                            else
                            {
                                _message = "You don't have enough suns";
                            }
                        }
                
                    }
  

                }
            }

        }
  
        
        for (int i = 0; i < Lawn.GetInstance().Rows.Count; i++)
        {

            for (int j = 0; j < Lawn.GetInstance().Rows[i].Tiles.Count; j++)
            {

                Tile tile = Lawn.GetInstance().Rows[i].Tiles[j];
                tile.Update();
                Plant plant = tile.Plant;
                if (plant!=null) {
                    tile.Plant.Update(gameTime); 
                    if (plant.Projectiles != null)
                    {
                        foreach (Projectile proj in plant.Projectiles)
                        {
                                foreach (Zombie zombie in _zombies) {
                                    if (zombie.isCollided(proj))
                                    {
                                        proj.IsRemoved = true;
                                        zombie.gotHit(proj.Damage);
                                        
                                    }
                                }
                            
                            
                        }
                    }
                    foreach (Zombie zombie in _zombies)
                    {
                        if (zombie.isCollided(plant))
                        {
                            
                            zombie.State = new ZombieEatingState(_zombieEatingTexture);
                            zombie.EatingLocation = new Tuple<int, int>(i, j);
                            plant.gotHit(zombie.Damage);
                        }
 

                    }
                    if (plant is Sunflower)
                    {
                        Sunflower sunflower = (Sunflower)plant;
                        Sun newSun = sunflower.GenerateSun(gameTime);
                        if (newSun != null) _sunList.Add(newSun);
                    }
                }

            }
        }


        for (int index = _zombies.Count - 1; index >= 0; index--)
        {
           
           
            if (_zombies[index].State is ZombieEatingState)
            {
              ;
                int rowNumber = _zombies[index].EatingLocation.Item1;
                int tileNumber = _zombies[index].EatingLocation.Item2;
        
                if (Lawn.GetInstance().Rows[rowNumber].Tiles[tileNumber].Plant == null)
                {
             
                    _zombies[index].State = new ZombieMovingState(_zombieTexture);
                }
            }
            _zombies[index].Update(gameTime);
            if (_zombies[index].Rectangle.Center.X <= 0)
            {
                _gameOver = true;
            }
            if (_zombies[index].IsRemoved)
            {
                
                _zombies.RemoveAt(index) ;
            }
            

        }
        
        lastMouseState = currentMouseState;
        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        if (!_gameOver)
        {
            Lawn.GetInstance().Draw(_spriteBatch, new Vector2(0, 150));
            for (int i = 0; i < _zombies.Count; i++)
            {
                _zombies[i].Draw(_spriteBatch);
            }
            for (int i = 0; i < Lawn.GetInstance().Rows.Count; i++)
            {
                for (int j = 0; j < Lawn.GetInstance().Rows[i].Tiles.Count; j++)
                {
                    Tile tile = Lawn.GetInstance().Rows[i].Tiles[j];
                    if (tile.Plant != null) tile.Plant.Draw(_spriteBatch);
                }
            }
            foreach (Sun sun in _sunList)
            {
                sun.Draw(_spriteBatch);
            }

            _deck.Draw(_spriteBatch);
            _spriteBatch.Draw(_sunCounterTexture, new Rectangle(150, 170, 200, 57), Color.White);

            _spriteBatch.DrawString(font, _sun.ToString(), new Vector2(260, 185), Color.Black);
            _spriteBatch.DrawString(font, new String("Stage: ") + _stage.ToString(), new Vector2(1250, 185), Color.White);
            if (_message != null) _spriteBatch.DrawString(font, _message, new Vector2(600, 200), Color.White);
        } else
        {
            _spriteBatch.DrawString(font, new string("Game Over!"), new Vector2(700, 450), Color.White);
        }
        
        


        base.Draw(gameTime);
        _spriteBatch.End();
        
    }
}

// fix ZombieFactory static

