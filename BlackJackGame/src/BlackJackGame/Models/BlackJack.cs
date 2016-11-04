using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        private const bool FaceDown = false;

        private const bool FaceUp = true;

        public Hand PlayerHand = new Hand();

        public Hand DealerHand = new Hand();

        public Deck _deck = new Deck();

        public GameState GameState;

        public BlackJack() : this(new Deck())
        {
        }

        public BlackJack(Deck deck)
        {
            _deck = deck;
            Deal();
        }

        public void AddCardToHand(Hand hand, bool faceUp)
        {
            try
            {
                BlackJackCard blackJackCard = _deck.Draw();
                if (faceUp != blackJackCard.FaceUp)
                    blackJackCard.TurnCard();
                hand.AddCard(blackJackCard);
            }
            catch (InvalidOperationException)
            {
                AdjustGameState(GameState.GameOver);
            }
        }

        public void AdjustGameState(GameState? gameState)
        {
            if (gameState.HasValue)
                GameState = gameState.Value;
            if(PlayerHand.Value >= 21 || DealerHand.Value >= 21 || DealerHand.Value > PlayerHand.Value)
                GameState = GameState.GameOver;
        }

        public void Deal()
        {
            AddCardToHand(DealerHand, FaceUp);
            AddCardToHand(DealerHand, FaceDown);
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState(GameState.PlayerPlays);
        }

        public string GameSummary()
        {
            if (GameState != GameState.GameOver)
                return null;
            if (PlayerHand.Value == DealerHand.Value)
                return "Equal, dealer wins";
            if (PlayerHand.Value > 21)
                return "Player burned, dealer wins";
            if (DealerHand.Value > 21)
                return "Dealer burned, player wins";
            return DealerHand.Value > PlayerHand.Value ? "Dealer wins": "BLACKJACK";
        }

        public void GivePlayerAnotherCard()
        {
            if(GameState != GameState.PlayerPlays)
                throw new InvalidOperationException();
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState(GameState.DealerPlays);
        }

        public void LetDealerFinalize()
        {
            while (GameState != GameState.GameOver)
            {
                AddCardToHand(DealerHand, FaceUp);
                AdjustGameState(GameState.DealerPlays);
            }
        }

        public void PassToDealer()
        {
            AdjustGameState(GameState.DealerPlays);
            DealerHand.TurnAllCardsFaceUp();
            LetDealerFinalize();
        }
    }
}
