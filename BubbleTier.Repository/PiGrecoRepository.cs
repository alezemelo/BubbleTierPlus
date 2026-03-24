using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleTier.Repository
{
    public class PiGrecoRepository: INumbersRepository
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
