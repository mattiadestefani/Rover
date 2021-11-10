namespace Rover.Model
{
    public interface IRobot
    {
        IPosizione Posizione { get; set; }
        Direzione Direzione { get; set; }
        void RotateTo(char rotazione);
    }
}
