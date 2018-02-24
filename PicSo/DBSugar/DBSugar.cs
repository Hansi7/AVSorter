using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using AVSORTER;

namespace PicSo.DBSugar
{
    class DBSugar
    {
        public DBSugar()
        {
            Db = new SqlSugar.SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "DataSource="+AppDomain.CurrentDomain.BaseDirectory + "\\db\\jav.db",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
            });
            Db.MappingTables.Add("Movie", "Movies");
        }
        public SqlSugarClient Db;
        public SimpleClient<Movie> MovieDb { get { return new SimpleClient<Movie>(Db); } }
    }
}
