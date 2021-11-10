
namespace Rover.Model
{
    public class Ostacolo : IOstacolo
    {
        public IPosizione Posizione { get;  }
        public Ostacolo(IPosizione poszione)
        {
            Posizione = poszione;
        }

    }
}
