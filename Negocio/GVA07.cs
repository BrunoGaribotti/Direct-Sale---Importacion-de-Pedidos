using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class GVA07
    {
        public string FILLER="";
        public string FECHA_VTO="";
        public string F_COMP_CAN="";
        public string IMPORTE_VT="";
        public string IMPORT_CAN="";
        public string MISMO_CLIE="";
        public string N_COMP="";
        public string N_COMP_CAN="";
        public string T_COMP="";
        public string T_COMP_CAN="";
        public string IMP_CAN_UN="";
        public string IMP_VT_UNI="";
        public string IMP_VT_EXT="";
        public string IM_CAN_EXT="";
        public string IM_CA_UN_E="";
        public string IM_VT_UN_E="";
        public string ID_GVA12_CAN="";
        public string MOTIVO="";

        public string insert()
        {
            string sql = "";
            sql = @"
            INSERT INTO GVA07 
            (
            FILLER
            ,FECHA_VTO 
            ,F_COMP_CAN
            ,IMPORTE_VT
            ,IMPORT_CAN
            ,MISMO_CLIE
            ,N_COMP
            ,N_COMP_CAN
            ,T_COMP
            ,T_COMP_CAN
            ,IMP_CAN_UN
            ,IMP_VT_UNI
            ,IMP_VT_EXT
            ,IM_CAN_EXT
            ,IM_CA_UN_E
            ,IM_VT_UN_E
            ,ID_GVA12_CAN
            ,MOTIVO
            ) VALUES ( 
            '" + FILLER + @"'
            ,CONVERT(DATETIME,'" + FECHA_VTO + @"',103)
            ,CONVERT(DATETIME,'" + F_COMP_CAN + @"',103)
            ,  " + IMPORTE_VT + @"
            ,  " + IMPORT_CAN + @"
            ,  " + MISMO_CLIE + @"
            ,  '" + N_COMP + @"'
            ,  '" + N_COMP_CAN + @"'
            ,  '" + T_COMP + @"'
            ,  '" + T_COMP_CAN + @"'
            ,  " + IMP_CAN_UN + @"
            ,  " + IMP_VT_UNI + @"
            ,  " + IMP_VT_EXT + @"
            ,  " + IM_CAN_EXT + @"
            ,  " + IM_CA_UN_E + @"
            ,  " + IM_VT_UN_E + @"
            , (SELECT ID_GVA12 FROM GVA12 WHERE T_COMP = '" + T_COMP_CAN + @"' AND N_COMP = '" + N_COMP_CAN + @"')
            ,  '" + MOTIVO + @"'
            )
            ";
            return sql;
        }
        public GVA07()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("CONFIG\\GVA07.xml");
            FILLER=ds.Tables[0].Rows[0]["FILLER"].ToString();
            FECHA_VTO=ds.Tables[0].Rows[0]["FECHA_VTO"].ToString();
            F_COMP_CAN=ds.Tables[0].Rows[0]["F_COMP_CAN"].ToString();
            IMPORTE_VT=ds.Tables[0].Rows[0]["IMPORTE_VT"].ToString();
            IMPORT_CAN=ds.Tables[0].Rows[0]["IMPORT_CAN"].ToString();
            MISMO_CLIE=ds.Tables[0].Rows[0]["MISMO_CLIE"].ToString();
            N_COMP=ds.Tables[0].Rows[0]["N_COMP"].ToString();
            N_COMP_CAN=ds.Tables[0].Rows[0]["N_COMP_CAN"].ToString();
            T_COMP=ds.Tables[0].Rows[0]["T_COMP"].ToString();
            T_COMP_CAN=ds.Tables[0].Rows[0]["T_COMP_CAN"].ToString();
            IMP_CAN_UN=ds.Tables[0].Rows[0]["IMP_CAN_UN"].ToString();
            IMP_VT_UNI=ds.Tables[0].Rows[0]["IMP_VT_UNI"].ToString();
            IMP_VT_EXT=ds.Tables[0].Rows[0]["IMP_VT_EXT"].ToString();
            IM_CAN_EXT=ds.Tables[0].Rows[0]["IM_CAN_EXT"].ToString();
            IM_CA_UN_E=ds.Tables[0].Rows[0]["IM_CA_UN_E"].ToString();
            IM_VT_UN_E=ds.Tables[0].Rows[0]["IM_VT_UN_E"].ToString();
            ID_GVA12_CAN=ds.Tables[0].Rows[0]["ID_GVA12_CAN"].ToString();
            MOTIVO=ds.Tables[0].Rows[0]["MOTIVO"].ToString();
            ds.Dispose();
        }

        internal string TOGVA46()
        {
            return @"UPDATE GVA46 SET ESTADO_VTO = 'PAG',ESTADO_UNI='PAG' WHERE 
                    T_COMP = '" + T_COMP + @"' AND N_COMP = '" + N_COMP + @"' 
                    AND FECHA_VTO = CONVERT(DATETIME,'" + FECHA_VTO + "',103)";
        }
    }
}
