using System;

namespace Rover.Model
{
    public static class FactoryStrategyR
    {
        public static Direzione BuildRotazioneR(char rotazione) => rotazione switch
        {
            'N' => new DirezioneE(),
            'S' => new DirezioneW(),
            'E' => new DirezioneS(),
            'W' => new DirezioneN(),
            _ => throw new Exception("No coordinate")
        };
    }
}
