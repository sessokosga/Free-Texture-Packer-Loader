using System.Collections.Generic;

namespace FreeTexturePackerLoader;

public class SpriteSheet{
    public List<SpriteFrame> frames {get;set;}
    public string name{get;set;}

    public SpriteSheet(){
        frames = new List<SpriteFrame>();
    }

    public SpriteFrame GetSprite(string filename){
        foreach (SpriteFrame sprite in frames)
        {
            if(sprite.filename == filename)
                return sprite;
        }
        return null;
    }
}