# Free Texture Packer Loader

Un loader sprite sheet pour utiliser  [Free Texture Packer](https://free-tex-packer.com) avec [Monogame](https://monogame.net)

*Lire dans une autre langue : [English](Readme.md), [Français](Readme.fr.md)*

## Structure
Il y a quatre classes principales : 
1. `SpriteFrame` represente une image à l'intérieur d'une spritesheet
2. `SpriteSheet` repressente un ensemble de SpriteFrame
3. `SpriteSheetLoader` sert à charger une spritesheet générée par Free Texture Packer
4. `SpriteRender` sert à afficher SpriteFrame

Les autres classes stockent des informations concernant une SpriteFrame :
1. `Pivot` stocke le point pivot d'une image 
2. `Rect` stocke la position (X,Y) d'une image à l'intérieur d'une spritesheet et sa taille (Largeur, Hauteur)
3. `Size` stocke la taille (Largeur, Hauteur) d'une image

## Projet d'Example

### Prérequis
Vous devez avoir Monogame instalé 
Pour cet exemple, j'utilise `Monogame 3.8.1.303`  
Vous devez aussi avoir Free Texture Packer instalé
Pour cet exemple, j'utilise `Free Texture Packer 0.6.7`  


### Installing
Vous avez deux possibilités de l'installer dans votre projet
1. Utiliser les sources
    Copiez simplement le dossier `FreeTexturePackerLoader` dans votre projet monogame

2. L'obtenir par Nuget

        dotnet add package FreeTexturePacker.Lib --version 1.0.0

### Utiliser Free Texture Packer pour créer une spritesheet
1. Ouvrez Free Texture Packer
2. Ajoutez les images du sossier `Examples/images`
3. Nommer la texture `chess`
4. Selectionner le format `png`
5. Cochez la case `Remove file ext`
6. Pour le packer, utiliser `OptimalPacker`
7. Décocher la case `Allow trim` 
7. Choisissez le format `custom`
8. Cliquez sur le crayon juste à côté
9. Coller ce template d'export:

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
    
10. Cochez la case `Allow trim` et `Allow rotation`
11. Ecrivez `json` comme extension
12. Cliquez sur  `Save`
13. Cliquez sur `Export`
14. Identifiez le dossier Content de votre projet Monogame et cliquer sur `Select Folder`

Cela va générer deux fichiers : `chess.json` et `chess.png`.  
Le premier contient des informations concernant la spritesheet telles que la position et la taille des images qui la constituent; le second fichier est la spritesheet.

### Charger la spritesheet et l'utiliser avec Monogame
1. Créez un projet Monogame pour desktop
2. Copiez le dossier `FreeTexturePackerLoader` dans votre projet
2. Tout en haut du ficher Game1.cs, ajoutez `using FreeTexturePackerLoader;`
3. Créez une instance du SpriteSheetLoader dans la méthode `LoadContent`

        var  spriteSheetLoader = new SpriteSheetLoader(Content);
4. Créez une instance du SpriteRenderer

        private SpriteRender spriteRender;
    Dans la méthode `LoadContent`, ajoutez : 

        spriteRender = new SpriteRender(_spriteBatch);
5. Chargez la spritesheet

        private SpriteSheet spriteSheet;
    Dans la méthode `LoadContent`, ajoutez : 

        spriteSheet = spriteSheetLoader.Load("chess");
6. Afficher un sprite à partir de la spritesheet
    Dans la méthode `Draw`, ajoutez : 

        spriteRender.Draw(spriteSheet.GetSprite("reine_blanc"), new Vector2(100, 100), Color.White);
    Vous devrez voir l'image de la reine blance à l'écran.

7. Maintenant, essayez d'afficher toutes les pièces à l'écran

    Vous trouverez le projet complet dans le dossier `Example/ChessBoard Final`

## Contribution

Veuillez lire le fichier [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) concernant la conduite à tenir pour contribuer à ce projet.

## Auteurs

* **Sesso Kosga** - *Travail inital* - [senor16](https://github.com/senor16)

## License

Ce projet utilise la licence MIT - voir le fichier [licence.md](licence.md) pour plus de détails