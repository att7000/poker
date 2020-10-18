using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    class PlayerHand:Cards
    {
        public List<Cards> hand;
         public string Player;
        public PlayerHand(string p) { hand = new List<Cards>(); Player = p; }
        public void CardsHave (List<Cards> AllCards)
        {
          
            var x = TakeCard(AllCards);
           // PrintCard(x);
            hand.Add(x);
            x = TakeCard(AllCards);
           // PrintCard(x);
            hand.Add(x);
           
        }
      
        
        

    }
}
