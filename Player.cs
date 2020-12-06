using System;
using SplashKitSDK;

namespace Player
{
    public class Player
    {
        private Bitmap _PlayerBitmap; // field with private modifier
        public double X { get; private set; } // auto property without declaring variable
        public double Y { get; private set; } // auto property without declaring variable
        
        public bool Quit { get; private set; }

        //property declaring variable width
        public int Width 
        {
            get
            {
                return _PlayerBitmap.Width;     
               
            }
        }

        //propert declaring variable width
        public int Height
        {
            get
            {
                return _PlayerBitmap.Height;
            }
        }
        public Player(Window gameWindow) // method with parameter

        //constructor lines initialising fields and defining width and height of window 
        {
            this._PlayerBitmap = new Bitmap("player1", "Player.png");
            X = (gameWindow.Width - Width) /2; 
            Y = (gameWindow.Height - Height) /2;
            Quit = false;

        //method without parameters making the draw availabe in program
        }
        public void Draw() 
        {
            _PlayerBitmap.Draw( X ,Y) ;
        }

        public void HandleInput()
        
        {
            const int SPEED = 5;
            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                X += SPEED;
               
            }
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                X -= SPEED;
                
            }
             if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                Y -= SPEED;
               
            }
            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                Y += SPEED;
                
            }
            if (SplashKit.KeyDown(KeyCode.EscapeKey))
            {
                Quit = true;
            }
            
        }

        public void StayOnWindow(Window limit)
        {
            const int GAP = 10;
            if (X < GAP)
            {
                X = GAP;
            }
            if (X > (limit.Width - _PlayerBitmap.Width))
            {
                X = limit.Width - _PlayerBitmap.Width;
            }
            if (Y < GAP)
            {
                Y = GAP;
            }
            if (Y > (limit.Height - _PlayerBitmap.Height))
            {
                Y = limit.Height - _PlayerBitmap.Height;
            }

        }
        public bool CollideWith( Robot robots )
        {

            return _PlayerBitmap.CircleCollision( X, Y, robots.CollisionCircle );

        }
       
    }
    
}
