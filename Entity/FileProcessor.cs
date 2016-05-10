using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AVSORTER
{
    public class FileProcessor
    {
        #region ctor
        public static FileProcessor GetInstance()
        {
            if (f == null)
            {
                f = new FileProcessor();
            }
            else
            {
                //nothing to do here
            }
            return f;
        }
        private static FileProcessor f;
        //public FileProcessor(string startPath)
        //{
        //    this.list = Directory.GetFileSystemEntries(startPath, "*.*", SearchOption.AllDirectories).ToList<string>();
        //    less(this.list);
        //}


        public FileProcessor()
        {
            this.DestPath = db.GetDestPath();
            this.SubPath = db.GetSubPath();
        }

        #endregion

        #region 属性字段

        DB.AVDB db = new DB.AVDB();

        StringBuilder _sblog = new StringBuilder();
        public List<string> Files
        {
            get
            {
                return this.list;
            }
        }
        List<string> list = new List<string>();
                /// <summary>
        /// 目标文件夹
        /// </summary>
        public string DestPath { get; set; }
        /// <summary>
        /// 自动显示文件移动日志
        /// </summary>
        public bool ShowLog { get; set; }
        /// <summary>
        /// 目标文件夹的自定义子文件夹
        /// </summary>
        public string SubPath { get; set; }
        /// <summary>
        /// 文件扩展名过滤
        /// </summary>
        public string Pattern 
        {
            get {

                return this._pattern;
            }
            set
            {
                this._pattern = value;
            }
        }
        string _pattern = @"\.mp4|\.mov|\.avi|\.wmv|\.iso|\.rm|\.rmvb|\.mkv";
        #endregion

        void less(List<string> l)
        {
            l.RemoveAll(j => !Regex.IsMatch(Path.GetExtension(j),Pattern, RegexOptions.IgnoreCase));
        }
        string _getFilePathName(Movie movie,string sourceFile)
        {
            if (SubPath!=null)
            {
                var a = SubPath.Replace("演员", movie.Actor.Count==0?"无名氏":Tools.ListToString(movie.Actor));
                a = a.Replace("番号", movie.AVCode);
                a = a.Replace("厂商", movie.Maker);
                a = a.Replace("制造商", movie.Producer);

                a = a.Replace("标题", movie.Title);
                a = a.Replace("标签", movie.Lable);
                return Path.Combine(DestPath, a, movie.AVCode + Path.GetExtension(sourceFile));
            }
            else
            {
                return Path.Combine(DestPath, movie.AVCode, Path.GetFileName(movie.AVCode));
            }

        }

        public void MakeMove(Movie m, string sourceFile)
        {
            string dest = _getFilePathName(m, sourceFile);

            
            try
            {
                MoveFile(sourceFile, dest);
                _sblog.AppendLine("复制" + sourceFile + "\r\n    至 " + dest);
                if (m.CoverFile != null)
                {
                    CopyFile(m.CoverFile, Path.Combine(Path.GetDirectoryName(dest), Path.GetFileName(m.CoverFile)));
                }
                var xiangduiPath = dest.Substring(this.DestPath.Length + 1);
                db.AddNewAV(m, xiangduiPath, true);
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                _sblog.AppendLine("===ERROR=== 数据库写入错误:" + err.Message + " 处理：" + sourceFile);
            }
            catch (Exception err)
            {
                _sblog.AppendLine("===ERROR===" + "文件" + sourceFile + "复制到" + dest + "未成功！");
            }
             
            //Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(sourceFile, dest, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            //Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(m.CoverFile, Path.Combine(Path.GetDirectoryName(dest),Path.GetFileName(m.CoverFile)), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        }
        public void MakeDataBase(Movie m, string sourceFile)
        {
            string dest = _getFilePathName(m, sourceFile);


            try
            {
                //MoveFile(sourceFile, dest);
                //_sblog.AppendLine("复制" + sourceFile + "\r\n    至 " + dest);
                //if (m.CoverFile != null)
                //{
                //    CopyFile(m.CoverFile, Path.Combine(Path.GetDirectoryName(dest), Path.GetFileName(m.CoverFile)));
                //}
                m.CoverFile = m.AVCode + ".jpg";
                var xiangduiPath = dest.Substring(this.DestPath.Length + 1);
                db.AddNewAV(m, xiangduiPath, true);
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                _sblog.AppendLine("===ERROR=== 数据库写入错误:" + err.Message + " 处理：" + sourceFile);
            }
            catch (Exception err)
            {
                _sblog.AppendLine("===ERROR===" + "文件" + sourceFile + "复制到" + dest + "未成功！");
            }

            //Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(sourceFile, dest, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            //Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(m.CoverFile, Path.Combine(Path.GetDirectoryName(dest),Path.GetFileName(m.CoverFile)), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        }



        /// <summary>
        /// 添加文件列表
        /// </summary>
        /// <param name="startDirectory"></param>
        public void AddDirectory(string startDirectory)
        {
            //是文件
            if (File.Exists(startDirectory))
	        {
                List<string> l = new List<string>();
                l.Add(startDirectory);
                less(l);
                this.list.AddRange(l);
                this.list = this.list.Distinct<string>().ToList<string>();
	        }
            else//是目录
            {
                var l = Directory.GetFileSystemEntries(startDirectory, "*.*", SearchOption.AllDirectories).ToList<string>();
                less(l);
                this.list.AddRange(l);
                this.list =  this.list.Distinct<string>().ToList<string>();
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        public void WriteLog()
        {
            string log = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
            File.WriteAllText(log, _sblog.ToString(), Encoding.Default);
            if (ShowLog)
	        {
		        System.Diagnostics.Process.Start(log);
	        }
        }

        void CopyFile(string sourceFile,string destFile)
        {
            //char[] invalidFileChars = Path.GetInvalidFileNameChars();


            //foreach (char cr in invalidFileChars)
            //{
            //    destFile = destFile.Replace(cr.ToString(), "");
            //}

            if (!Directory.Exists(Path.GetDirectoryName(destFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
            }
            int c = 0;
            while (Microsoft.VisualBasic.FileIO.FileSystem.FileExists(destFile))
            {
                destFile = Path.Combine(Path.GetDirectoryName(destFile), Path.GetFileNameWithoutExtension(destFile) + "_" + (++c).ToString() + Path.GetExtension(destFile));
            }
            Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(sourceFile, destFile,  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        }

        void MoveFile(string sourceFile, string destFile)
        {
            //char[] invalidFileChars = Path.GetInvalidFileNameChars();
            //foreach (char cr in invalidFileChars)
            //{
            //    destFile = destFile.Replace(cr.ToString(), "");
            //}


            if (sourceFile==destFile)
            {
                return;
            }
            if (!Directory.Exists(Path.GetDirectoryName(destFile)))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            int c = 0;
            while (Microsoft.VisualBasic.FileIO.FileSystem.FileExists(destFile))
            {
                destFile = Path.Combine(Path.GetDirectoryName(destFile), Path.GetFileNameWithoutExtension(destFile) + "_" + (++c).ToString() + Path.GetExtension(destFile));
            }
            Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(sourceFile, destFile, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        }
    }
}
