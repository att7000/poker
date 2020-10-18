using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Poker
{
    public class Combination : Cards
    {

        public IEnumerable<Cards> fullhand;
        public int[] Rezult = new int[7];
        public string Playername;
       
        public void CombiCheck()
        {


            var A = fullhand.GroupBy(p => p.number).Select(g => new { Name = g.Key, Count = g.Count() });
            string flagset = "";
            string s = "";

            foreach (var group in A)
            {
                s = ConverString(group.Name);
                if (group.Count == 2)
                {
                    Rezult[0] = 1;
                    Rezult[1] = group.Name;
                    var temp2 = fullhand.Where(p => p.number != group.Name);
                    var X= kikers(temp2);
                    Rezult[2] = X[0];
                    Rezult[3] = X[1];
                }
                if (group.Count == 3)
                {
                    flagset = "set";
                    Rezult[0] = 3;
                    Rezult[1] = group.Name;
                    var temp2 = fullhand.Where(p => p.number != group.Name);
                    var X = kikers(temp2);
                    Rezult[2] = X[0];
                    Rezult[3] = X[1];
                }
            }
            TwoPairCheck();


            StreetCheck();
            FlashCheck();
            
            foreach (var group in A)
            {
                if (group.Count == 3 && Rezult[0] == 1) 
                { 
                   // Console.WriteLine($"{Playername} have fullhouse");
                    Rezult[0] = 6; 
                }
                if (group.Count == 2 && flagset == "set") 
                { 
                   // Console.WriteLine($"{Playername} have fullhouse");
                    Rezult[0] = 6; }
                }
               
            
            QuadCheck();

            if (Rezult[0] == 0 && flagset == "")
            {
                IEnumerable<int> Array = fullhand.Select(p => p.number);
                int[] OrderedCards = Array.OrderByDescending(p => p).Distinct().ToArray();
                for (int j = 0; j < 5; j++)
                    Rezult[j + 1] = OrderedCards[j];
            }
            Console.Write($"    Rezult =");
            foreach (int i in Rezult)
               Console.Write($" {i}");
            Console.WriteLine();
        }
        private void QuadCheck()
        {
           
            var A = fullhand.GroupBy(p => p.number).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var group in A)

            {
                string s = ConverString(group.Name);
                if (group.Count == 4)
                {
                    Rezult[0] = 7;
                    Rezult[1] = group.Name;
                    //Console.WriteLine($"{Playername} have quad of {s}");
                }
                var temp2 = fullhand.Where(p => p.number != group.Name);
                var K= kikers(temp2);
                Rezult[2] = K[0];
            }
}
        private void TwoPairCheck()
        {
            var A = fullhand.GroupBy(p => p.number).Select(g => new { Name = g.Key, Count = g.Count() });
            var Pairs = A.Where(p => p.Count == 2).ToList(); 
             var Kikers = A.Where(p => p.Count == 1).ToList();
             var PairsOrdered = Pairs.OrderByDescending(p => p.Name).ToList();
            if (Pairs.Count >= 2)
            { Rezult[0] = 2;
                Rezult[1] = PairsOrdered[0].Name;
                Rezult[2] = PairsOrdered[1].Name;
                Rezult[3] = Kikers.Max(p=>p.Name);
            }

        }
        private void StreetCheck()
        {
            IEnumerable<int> Array = fullhand.Select(p => p.number);
            int[] OrderedCards = Array.OrderByDescending(p => p).Distinct().ToArray();


            for (int i = 0; i < OrderedCards.Length; i++)
            {
                int counter = 0;
                for (int j = i; j < OrderedCards.Count() - 1; j++)
                    if (OrderedCards[j] == OrderedCards[j + 1] + 1)
                    {
                        counter++;
                    }
                    else break;
                if (counter >= 4) { 
                    //Console.WriteLine($"{Playername} have street from  {ConverString(OrderedCards[i])}");
                    Rezult[0] = 4;
                    Rezult[1] = OrderedCards[i];
                    break;
                }
            }
        }
        private void FlashCheck()
            {
                var flash = fullhand.GroupBy(p => p.mast).Select(g => new { Name = g.Key, Count = g.Count() });
                foreach (var gr in flash)
                    if (gr.Count > 4)
                    {
                        Rezult[0] = 5;
                        Rezult[1] = fullhand.Max(p => p.number);
                        var top = fullhand.Where(p => p.mast == gr.Name);
                        //Console.WriteLine($"{Playername} have flash of {gr.Name} with {Kiker(top)} high ");
                    }
            }

        
        public int[] kikers(IEnumerable<Cards> fullhand)
        { 
            int[] x = fullhand.OrderByDescending(p=>p.number).Select(p=>p.number).ToArray();
          return x;
           }
    }
}
