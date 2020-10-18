using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    class Players
    {
       public List<string> players;
        public Players() { players = new List<string>(); }
        public void CreatePlayers(int count)
        {
            
                    if (count > 1 && count < 10)
                    {
                        for (int i = 1; i <= count; i++)
                            players.Add($"Player {i}");
                    }
                    else count = 0;
            
        }
    }
}
