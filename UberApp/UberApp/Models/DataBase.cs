using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;

namespace UberApp.Models
{
    public class DataBase
    {
        SqlConnection _sqlConnection;


        public DataBase()
        {
            Stream resourceStream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("UberApp.appsettings.json");

            var configuration = new ConfigurationBuilder().AddJsonStream(resourceStream).Build();

            _sqlConnection = new(configuration["DefaultConnection"]);
            _sqlConnection.Open();
        }
    }
}
