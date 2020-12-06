using System;
using SplashKitSDK;

namespace Player
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow; //create window object for the player

            //assignment statement for window 
            gameWindow = new Window( "Player Window", 800, 600 );
            RobotDodge robotDodge = new RobotDodge( gameWindow );
        


            while ( !robotDodge.Quit && !gameWindow.CloseRequested )
            {
                
                SplashKit.ProcessEvents();
                robotDodge.HandleInput();
                robotDodge.Update();
                robotDodge.Update();
                robotDodge.Draw();
    
                
            }
            gameWindow.Close();
        }

    }
    
}
