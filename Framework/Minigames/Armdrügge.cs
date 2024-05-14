using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Framework.Minigames.MinigameDefClasses;


public class MyMinigame6 : MinigameDefBase
{


    public override string BackgroundImage { get; set; } = "/images/Armdrücken test.jpg";

    [Element]
    public Rectangle Recttop { get; set; }
    [Element]
    public Rectangle Rectleft { get; set;}
    [Element]
    public Rectangle Rectbottom { get; set;}
    [Element]
    public Rectangle Rectright { get; set;}
    [Element]
    public Rectangle Rectrightr { get; set;}
    [Element]
    public Rectangle Rectleftr { get; set;}
    [Element]
    public Rectangle Recttopr { get; set;}
    [Element]
    public Rectangle Rectbottomr { get; set;}

    public GameObjectContainer<Rectangle> RectRot {get; set;} = new();


    public GameObjectContainer<Rectangle> Rects {get; set;} = new();
    public MyMinigame6()
    {
        Rectleft = new()
        {
            X = 150,
            Y = 150,
            Width = 20,
            Height = 700,
            Fill = "black",
            // OnClick = spawnRect,
        };

        Rectleftr = new()
        {
            X = 1350,
            Y = 150,
            Width = 20,
            Height = 700,
            Fill = "black",
        };
   
        Recttop = new()
        {
            X = 150,
            Y = 150,
            Width = 100,
            Height = 20,
            Fill = "black",
        };

        Recttopr = new()
        {
            X = 1350,
            Y = 150,
            Width = 100,
            Height = 20,
            Fill = "black",
        };

        Rectright = new()
        {
            X = 249,
            Y = 150,
            Width = 20,
            Height = 700,
            Fill = "black",
        };

        Rectrightr = new()
        {
            X = 1449,
            Y = 150,
            Width = 20,
            Height = 700,
            Fill = "black",
        };

        Rectbottom= new()
        {
            X = 150,
            Y = 830,
            Width = 100,
            Height = 20,
            Fill = "black",
        };

        Rectbottomr= new()
        {
            X = 1350,
            Y = 830,
            Width = 100,
            Height = 20,
            Fill = "black",
        };

        Rects.Add(Rectbottomr);
        Rects.Add(Recttopr);
        Rects.Add(Rectleftr);
        Rects.Add(Rectrightr);
        Rects.Add(Rectbottom);
        Rects.Add(Rectright);
        Rects.Add(Recttop);
        Rects.Add(Rectleft);

        AddElement(
        new Rectangle()
        {
            X = 200,
            Y = 730,
            Width = 19,
            Height = 60,
            Fill = "transparent",
            Stroke = "orange",
            StrokeWidth = 100
        }
        );
  
        Update();
    }


 public void spawnRect(EventArgs args)
    {

    Random rnd = new Random();

    int randomx = rnd.Next(1,1900);
    int randomy = rnd.Next(1,1080);
        
            var rect = new Rectangle()
            {
                Id = "rectr",
                X = randomx,
                Y = randomy,
                Width = 50,
                Height= 50,
                Fill = "red",
                OnClick = (args) => {RectRot.KillId("rectr"); Update();},
                
                
                
            };
            AddElement(rect);
            RectRot.Add(rect);
        
        Update();
    }
   
}


