using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Cards
    {
        public int number;
        public int mast;
        public Random rnd = new Random();

        static readonly Dictionary<int, string> Masti = new Dictionary<int, string>
        {
    {1, "h"},
    {2, "d"},
    {3, "c"},
    {4, "s"}
        };
        public static List<Cards> Generate()
        {
            List<Cards> Koloda = new List<Cards>();
            

            for (int j = 1; j < 5; j++)
                for (int i = 2; i < 15; i++)
                {
                    Cards x = new Cards
                    {
                        number = i,
                        mast = j
                    };
                    
                    Koloda.Add(x);
                }
            return Koloda;
        }
        public  Cards TakeCard(List<Cards> A)
        {
            
            int i = rnd.Next(0, A.Count());
            Cards x = A[i];
            A.RemoveAt(i);
            return x;
        }
        public static string ConverString(int i)
        {
            string s;
            switch (i)
            {
                case 10: s = "T"; break;
                case 11: s = "J"; break;
                case 12: s = "Q"; break;
                case 13: s = "K"; break;
                case 14: s = "A"; break;
                default: s = i.ToString(); break;
            }
            return s;
        }
    }
}
