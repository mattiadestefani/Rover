using Microsoft.Extensions.Configuration;
using Rover.Model;
using System;
using System.IO;

namespace Rover.Writer
{
    public class CsvWriter : IWriter
    {
        private readonly IConfiguration _configurazione;
        public CsvWriter(IConfiguration config)
        {
            _configurazione = config;
        }
        public void LogRover(IRobot rover)
        {
            File.AppendAllText(_configurazione["outputFile"], $"({rover.Posizione.X},{rover.Posizione.Y},{rover.Direzione.Descrizione}){Environment.NewLine}");
        }

        public void EraseAllCommand()
        {
            File.WriteAllText(_configurazione["inputFile"], string.Empty);
        }
    }
}
