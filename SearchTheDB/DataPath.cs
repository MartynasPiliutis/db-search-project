using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SearchTheDB
{
    internal class DataPath
    {
        public static readonly string csvToImport = @"C:\Users\kooky\Documents\DOTNET2\DocLogix\SearchTheDB\SearchTheDB\csv\csvToImport.csv"; //required if you want to build SQLDB from the csv file.
        public static readonly string sqlConnectionDetails = "Server=Localhost;Database=DocLogixTaskDB;Trusted_Connection=True"; //Change according to your settings. Database backup and .mdf can be found in dbBackup folder in the project.
    }
}
