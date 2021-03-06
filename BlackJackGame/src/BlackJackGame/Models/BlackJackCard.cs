﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class BlackJackCard: Card
    {
        public bool FaceUp { get; private set; } = false;

        public int Value { get; private set; } = 0;

        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue)
        {

        }

        public void TurnCard()
        {
            FaceUp = !FaceUp;
            if (FaceUp)
            {
                Value = (int) FaceValue;
            }
            else
            {
                Value = 0;
            }
        }
    }
}
