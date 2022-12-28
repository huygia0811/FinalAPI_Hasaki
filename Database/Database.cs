﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FinalAPI_Hasaki.Controllers;
namespace FinalAPI_Hasaki.Database
{
    public class Database
    {
        public static DataTable ReadTable(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // Result variable
                DataTable resultTable = new DataTable();

                // Create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["dbhasakiConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // Create and Assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // Check parameters in Stored Procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // Execute sqlCommand and Assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(resultTable);

                connection.Close();

                return resultTable;
            }
            catch
            {
                return null;
            }
        }
        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                // Start a local transaction.

                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@currentid", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@currentid"].Value;
                    // Attempt to commit the transaction.

                }
                catch (Exception ex)
                {

                    result = null;
                }

            }
            return result;
        }
        public static NguoiDung Them_Nguoi_Dung(NguoiDung nd)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("hoten", nd.HOTEN);
            param.Add("sodt", nd.SODIENTHOAI);
            param.Add("matkhau", nd.MATKHAU);
            int kq = int.Parse(Exec_Command("Proc_DangKy", param).ToString());
            if (kq > -1)
                nd.MAKH = kq;
            return nd;
        }
    }
}