using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formatter.Common;

namespace Formatter
{
    public class InsertQueryParser
    {
        public static InsertQuery Parse(String input)
        {
            List<string> keywords = Constants.KEYWORDS.ToList();

            keywords.ForEach(x => input = input.Replace(x.ToLower(), x));

            string[] values = input.Trim().Split(keywords.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            InsertQuery query = new InsertQuery();
            query.Table = GetTable(values[0].Trim());
            query.Columns = GetColumns(values[1].Trim());
            query.Values = values[1].Trim().Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return query;
        }

        private static String GetTable(string input)
        {
            int startIndexColumns = input.IndexOf("(") + 1;
            string table = input.Substring(0, startIndexColumns - 1);
            return table;
        }

        private static List<string> GetColumns(string input)
        {
            int startIndexColumns = input.IndexOf("(") + 1 ;
            int endIndexColumns = input.IndexOf(")") - 1;

            string rawcolumns = input.Substring(startIndexColumns, endIndexColumns - startIndexColumns + 1);

            return rawcolumns.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries).ToList<string>().ToList<string>();
        }
    }
}

