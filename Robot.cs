using System;
using SplashKitSDK;
using System.Drawing;
using Color = SplashKitSDK.Color;

namespace Player
{
    public abstract class Robot
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Color MainColor
        {
            get; private set;
        }

        private Vector2D Velocity
        {
            get; set;
        }
        public int Width
        {
            get
            {
                return 50;
            }
        }
        public int Height
        {
            get
            {
                return 50;
            }
        }
        public Circle CollisionCircle
        {
            get
            {
                Circle _CollisionCircle;
                _CollisionCircle = SplashKit.CircleAt( X + 25, Y - 25, 20 );
                return _CollisionCircle;
            }
        }

        public Robot( Window gameWindow, Player player )
        {
            //X = SplashKit.Rnd( gameWindow.Width - Width );
            //Y = SplashKit.Rnd( gameWindow.Height - Height );
                 
            
            //Lets test with starting at top left... 
            X = 0;
            Y = 0;
            
            //Randomly pick... Top / Bottom or Left / Right

            if (SplashKit.Rnd() < 0.5 )
            {
                //We picked... Top / Bottom
                //Start by picking a random position left to right (X)
        
                X = SplashKit.Rnd( gameWindow.Width );

                //Now work out if we are top or bottom?
                if ( SplashKit.Rnd() < 0.5)
                {
                    Y = -Height; //Top... so above top
        
                } 
                else
                {
                    Y = gameWindow.Height; //Bottom... so below bottom
                }
            }
            else
            {
                Y = SplashKit.Rnd( gameWindow.Height );
                
                //We picked... Left /Right
                if ( SplashKit.Rnd() < 0.5 )
                {
                    X = -Width;
                }
                else
                {
                    X = gameWindow.Width;
                }
            }

            

            MainColor = Color.RandomRGB( 200 );
            const int SPEED = 4;

            //Get a Point for the Robot
            Point2D fromPt = new Point2D() 
            { 
                X = X, Y = Y 
            };

            //Get a Point for the Player
            Point2D toPt = new Point2D()
            {
                X = player.X, Y = player.Y
            };

            //Calculate the direction to head
            Vector2D dir;
            dir = SplashKit.UnitVector ( SplashKit.VectorPointToPoint ( fromPt, toPt ));
            
            //Set the speed and assign to the Velocity
            Velocity = SplashKit.VectorMultiply ( dir, SPEED );

            //Using vector maths to calculate the vector that will store the direction and distance to travel.
            //Internally, the Vector2D is just storing an X and a Y offset. This represents the distance to travel each update.

        
        }

        public void Update()
        {
            //This will move the Robot by the amount in its Velocity property.
            X += Velocity.X;
            Y += Velocity.Y;

        }
        public abstract void Draw();
        
           

        public Boolean IsOffScreen( Window screen )
        {
            return ( X < -Width || Y < -Height || Y > screen.Height || X > screen.Width );
        }
    }

    public class Boxy : Robot
    {
        public Boxy ( Window boxyW, Player player ) : base ( boxyW, player )
        {


        }
        public override void Draw()
        {
            double leftX, rightX;
            double eyeY, mouthY;

            leftX = X + 12;
            rightX = X + 27;
            eyeY = Y + 10;
            mouthY = Y + 30;

            SplashKit.FillRectangle( Color.Gray, X, Y, Width, Height );
            SplashKit.FillRectangle( MainColor, leftX, eyeY, 10, 10 );
            SplashKit.FillRectangle( MainColor, rightX, eyeY, 10, 10 );
            SplashKit.FillRectangle( MainColor, leftX, mouthY, 25, 10 );
            SplashKit.FillRectangle( MainColor, leftX + 2, mouthY + 2, 21, 6 );
        }

    }

    public class Roundy : Robot
    {
        public Roundy ( Window roundyW, Player player ) : base ( roundyW, player )
        {

        }

        public override void Draw() 
        {

            double leftX, midX, rightX;
            double midY, eyeY, mouthY;

            leftX = X + 17;
            midX = X + 25;
            rightX = X + 33; 

            midY = Y + 25;
            eyeY = Y + 20;
            mouthY = Y + 35;

            SplashKit.FillCircle( Color.White, midX, midY, 25 );
            SplashKit.DrawCircle( Color.Gray, midX, midY, 25 );
            SplashKit.FillCircle( MainColor, leftX, eyeY, 5 );
            SplashKit.FillCircle( MainColor, rightX, eyeY, 5 );
            SplashKit.FillEllipse( Color.Gray, X, eyeY, 50, 30 );
            SplashKit.DrawLine( Color.Black, X, mouthY, X + 50, Y + 35 );
            
        }
    }
}
