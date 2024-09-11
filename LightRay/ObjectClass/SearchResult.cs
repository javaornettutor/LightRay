using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ObjectClass
{
    public class SearchResult
    {
        public string total_results { get; set; }
        public string query { get; set; }
        public List<Slip> slips { get; set; }
    }

}
