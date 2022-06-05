using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace SearchTheDB
{
    public class SqlRequestJsonResponse
    {
        public void SqlRequestJson(string sqlString)
        {
            using (SqlConnection conn = new SqlConnection(DataPath.sqlConnectionDetails))
            {
                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    conn.Open();
                    var responseJson = new StringBuilder();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        responseJson.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            responseJson.Append(reader.GetValue(0).ToString());
                        }
                    }
                    dynamic json = JsonConvert.DeserializeObject(responseJson.ToString());
                    Console.WriteLine(json);
                    conn.Close();
                }
            }
        }
    }
}
