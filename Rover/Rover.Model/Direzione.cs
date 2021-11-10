namespace Rover.Model
{
    public abstract class Direzione
    {
        public char Descrizione { get; }
        public int DirectionX { get; }
        public int DirectionY { get;  }

        public Direzione(char descr, int dx, int dy)
        {
            Descrizione = descr;
            DirectionX = dx;
            DirectionY = dy;
        }
    }
}
