using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeTexturePackerLoader;

public class SpriteFrame
{
    public  Rectangle sourceRect{get;set;}

    public string filename { get; set; }
    public Rect frame { get; set; }
    public Rect spriteSourceSize { get; set; }
    public Size sourceSize { get; set; }

    public Vector2 origin{get;set;}
    public Pivot pivot { get; set; }
    public Texture2D texture{get;set;}
    public bool rotated { get; set; }
    public bool trimmed { get; set; }
}