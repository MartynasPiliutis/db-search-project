using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web;
using System.Xml;
using System.Text;
using Newtonsoft.Json.Linq;

/*====================================================================================================
Before starting the program please check comments on CSVImportToDB.cs and DataPath.cs
====================================================================================================*/

namespace SearchTheDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlRequestJsonResponse sqlRequestJsonResponse = new SqlRequestJsonResponse();
            ConsoleDialogMessages consoleDialogMessages = new ConsoleDialogMessages();
            string userInput = consoleDialogMessages.InputRequestMessage();
            try
            {
                sqlRequestJsonResponse.SqlRequestJson(userInput);
            }
            catch (SqlException)
            {
                consoleDialogMessages.SqlExceptionErrorMessage();
            }
        }
    }
}
