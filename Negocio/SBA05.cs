using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class SBA05
    {
        public string ID_SBA05 = "";
        public string FILLER = "";
        public string BARRA = "";
        public decimal CANT_MONE = 0;
        public string CHEQUES = "";
        public string CLASE = "";
        public string COD_COMP = "";
        public string COD_CTA = "";
        public string COD_OPERAC = "";
        public string CONCILIADO = "";
        public decimal COTIZ_MONE = 0;
        public string D_H = "";
        public string EFECTIVO = "";
        public string FECHA = "";
        public string FECHA_CONC = "";
        public string LEYENDA = "";
        public decimal MONTO = 0;
        public string N_COMP = "";
        public string RENGLON = "";
        public decimal UNIDADES = 0;
        public string VA_DIRECTO = "";
        public string ID_SBA02 = "";
        public string ID_GVA81 = "";
        public string CONC_EFTV = "";
        public string F_CONC_EFT = "";
        public string COMENTARIO = "";
        public string COMENTARIO_EFT = "";
        public string COD_GVA14 = "";
        public string COD_CPA01 = "";
        public string ID_CODIGO_RELACION = "";
        public string ID_LEGAJO = "";
        public string TIPO_COD_RELACIONADO = "";
        public string ID_TIPO_COTIZACION = "";
        public string ID_SBA11 = "";
        public string insert()
        {
            string sql = "";
            sql = @"
            INSERT INTO SBA05 
            (
            FILLER
            ,BARRA
            ,CANT_MONE
            ,CHEQUES
            ,CLASE
            ,COD_COMP
            ,COD_CTA
            ,COD_OPERAC
            ,CONCILIADO
            ,COTIZ_MONE
            ,D_H
            ,EFECTIVO
            ,FECHA
            ,FECHA_CONC
            ,LEYENDA
            ,MONTO
            ,N_COMP
            ,RENGLON
            ,UNIDADES
            ,VA_DIRECTO
            ,ID_SBA02
            ,ID_GVA81
            ,CONC_EFTV
            ,F_CONC_EFT
            ,COMENTARIO
            ,COMENTARIO_EFT
            ,COD_GVA14
            ,COD_CPA01
            ,ID_CODIGO_RELACION
            ,ID_LEGAJO
            ,TIPO_COD_RELACIONADO
            ,ID_TIPO_COTIZACION
            ,ID_SBA11
            ) VALUES ( 
           '" + FILLER + @"'
            ," + BARRA + @" 
            ," + CANT_MONE.ToString().Replace(",", ".") + @" 
            ," + CHEQUES + @" 
            ," + CLASE + @" 
           ,'" + COD_COMP + @"'
            ," + COD_CTA + @" 
           ,'" + COD_OPERAC + @"'
            ," + CONCILIADO + @" 
            ," + COTIZ_MONE + @" 
           ,'" + D_H + @"'
            ," + EFECTIVO + @" 
            ,CONVERT(DATETIME,'" + FECHA + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_CONC + @"',103)
           ,'" + LEYENDA + @"'
            ," + MONTO.ToString().Replace(",", ".") + @" 
           ,'" + N_COMP + @"'
            ," + RENGLON + @" 
            ," + UNIDADES.ToString().Replace(",",".") + @" 
           ,'" + VA_DIRECTO + @"'
            ," + ID_SBA02 + @" 
            ," + ID_GVA81 + @" 
            ," + CONC_EFTV + @" 
            ,CONVERT(DATETIME,'" + F_CONC_EFT + @"',103)
           ,'" + COMENTARIO + @"'
           ,'" + COMENTARIO_EFT + @"'
           ,'" + COD_GVA14 + @"'
           ," + COD_CPA01 + @"
            ," + ID_CODIGO_RELACION + @" 
            ," + ID_LEGAJO + @" 
            ,'" + TIPO_COD_RELACIONADO + @"'
            ," + ID_TIPO_COTIZACION + @" 
            ," + ID_SBA11 + @" 
            )
            ";
            return sql;
        }
        
        public SBA05(string p)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("CONFIG\\SBA05.XML");
            ID_SBA05 = ds.Tables[0].Rows[0]["ID_SBA05"].ToString();
            FILLER = ds.Tables[0].Rows[0]["FILLER"].ToString();
            BARRA = ds.Tables[0].Rows[0]["BARRA"].ToString();
            CANT_MONE = 0;
            CHEQUES = ds.Tables[0].Rows[0]["CHEQUES"].ToString();
            CLASE = ds.Tables[0].Rows[0]["CLASE"].ToString();
            COD_COMP = ds.Tables[0].Rows[0]["COD_COMP"].ToString();
            COD_CTA = ds.Tables[0].Rows[0]["COD_CTA"].ToString();
            COD_OPERAC = ds.Tables[0].Rows[0]["COD_OPERAC"].ToString();
            CONCILIADO = ds.Tables[0].Rows[0]["CONCILIADO"].ToString();
            COTIZ_MONE = 1;
            D_H = ds.Tables[0].Rows[0]["D_H"].ToString();
            EFECTIVO = ds.Tables[0].Rows[0]["EFECTIVO"].ToString();
            FECHA = ds.Tables[0].Rows[0]["FECHA"].ToString();
            FECHA_CONC = ds.Tables[0].Rows[0]["FECHA_CONC"].ToString();
            LEYENDA = ds.Tables[0].Rows[0]["LEYENDA"].ToString();
            MONTO = 0;
            N_COMP = ds.Tables[0].Rows[0]["N_COMP"].ToString();
            RENGLON = ds.Tables[0].Rows[0]["RENGLON"].ToString();
            UNIDADES = 0;
            VA_DIRECTO = ds.Tables[0].Rows[0]["VA_DIRECTO"].ToString();
            ID_SBA02 = ds.Tables[0].Rows[0]["ID_SBA02"].ToString();
            ID_GVA81 = ds.Tables[0].Rows[0]["ID_GVA81"].ToString();
            CONC_EFTV = ds.Tables[0].Rows[0]["CONC_EFTV"].ToString();
            F_CONC_EFT = ds.Tables[0].Rows[0]["F_CONC_EFT"].ToString();
            COMENTARIO = ds.Tables[0].Rows[0]["COMENTARIO"].ToString();
            COMENTARIO_EFT = ds.Tables[0].Rows[0]["COMENTARIO_EFT"].ToString();
            COD_GVA14 = ds.Tables[0].Rows[0]["COD_GVA14"].ToString();
            COD_CPA01 = ds.Tables[0].Rows[0]["COD_CPA01"].ToString();
            ID_CODIGO_RELACION = ds.Tables[0].Rows[0]["ID_CODIGO_RELACION"].ToString();
            ID_LEGAJO = ds.Tables[0].Rows[0]["ID_LEGAJO"].ToString();
            TIPO_COD_RELACIONADO = ds.Tables[0].Rows[0]["TIPO_COD_RELACIONADO"].ToString();
            ID_TIPO_COTIZACION = ds.Tables[0].Rows[0]["ID_TIPO_COTIZACION"].ToString();
            ID_SBA11 = ds.Tables[0].Rows[0]["ID_SBA11"].ToString();

            if (p.Equals("D"))
            {
                COD_OPERAC = "";
                RENGLON = "1";
                ID_SBA11 = "NULL";
            }

            ds.Dispose();
        }

        internal string TOSBA01()
        {
            string SIGNO = "+";

            if (D_H == "H")
            {
                SIGNO = "-";
            }

            return @"UPDATE SBA01 set SALDO_A_MO= SALDO_A_MO " + SIGNO + MONTO.ToString().Replace(",", ".") + " ,SALDO_A_UN= SALDO_A_UN  " + SIGNO + MONTO.ToString().Replace(",", ".") + "  ,SALDO_ACT= SALDO_ACT  " + SIGNO + MONTO.ToString().Replace(",", ".") + " WHERE COD_CTA=" + COD_CTA + "";
        }
    }

}
