using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formatter.Common;

namespace Formatter
{
    public class UpdateQueryParser
    {
        public static UpdateQuery Parse(String input)
        {
            List<string> keywords = Constants.KEYWORDS.ToList();

            keywords.ForEach(x => input = input.Replace(x.ToLower(), x));

            string[] values = input.Trim().Split(keywords.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            UpdateQuery query = new UpdateQuery();
            query.Table = values[0].Trim();
            query.Columns = GetColumnValues(values[1]);
            if (values.Length > 2)
              query.Conditions = GetColumnValues(values[2]);

            return query;
        }

        private static Dictionary<string, string> GetColumnValues(string input)
        {
            Dictionary<string, string> conditions = new Dictionary<string, string>();
            string[] rawConditions = input.Split(new String[] { "AND", "and","," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rawConditions.Length; i++)
            {
                string[] condition = rawConditions[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                conditions.Add(condition[0].Trim(), condition[condition.Length - 1].Trim());
            }
            return conditions;
        }

    }
}
