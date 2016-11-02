using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Deck
    {
        private readonly Random _random = new Random();

        public IList<BlackJackCard> _cards;

        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                {
                    _cards.Add(new BlackJackCard(suit, faceValue));
                }
            }
        }

        public BlackJackCard Draw()
        {
            if(_cards.Count == 0)
                throw new InvalidOperationException();
            BlackJackCard card = _cards.First();
            _cards.Remove(card);
            return card;
        }

        private void Shuffle()
        {
            _cards.OrderBy<BlackJackCard, int>((card) => _random.Next());
        }
    }
}
