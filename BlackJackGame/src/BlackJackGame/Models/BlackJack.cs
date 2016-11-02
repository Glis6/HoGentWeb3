using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        public bool FaceDown;

        public bool FaceUp;

        public Hand PlayerHand;

        public Hand DealerHand;

        public Deck _deck;

        public GameState GameState;

        public BlackJack() : this(new Deck())
        {

        }

        public BlackJack(Deck deck)
        {
            _deck = deck;
        }

        public void AddCardToHand(Hand hand, bool faceUp)
        {
            throw new NotImplementedException();
        }

        public void AdjustGameState(GameState? gameState)
        {
            throw new NotImplementedException();
        }

        public void Deal()
        {
            throw new NotImplementedException();
        }

        public string GameSummany()
        {
            throw new NotImplementedException();
        }

        public void GivePlayerAnotherCard()
        {
            throw new NotImplementedException();
        }

        public void LetDealerFinalize()
        {
            throw new NotImplementedException();
        }

        public void PassToDealer()
        {
            throw new NotImplementedException();
        }
    }
}
