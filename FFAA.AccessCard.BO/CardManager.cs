using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FFAA.AccessCard.Dao;
using FFAA.AccessCard.Entity;

namespace FFAA.AccessCard.BO
{
    public static class CardManager
    {
        public static CardInfoEntity GetInfo(string pUsername)
        {
            CardInfoEntity cardItem = null;

            try
            {
                List<SqlParameter> lstParam = new List<SqlParameter>();
                lstParam.Add(new SqlParameter() { ParameterName = "@p_username", Value = pUsername, SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input });
                DataTable dt = CardAccess.ExecuteProcedure(lstParam, "pr_vw_tarjetas");

                foreach (DataRow dr in dt.Rows)
                {
                    CardInfoEntity item = new CardInfoEntity();
                    item.TarjetaID = long.Parse(dr["TarjetaID"].ToString());
                    item.FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString());
                    item.FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString());
                    item.Tipo = dr["Tipo"].ToString();
                    item.Clasificacion = dr["Clasificacion"].ToString();
                    item.Identificacion = long.Parse(dr["Identificacion"].ToString());
                    item.Grado = dr["Grado"].ToString();
                    item.Nombres = dr["Nombres"].ToString();
                    item.Apellidos = dr["Apellidos"].ToString();
                    item.Unidad = int.Parse(dr["Unidad"].ToString());
                    item.Dependencia = dr["Dependencia"].ToString();
                    item.Vigencia = int.Parse(dr["Vigencia"].ToString());
                    item.Cargo = dr["Cargo"].ToString();
                    item.NombreFirma = dr["NombreFirma"].ToString();
                    item.CargoFirma = dr["CargoFirma"].ToString();

                    cardItem = item;
                }

                return cardItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
