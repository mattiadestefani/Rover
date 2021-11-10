using Rover.Model;
using System.Collections.Generic;
using System.Linq;

namespace Rover.Engine
{
    public static class RoverCollisionCenter
    {
        public static bool CheckCollisionObject(IPosizione posizione, IEnumerable<IOstacolo> ostacoli) => 
            ostacoli.Any(x => x.Posizione.X.Equals(posizione.X) && x.Posizione.Y.Equals(posizione.Y));

        public static Posizione PackmanEffect(Posizione position, int maxX,int maxY)
        {
            position.X = OutFromLeft(OutFromRigth(position.X, maxX), maxX);
            position.Y = OutFromLeft(OutFromRigth(position.Y, maxY), maxY);
            return position; 
        }

        private static int OutFromLeft(int coordinate, int max) => coordinate < 0 ? max - 1 : coordinate;
        private static int OutFromRigth(int coordinate, int max) => coordinate >= max ? 0 : coordinate;
    }
}
