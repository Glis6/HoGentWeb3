﻿using System.Collections.Generic;
using BlackJackGame.Models;

namespace BlackJackGame.Tests.Models.DeckStubs {
    public class DealerWinsPlayerBurnsDeck : Deck {

        public DealerWinsPlayerBurnsDeck() {
            _cards = new List<BlackJackCard>
            {
                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),

                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
