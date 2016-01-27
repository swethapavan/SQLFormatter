using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Formatter.utilities;

namespace Formatter
{
    public class UpdateQueryFormatter : ISqlFormatter
    {
        public string FormatQuery(String query)
        {
            UpdateQuery input = UpdateQueryParser.Parse(query);
            String format = FileHandler.ReadFormatter(QueryTypes.UPDATE);

            Dictionary<string, string> columns = input.Columns;
            String table = input.Table;
            Dictionary<string, string> conditions = input.Conditions;

            String update = format.Substring(0,"UPDATE".ToString().Length);
            string fromTableText = GetTableFromText(format, table);
            StringBuilder columnTexts = GetColumnValuesText(format, columns);
            
            StringBuilder conditionTexts = GetConditionValuesText(format, conditions);

           String formattedSql = fromTableText.ToString() + columnTexts.ToString() + conditionTexts.ToString()  ;
           return formattedSql;

        }

        private string GetTableFromText(String format, string table)
        {
            int startIndexOfFromTable = format.IndexOf("UPDATE");
            int endIndexOfFromTable = format.IndexOf("@table") - 1;
            string fromPlaceHolderText = format.Substring(startIndexOfFromTable, endIndexOfFromTable - startIndexOfFromTable + 1);
            string fromtext = fromPlaceHolderText + table;

            return fromtext;
        }

        private StringBuilder GetColumnValuesText(String format, Dictionary<string, string> columnValues)
        {
            StringBuilder sb = new StringBuilder();

            List<string> conditionTexts = new List<string>();

            int columnOneStartIndex = format.IndexOf("@table") + "@table".Length;
            int columnOneEndIndex = format.IndexOf("[", columnOneStartIndex) - 1;

            int columnTwoStartIndex = columnOneEndIndex + 2;
            int columnTwoEndIndex = format.IndexOf("]", columnTwoStartIndex) - 1;
            string conditionOnePlaceHolderText =
                format.Substring(columnOneStartIndex, columnOneEndIndex - columnOneStartIndex + 1);
            string conditionTwoPlaceHolderText =
                format.Substring(columnTwoStartIndex, columnTwoEndIndex - columnTwoStartIndex + 1);


            string formatCondition = "@column";
            string formatConditionValue = "@value";
            string textToReplace = conditionOnePlaceHolderText;
            int index = 1;
            for (int i = 0; i < columnValues.Count; i++)
            {

                textToReplace = textToReplace.Replace(formatCondition + index, columnValues.Keys.ElementAt(i));
                textToReplace = textToReplace.Replace(formatConditionValue + index, columnValues.Values.ElementAt(i));
                index++;
                if (!textToReplace.Contains(formatCondition) || i == (columnValues.Count - 1))
                {
                    textToReplace = Regex.Replace(textToReplace, "AND[\\s]*@condition[0-9]*[\\s]*[=]*[\\s]*@conditionvalue[0-9]*[\\s]*", "");
                    conditionTexts.Add(textToReplace);
                    textToReplace = conditionTwoPlaceHolderText;
                    index = 1;
                }
            }

            for (int y = 0; y < conditionTexts.Count; y++)
            {
                sb.Append(conditionTexts[y]);

            }
            return sb;
        }

        private StringBuilder GetConditionValuesText(String format, Dictionary<string, string> conditionValues)
        {
            StringBuilder sb = new StringBuilder();

            List<string> conditionTexts = new List<string>();

            if (conditionValues == null || conditionValues.Count == 0)
                return sb;

            int conditionOneStartIndex = format.IndexOf("]") + 1;
            int conditionOneEndIndex = format.LastIndexOf("[") - 1;

            int conditionTwoStartIndex = conditionOneEndIndex + 2;
            int conditionTwoEndIndex = format.LastIndexOf("]") - 1;
            string conditionOnePlaceHolderText =
                format.Substring(conditionOneStartIndex, conditionOneEndIndex - conditionOneStartIndex + 1);
            string conditionTwoPlaceHolderText =
                format.Substring(conditionTwoStartIndex, conditionTwoEndIndex - conditionTwoStartIndex + 1);


            string formatCondition = " @condition";
            string formatConditionValue = "@conditionvalue";
            string textToReplace = conditionOnePlaceHolderText;
            int index = 1;
            for (int i = 0; i < conditionValues.Count; i++)
            {

                textToReplace = textToReplace.Replace(formatCondition + index, conditionValues.Keys.ElementAt(i));
                textToReplace = textToReplace.Replace(formatConditionValue + index, conditionValues.Values.ElementAt(i));
                index++;
                if (!textToReplace.Contains(formatCondition) || i == (conditionValues.Count - 1))
                {
                    textToReplace = Regex.Replace(textToReplace, "AND[\\s]*@condition[0-9]*[\\s]*[=]*[\\s]*@conditionvalue[0-9]*[\\s]*", "");
                    conditionTexts.Add(textToReplace);
                    textToReplace = conditionTwoPlaceHolderText;
                    index = 1;
                }
            }

            for (int y = 0; y < conditionTexts.Count; y++)
            {
                sb.Append(conditionTexts[y]);

            }
            return sb;
        }

    }
}
