using System;
using System.Collections.Generic;
using System.Linq;

namespace DiakKonzol
{
    internal class Diak
    {
        public string Nev { get; set; }
        public string Osztaly { get; set; }
        public List<int> Jegyek { get; set; }     // LISTA az osztályon belül: több jegy egy diákhoz
        public int Hianyzas { get; set; }

        public Diak(string sor)
        {
            // A sor: "Tóth Gergő;11.A;3,4,4,3,4,5,5;24"
            // Először ;-vel bontunk, a jegyek mezőt pedig utána még egyszer ,-vel.
            string[] m = sor.Split(';');
            Nev = m[0];
            Osztaly = m[1];

            // KÉTSZINTŰ SPLIT: "3,4,4,3" -> ["3","4","4","3"] -> mindegyikből int -> lista
            Jegyek = new List<int>();
            foreach (string j in m[2].Split(','))
            {
                Jegyek.Add(int.Parse(j));
            }
            // Ugyanez egy sorban: Jegyek = m[2].Split(',').Select(int.Parse).ToList();

            Hianyzas = int.Parse(m[3]);
        }

        // Metódusok az osztályban (1_TECHNIKAK/18): ezeket a Program.cs-ben d.Atlag() formában hívjuk.
        public double Atlag()
        {
            return Jegyek.Average();
        }

        // All = MINDEN elemre igaz-e a feltétel (itt: minden jegy 5-ös)
        public bool Kituno()
        {
            return Jegyek.All(j => j == 5);
        }

        // Contains = benne van-e egy adott érték a listában
        public bool VanEgyese()
        {
            return Jegyek.Contains(1);
        }
    }
}
