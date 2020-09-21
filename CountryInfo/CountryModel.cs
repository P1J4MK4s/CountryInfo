using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo
{
    public class CountryModel
    {
        public string Name { get; set; }
        public int CallingCodes { get; set; }
        public string Capital  { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }
        public string Region { get; set; }
    }
}
