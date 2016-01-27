using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formatter
{
    public interface ISqlFormatter
    {
       String FormatQuery(String query);
    }
}
