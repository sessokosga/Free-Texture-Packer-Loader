using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeTexturePackerLoader;

public class SpriteSheetLoader
{
    private readonly ContentManager contentManager;
    public SpriteSheetLoader(ContentManager pContentManager)
    {
        contentManager = pContentManager;
    }

    public SpriteSheet Load(string filename)
    {

        string path = contentManager.RootDirectory + Path.DirectorySeparatorChar.ToString() + filename + ".json";
        string getJson = File.ReadAllText(path);
        SpriteSheet spriteSheet = JsonSerializer.Deserialize<SpriteSheet>(getJson);
        Texture2D texture = contentManager.Load<Texture2D>(filename);
        foreach (SpriteFrame sprite in spriteSheet.frames)
        {
            sprite.texture = texture;
            if (sprite.rotated)
                sprite.sourceRect = new Rectangle(sprite.frame.X, sprite.frame.Y, sprite.frame.Height, sprite.frame.Width);
            else
                sprite.sourceRect = new Rectangle(sprite.frame.X, sprite.frame.Y, sprite.frame.Width, sprite.frame.Height);
            sprite.origin = new Vector2(sprite.pivot.X * sprite.frame.Width, sprite.pivot.Y * sprite.frame.Width);
        }
        return spriteSheet;
    }
}