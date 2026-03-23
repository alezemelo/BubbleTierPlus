using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BubbleTier
{
    internal class PiGrecoRepository : INumbersRepository
    {
       
        public IEnumerable<int> GetAll()
        {
            double pi = Math.PI;
            string piString = pi.ToString("F" + Config.numeroDopoLaVirgola).Replace(",", ""); // Rimuove il punto decimale
            for (int i = 0; i < piString.Length; i++)
            {
                yield return int.Parse(piString[i].ToString());
            }
        }
    }
}
