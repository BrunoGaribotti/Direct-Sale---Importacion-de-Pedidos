using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class SBA04
    {
        public string ID_SBA04 = "";
        public string FILLER = "";
        public string BARRA = "";
        public string CERRADO = "";
        public string CLASE = "";
        public string COD_COMP = "";
        public string CONCEPTO = "";
        public string COTIZACION = "";
        public string EXPORTADO = "";
        public string EXTERNO = "";
        public string FECHA = "";
        public string FECHA_ING = "";
        public string HORA_ING = "";
        public string N_COMP = "";
        public string N_INTERNO = "";
        public string PASE = "";
        public string SITUACION = "";
        public string TERMINAL = "";
        public string USUARIO = "";
        public string LOTE = "";
        public string LOTE_ANU = "";
        public string SUCUR_ORI = "";
        public string FECHA_ORI = "";
        public string C_COMP_ORI = "";
        public string N_COMP_ORI = "";
        public string BARRA_ORI = "";
        public string FECHA_EMIS = "";
        public string GENERA_ASIENTO = "";
        public string FECHA_ULTIMA_MODIFICACION = "";
        public string HORA_ULTIMA_MODIFICACION = "";
        public string USUA_ULTIMA_MODIFICACION = "";
        public string TERM_ULTIMA_MODIFICACION = "";
        public string ID_PUESTO_CAJA = "";
        public string ID_GVA81 = "";
        public string ID_SBA02 = "";
        public string ID_SBA02_C_COMP_ORI = "";
        public string COD_GVA14 = "";
        public string COD_CPA01 = "";
        public string ID_CODIGO_RELACION = "";
        public string ID_LEGAJO = "";
        public string OBSERVACIONES = "";
        public string TIPO_COD_RELACIONADO = "";
        public string CN_ASTOR = "";
        public string ID_MODELO_INGRESO_SB = "";
        public decimal TOTAL_IMPORTE_CTE = 0;
        public decimal TOTAL_IMPORTE_EXT = 0;
        public string TRANSFERENCIA_DEVOLUCION_CUPONES = "";
      
        public string insert()
        {
            string sql = "";
            sql = @"
            INSERT INTO SBA04 
            (
            FILLER
            ,BARRA
            ,CERRADO
            ,CLASE
            ,COD_COMP
            ,CONCEPTO
            ,COTIZACION
            ,EXPORTADO
            ,EXTERNO
            ,FECHA
            ,FECHA_ING
            ,HORA_ING
            ,N_COMP
            ,N_INTERNO
            ,PASE
            ,SITUACION
            ,TERMINAL
            ,USUARIO
            ,LOTE
            ,LOTE_ANU
            ,SUCUR_ORI
            ,FECHA_ORI
            ,C_COMP_ORI
            ,N_COMP_ORI
            ,BARRA_ORI
            ,FECHA_EMIS
            ,GENERA_ASIENTO
            ,FECHA_ULTIMA_MODIFICACION
            ,HORA_ULTIMA_MODIFICACION
            ,USUA_ULTIMA_MODIFICACION
            ,TERM_ULTIMA_MODIFICACION
            ,ID_PUESTO_CAJA
            ,ID_GVA81
            ,ID_SBA02
            ,ID_SBA02_C_COMP_ORI
            ,COD_GVA14
            ,COD_CPA01
            ,ID_CODIGO_RELACION
            ,ID_LEGAJO
            ,OBSERVACIONES
            ,TIPO_COD_RELACIONADO
            ,CN_ASTOR
            ,ID_MODELO_INGRESO_SB
            ,TOTAL_IMPORTE_CTE
            ,TOTAL_IMPORTE_EXT
            ,TRANSFERENCIA_DEVOLUCION_CUPONES
            ) VALUES ( 
            '" + FILLER + @"'
            ," + BARRA + @" 
            ," + CERRADO + @" 
            ," + CLASE + @" 
           ,'" + COD_COMP + @"'
           ,'" + CONCEPTO + @"'
            ," + COTIZACION + @" 
            ," + EXPORTADO + @" 
            ," + EXTERNO + @" 
            ,CONVERT(DATETIME,'" + FECHA + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_ING + @"',103)
           ,'" + HORA_ING + @"'
           ,'" + N_COMP + @"'
            ,(SELECT ISNULL(MAX(N_INTERNO),0) +1 FROM SBA04)
            ," + PASE + @" 
           ,'" + SITUACION + @"'
           ,'" + TERMINAL + @"'
           ,'" + USUARIO + @"'
            ," + LOTE + @" 
            ," + LOTE_ANU + @" 
            ," + SUCUR_ORI + @" 
            ,CONVERT(DATETIME,'" + FECHA_ORI + @"',103)
           ,'" + C_COMP_ORI + @"'
           ,'" + N_COMP_ORI + @"'
            ," + BARRA_ORI + @" 
            ,CONVERT(DATETIME,'" + FECHA_EMIS + @"',103)
            ,'" + GENERA_ASIENTO + @"'
            ," + FECHA_ULTIMA_MODIFICACION + @" 
           ,'" + HORA_ULTIMA_MODIFICACION + @"'
           ,'" + USUA_ULTIMA_MODIFICACION + @"'
           ,'" + TERM_ULTIMA_MODIFICACION + @"'
            ," + ID_PUESTO_CAJA + @" 
            ," + ID_GVA81 + @" 
            ," + ID_SBA02 + @" 
            ," + ID_SBA02_C_COMP_ORI + @" 
           ,'" + COD_GVA14 + @"'
           ,'" + COD_CPA01 + @"'
            ," + ID_CODIGO_RELACION + @" 
            ," + ID_LEGAJO + @" 
            ,'" + OBSERVACIONES + @"'
            ,'" + TIPO_COD_RELACIONADO + @"' 
            ,'" + CN_ASTOR + @"'
            ," + ID_MODELO_INGRESO_SB + @" 
            ," + TOTAL_IMPORTE_CTE.ToString().Replace(",",".") + @" 
            ," + TOTAL_IMPORTE_EXT.ToString().Replace(",", ".") + @" 
           ,'" + TRANSFERENCIA_DEVOLUCION_CUPONES + @"'
            )
            ";
            return sql;
        }
        
        public SBA04()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("CONFIG\\SBA04.xml");
            FILLER = ds.Tables[0].Rows[0]["FILLER"].ToString();
            BARRA = ds.Tables[0].Rows[0]["BARRA"].ToString();
            CERRADO = ds.Tables[0].Rows[0]["CERRADO"].ToString();
            CLASE = ds.Tables[0].Rows[0]["CLASE"].ToString();
            COD_COMP = ds.Tables[0].Rows[0]["COD_COMP"].ToString();
            CONCEPTO = ds.Tables[0].Rows[0]["CONCEPTO"].ToString();
            COTIZACION = ds.Tables[0].Rows[0]["COTIZACION"].ToString();
            EXPORTADO = ds.Tables[0].Rows[0]["EXPORTADO"].ToString();
            EXTERNO = ds.Tables[0].Rows[0]["EXTERNO"].ToString();
            FECHA = ds.Tables[0].Rows[0]["FECHA"].ToString();
            FECHA_ING = ds.Tables[0].Rows[0]["FECHA_ING"].ToString();
            HORA_ING = ds.Tables[0].Rows[0]["HORA_ING"].ToString();
            N_COMP = ds.Tables[0].Rows[0]["N_COMP"].ToString();
            N_INTERNO = ds.Tables[0].Rows[0]["N_INTERNO"].ToString();
            PASE = ds.Tables[0].Rows[0]["PASE"].ToString();
            SITUACION = ds.Tables[0].Rows[0]["SITUACION"].ToString();
            TERMINAL = ds.Tables[0].Rows[0]["TERMINAL"].ToString();
            USUARIO = ds.Tables[0].Rows[0]["USUARIO"].ToString();
            LOTE = ds.Tables[0].Rows[0]["LOTE"].ToString();
            LOTE_ANU = ds.Tables[0].Rows[0]["LOTE_ANU"].ToString();
            SUCUR_ORI = ds.Tables[0].Rows[0]["SUCUR_ORI"].ToString();
            FECHA_ORI = ds.Tables[0].Rows[0]["FECHA_ORI"].ToString();
            C_COMP_ORI = ds.Tables[0].Rows[0]["C_COMP_ORI"].ToString();
            N_COMP_ORI = ds.Tables[0].Rows[0]["N_COMP_ORI"].ToString();
            BARRA_ORI = ds.Tables[0].Rows[0]["BARRA_ORI"].ToString();
            FECHA_EMIS = ds.Tables[0].Rows[0]["FECHA_EMIS"].ToString();
            GENERA_ASIENTO = ds.Tables[0].Rows[0]["GENERA_ASIENTO"].ToString();
            FECHA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["FECHA_ULTIMA_MODIFICACION"].ToString();
            HORA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["HORA_ULTIMA_MODIFICACION"].ToString();
            USUA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["USUA_ULTIMA_MODIFICACION"].ToString();
            TERM_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["TERM_ULTIMA_MODIFICACION"].ToString();
            ID_PUESTO_CAJA = ds.Tables[0].Rows[0]["ID_PUESTO_CAJA"].ToString();
            ID_GVA81 = ds.Tables[0].Rows[0]["ID_GVA81"].ToString();
            ID_SBA02 = ds.Tables[0].Rows[0]["ID_SBA02"].ToString();
            ID_SBA02_C_COMP_ORI = ds.Tables[0].Rows[0]["ID_SBA02_C_COMP_ORI"].ToString();
            COD_GVA14 = ds.Tables[0].Rows[0]["COD_GVA14"].ToString();
            COD_CPA01 = ds.Tables[0].Rows[0]["COD_CPA01"].ToString();
            ID_CODIGO_RELACION = ds.Tables[0].Rows[0]["ID_CODIGO_RELACION"].ToString();
            ID_LEGAJO = ds.Tables[0].Rows[0]["ID_LEGAJO"].ToString();
            OBSERVACIONES = ds.Tables[0].Rows[0]["OBSERVACIONES"].ToString();
            TIPO_COD_RELACIONADO = ds.Tables[0].Rows[0]["TIPO_COD_RELACIONADO"].ToString();
            CN_ASTOR = ds.Tables[0].Rows[0]["CN_ASTOR"].ToString();
            ID_MODELO_INGRESO_SB = ds.Tables[0].Rows[0]["ID_MODELO_INGRESO_SB"].ToString();
            TOTAL_IMPORTE_CTE = 0;
            TOTAL_IMPORTE_EXT = 0;
            TRANSFERENCIA_DEVOLUCION_CUPONES = ds.Tables[0].Rows[0]["TRANSFERENCIA_DEVOLUCION_CUPONES"].ToString();
            ds.Dispose();
        }

        internal string TOASIENTO_COMPROBANTE_SB()
        {
            return @"
                    INSERT INTO [ASIENTO_COMPROBANTE_SB]
                   (ID_ASIENTO_COMPROBANTE_SB
                   ,N_INTERNO
                   ,[ASIENTO_ANULACION]
                   ,[CONTABILIZADO]
                   ,[USUARIO_CONTABILIZACION]
                   ,[FECHA_CONTABILIZACION]
                   ,[TERMINAL_CONTABILIZACION]
                   ,[TRANSFERIDO_CN])
             VALUES
                   (next value for sequence_asiento_comprobante_sb
                   ,(SELECT MAX(N_INTERNO) +1 FROM SBA04)
                   ,'N'
                   ,'N'
                   ,NULL
                   ,NULL
                   ,NULL
                   ,'N')

                    "; //((SELECT ISNULL(MAX(ID_ASIENTO_COMPROBANTE_SB),0) + 1 FROM ASIENTO_COMPROBANTE_SB ) cambiado por la sequence y +1 al max(N_INTERNO)
        }



    }

}
