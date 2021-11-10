using System;

namespace Rover.Model
{
    public class Roover : IRobot
    {
        public IPosizione Posizione { get; set; }
        public Direzione Direzione { get; set; }

        public Roover(IPosizione posizione)
        {
            Posizione = posizione;
            Direzione = new DirezioneN();
        }

        public void RotateTo(char rotazione)
        {
            switch(rotazione)
            {
                case 'L': Direzione = FactoryStrategyL.BuildRotazioneL(Direzione.Descrizione);break;
                case 'R': Direzione = FactoryStrategyR.BuildRotazioneR(Direzione.Descrizione);break;
                default: throw new Exception("Comando indefinito");
            };
        }

    }
}
