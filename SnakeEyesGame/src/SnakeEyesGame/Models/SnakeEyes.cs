using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SnakeEyesGame.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SnakeEyes
    {
        [JsonProperty]
        private Dice _eye1 = new Dice();
        [JsonProperty]
        private Dice _eye2 = new Dice();

        public int Eye1 => _eye1.Pips;

        public int Eye2 => _eye2.Pips;

        public bool HasSnakeEyes => Eye1 == 2 && Eye2 == 2;

        [JsonProperty]
        public int Total { get; private set; } = 0;

        public SnakeEyes() { }

        public void Play()
        {
            _eye1.Roll();
            _eye2.Roll();
            Total = Eye1 + Eye2;
        }
    }
}
