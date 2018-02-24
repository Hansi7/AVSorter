using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVSORTER;

namespace PicSo.DBSugar
{
    class MovieDBController : DBSugar
    {
        public MovieDBController()
        {
            //List<Movie> list = Db.Queryable<Movie>().ToList();
            //List<Movie> list2 = MovieDb.GetList();
        }

        public bool InsertMovie(Movie m)
        {
            return MovieDb.Insert(m);
        }
        public string ClearDB()
        {

            string dbFileName = AppDomain.CurrentDomain.BaseDirectory + "jav.db";
            System.Data.SQLite.SQLiteConnection.CreateFile(dbFileName);

            string connectString = @"Data Source=" + dbFileName;

            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectString);

            using (System.Data.SQLite.SQLiteCommand comm = new System.Data.SQLite.SQLiteCommand(conn))
            {

                conn.Open();
                comm.CommandText = @"
                CREATE TABLE Movies(
                    ID INTEGER PRIMARY KEY   AUTOINCREMENT,
                    Title               TEXT        NOT NULL,
                    Actor               TEXT,
                    CoverURL            TEXT,
                    CoverFile           TEXT,
                    Maker               TEXT,
                    Lable               TEXT,
                    Series              TEXT,
                    Producer            TEXT,
                    ReleaseDate         TEXT,
                    Minutes             TEXT,
                    AVCode              CHAR(16),
                    Introduction        TEXT,
                    ItemURL             TEXT,
                    Censored            SMALLINT,
                    VideosFile          TEXT
                );";
                comm.ExecuteNonQuery();

                comm.CommandText = @"
                CREATE TABLE Settings(
                    ID INTEGER PRIMARY KEY   AUTOINCREMENT,
                    DestPath            TEXT,
                    SubPath             TEXT
                );";


                comm.ExecuteNonQuery();
                conn.Close();
            }

            return "新的数据库文件已经产生，如果确实要清空，请将jav.db，移动到db文件夹中替换。此操作会清空本地数据";
        }



    }
}
