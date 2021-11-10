using System;

namespace Rover.Model
{
    public static class FactoryStrategyL
    {
        public static Direzione BuildRotazioneL(char rotazione) => rotazione switch
        {
            'N' => new DirezioneW(),
            'S' => new DirezioneE(),
            'E' => new DirezioneN(),
            'W' => new DirezioneS(),
            _ => throw new Exception("No coordinate")
        };
    }
}
