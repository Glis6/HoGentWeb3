using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Hand
    {

        public IList<BlackJackCard> _cards = new List<BlackJackCard>();

        public int NrOfCards => _cards.Count;

        public int Value => CalculateValue();

        public IEnumerable<BlackJackCard> Cards => _cards;

        public Hand() {}

        public void AddCard(BlackJackCard blackJackCard)
        {
           _cards.Add(blackJackCard);
        }

        public int CalculateValue()
        {
            int totalValue = 0;
            foreach (BlackJackCard blackJackCard in _cards)
            {
                if (blackJackCard.FaceUp)
                {
                    int cardValue = blackJackCard.Value;
                    if (cardValue == 1 && totalValue + 11 <= 21)
                        cardValue = 11;
                    totalValue += cardValue;
                }
            }
            return totalValue;
        }

        public void TurnAllCardsFaceUp()
        {
            foreach (BlackJackCard blackJackCard in _cards)
            {
               if(!blackJackCard.FaceUp)
                    blackJackCard.TurnCard();
            }
        }
    }
}
