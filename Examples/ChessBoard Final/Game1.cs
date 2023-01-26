using FreeTexturePackerLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessBoard_Final;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteSheet spriteSheet;
    private SpriteRender spriteRender;
    private int[,] map;
    private SpriteFrame[] frames;
    private int offsetX, offsetY, spaceY, spaceX;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 680;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        var spriteSheetLoader = new SpriteSheetLoader(Content);
        spriteRender = new SpriteRender(_spriteBatch);
        spriteSheet = spriteSheetLoader.Load("chess");

        map = new int[8, 8];
        frames = new SpriteFrame[12];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (i == 1)
                    map[i, j] = 3;
                else if (i == 6)
                    map[i, j] = 2;
                else
                    map[i, j] = -1;
            }
        }
        // Black
        map[0, 0] = map[0, 7] = 11;
        map[0, 1] = map[0, 6] = 1;
        map[0, 2] = map[0, 5] = 3;
        map[0, 3] = 7;
        map[0, 4] = 9;

        // White
        map[7, 0] = map[7, 7] = 10;
        map[7, 1] = map[7, 6] = 0;
        map[7, 2] = map[7, 5] = 2;
        map[7, 3] = 6;
        map[7, 4] = 8;

        frames[0] = spriteSheet.GetSprite("cavalier_blanc");
        frames[1] = spriteSheet.GetSprite("cavalier_noir");
        frames[2] = spriteSheet.GetSprite("fou_blanc");
        frames[3] = spriteSheet.GetSprite("fou_noir");
        frames[4] = spriteSheet.GetSprite("pion_blanc");
        frames[5] = spriteSheet.GetSprite("pion_noir");
        frames[6] = spriteSheet.GetSprite("reine_blanc");
        frames[7] = spriteSheet.GetSprite("reine_noir");
        frames[8] = spriteSheet.GetSprite("roi_blanc");
        frames[9] = spriteSheet.GetSprite("roi_noir");
        frames[10] = spriteSheet.GetSprite("tour_blanc");
        frames[11] = spriteSheet.GetSprite("tour_noir");

        spaceY = 7;
        spaceX = 7;
        offsetX = (Window.ClientBounds.Width - 8 * (frames[0].frame.Width + spaceX)) / 2 + frames[0].frame.Width / 2;
        offsetY = (Window.ClientBounds.Height - 8 * (frames[0].frame.Height + spaceY)) / 2 + frames[0].frame.Height / 2;

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        int y = offsetY;
        for (int i = 0; i < 8; i++)
        {
            int x = offsetX;
            for (int j = 0; j < 8; j++)
            {
                if (map[i, j] >= 0)
                {
                    spriteRender.Draw(frames[map[i, j]], new Vector2(x, y), Color.White);//
                    x += 70 + spaceX;
                }
            }
            y += 70 + spaceY;
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
