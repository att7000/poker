using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class TableCards:Cards
    {
        public List<Cards> cards;
        public TableCards () { cards = new List<Cards>();  }
        public void CardsOnTable(List<Cards> AllCards)
        {
            
            for (int i = 0; i < 5; i++)
            {
                var x = TakeCard(AllCards);
                cards.Add(x);
                
            }
      
        }
    }
}
