using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.DAL
{
    public class DataAccess
    {
        string dbConfig = ConfigurationManager.ConnectionStrings["db_config"].ToString();
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlTransaction trans;

        //资源释放
        private void Dispose()
        {
            if(trans!=null)
            {
                trans.Dispose();
                trans = null;
            }
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        private DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection = new MySqlConnection(dbConfig);
                connection.Open();
                adapter = new MySqlDataAdapter(sql, connection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            return dt;
        }

        public DataTable GetStorageArea()
        {
            string stringSql = "select * from storage_area";
            return GetData(stringSql);
        }

        public DataTable GetDevice()
        {
            string stringSql = "select * from deviceinfo";
            return GetData(stringSql);
        }

        public DataTable GetMonitorValues()
        {
            string stringSql = "select * from monitor_values Order by d_id , value_id";
            return GetData(stringSql);
        }

    }
}
