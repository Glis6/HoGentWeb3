using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SnakeEyesGame.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Dice
    {
        private static Random _random = new Random();

        [JsonProperty]
        public int Pips { get; private set; } = 6;

        public Dice() { }

        public void Roll()
        {
            Pips = _random.Next(1, 6);
        }
    }
}
