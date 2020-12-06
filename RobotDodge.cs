using System;
using SplashKitSDK;

using System.Collections.Generic;

namespace Player
{
    
    public class RobotDodge
    {
        private Player _Player;
        private Window _GameWindow;

        private Robot _TestRobot;

        private List < Robot > _Robots = new List< Robot > ();

        private List < Robot > _CollisionRobots;

        private int testRobots = 1;



        //Add the Quit read only property. 
        //This can just ask the Player if they have quit,returning the answer it gets from the player.
        public bool Quit
        {
            get
            {
                return _Player.Quit;
            }
        }

        public RobotDodge ( Window gameWindow )
        {

            _GameWindow = gameWindow;
            _Player = new Player( _GameWindow );
            //_TestRobot = RandomRobot( _GameWindow, _Player );

        }

        public void HandleInput ()
        {

            _Player.HandleInput ();
            _Player.StayOnWindow ( _GameWindow );

        }
        public void UpdateRobots()
        {
            
        }

        public void CheckCollisions()
        {
            _CollisionRobots = new List < Robot > ();

            foreach ( Robot robots in _Robots )
            {
                if ( _Player.CollideWith ( robots ) || robots.IsOffScreen ( _GameWindow ))
                {
                    _CollisionRobots.Add( robots );
                }
            }

            foreach ( Robot newRobots in _CollisionRobots )
            {
                _Robots.Remove ( newRobots );
            }

        }

        public void Update()
        {
            foreach ( Robot robots in _Robots )
            {
                robots.Update();
            }
            if ( SplashKit.Rnd( 0, 50 ) == 1 )
            {
                Robot newRobots = RandomRobot ( _GameWindow, _Player );
                _Robots.Add( newRobots );
                
            }
            CheckCollisions();
        

        }
        public void Draw()
        {

            _GameWindow.Clear( Color.White );
            
            foreach ( Robot robots in _Robots )
            {
                robots.Draw();
            }

            _Player.Draw();
            _GameWindow.Refresh(60);
            
        }
        public Robot RandomRobot( Window _GameWindow, Player player )
        {
            //int number = SplashKit.Rnd( 1, 3 );
            //Console.Write(number);

            if ( testRobots == 1)
            {
                _TestRobot = new Boxy( _GameWindow, _Player ); 
                testRobots++; 
            }
            else if ( testRobots == 2 )
            {
                _TestRobot = new Roundy( _GameWindow, _Player );
                testRobots++;
            }
            else
            {
                _TestRobot = new Roundy ( _GameWindow, _Player );
                testRobots = 1;
            }
            return _TestRobot;
        }
    }

}