using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formatter.Common;

namespace Formatter.Parser
{
    public class DeleteQueryParser
    {
        public static DeleteQuery Parse(String input)
        {
            List<string> keywords = Constants.KEYWORDS.ToList();
            keywords.ForEach(x => input = input.Replace(x.ToLower(), x));

            List<string> values = input.Trim().Split(keywords.ToArray(), StringSplitOptions.RemoveEmptyEntries).
                ToList();
            values.RemoveAll(x => { return  String.IsNullOrWhiteSpace(x); });
            DeleteQuery query = new DeleteQuery();
            query.Table = values[0].Trim();

            if (values.Count > 1)
            {
                query.Conditions = GetColumnValues(values[1]);
            }
            return query;
        }
        private static Dictionary<string, string> GetColumnValues(string input)
        {
            Dictionary<string, string> conditions = new Dictionary<string, string>();
            string[] rawConditions = input.Split(new String[] { "AND", "and", "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rawConditions.Length; i++)
            {
                string[] condition = rawConditions[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                conditions.Add(condition[0].Trim(), condition[condition.Length - 1].Trim());
            }
            return conditions;
        }

    }
}
