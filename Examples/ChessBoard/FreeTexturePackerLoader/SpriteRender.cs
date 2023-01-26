using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeTexturePackerLoader;

public class SpriteRender{
    private SpriteBatch spriteBatch;

    public SpriteRender(SpriteBatch pSpriteBacth){
        spriteBatch = pSpriteBacth;
    }

    public void Draw(SpriteFrame pSprite, Vector2 pPosition, Color pColor, float pRotation=0, float pScale=1, SpriteEffects pEffect=SpriteEffects.None, float pLayerDepth=1){        
        float rotation = pRotation;
        if(pSprite.rotated){
            rotation+=MathHelper.ToRadians(-90);
        }
        spriteBatch.Draw(pSprite.texture, pPosition,pSprite.sourceRect,pColor,rotation,pSprite.origin,pScale,pEffect,pLayerDepth);
    }
}