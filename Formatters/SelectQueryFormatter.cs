using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Formatter;
using System.Linq;
using Formatter.utilities;


public class SelectQueryFormatter : ISqlFormatter
{

    public string FormatQuery(String query)
    {
        SelectQuery input = SelectQueryParser.Parse(query);
        String format = FileHandler.ReadFormatter(QueryTypes.SELECT);

        Dictionary<string, string> columns = input.Columns;
        String table = input.Table;
        Dictionary<string, string> conditions = input.Conditions;

        String select = format.Substring(0, "SELECT".Length);
        StringBuilder columnTexts = GetcolumnTexts(format, columns);
        string fromTableText = GetTableFromText(format, table);
        StringBuilder conditionTexts = GetconditionsTexts(format, conditions);

        String formattedSql = select + columnTexts.ToString() + fromTableText + conditionTexts.ToString();
        return formattedSql;

    }

    private string GetTableFromText(String format, string table)
    {
        int startIndexOfFromTable = format.IndexOf("]") + 1;
        int endIndexOfFromTable = format.IndexOf("@table") - 1;
        string fromPlaceHolderText = format.Substring(startIndexOfFromTable, endIndexOfFromTable - startIndexOfFromTable + 1);
        string fromtext = fromPlaceHolderText + table;

        return fromtext;
    }

    private static StringBuilder GetcolumnTexts(String format, Dictionary<string, string> columns)
    {
        List<string> columnTexts = new List<string>();
        int columnOneStartIndex = "SELECT".Length;
        int columnOneEndIndex = format.IndexOf("[") - 1;
        int columnTwoStartIndex = columnOneEndIndex + 2;
        int columnTwoEndIndex = format.IndexOf("]") - 1;
        string columneOnePlaceHolderText =
            format.Substring(columnOneStartIndex, columnOneEndIndex - columnOneStartIndex + 1);
        string columnTwoPlaceHolderText =
            format.Substring(columnTwoStartIndex, columnTwoEndIndex - columnTwoStartIndex + 1);

        string textToReplace = columneOnePlaceHolderText;

        string formatCol = "@column";
        string formatColAlias = "@columnalias";
        int index = 1;
        for (int i = 0; i < columns.Count; i++)
        {

            textToReplace = textToReplace.Replace(formatCol + index, columns.Keys.ElementAt(i));
            textToReplace = textToReplace.Replace(formatColAlias + index, columns.Values.ElementAt(i));
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

    private static StringBuilder GetconditionsTexts(String format, Dictionary<string, string> conditions)
    {
        StringBuilder sb = new StringBuilder();

        List<string> conditionTexts = new List<string>();

        if (conditions == null || conditions.Count == 0)
            return sb;

        int conditionOneStartIndex = format.IndexOf("table") + "table".Length;
        int conditionOneEndIndex = format.IndexOf("[", conditionOneStartIndex) - 1;

        int conditionTwoStartIndex = conditionOneEndIndex + 2;
        int conditionTwoEndIndex = format.IndexOf("]", conditionTwoStartIndex) - 1;
        string conditionOnePlaceHolderText =
            format.Substring(conditionOneStartIndex, conditionOneEndIndex - conditionOneStartIndex + 1);
        string conditionTwoPlaceHolderText =
            format.Substring(conditionTwoStartIndex, conditionTwoEndIndex - conditionTwoStartIndex + 1);


        string formatCondition = "@condition";
        string formatConditionValue = "@conditionvalue";
        string textToReplace = conditionOnePlaceHolderText;
        int index = 1;
        for (int i = 0; i < conditions.Count; i++)
        {

            textToReplace = textToReplace.Replace(formatCondition + index, conditions.Keys.ElementAt(i));
            textToReplace = textToReplace.Replace(formatConditionValue + index, conditions.Values.ElementAt(i));
            index++;
            if (!textToReplace.Contains(formatCondition) || i== (conditions.Count - 1))
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
