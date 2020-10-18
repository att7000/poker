
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Poker
{


    public class Game:Form1
    {
        
        static readonly Dictionary<int, string> CombiName = new Dictionary<int, string>
        {
             {0, "kiker high"},
             {1, "Pair"},
             {2, "two pair"},
             {3, "Set"},
             {4, "Street"},
             {5, "Flash"},
             {6, "Fullhouse"},
             {7, "Quad"},
        };
        public  Combination FindWinner(List<Combination> A)
        {
            List<Combination> Winner = A.OrderByDescending(p => p.Rezult[0]).ThenByDescending(p=>p.Rezult[1]).ThenByDescending(p=>p.Rezult[2]).ThenByDescending(p=>p.Rezult[3]).ToList();
            return Winner[0];
        }
        //===============================================================================
        public void StartGame()
        {
                Players AllPlayers = new Players();
                AllPlayers.CreatePlayers(2);
                var AllCards = Cards.Generate();

              
                List<PlayerHand> Plh = new List<PlayerHand>();
                for (int i = 0; i < AllPlayers.players.Count; i++)
                {
                    PlayerHand hand1 = new PlayerHand(AllPlayers.players[i]);
                    Plh.Add(hand1);
                    Plh[i].CardsHave(AllCards);
                }

                TableCards Table = new TableCards();
                Table.CardsOnTable(AllCards);
               // ShowTableCard(Table.cards);
                List<Combination> CombinationOfEachPlayer = new List<Combination>();
                for (int i = 0; i < AllPlayers.players.Count; i++)
                {
                    Combination p1 = new Combination();
                    //Console.Write($"Карты Игрока {i + 1} : ");
                    p1.fullhand = Plh[i].hand.Union(Table.cards);
                    p1.Playername = $"Player {i + 1}";
                    CombinationOfEachPlayer.Add(p1);
                    //foreach (Cards card in p1.fullhand)
                    //    Console.Write(card.name + " ");
                    //Console.WriteLine();
                }

                //foreach (var Spisok in CombinationOfEachPlayer)
                //{
                //    Spisok.CombiCheck();
                //    Console.WriteLine($"{Spisok.Playername} have {CombiName[Spisok.Rezult[0]]} of {Cards.ConverString(Spisok.Rezult[1])}");
                //}
                //var winner=FindWinner(CombinationOfEachPlayer);
                //Console.WriteLine($"{winner.Playername} WIN with {CombiName[winner.Rezult[0]]}");


               
            
        }
    }
}
    

