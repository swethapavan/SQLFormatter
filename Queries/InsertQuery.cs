using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatter
{
    public class InsertQuery
    {
        public string Table { get; set; }
        public List<String> Columns { get; set; }
        public List<String> Values { get; set; }
    }
}
