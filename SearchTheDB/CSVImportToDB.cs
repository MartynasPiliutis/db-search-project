using System;
using System.Data.SqlClient;
using System.IO;

/*====================================================================================================
//This part imports CSV to SQLDB. Run it first to populate DB table. Comment after import complete
//To use it move the below code to Program.cs
CSVImportToDB cSVImportToDB = new();
cSVImportToDB.ExportCSVToSQLDB();
Console.WriteLine("Done");
Console.ReadLine();
====================================================================================================*/

namespace SearchTheDB
{
    public class CSVImportToDB
    {
        public void ExportCSVToSQLDB()
        {           
            int lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(DataPath.sqlConnectionDetails))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(DataPath.csvToImport))
                { 
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        while (line.EndsWith(".") == true)
                        {
                            var nextLine = reader.ReadLine();
                            line = line + " " + nextLine;
                        }
                        if (lineNumber != 0)
                        {
                            line = line.Replace(", ", "%%");
                            line = line.Replace("'", "`");
                            var values = line.Split(',');
                            string sql = $"INSERT INTO DocLogixTaskDB.dbo.AuditingReport VALUES ('{values[0].Replace("%%", ", ")}','{values[1].Replace("%%", ", ")}',{values[2]},'{values[3].Replace("%%", ", ")}',{values[4]},'{values[5].Replace("%%", ", ")}','{values[6].Replace("%%", ", ")}',{values[7]},'{values[8].Replace("%%", ", ")}','{values[9].Replace("%%", ", ")}','{values[10].Replace("%%", ", ")}','{values[11].Replace("%%", ", ")}','{values[12].Replace("%%", ", ")}','{values[13].Replace("%%", ", ")}','{values[14].Replace("%%", ", ")}',{values[15]},'{values[16].Replace("%%", ", ")}','{values[17].Replace("%%", ", ")}')";
                            Console.WriteLine(sql);
                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber = lineNumber + 1;
                    }
                }
                conn.Close();
            }
        }
    }
}
