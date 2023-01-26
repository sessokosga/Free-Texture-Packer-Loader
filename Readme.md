# Free Texture Packer Loader

A spritesheet loader for using `Free Texture Packer` with `Monogame`

## Structure
There are four main classes to look at :  
1. SpriteFrame : it represent one image inside of a spritesheet
2. SpriteSheet : it represent the a collection on spriteframe
3. SpriteSheetLoader : it is used to load the spritesheet generated from `Free Texture Packer` 
4. SpriteRender : it draws a sprite to the screen

The other classes are used to store information about a SpriteFrame:
1. Pivot stores the pivot point of a frame
2. Rect store the (X,Y) position of an image inside of a sritesheet and that image size (Width, Height)
3. Size store the size (With, Height) of the image

## Usage
Don't forget to add `using FreeTexturePackerLoader;`

1. Start by creating an instance of the SpriteSheetLoader.  
It's usually done in the `LoadContent` method
It needs the `Content`
    var spritesheetLoader = new SpriteSheetLoader(Content);

2. Create aninstance of the SpriteRenderer
It's usually done in the `LoadContent` method
It needs the `spriteBatch`
    var spriteRenderer = new SpriteRender(spriteBatch);

3. Load the spritesheet
    var spritesheet = spriteSheetLoader.Load(filename);

4. Draw a sprite from the spritesheet
    spriteRender.Draw(spriteSheet.GetSprite(spritename), new Vector2(100, 100), Color.White);

## Example project
Create a monogame desktop project
### Using Free Texture Packer to create the spritesheet
1. Open Free Texture Packer
2. Add the images in the `Examples/images` folder
3. Set texture name to `chess`
4. Set texture format to `png`
5. Check the `Remove file ext` box
6. For the packer use `OptimalPacker`
7. For the format, choose `custom`
8. Click the little pencil next to it
9. Paste the following export template : 
    {
        "name":"{{{config.imageName}}}",
        "frames":[
            {{#rects}}
            {
            "filename":"{{{name}}}",
            "frame":{
                "X":{{frame.x}},
                "Y":{{frame.y}},
                "Width":{{frame.w}},
                "Height":{{frame.h}}
            },
            "rotated":{{rotated}},
            "trimmed":{{trimmed}},
            "spriteSourceSize":{
                "X":{{spriteSourceSize.x}},
                "Y":{{spriteSourceSize.y}},
                "Width":{{spriteSourceSize.w}},
                "Height":{{spriteSourceSize.h}}
            },
            "sourceSize":{
                "Width":{{sourceSize.w}},
                "Height":{{sourceSize.h}}
            },
            "pivot":{
                "X":0.5,
                "Y":0.5
            }        
            }{{^last}},{{/last}}
            {{/rects}}
            ],
        "meta":{
            "app":"{{{appInfo.url}}}",
            "version":"{{{appInfo.version}}}",
            "image":"{{{config.imageName}}}",
            "format":"{{{config.format}}}",
            "size":{
                "Width":{{config.imageWidth}},
                "Height":{{config.imageHeight}}
            },
            "scale":{{config.scale}}
        }
    }
10. Check `Allow trim` and `Allow rotation boxes`
11. For file extension, write `json`
12. Click save
13. Click Export
14. Locate the Content directory of your monogame project and click `Select Folder`

It'll generate two files, a json file and an png image

### Loading the spritesheet and using it with monogame
1. Copy the `FreeTexturePackerLoader` folder inside of your monogame project
2. At this using line at the top of yout Game1.cs file `using FreeTexturePackerLoader;`
3. Create an instance of the SpriteSheetLoader in the LoadContent method
    var  spriteSheetLoader = new SpriteSheetLoader(Content);
4. Create aninstance of the SpriteRenderer
    private SpriteRender spriteRender;
In the LoadContent method, add : 
    spriteRender = new SpriteRender(_spriteBatch);
5. Load the spritesheet
    private SpriteSheet spriteSheet;
In the LoadContent method, add : 
    spriteSheet = spriteSheetLoader.Load("chess");
6. Draw a sprite from the spritesheet
In the Draw method, add :
    spriteRender.Draw(spriteSheet.GetSprite("reine_blanc"), new Vector2(100, 100), Color.White);
