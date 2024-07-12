using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FFAA.AccessCard.Dao
{
    public static class CardAccess
    {
        private static string GetConnectionStringByName(string name)
        {
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public static DataTable ExecuteProcedure(List<SqlParameter> pParams, string pSqlProc)
        {
            DataTable dt = null;
            String ConnnectionString = GetConnectionStringByName("TarjetasDB");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = pSqlProc;
                    foreach (SqlParameter param in pParams)
                    {
                        cmd.Parameters.Add((SqlParameter)param);
                    }

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
