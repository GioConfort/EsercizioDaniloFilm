using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EsercizioDaniloFilm.Data;

namespace EsercizioDaniloFilm.Models.Services.Infrastructures
{
    public class MySqlDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            using(var conn = new SqliteConnection("Data Source=Data/cinema.db"))
            { 
                conn.Open();
                using(var cmd=new SqliteCommand(query, conn))
                { 
                    using(var reader = cmd.ExecuteReader())
                    { 
                        var dataSet = new DataSet();
                        dataSet.EnforceConstraints=false;
                        var dataTable= new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                        return dataSet;
                    }
                }
            }
        }
    }
}