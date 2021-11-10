using Rover.Engine;
using System;

namespace Rover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var myPlanet = new Navigatore();
            myPlanet.SetPianeta();
            myPlanet.StartRoverAction();
        }
    }
}
