using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistion;

namespace DAL
{
    public class MobileDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public MobileDAL()
        {
            connection = DatabaseAccess.OpenConnection();
        }

        public Mobile GetMobilebyId(int MobileID)
        {
            query = @"Select * from Mobile where Mobile_id = " + MobileID + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            Mobile mobile = null;
            if (reader.Read())
            {
                mobile = GetMobileDetail(reader);
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return mobile;
        }

        private Mobile GetMobileDetail(MySqlDataReader reader)
        {
            Mobile mobi = new Mobile();
            mobi.MobileID = reader.GetInt32("Mobile_id");
            mobi.MobileName = reader.GetString("Mobile_name");
            mobi.MobileRAM = reader.GetString("Mobile_RAM");
            mobi.MobileCamera = reader.GetString("Mobile_Camera");
            mobi.MobileCPU = reader.GetString("Mobile_CPU");
            mobi.MobilePrice = reader.GetDecimal("Mobile_Price");
            mobi.MobileScreen = reader.GetString("Mobile_Screen");
            mobi.MobileTradeMack = reader.GetString("Mobile_Trademack");
            mobi.MobileQuantity = reader.GetInt32("Mobile_quantity");
            return mobi;
        }
        public List<Mobile> GetListMobile()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select * from Mobile;";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<Mobile> listMobiles = new List<Mobile>();
            if (reader != null)
            {
                listMobiles = GetListMobiles(command);
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return listMobiles;
        }
        public List<Mobile> GetMobilebyName(string MobileName)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select * from Mobile where Mobile_name like '%" + MobileName + "%';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<Mobile> listMobiles = new List<Mobile>();
            if (reader != null)
            {
                listMobiles = GetListMobiles(command);
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return listMobiles;
        }
        private List<Mobile> GetListMobiles(MySqlCommand command)
        {
            List<Mobile> listMobiles = new List<Mobile>();
            while (reader.Read())
            {
                listMobiles.Add(GetMobileDetail(reader));
            }
            connection.Close();
            return listMobiles;
        }

    }
}