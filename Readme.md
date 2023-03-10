# Free Texture Packer Loader

A sprite sheet loader for using [Free Texture Packer](https://free-tex-packer.com) with [Monogame](https://monogame.net)

*Read in another language : [English](Readme.md), [Français](Readme.fr.md)*

## Structure
There are four main classes to look at :  
1. `SpriteFrame` : it represent one image inside of a spritesheet
2. `SpriteSheet` : it represent the a collection on spriteframe
3. `SpriteSheetLoader` : it is used to load the spritesheet generated from Free Texture Packer 
4. `SpriteRender` : it draws a sprite to the screen

The other classes are used to store information about a SpriteFrame:
1. `Pivot` stores the pivot point of a frame
2. `Rect` store the (X,Y) position of an image inside of a sritesheet and that image size (Width, Height)
3. `Size` store the size (With, Height) of the image

## Getting started

### Prerequisites
You must have Monogame installed.  
For this example, I'm using `Monogame 3.8.1.303`  
You must also have Free Texture Packer installed  
For this example, I'm using `Free Texture Packer 0.6.7`  

### Installing
You have two ways to install it in your project
1. Use the sources  
    Simply copy the `FreeTexturePackerLoader` folder in your monogame project

2. Get IT through Nuget  

        dotnet add package FreeTexturePacker.Lib --version 1.0.0

### Using Free Texture Packer to create a spritesheet
1. Open Free Texture Packer
2. Add the images in the `Examples/images` folder
3. Set texture name to `chess`
4. Set texture format to `png`
5. Check the `Remove file ext` box
6. For the packer use `OptimalPacker`
7. Uncheck `Allow trim` box
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
    
10. Check `Allow trim` and `Allow rotation` boxes
11. For file extension, write `json`
12. Click `Save`
13. Click `Export`
14. Locate the Content directory of your monogame project and click `Select Folder`

It'll generate two files: `chess.json` and `chess.png`.  
The first contains informations about the spritesheet such as the posistion and size all the images inside that spritesheet and the last file is the actual spritesheet.

### Loading the spritesheet and using it with monogame
1. Create a monogame desktop project
2. Copy the `FreeTexturePackerLoader` folder inside of your monogame project or add it through nuget
2. At this using line at the top of your Game1.cs file `using FreeTexturePackerLoader;`
3. Create an instance of the SpriteSheetLoader in the `LoadContent` method

        var  spriteSheetLoader = new SpriteSheetLoader(Content);
4. Create aninstance of the SpriteRenderer

        private SpriteRender spriteRender;
    In the `LoadContent` method, add : 

        spriteRender = new SpriteRender(_spriteBatch);
5. Load the spritesheet

        private SpriteSheet spriteSheet;
    In the `LoadContent` method, add : 

        spriteSheet = spriteSheetLoader.Load("chess");
6. Draw a sprite from the spritesheet
    In the `Draw` method, add :

        spriteRender.Draw(spriteSheet.GetSprite("reine_blanc"), new Vector2(100, 100), Color.White);
    You should see the white queen at the screen
7. Now try to show all the chess piece at the screen.

    You can find the full project in the `Example/ChessBoard Final`

## Contributing

Please read [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Authors

* **Sesso Kosga** - *Initial work* - [senor16](https://github.com/senor16)

## License

This project is licensed under the MIT License - see the [licence.md](licence.md) file for details