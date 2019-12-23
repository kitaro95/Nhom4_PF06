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
            query = @"Select * from Mobiles where Mobile_id = " + MobileID+ ";";
            MySqlCommand command= new MySqlCommand(query,connection);
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

        private Mobile GetMobileDetail (MySqlDataReader reader)
        {
            Mobile mobi = new Mobile();
            mobi.MobileID = reader.GetInt32("Mobile_id");
            mobi.MobileName = reader.GetString("M_Name");
            mobi.MobileRAM = reader.GetString("M_RAM");
            mobi.MobileCamera = reader.GetString("M_Camera");
            mobi.MobileStorage = reader.GetString("M_Storage");
            return mobi;
        }
        public List<Mobile> GetListMobile()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select Mobile_id,M_Name,M_RAM,M_Camera,M_Storage from mobiles;";
            MySqlCommand command = new MySqlCommand(query,connection);
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