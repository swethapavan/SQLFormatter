using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Formatter.utilities;

namespace Formatter
{
    public class InsertQueryFormatter: ISqlFormatter
    {

       public string FormatQuery(String query)
        {
            InsertQuery input = InsertQueryParser.Parse(query);
            String format = FileHandler.ReadFormatter(QueryTypes.INSERT);
            String table = input.Table;

            String insertText = "INSERT INTO";
            StringBuilder columnTexts = GetcolumnTexts(format, input.Columns);
            string fromTableText = GetTableFromText(format, table);
            string valueTexts = GetValueText(format, input.Values);
            String formattedSql = insertText + fromTableText + columnTexts.ToString() + valueTexts;
            return formattedSql;

        }

        private static string GetTableFromText(String format, string table)
        {
            int startIndexOfFromTable = format.IndexOf("INSERT INTO") + "INSERT INTO".Length;
            int endIndexOfFromTable = format.IndexOf("(");
            string fromPlaceHolderText = format.Substring(startIndexOfFromTable, endIndexOfFromTable - startIndexOfFromTable + 1);
            string fromtext = fromPlaceHolderText.Replace("@table", table);

            return fromtext;
        }
        private static string GetValueText(String format,List<String> values)
        {
            List<string> valueTexts = new List<string>();
            int valuesStartIndex = format.IndexOf("]") + 1;
            int valuesEndIndex = format.LastIndexOf("(");
            string valueStartText = format.Substring(valuesStartIndex, valuesEndIndex - valuesStartIndex + 1);
            int columnOneStartIndex = valuesEndIndex + 1;
            int columnOneEndIndex = format.LastIndexOf("[") - 1;
            int columnTwoStartIndex = columnOneEndIndex + 2;
            int columnTwoEndIndex = format.LastIndexOf("]") - 1;
            string columneOnePlaceHolderText =
                format.Substring(columnOneStartIndex, columnOneEndIndex - columnOneStartIndex + 1);
            string columnTwoPlaceHolderText =
                format.Substring(columnTwoStartIndex, columnTwoEndIndex - columnTwoStartIndex + 1);

            string textToReplace = columneOnePlaceHolderText;

            string formatCol = "@value";
           
            int index = 1;
            for (int i = 0; i < values.Count; i++)
            {
                textToReplace = textToReplace.Replace(formatCol + index, values[i].Trim());
                index++;
                if (!textToReplace.Contains(formatCol) || i == (values.Count - 1))
                {
                    textToReplace = Regex.Replace(textToReplace, ",[\\s]*@value[0-9]*[\\s]*", "");
                    valueTexts.Add(textToReplace);
                    textToReplace = columnTwoPlaceHolderText;
                    index = 1;
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < valueTexts.Count; y++)
            {
                sb.Append(valueTexts[y]);

            }

            int valueEndStartIndex = columnTwoEndIndex + 2;
            int valueEndEndIndex = format.LastIndexOf(")");
            string valueEndText = format.Substring(valueEndStartIndex, valueEndEndIndex - valueEndStartIndex + 1);
            return valueStartText + sb.ToString() + valueEndText;
        }
        private static StringBuilder GetcolumnTexts(String format, List<string> columns)
        {
            List<string> columnTexts = new List<string>();
            int columnOneStartIndex = format.IndexOf("(") + 1;
            int columnOneEndIndex = format.IndexOf("[") - 1;
            int columnTwoStartIndex = columnOneEndIndex + 2;
            int columnTwoEndIndex = format.IndexOf("]") - 1;
            string columneOnePlaceHolderText =
                format.Substring(columnOneStartIndex, columnOneEndIndex - columnOneStartIndex + 1);
            string columnTwoPlaceHolderText =
                format.Substring(columnTwoStartIndex, columnTwoEndIndex - columnTwoStartIndex + 1);

            string textToReplace = columneOnePlaceHolderText;

            string formatCol = "@column";
            int index = 1;
            for (int i = 0; i < columns.Count; i++)
            {

                textToReplace = textToReplace.Replace(formatCol + index, columns[i].Trim());
                index++;
                if (!textToReplace.Contains(formatCol) || i == (columns.Count - 1))
                {
                    textToReplace = Regex.Replace(textToReplace, ",[\\s]*@column[0-9]*[\\s]*@columnalias[0-9]*[\\s]*", "");
                    columnTexts.Add(textToReplace);
                    textToReplace = columnTwoPlaceHolderText;
                    index = 1;
                }

            }
           
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < columnTexts.Count; y++)
            {
                sb.Append(columnTexts[y]);

            }
            return sb;
        }
    }
}
