using Rover.Model;

namespace Rover.Writer
{
    public interface IWriter
    {
        void LogRover(IRobot rover);

        void EraseAllCommand();
    }
}
