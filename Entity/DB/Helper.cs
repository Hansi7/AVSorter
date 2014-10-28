using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace AVSORTER.DB
{
    public class Helper
    {
        string b = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB","AVDB.accdb");
        string ConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        OleDbConnection connection;
        /// <summary>
        /// 数据连接帮助类
        /// </summary>
        /// <param name="connectionString">为空字符时使用默认的连接字符串</param>
        public Helper(string connectionString)
        {
            ConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + b;
            if (connectionString== string.Empty)
            {
                connection = new OleDbConnection(ConnectString);
            }
            else
            {
                connection = new OleDbConnection(connectionString);
            }

            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable ExecuteDataTable(OleDbCommand command)
        {
            AddConnection(command);
            OleDbDataAdapter adpt = new OleDbDataAdapter(command);
            DataTable datatable = new DataTable();
            adpt.Fill(datatable);
            return datatable;
        }

        public DataTable ExecuteDataTable(string selectCommand)
        {
            OleDbDataAdapter adpt = new OleDbDataAdapter(selectCommand,this.connection);
            DataTable datatable = new DataTable();
            adpt.Fill(datatable);
            return datatable;
        }
        /// <summary>
        /// in used
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(OleDbCommand command)
        {
            AddConnection(command);
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                return command.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(string nonQueryCommand)
        {
            using (OleDbCommand comm = new OleDbCommand(nonQueryCommand))
            {
                AddConnection(comm);
                return comm.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(OleDbCommand command)
        {
            AddConnection(command);
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                return command.ExecuteScalar();
            }
        }

        public object ExecuteScalar(string sqlCommand)
        {
            using (OleDbCommand comm = new OleDbCommand(sqlCommand))
            {
                AddConnection(comm);
                if (comm.Connection.State == ConnectionState.Closed)
                {
                    comm.Connection.Open();
                }
                return comm.ExecuteScalar();
            }
        }

        #region 属性

        public ConnectionState State
        {
            get { return this.connection.State; }
        }

        #endregion

        private void AddConnection(OleDbCommand comm)
        {
            comm.Connection = this.connection;
        }

        
    }

}
