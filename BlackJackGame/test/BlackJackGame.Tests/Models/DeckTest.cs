using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models
{
    public class DeckTest
    {
        [Fact]
        public void DrawReturnsTypeBlackJackCard()
        {
            Assert.Equal(new Deck().Draw().GetType(), typeof(BlackJackCard));
        }

        [Fact]
        public void ConstructorHas52Cards()
        {
            Assert.Equal(new Deck()._cards.Count, 52);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenEmptyDeck()
        {
            Deck deck = new Deck();
            deck._cards = new List<BlackJackCard>();
            Assert.Throws<InvalidOperationException>(() => deck.Draw());
        }
    }
}
