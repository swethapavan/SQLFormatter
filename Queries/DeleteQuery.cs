using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatter
{
    public class DeleteQuery
    {
        public string Table { get; set; }
        public Dictionary<String, String> Conditions { get; set; }
    }
}
