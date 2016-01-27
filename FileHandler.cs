using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formatter.utilities;

namespace Formatter
{
    public class FileHandler
    {
        public static string ReadFormatter(QueryTypes queryType){

            string name = string.Empty;
            switch(queryType){

                case QueryTypes.SELECT :
                    name = "SelectFormat.txt";
                    break;
                case QueryTypes.INSERT:
                    name = "InsertFormat.txt";
                    break;
                case QueryTypes.DELETE:
                    name = "DeleteFormat.txt";
                    break;
                case QueryTypes.UPDATE:
                    name = "UpdateFormat.txt";
                    break;

            }

            string format = File.ReadAllText(@".\resources\" + name);

            return format;

        }


    }
}
