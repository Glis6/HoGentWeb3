using Newtonsoft.Json;

namespace BlackJackGame.Models {
    public class Card {

        #region Properties
        
        public FaceValue FaceValue { get; private set; }
        
        public Suit Suit { get; private set; }
        #endregion

        #region Constructors
        public Card(Suit suit, FaceValue faceValue) {
            Suit = suit;
            FaceValue = faceValue;
        }
        #endregion

        }       
    }
