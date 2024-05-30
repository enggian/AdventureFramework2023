using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Framework.Sound;

namespace Framework.Minigames.MinigameDefClasses;

public class MyMinigame6 : MinigameDefBase
{
    public override string BackgroundImage { get; set; } = "/images/Arm_0_F.png";
    [Element]
    public Rectangle ProgressBar { get; set; }
    int enemycounter = 0;
    int clickcount = 400; // Wie oft man auf den Kreis gedrückt hat (für die Farben zustädnig)

    int clickcount2 = 400;
    int Ycord = 758; //Unterster Startpunkt
    int enemyYcord = 758;
    int score = 0;

    int tencount = 0;
    int circleX = 1200;

    int circleY = 500;
    int frog1 = 1;

    int soundint = 0;
    bool gameover = false;

    string redcol = "red";
    GameObjectContainer<Rectangle> Quadrate { get; set; } = new();

    public MyMinigame6()
    {
        AddElement(
                     new Rectangle()
                     {
                         // Progressbar links (Spieler)
                         Id = "Frog4",
                         X = 80,
                         Y = 100,
                         Width = 160,
                         Height = 160,
                         Fill = "transparent",
                         Stroke = "green",
                         StrokeWidth = 1,
                         OnClick = (args) =>

                         {  //ADITEM NOCH MACHEN FRAMEWORK UPDATEN
                             gamestart();
                             Elements.KillId("StartCircle");
                             Elements.KillId("Frog4");
                             Update();
                             frog1 = 3;

                         }

                     }
                 );

        AddElement(
              new Circle()
              {
                  //Hand zum klicken
                  Id = "StartCircle",
                  R = 10,
                  CX = 800,
                  CY = 640,
                  Fill = "yellow",
                  Stroke = "yellow",
                  StrokeWidth = 40,
                  OnClick = (args) =>
                  {
                      gamestart();
                      Elements.KillId("StartCircle");
                      Elements.KillId("Frog4");
                      Update();

                  },
              }
          );
    }
    public void gamestart()
    {

        BackgroundImage = "/images/Arm_1.png";
        Update();


        ProgressBar = new()
        {
            Id = "ProgressBar11",
            X = 350,
            Y = 50,
            Width = 400,
            Height = 35,
            Fill = "yellow"
        };
        AddElement(ProgressBar);
        Update();


        circlechanger();
        Update();



        _ = StartEnemyClick();
        Update();
    }

    public void sounds()
    {
        List<string> Gamesounds = new List<string> { "/audio/Armwrestling3.wav", "/audio/Armwrestling2.wav", "/audio/Armwrestling1.wav" };

        if (soundint >= 6)
        {
            Random rnd = new Random();
            int randomint = rnd.Next(0, 3);
            SoundService.PlaySound(Gamesounds[randomint]);
            soundint = 0;
        }
    }
    public void circlechanger()
    {
        AddElement(
      new Circle()
      {
          //Hand zum klicken
          Id = "Circle1",
          R = 60,
          CX = circleX,
          CY = circleY,
          Fill = redcol,
          Stroke = redcol,
          StrokeWidth = 40,
          OnClick = (args) =>
          {
              progressClick(Ycord, clickcount);
              soundint++;
              sounds();
              clickcount++;
              Update();
              imageswap();
              Elements.KillId("Circle1");
              circlechanger();
          }, //OnClick wird Funktion ausgeführt, die die Füllung macht und Ycord wird angepasst, damit es hoch geht
      }
  );
        Update();
    }

    async public void Progress()
    {
        while (clickcount2 > clickcount)
        {

            ProgressBar.Width = clickcount2;
            Update();
            await Task.Delay(5);
        }

        while (clickcount2 < clickcount)
        {

            ProgressBar.Width = clickcount2;
            Update();
            await Task.Delay(5);
        }


        Update();

    }

    public void imageswap()
    {


        if (clickcount2 >= 800)
        {
            score++;
            clickcount2 = 400;
            ProgressBar.Fill = "yellow";
        }
        else if (clickcount2 <= 0)
        {
            score--;
            clickcount2 = 400;
            ProgressBar.Fill = "yellow";
        }
        if (score == 0)
        {
            BackgroundImage = "/images/Arm_1.png";
            circleX = 1200;
            circleY = 500;
            Update();
            Elements.KillId("Circle1");
            circlechanger();
        }
        else if (score == 1)
        {
            BackgroundImage = "/images/Arm_4.png";
            circleX = 970;
            circleY = 720;
            Update();
            Elements.KillId("Circle1");
            circlechanger();
        }
        else if (score == -1)
        {
            BackgroundImage = "/images/Arm_2_.png";
            circleX = 1300;
            circleY = 500;
            Update();
            Elements.KillId("Circle1");
            circlechanger();
        }
        else if (score == -2)
        {

            Update();
            Elements.KillId("ProgressBar11");
            Elements.KillId("Circle1");
            Update();
            BackgroundImage = "/images/Arm_3.png";
            gameover = true;
            Update();
        }
        else if (score == 2)
        {
            ProgressBar.Fill = "transparent";
            BackgroundImage = "/images/Arm_5.png";
            redcol = "transparent";
            Update();
            gameover = true;
            Update();
        }

        Update();
    }

    public async Task StartEnemyClick()
    {
        using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(200));

        while (await timer.WaitForNextTickAsync() && gameover == false)
        {

            clickcount2 = clickcount2 + -30;


            switch (clickcount2)
            {
                case <= 300:
                    ProgressBar.Fill = "Red";  // Covers 0 to 25
                    Update();
                    break;

                case >= 500:
                    ProgressBar.Fill = "green";
                    Update();
                    break;
            }


            Progress();
            imageswap();
            Update();
        }
    }

    public void progressClick(int Ycord, int counter)
    {
        List<string> colors = new List<string> { "LightGoldenrodYellow", "yellow", "Gold", "orange", "DarkOrange", "red", "red" };
        //Stroke also Füllfarbe wird mit der Liste berechnet, für jeden Klick erhöht sich counter und somit verändert sich die Farbe
        if (gameover == false)
        {
            clickcount2 = clickcount2 + 12 * frog1;


            switch (clickcount2)
            {
                case <= 300:
                    ProgressBar.Fill = "Red";  // Covers 0 to 25
                    Update();
                    break;

                case >= 500:
                    ProgressBar.Fill = "green";
                    Update();
                    break;
            }


            Progress();
            Update();
        }
        Update();
    }

}