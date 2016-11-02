using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Hand
    {
        public int NrOfCards { get; }

        public int Value { get; }

        public IEnumerable<BlackJackCard> Cards;

        public IList<BlackJackCard> _cards;

        public Hand()
        {
            
        }

        public void AddCard(BlackJackCard blackJackCard)
        {
            throw new NotImplementedException();
        }

        public int CalculateValue()
        {
            throw new NotImplementedException();
        }

        public void TurnAllCardsFaceUp()
        {
            throw new NotImplementedException();
        }
    }
}
