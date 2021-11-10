using System.Collections.Generic;

namespace Rover.Reader
{
    public interface IReader
    {
        IEnumerable<string> GetComando();
    }
}
