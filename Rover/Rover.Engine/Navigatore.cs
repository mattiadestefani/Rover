using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rover.Model;
using Rover.Reader;
using Rover.Writer;
using System;
using System.Collections.Generic;

namespace Rover.Engine
{
    public class Navigatore
    {
        public IRobot rover;
        private readonly IConfiguration _configurazione;
        private readonly IWriter _writer;
        private readonly ILogger<Navigatore> _logger;
        private readonly IReader _reader;
        private List<IOstacolo> _ostacolo;

        public Navigatore(IConfiguration configuration, IReader reader, IWriter writer, ILogger<Navigatore> logger)
        {
            _configurazione = configuration;
            _reader = reader;
            _writer = writer;
            _logger = logger;
        }
        public void SetPianeta()
        {
            var coordinata = new Random();
            var nogg = 0;
            _ostacolo = new();
            do
            {
                var posizione = new Posizione
                {
                    X = coordinata.Next(0, Convert.ToInt32(_configurazione["numberRow"]) - 1),
                    Y = coordinata.Next(0, Convert.ToInt32(_configurazione["numberColumn"]) - 1)
                };
                if (!RoverCollisionCenter.CheckCollisionObject(posizione, _ostacolo))
                {
                    if (nogg < Convert.ToInt32(_configurazione["numbOstacoli"]))
                    {
                        _ostacolo.Add(new Ostacolo(posizione));
                        _logger.LogInformation($"ostacolo {nogg} in posizione ({posizione.X},{posizione.Y})");
                    }
                    else
                    {
                        rover = new Roover(posizione);
                        _logger.LogInformation($"rover INIZIA ({rover.Posizione.X},{rover.Posizione.Y}) DIR {rover.Direzione.Descrizione}");
                    }
                    nogg++;
                }
            } while (nogg <= Convert.ToInt32(_configurazione["numbOstacoli"]));
        }

        public void StartRoverAction()
        {
            var comandi = _reader.GetComando();

            var maxX = Convert.ToInt32(_configurazione["numberRow"]);
            var maxY = Convert.ToInt32(_configurazione["numberColumn"]);
            Posizione futurePosition = new();
            foreach (var single in comandi)
            {
                for (var ii = 0; ii < single.Length; ii++)
                {
                    if (single[ii] == 'L' || single[ii] == 'R')
                    {
                        rover.RotateTo(single[ii]);
                        continue;
                    }
                    futurePosition = CalculateFuturePosition(single[ii] == 'F' ? 1 : -1, rover, maxX, maxY);

                    if (!RoverCollisionCenter.CheckCollisionObject(futurePosition, _ostacolo)) rover.Posizione = futurePosition;
                }
                 _writer.LogRover(rover);
                 _logger.LogInformation($"rover SPOSTAMENTO ({rover.Posizione.X},{rover.Posizione.Y}) DIR {rover.Direzione.Descrizione}");
            }
            _writer.EraseAllCommand();
        }
        private static Posizione CalculateFuturePosition(int move, IRobot rover, int maxX, int maxY) =>
            RoverCollisionCenter.PackmanEffect(new Posizione()
            {
                X = rover.Posizione.X + rover.Direzione.DirectionX * move,
                Y = rover.Posizione.Y + rover.Direzione.DirectionY * move
            }, maxX, maxY);
    }
}
