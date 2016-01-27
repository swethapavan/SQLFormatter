using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Formatter.Common;

namespace Formatter
{
    public class SelectQueryParser
    {
        public static SelectQuery Parse(String input)
        {
            List<string> keywords = Constants.KEYWORDS.ToList();

            keywords.ForEach(x => input = input.Replace(x.ToLower(), x));
           
            string[] values =  input.Trim().Split(keywords.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            SelectQuery query = new SelectQuery();
            query.Table = values[1].Trim();
            query.Columns = GetColumns(values[0]);
            if(values.Length > 2)
             query.Conditions = GetConditions(values[2]);

            return query;
        }
    
        private  static Dictionary<string,string> GetColumns(string input)
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            string[] rawcolumns = input.Split(',');
            for(int i =0; i < rawcolumns.Length;i++)
            {
               string[] column = rawcolumns[i].Split(new string[]{" ",Environment.NewLine},StringSplitOptions.RemoveEmptyEntries );
               string columnAlias;

               if (!column[column.Length - 1].Contains("\""))
               {
                   columnAlias = "\"" + column[column.Length - 1] + "\"";
               }
               else
                   columnAlias = column[column.Length - 1];
                    
               columns.Add(column[0].Trim(), columnAlias.Trim());
            }

            return columns;
        }

        private static Dictionary<string, string> GetConditions(string input)
        {
            Dictionary<string, string> conditions = new Dictionary<string, string>();
            string[] rawConditions = input.Split(new String[]{"AND","and"},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rawConditions.Length; i++)
            {
                string[] condition = rawConditions[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                conditions.Add(condition[0].Trim(), condition[condition.Length - 1].Trim());
            }
            return conditions;
        }
    }
}
