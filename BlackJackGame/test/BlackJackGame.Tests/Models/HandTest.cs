using System.Collections;
using System.Collections.Generic;
using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models
{

    public class HandTest
    {
        private Hand _aHand;

        public HandTest()
        {
            _aHand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards()
        {
            Assert.Equal(0, _aHand.NrOfCards);
        }
        [Fact]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            Assert.Equal(1, _aHand.NrOfCards);
        }
        [Fact]
        public void AddCard_AHandWithCards_AddsACard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            Assert.Equal(2, _aHand.NrOfCards);
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _aHand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact]
        public void Value_EmptyHand_IsZero()
        {
            Assert.Equal(0, new Hand().Value);
        }

        [Fact]
        public void Value_HandWith6and5_Is11()
        {
            TestHandValues(new FaceValue[] {FaceValue.Six, FaceValue.Five}, 11);
        }

        [Fact]
        public void Value_HandWith5AndKing_Is15()
        {
            TestHandValues(new FaceValue[] { FaceValue.Five, FaceValue.King }, 18);
        }

        private void TestHandValues(FaceValue[] faceValues, int expectedResult)
        {
            IList<BlackJackCard> _blackJackCards = new List<BlackJackCard>();
            foreach (FaceValue faceValue in faceValues)
            {
                _blackJackCards.Add(new BlackJackCard(Suit.Hearts, faceValue));
            }
            foreach (BlackJackCard blackJackCard in _blackJackCards)
            {
                blackJackCard.TurnCard();
                _aHand.AddCard(blackJackCard);
            }
            Assert.Equal(_aHand.Value, expectedResult);
        }

        [Fact]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown()
        {
            BlackJackCard card = new BlackJackCard(Suit.Clubs, FaceValue.Five);
            card.TurnCard();
            _aHand.AddCard(card);
            card = new BlackJackCard(Suit.Clubs, FaceValue.Five);
            _aHand.AddCard(card);
            Assert.Equal(_aHand.Value, 5);
        }

        [Fact]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11()
        {
            BlackJackCard card = new BlackJackCard(Suit.Clubs, FaceValue.Five);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(_aHand.Value, 5);
            card = new BlackJackCard(Suit.Clubs, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(_aHand.Value, 16);
        }

        [Fact]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1()
        {
            BlackJackCard card = new BlackJackCard(Suit.Clubs, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(_aHand.Value, 11);
            card = new BlackJackCard(Suit.Clubs, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(_aHand.Value, 12);
        }
    }
}
