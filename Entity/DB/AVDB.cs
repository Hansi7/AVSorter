using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace AVSORTER.DB
{
    public class AVDB
    {
        Helper h = new Helper(string.Empty);
        string DestPath;
        string SubPath;

        public AVDB()
        {
            GetDestPath();
            GetSubPath();
        }
        public void AddNewAV(AVSORTER.Movie m, string video, bool censored)
        {
            if (isInDB(m))
            {
                updateAV(m, video, censored);
            }
            else
            {
                insertAV(m, video, censored);
            }
        }
        public List<Movie> QueryAV(string fcode)
        {

            List<Movie> list = new List<Movie>();
            var dt = h.ExecuteDataTable("select * from movies where FCode like '%" + fcode + "%'");
            foreach (DataRow item in dt.Rows)
            {
                Movie m = new Movie();
                m.Title = item[1].ToString();
                m.Actor = item[2].ToString().Split(',').ToList<string>();
                m.ItemURL = item[3].ToString();
                m.Maker = item[5].ToString();
                m.Lable = item[6].ToString();
                m.Series = item[7].ToString();
                m.Producer = item[8].ToString();
                m.ReleaseDate = item.Field<DateTime>(9);
                m.Minutes = item[10].ToString();
                m.AVCode = item[11].ToString();
                m.Introduction = item[12].ToString();

                var a = SubPath.Replace("演员", m.Actor.Count == 0 ? "无名氏" : Tools.ListToString(m.Actor));
                a = a.Replace("番号", m.AVCode);
                a = a.Replace("厂商", m.Maker);
                a = a.Replace("制造商", m.Producer);

                a = a.Replace("标题", m.Title);
                a = a.Replace("标签", m.Lable);
                a = System.IO.Path.Combine(DestPath, a, m.AVCode + System.IO.Path.GetExtension(item[4].ToString()));
                m.CoverFile = a;
                list.Add(m);
            }
            return list;


        }
        public void SetDestPath(string path)
        {
            DestPath = path;
            using (OleDbCommand comm = new OleDbCommand("update settings set destPath = '" + path + "'"))
            {
                h.ExecuteScalar(comm);
            }

        }
        public string GetDestPath()
        {
            using (OleDbCommand comm = new OleDbCommand("select top 1 destPath from settings"))
            {
                this.DestPath = (string)h.ExecuteScalar(comm);
                return DestPath;
            }
        }
        public void SetSubPath(string path)
        {
            this.SubPath = path;
            using (OleDbCommand comm = new OleDbCommand("update settings set SubPath = '" + path + "'"))
            {
                h.ExecuteScalar(comm);
            }
        }
        public string GetSubPath()
        {

            using (OleDbCommand comm = new OleDbCommand("select top 1 SubPath from settings"))
            {
                this.SubPath = (string)h.ExecuteScalar(comm);
                return this.SubPath;
            }
        }
        private void updateAV(Movie m, string videof, bool censored)
        {
            using (OleDbCommand comm = new OleDbCommand(@"update movies set Title=title,
                        actor=@actor,
                        itemurl=@url,
                        coverfile=@coverfile,
                        maker=@maker,
                        labels=@labels,
                        series=@series,
                        producer=@producer,
                        releasedate=@releasedate,
                        minuses=@minutes,
                        intro=@intro,
                        censored=@c,
                        videofile = @video
                        where fcode=@fcode"))
            {
                comm.Parameters.Add("@title", OleDbType.VarWChar).Value = m.Title;
                comm.Parameters.Add("@actor", OleDbType.VarWChar).Value = AVSORTER.Tools.ListToString(m.Actor);
                comm.Parameters.Add("@url", OleDbType.VarWChar).Value = m.ItemURL;


                string cfile;
                if (string.IsNullOrEmpty(m.CoverFile))
                {
                    cfile = "";
                }
                else
                {
                    cfile = m.CoverFile;
                    cfile = System.IO.Path.GetFileName(cfile);
                }
                comm.Parameters.Add("@coverfile", OleDbType.VarWChar).Value = cfile;
                comm.Parameters.Add("@maker", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Maker) ? "" : m.Maker;
                comm.Parameters.Add("@labels", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Lable) ? "" : m.Lable;
                comm.Parameters.Add("@series", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Series) ? "" : m.Series;
                comm.Parameters.Add("@producer", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Producer) ? "" : m.Producer;
                comm.Parameters.Add("@releasedate", OleDbType.Date).Value = m.ReleaseDate;
                comm.Parameters.Add("@minutes", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Minutes) ? "" : m.Minutes;
                comm.Parameters.Add("@fcode", OleDbType.VarWChar).Value = m.AVCode;
                comm.Parameters.Add("@intro", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Introduction) ? "" : m.Introduction;
                comm.Parameters.Add("@c", OleDbType.Boolean).Value = censored;
                comm.Parameters.Add("@video", OleDbType.VarWChar).Value = videof;

                h.ExecuteNonQuery(comm);
            }
        }
        private void insertAV(Movie m, string videof, bool censored)
        {
            using (OleDbCommand comm = new OleDbCommand(@"insert into
movies (Title,actor,itemurl,coverfile,maker,labels,series,producer,releasedate,minuses,fcode,intro,censored,videofile )
values (@title,@actor,@url,@coverfile,@maker,@labels,@series,@producer,@releasedate,@minutes,@fcode,@intro,@c,@video)"))
            {
                comm.Parameters.Add("@title", OleDbType.VarWChar).Value = m.Title;
                comm.Parameters.Add("@actor", OleDbType.VarWChar).Value = AVSORTER.Tools.ListToString(m.Actor);
                comm.Parameters.Add("@url", OleDbType.VarWChar).Value = m.ItemURL;

                string cfile;
                if (string.IsNullOrEmpty(m.CoverFile))
                {
                    cfile = "";
                }
                else
                {
                    cfile = m.CoverFile;
                    cfile = System.IO.Path.GetFileName(cfile);
                }

                comm.Parameters.Add("@coverfile", OleDbType.VarWChar).Value = cfile;
                comm.Parameters.Add("@maker", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Maker) ? "" : m.Maker;
                comm.Parameters.Add("@labels", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Lable) ? "" : m.Lable;
                comm.Parameters.Add("@series", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Series) ? "" : m.Series;
                comm.Parameters.Add("@producer", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Producer) ? "" : m.Producer;
                comm.Parameters.Add("@releasedate", OleDbType.Date).Value = m.ReleaseDate;
                comm.Parameters.Add("@minutes", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Minutes) ? "" : m.Minutes;
                comm.Parameters.Add("@fcode", OleDbType.VarWChar).Value = m.AVCode;
                comm.Parameters.Add("@intro", OleDbType.VarWChar).Value = string.IsNullOrEmpty(m.Introduction) ? "" : m.Introduction;
                comm.Parameters.Add("@c", OleDbType.Boolean).Value = censored;
                comm.Parameters.Add("@video", OleDbType.VarWChar).Value = videof;
                h.ExecuteNonQuery(comm);
            }

        }
        private bool isInDB(AVSORTER.Movie movie)
        {
            var obj = h.ExecuteScalar("select count(*) from movies where FCode='" + movie.AVCode + "'");
            return (int)obj > 0;
        }
        private bool isInDB(string fcode)
        {
            var obj = h.ExecuteScalar("select count(*) from movies where FCode='" + fcode + "'");
            return (int)obj > 0;
        }
    }
}
