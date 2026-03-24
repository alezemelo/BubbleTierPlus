using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleTier.Repository
{
    public interface INumbersRepository
    {
        public IEnumerable<int> GetAll();
    }
    
}
