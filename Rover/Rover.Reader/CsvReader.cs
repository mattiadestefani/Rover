using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace Rover.Reader
{
    public class CsvReader : IReader
    {
        private readonly IConfiguration _configurazione;
        public CsvReader(IConfiguration config)
        {
            _configurazione = config;
        }
        public IEnumerable<string> GetComando()
        {
            using var stramreader = new StreamReader(_configurazione["inputFile"]);
            while (!stramreader.EndOfStream)
            {
                yield return stramreader.ReadLine();
            }
        }
        
    }
}
