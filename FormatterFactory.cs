using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Formatter.utilities;

namespace Formatter
{
    public class FormatterFactory
    {
        public ISqlFormatter GetFormatter(string queryType){

            ISqlFormatter formatter = null;
            switch ((QueryTypes)(Enum.Parse( typeof(QueryTypes),queryType)))
            {
                case QueryTypes.INSERT
                : formatter = new InsertQueryFormatter();
                  break;
                case QueryTypes.UPDATE
                : formatter = new UpdateQueryFormatter();
                    break;
                case QueryTypes.SELECT
                : formatter = new SelectQueryFormatter();
                    break;
                case QueryTypes.DELETE
                :formatter = new DeleteQueryFormatter();
                break;
            }

            return formatter;
        }
    }
}
