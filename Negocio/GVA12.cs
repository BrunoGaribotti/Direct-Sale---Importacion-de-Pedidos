using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class GVA12
    {
        public string FECHA_VTO = "";
        public string T_COMP_FAC = "";
        public string N_COMP_FAC = "";
        public string ID_GVA12_CAN = "";
        public string CUENTA = "";

        public string ID_GVA12 = "";
        public string FILLER = "";
        public string AFEC_STK = "";
        public string CANC_COMP = "";
        public string CANT_HOJAS = "";
        public string CAT_IVA = "";
        public string CENT_STK = "";
        public string CENT_COB = "";
        public string CITI_OPERA = "";
        public string CITI_TIPO = "";
        public string COD_CAJA = "";
        public string COD_CLIENT = "";
        public string COD_SUCURS = "";
        public string COD_TRANSP = "";
        public string COD_VENDED = "";
        public string COND_VTA = "";
        public string CONTABILIZ = "";
        public string CONTFISCAL = "";
        public string COTIZ = "";
        public string DESC_PANT = "";
        public string ESTADO = "";
        public string ESTADO_STK = "";
        public string EXPORTADO = "";
        public string FECHA_ANU = "";
        public string FECHA_EMIS = "";
        public string ID_CIERRE = "";
        public decimal IMPORTE = 0;
        public string IMPORTE_BO = "";
        public string IMPORTE_EX = "";
        public string IMPORTE_FL = "";
        public string IMPORTE_GR = "";
        public string IMPORTE_IN = "";
        public string IMPORTE_IV = "";
        public string IMP_TICK_N = "";
        public string IMP_TICK_P = "";
        public string LEYENDA = "";
        public string LOTE = "";
        public string MON_CTE = "";
        public string MOTI_ANU = "";
        public string NRO_DE_LIS = "";
        public string NRO_SUCURS = "";
        public string N_COMP = "";
        public string ORIGEN = "";
        public string PORC_BONIF = "";
        public string PORC_PRO = "";
        public string PORC_REC = "";
        public string PORC_TICK = "";
        public string PROPINA = "";
        public string PROPINA_EX = "";
        public string PTO_VTA = "";
        public string REC_PANT = "";
        public string TALONARIO = "";
        public string TCOMP_IN_V = "";
        public string TICKET = "";
        public string TIPO_ASIEN = "";
        public string TIPO_EXPOR = "";
        public string TIPO_VEND = "";
        public string T_COMP = "";
        public string T_FORM = "";
        public decimal UNIDADES = 0;
        public string LOTE_ANU = "";
        public string PORC_INT = "";
        public string PORC_FLE = "";
        public string ESTADO_UNI = "";
        public string ID_CFISCAL = "";
        public string NUMERO_Z = "";
        public string HORA_COMP = "";
        public string SENIA = "";
        public string ID_TURNO = "";
        public string ID_TURNOX = "";
        public string HORA_ANU = "";
        public string CCONTROL = "";
        public string ID_A_RENTA = "";
        public string COD_CLASIF = "";
        public string AFEC_CIERR = "";
        public string CAICAE = "";
        public string CAICAE_VTO = "";
        public string DOC_ELECTR = "";
        public string SERV_DESDE = "";
        public string SERV_HASTA = "";
        public string CANT_IMP = "";
        public string CANT_MAIL = "";
        public string ULT_IMP = "";
        public string ULT_MAIL = "";
        public string MORA_SOBRE = "";
        public string ESTADO_ANT = "";
        public string T_DOC_DTE = "";
        public string DTE_ANU = "";
        public string FOLIO_ANU = "";
        public string REBAJA_DEB = "";
        public string SUCURS_SII = "";
        public string EXENTA = "";
        public string MOTIVO_DTE = "";
        public string IMPOR_EXT = "";
        public string CERRADO = "";
        public string IMP_BO_EXT = "";
        public string IMP_EX_EXT = "";
        public string IMP_FL_EXT = "";
        public string IMP_GR_EXT = "";
        public string IMP_IN_EXT = "";
        public string IMP_IV_EXT = "";
        public string IM_TIC_N_E = "";
        public string IM_TIC_P_E = "";
        public string UNIDAD_EXT = "";
        public string PROPIN_EXT = "";
        public string PRO_EX_EXT = "";
        public string REC_PAN_EX = "";
        public string DES_PAN_EX = "";
        public string T_DTO_COMP = "";
        public string RECARGO_PV = "";
        public string NCOMP_IN_V = "";
        public string ID_ASIENTO_MODELO_GV = "";
        public string GENERA_ASIENTO = "";
        public string FECHA_INGRESO = "";
        public string HORA_INGRESO = "";
        public string USUARIO_INGRESO = "";
        public string TERMINAL_INGRESO = "";
        public string FECHA_ULTIMA_MODIFICACION = "";
        public string HORA_ULTIMA_MODIFICACION = "";
        public string USUA_ULTIMA_MODIFICACION = "";
        public string TERM_ULTIMA_MODIFICACION = "";
        public string ID_PUESTO_CAJA = "";
        public string NCOMP_IN_ORIGEN = "";
        public string OBS_COMERC = "";
        public string OBSERVAC = "";
        public string LEYENDA_1 = "";
        public string LEYENDA_2 = "";
        public string LEYENDA_3 = "";
        public string LEYENDA_4 = "";
        public string LEYENDA_5 = "";
        public string IMP_CIGARRILLOS = "";
        public string POR_CIGARRILLOS = "";
        public string ID_MOTIVO_NOTA_CREDITO = "";
        public string FECHA_DESCARGA_PDF = "";
        public string HORA_DESCARGA_PDF = "";
        public string USUARIO_DESCARGA_PDF = "";
        public string ID_DIRECCION_ENTREGA = "";
        public string ID_HISTORIAL_RENDICION = "";
        public string IMPUTACION_MODIFICADA = "";
        public string PUBLICADO_WEB_CLIENTES = "";
        public string RG_3572_TIPO_OPERACION_HABITUAL_VENTAS = "";
        public string RG_3685_TIPO_OPERACION_VENTAS = "";
        public string DESCRIPCION_FACTURA = "";
        public string ID_NEXO_COBRANZAS_PAGO = "";
        public string TIPO_TRANSACCION_VENTA = "";
        public string TIPO_TRANSACCION_COMPRA = "";
        
        public string TOGVA_SALDO()
        {

            string sql = "";

            sql = @"UPDATE GVA14 
                    SET SALDO_CC = SALDO_CC - " + IMPORTE.ToString().Replace(",", ".") + @"
                    ,SALDO_CC_U = SALDO_CC_U - " + IMPORTE.ToString().Replace(",", ".") + @"
                    WHERE COD_CLIENT = '" + COD_CLIENT + @"'                    
                    ";

            return sql;
        }

        public string insert()
        {
            string sql = "";
            sql = @"
            INSERT INTO GVA12 
            (
            FILLER
            ,AFEC_STK
            ,CANC_COMP
            ,CANT_HOJAS
            ,CAT_IVA
            ,CENT_STK
            ,CENT_COB
            ,CITI_OPERA
            ,CITI_TIPO
            ,COD_CAJA
            ,COD_CLIENT
            ,COD_SUCURS
            ,COD_TRANSP
            ,COD_VENDED
            ,COND_VTA
            ,CONTABILIZ
            ,CONTFISCAL
            ,COTIZ
            ,DESC_PANT
            ,ESTADO
            ,ESTADO_STK
            ,EXPORTADO
            ,FECHA_ANU
            ,FECHA_EMIS
            ,ID_CIERRE
            ,IMPORTE
            ,IMPORTE_BO
            ,IMPORTE_EX
            ,IMPORTE_FL
            ,IMPORTE_GR
            ,IMPORTE_IN
            ,IMPORTE_IV
            ,IMP_TICK_N
            ,IMP_TICK_P
            ,LEYENDA
            ,LOTE
            ,MON_CTE
            ,MOTI_ANU
            ,NRO_DE_LIS
            ,NRO_SUCURS
            ,N_COMP
            ,ORIGEN
            ,PORC_BONIF
            ,PORC_PRO
            ,PORC_REC
            ,PORC_TICK
            ,PROPINA
            ,PROPINA_EX
            ,PTO_VTA
            ,REC_PANT
            ,TALONARIO
            ,TCOMP_IN_V
            ,TICKET
            ,TIPO_ASIEN
            ,TIPO_EXPOR
            ,TIPO_VEND
            ,T_COMP
            ,T_FORM
            ,UNIDADES
            ,LOTE_ANU
            ,PORC_INT
            ,PORC_FLE
            ,ESTADO_UNI
            ,ID_CFISCAL
            ,NUMERO_Z
            ,HORA_COMP
            ,SENIA
            ,ID_TURNO
            ,ID_TURNOX
            ,HORA_ANU
            ,CCONTROL
            ,ID_A_RENTA
            ,COD_CLASIF
            ,AFEC_CIERR
            ,CAICAE
            ,CAICAE_VTO
            ,DOC_ELECTR
            ,SERV_DESDE
            ,SERV_HASTA
            ,CANT_IMP
            ,CANT_MAIL
            ,ULT_IMP
            ,ULT_MAIL
            ,MORA_SOBRE
            ,ESTADO_ANT
            ,T_DOC_DTE
            ,DTE_ANU
            ,FOLIO_ANU
            ,REBAJA_DEB
            ,SUCURS_SII
            ,EXENTA
            ,MOTIVO_DTE
            ,IMPOR_EXT
            ,CERRADO
            ,IMP_BO_EXT
            ,IMP_EX_EXT
            ,IMP_FL_EXT
            ,IMP_GR_EXT
            ,IMP_IN_EXT
            ,IMP_IV_EXT
            ,IM_TIC_N_E
            ,IM_TIC_P_E
            ,UNIDAD_EXT
            ,PROPIN_EXT
            ,PRO_EX_EXT
            ,REC_PAN_EX
            ,DES_PAN_EX
            ,T_DTO_COMP
            ,RECARGO_PV
            ,NCOMP_IN_V
            ,ID_ASIENTO_MODELO_GV
            ,GENERA_ASIENTO
            ,FECHA_INGRESO
            ,HORA_INGRESO
            ,USUARIO_INGRESO
            ,TERMINAL_INGRESO
            ,FECHA_ULTIMA_MODIFICACION
            ,HORA_ULTIMA_MODIFICACION
            ,USUA_ULTIMA_MODIFICACION
            ,TERM_ULTIMA_MODIFICACION
            ,ID_PUESTO_CAJA
            ,NCOMP_IN_ORIGEN
            ,OBS_COMERC
            ,OBSERVAC
            ,LEYENDA_1
            ,LEYENDA_2
            ,LEYENDA_3
            ,LEYENDA_4
            ,LEYENDA_5
            ,IMP_CIGARRILLOS
            ,POR_CIGARRILLOS
            ,ID_MOTIVO_NOTA_CREDITO
            ,FECHA_DESCARGA_PDF
            ,HORA_DESCARGA_PDF
            ,USUARIO_DESCARGA_PDF
            ,ID_DIRECCION_ENTREGA
            ,ID_HISTORIAL_RENDICION
            ,IMPUTACION_MODIFICADA
            ,PUBLICADO_WEB_CLIENTES
            ,RG_3572_TIPO_OPERACION_HABITUAL_VENTAS
            ,RG_3685_TIPO_OPERACION_VENTAS
            ,DESCRIPCION_FACTURA
            ,ID_NEXO_COBRANZAS_PAGO
            ) VALUES ( 
            '" + FILLER + @"'
            ," + AFEC_STK + @" 
           ,'" + CANC_COMP + @"'
            ," + CANT_HOJAS + @" 
           ,'" + CAT_IVA + @"'
           ,'" + CENT_STK + @"'
           ,'" + CENT_COB + @"'
           ,'" + CITI_OPERA + @"'
           ,'" + CITI_TIPO + @"'
            ," + COD_CAJA + @" 
           ,'" + COD_CLIENT + @"'
           ,'" + COD_SUCURS + @"'
           ,'" + COD_TRANSP + @"'
           ,'" + COD_VENDED + @"'
            ," + COND_VTA + @" 
            ," + CONTABILIZ + @" 
            ," + CONTFISCAL + @" 
            ," + COTIZ + @" 
            ," + DESC_PANT + @" 
           ,'" + ESTADO + @"'
           ,'" + ESTADO_STK + @"'
            ," + EXPORTADO + @" 
            ,CONVERT(DATETIME,'" + FECHA_ANU + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_EMIS + @"',103)
            ," + ID_CIERRE + @" 
            ," + IMPORTE.ToString().Replace(",",".") + @" 
            ," + IMPORTE_BO + @" 
            ," + IMPORTE_EX + @" 
            ," + IMPORTE_FL + @" 
            ," + IMPORTE_GR + @" 
            ," + IMPORTE_IN + @" 
            ," + IMPORTE_IV + @" 
            ," + IMP_TICK_N + @" 
            ," + IMP_TICK_P + @" 
           ,'" + LEYENDA + @"'
            ," + LOTE + @" 
            ," + MON_CTE + @" 
           ,'" + MOTI_ANU + @"'
            ," + NRO_DE_LIS + @" 
            ," + NRO_SUCURS + @" 
           ,'" + N_COMP + @"'
           ,'" + ORIGEN + @"'
            ," + PORC_BONIF + @" 
            ," + PORC_PRO + @" 
            ," + PORC_REC + @" 
            ," + PORC_TICK + @" 
            ," + PROPINA + @" 
            ," + PROPINA_EX + @" 
            ," + PTO_VTA + @" 
            ," + REC_PANT + @" 
            ," + TALONARIO + @" 
           ,'" + TCOMP_IN_V + @"'
           ,'" + TICKET + @"'
           ,'" + TIPO_ASIEN + @"'
           ,'" + TIPO_EXPOR + @"'
           ,'" + TIPO_VEND + @"'
           ,'" + T_COMP + @"'
           ,'" + T_FORM + @"'
            ," + UNIDADES.ToString().Replace(",", ".") + @" 
            ," + LOTE_ANU + @" 
            ," + PORC_INT + @" 
            ," + PORC_FLE + @" 
           ,'" + ESTADO_UNI + @"'
           ,'" + ID_CFISCAL + @"'
            ," + NUMERO_Z + @" 
           ,'" + HORA_COMP + @"'
            ," + SENIA + @" 
            ," + ID_TURNO + @" 
            ," + ID_TURNOX + @" 
           ,'" + HORA_ANU + @"'
           ,'" + CCONTROL + @"'
            ," + ID_A_RENTA + @" 
           ,'" + COD_CLASIF + @"'
           ,'" + AFEC_CIERR + @"'
           ,'" + CAICAE + @"'
            ,CONVERT(DATETIME,'" + CAICAE_VTO + @"',103)
            ," + DOC_ELECTR + @" 
            ,CONVERT(DATETIME,'" + SERV_DESDE + @"',103)
            ,CONVERT(DATETIME,'" + SERV_HASTA + @"',103)
            ," + CANT_IMP + @" 
            ," + CANT_MAIL + @" 
            ,CONVERT(DATETIME,'" + ULT_IMP + @"',103)
            ,CONVERT(DATETIME,'" + ULT_MAIL + @"',103)
           ,'" + MORA_SOBRE + @"'
           ,'" + ESTADO_ANT + @"'
           ,'" + T_DOC_DTE + @"'
           ,'" + DTE_ANU + @"'
           ,'" + FOLIO_ANU + @"'
            ," + REBAJA_DEB + @" 
            ," + SUCURS_SII + @" 
            ," + EXENTA + @" 
            ," + MOTIVO_DTE + @" 
            ," + IMPOR_EXT + @" 
            ," + CERRADO + @" 
            ," + IMP_BO_EXT + @" 
            ," + IMP_EX_EXT + @" 
            ," + IMP_FL_EXT + @" 
            ," + IMP_GR_EXT + @" 
            ," + IMP_IN_EXT + @" 
            ," + IMP_IV_EXT + @" 
            ," + IM_TIC_N_E + @" 
            ," + IM_TIC_P_E + @" 
            ," + UNIDAD_EXT + @" 
            ," + PROPIN_EXT + @" 
            ," + PRO_EX_EXT + @" 
            ," + REC_PAN_EX + @" 
            ," + DES_PAN_EX + @" 
           ,'" + T_DTO_COMP + @"'
            ," + RECARGO_PV + @" 
            ," + NCOMP_IN_V + @" 
            ," + ID_ASIENTO_MODELO_GV + @" 
            ,'" + GENERA_ASIENTO + @"'
            ,CONVERT(DATETIME,'" + FECHA_INGRESO + @"',103)
           ,'" + HORA_INGRESO + @"'
           ,'" + USUARIO_INGRESO + @"'
           ,'" + TERMINAL_INGRESO + @"'
            ,CONVERT(DATETIME,'" + FECHA_ULTIMA_MODIFICACION + @"',103)
           ,'" + HORA_ULTIMA_MODIFICACION + @"'
           ,'" + USUA_ULTIMA_MODIFICACION + @"'
           ,'" + TERM_ULTIMA_MODIFICACION + @"'
            ," + ID_PUESTO_CAJA + @" 
            ," + NCOMP_IN_ORIGEN + @" 
            ," + OBS_COMERC + @" 
            ," + OBSERVAC + @" 
           ,'" + LEYENDA_1 + @"'
           ,'" + LEYENDA_2 + @"'
           ,'" + LEYENDA_3 + @"'
           ,'" + LEYENDA_4 + @"'
           ,'" + LEYENDA_5 + @"'
            ," + IMP_CIGARRILLOS + @" 
            ," + POR_CIGARRILLOS + @" 
            ," + ID_MOTIVO_NOTA_CREDITO + @" 
            ," + FECHA_DESCARGA_PDF + @"
            ," + HORA_DESCARGA_PDF + @"
           ,'" + USUARIO_DESCARGA_PDF + @"'
            ," + ID_DIRECCION_ENTREGA + @" 
            ," + ID_HISTORIAL_RENDICION + @" 
           ,'" + IMPUTACION_MODIFICADA + @"'
           ,'" + PUBLICADO_WEB_CLIENTES + @"'
           ,'" + RG_3572_TIPO_OPERACION_HABITUAL_VENTAS + @"'
           ,'" + RG_3685_TIPO_OPERACION_VENTAS + @"'
           ,'" + DESCRIPCION_FACTURA + @"'
            ," + ID_NEXO_COBRANZAS_PAGO + @" 

            )
            ";
            return sql;
        }
        public GVA12()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("CONFIG\\GVA12.xml");
            ID_GVA12 = ds.Tables[0].Rows[0]["ID_GVA12"].ToString();
            FILLER = ds.Tables[0].Rows[0]["FILLER"].ToString();
            AFEC_STK = ds.Tables[0].Rows[0]["AFEC_STK"].ToString();
            CANC_COMP = ds.Tables[0].Rows[0]["CANC_COMP"].ToString();
            CANT_HOJAS = ds.Tables[0].Rows[0]["CANT_HOJAS"].ToString();
            CAT_IVA = ds.Tables[0].Rows[0]["CAT_IVA"].ToString();
            CENT_STK = ds.Tables[0].Rows[0]["CENT_STK"].ToString();
            CENT_COB = ds.Tables[0].Rows[0]["CENT_COB"].ToString();
            CITI_OPERA = ds.Tables[0].Rows[0]["CITI_OPERA"].ToString();
            CITI_TIPO = ds.Tables[0].Rows[0]["CITI_TIPO"].ToString();
            COD_CAJA = ds.Tables[0].Rows[0]["COD_CAJA"].ToString();
            COD_CLIENT = ds.Tables[0].Rows[0]["COD_CLIENT"].ToString();
            COD_SUCURS = ds.Tables[0].Rows[0]["COD_SUCURS"].ToString();
            COD_TRANSP = ds.Tables[0].Rows[0]["COD_TRANSP"].ToString();
            COD_VENDED = ds.Tables[0].Rows[0]["COD_VENDED"].ToString();
            COND_VTA = ds.Tables[0].Rows[0]["COND_VTA"].ToString();
            CONTABILIZ = ds.Tables[0].Rows[0]["CONTABILIZ"].ToString();
            CONTFISCAL = ds.Tables[0].Rows[0]["CONTFISCAL"].ToString();
            COTIZ = ds.Tables[0].Rows[0]["COTIZ"].ToString();
            DESC_PANT = ds.Tables[0].Rows[0]["DESC_PANT"].ToString();
            ESTADO = ds.Tables[0].Rows[0]["ESTADO"].ToString();
            ESTADO_STK = ds.Tables[0].Rows[0]["ESTADO_STK"].ToString();
            EXPORTADO = ds.Tables[0].Rows[0]["EXPORTADO"].ToString();
            FECHA_ANU = ds.Tables[0].Rows[0]["FECHA_ANU"].ToString();
            FECHA_EMIS = ds.Tables[0].Rows[0]["FECHA_EMIS"].ToString();
            ID_CIERRE = ds.Tables[0].Rows[0]["ID_CIERRE"].ToString();
            IMPORTE = 0;
            IMPORTE_BO = ds.Tables[0].Rows[0]["IMPORTE_BO"].ToString();
            IMPORTE_EX = ds.Tables[0].Rows[0]["IMPORTE_EX"].ToString();
            IMPORTE_FL = ds.Tables[0].Rows[0]["IMPORTE_FL"].ToString();
            IMPORTE_GR = ds.Tables[0].Rows[0]["IMPORTE_GR"].ToString();
            IMPORTE_IN = ds.Tables[0].Rows[0]["IMPORTE_IN"].ToString();
            IMPORTE_IV = ds.Tables[0].Rows[0]["IMPORTE_IV"].ToString();
            IMP_TICK_N = ds.Tables[0].Rows[0]["IMP_TICK_N"].ToString();
            IMP_TICK_P = ds.Tables[0].Rows[0]["IMP_TICK_P"].ToString();
            LEYENDA = ds.Tables[0].Rows[0]["LEYENDA"].ToString();
            LOTE = ds.Tables[0].Rows[0]["LOTE"].ToString();
            MON_CTE = ds.Tables[0].Rows[0]["MON_CTE"].ToString();
            MOTI_ANU = ds.Tables[0].Rows[0]["MOTI_ANU"].ToString();
            NRO_DE_LIS = ds.Tables[0].Rows[0]["NRO_DE_LIS"].ToString();
            NRO_SUCURS = ds.Tables[0].Rows[0]["NRO_SUCURS"].ToString();
            N_COMP = ds.Tables[0].Rows[0]["N_COMP"].ToString();
            ORIGEN = ds.Tables[0].Rows[0]["ORIGEN"].ToString();
            PORC_BONIF = ds.Tables[0].Rows[0]["PORC_BONIF"].ToString();
            PORC_PRO = ds.Tables[0].Rows[0]["PORC_PRO"].ToString();
            PORC_REC = ds.Tables[0].Rows[0]["PORC_REC"].ToString();
            PORC_TICK = ds.Tables[0].Rows[0]["PORC_TICK"].ToString();
            PROPINA = ds.Tables[0].Rows[0]["PROPINA"].ToString();
            PROPINA_EX = ds.Tables[0].Rows[0]["PROPINA_EX"].ToString();
            PTO_VTA = ds.Tables[0].Rows[0]["PTO_VTA"].ToString();
            REC_PANT = ds.Tables[0].Rows[0]["REC_PANT"].ToString();
            TALONARIO = ds.Tables[0].Rows[0]["TALONARIO"].ToString();
            TCOMP_IN_V = ds.Tables[0].Rows[0]["TCOMP_IN_V"].ToString();
            TICKET = ds.Tables[0].Rows[0]["TICKET"].ToString();
            TIPO_ASIEN = ds.Tables[0].Rows[0]["TIPO_ASIEN"].ToString();
            TIPO_EXPOR = ds.Tables[0].Rows[0]["TIPO_EXPOR"].ToString();
            TIPO_VEND = ds.Tables[0].Rows[0]["TIPO_VEND"].ToString();
            T_COMP = ds.Tables[0].Rows[0]["T_COMP"].ToString();
            T_FORM = ds.Tables[0].Rows[0]["T_FORM"].ToString();
            UNIDADES = 0;
            LOTE_ANU = ds.Tables[0].Rows[0]["LOTE_ANU"].ToString();
            PORC_INT = ds.Tables[0].Rows[0]["PORC_INT"].ToString();
            PORC_FLE = ds.Tables[0].Rows[0]["PORC_FLE"].ToString();
            ESTADO_UNI = ds.Tables[0].Rows[0]["ESTADO_UNI"].ToString();
            ID_CFISCAL = ds.Tables[0].Rows[0]["ID_CFISCAL"].ToString();
            NUMERO_Z = ds.Tables[0].Rows[0]["NUMERO_Z"].ToString();
            HORA_COMP = ds.Tables[0].Rows[0]["HORA_COMP"].ToString();
            SENIA = ds.Tables[0].Rows[0]["SENIA"].ToString();
            ID_TURNO = ds.Tables[0].Rows[0]["ID_TURNO"].ToString();
            ID_TURNOX = ds.Tables[0].Rows[0]["ID_TURNOX"].ToString();
            HORA_ANU = ds.Tables[0].Rows[0]["HORA_ANU"].ToString();
            CCONTROL = ds.Tables[0].Rows[0]["CCONTROL"].ToString();
            ID_A_RENTA = ds.Tables[0].Rows[0]["ID_A_RENTA"].ToString();
            COD_CLASIF = ds.Tables[0].Rows[0]["COD_CLASIF"].ToString();
            AFEC_CIERR = ds.Tables[0].Rows[0]["AFEC_CIERR"].ToString();
            CAICAE = ds.Tables[0].Rows[0]["CAICAE"].ToString();
            CAICAE_VTO = ds.Tables[0].Rows[0]["CAICAE_VTO"].ToString();
            DOC_ELECTR = ds.Tables[0].Rows[0]["DOC_ELECTR"].ToString();
            SERV_DESDE = ds.Tables[0].Rows[0]["SERV_DESDE"].ToString();
            SERV_HASTA = ds.Tables[0].Rows[0]["SERV_HASTA"].ToString();
            CANT_IMP = ds.Tables[0].Rows[0]["CANT_IMP"].ToString();
            CANT_MAIL = ds.Tables[0].Rows[0]["CANT_MAIL"].ToString();
            ULT_IMP = ds.Tables[0].Rows[0]["ULT_IMP"].ToString();
            ULT_MAIL = ds.Tables[0].Rows[0]["ULT_MAIL"].ToString();
            MORA_SOBRE = ds.Tables[0].Rows[0]["MORA_SOBRE"].ToString();
            ESTADO_ANT = ds.Tables[0].Rows[0]["ESTADO_ANT"].ToString();
            T_DOC_DTE = ds.Tables[0].Rows[0]["T_DOC_DTE"].ToString();
            DTE_ANU = ds.Tables[0].Rows[0]["DTE_ANU"].ToString();
            FOLIO_ANU = ds.Tables[0].Rows[0]["FOLIO_ANU"].ToString();
            REBAJA_DEB = ds.Tables[0].Rows[0]["REBAJA_DEB"].ToString();
            SUCURS_SII = ds.Tables[0].Rows[0]["SUCURS_SII"].ToString();
            EXENTA = ds.Tables[0].Rows[0]["EXENTA"].ToString();
            MOTIVO_DTE = ds.Tables[0].Rows[0]["MOTIVO_DTE"].ToString();
            IMPOR_EXT = ds.Tables[0].Rows[0]["IMPOR_EXT"].ToString();
            CERRADO = ds.Tables[0].Rows[0]["CERRADO"].ToString();
            IMP_BO_EXT = ds.Tables[0].Rows[0]["IMP_BO_EXT"].ToString();
            IMP_EX_EXT = ds.Tables[0].Rows[0]["IMP_EX_EXT"].ToString();
            IMP_FL_EXT = ds.Tables[0].Rows[0]["IMP_FL_EXT"].ToString();
            IMP_GR_EXT = ds.Tables[0].Rows[0]["IMP_GR_EXT"].ToString();
            IMP_IN_EXT = ds.Tables[0].Rows[0]["IMP_IN_EXT"].ToString();
            IMP_IV_EXT = ds.Tables[0].Rows[0]["IMP_IV_EXT"].ToString();
            IM_TIC_N_E = ds.Tables[0].Rows[0]["IM_TIC_N_E"].ToString();
            IM_TIC_P_E = ds.Tables[0].Rows[0]["IM_TIC_P_E"].ToString();
            UNIDAD_EXT = ds.Tables[0].Rows[0]["UNIDAD_EXT"].ToString();
            PROPIN_EXT = ds.Tables[0].Rows[0]["PROPIN_EXT"].ToString();
            PRO_EX_EXT = ds.Tables[0].Rows[0]["PRO_EX_EXT"].ToString();
            REC_PAN_EX = ds.Tables[0].Rows[0]["REC_PAN_EX"].ToString();
            DES_PAN_EX = ds.Tables[0].Rows[0]["DES_PAN_EX"].ToString();
            T_DTO_COMP = ds.Tables[0].Rows[0]["T_DTO_COMP"].ToString();
            RECARGO_PV = ds.Tables[0].Rows[0]["RECARGO_PV"].ToString();
            NCOMP_IN_V = ds.Tables[0].Rows[0]["NCOMP_IN_V"].ToString();
            ID_ASIENTO_MODELO_GV = ds.Tables[0].Rows[0]["ID_ASIENTO_MODELO_GV"].ToString();
            GENERA_ASIENTO = ds.Tables[0].Rows[0]["GENERA_ASIENTO"].ToString();
            FECHA_INGRESO = ds.Tables[0].Rows[0]["FECHA_INGRESO"].ToString();
            HORA_INGRESO = ds.Tables[0].Rows[0]["HORA_INGRESO"].ToString();
            USUARIO_INGRESO = ds.Tables[0].Rows[0]["USUARIO_INGRESO"].ToString();
            TERMINAL_INGRESO = ds.Tables[0].Rows[0]["TERMINAL_INGRESO"].ToString();
            FECHA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["FECHA_ULTIMA_MODIFICACION"].ToString();
            HORA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["HORA_ULTIMA_MODIFICACION"].ToString();
            USUA_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["USUA_ULTIMA_MODIFICACION"].ToString();
            TERM_ULTIMA_MODIFICACION = ds.Tables[0].Rows[0]["TERM_ULTIMA_MODIFICACION"].ToString();
            ID_PUESTO_CAJA = ds.Tables[0].Rows[0]["ID_PUESTO_CAJA"].ToString();
            NCOMP_IN_ORIGEN = ds.Tables[0].Rows[0]["NCOMP_IN_ORIGEN"].ToString();
            OBS_COMERC = ds.Tables[0].Rows[0]["OBS_COMERC"].ToString();
            OBSERVAC = ds.Tables[0].Rows[0]["OBSERVAC"].ToString();
            LEYENDA_1 = ds.Tables[0].Rows[0]["LEYENDA_1"].ToString();
            LEYENDA_2 = ds.Tables[0].Rows[0]["LEYENDA_2"].ToString();
            LEYENDA_3 = ds.Tables[0].Rows[0]["LEYENDA_3"].ToString();
            LEYENDA_4 = ds.Tables[0].Rows[0]["LEYENDA_4"].ToString();
            LEYENDA_5 = ds.Tables[0].Rows[0]["LEYENDA_5"].ToString();
            IMP_CIGARRILLOS = ds.Tables[0].Rows[0]["IMP_CIGARRILLOS"].ToString();
            POR_CIGARRILLOS = ds.Tables[0].Rows[0]["POR_CIGARRILLOS"].ToString();
            ID_MOTIVO_NOTA_CREDITO = ds.Tables[0].Rows[0]["ID_MOTIVO_NOTA_CREDITO"].ToString();
            FECHA_DESCARGA_PDF = ds.Tables[0].Rows[0]["FECHA_DESCARGA_PDF"].ToString();
            HORA_DESCARGA_PDF = ds.Tables[0].Rows[0]["HORA_DESCARGA_PDF"].ToString();
            USUARIO_DESCARGA_PDF = ds.Tables[0].Rows[0]["USUARIO_DESCARGA_PDF"].ToString();
            ID_DIRECCION_ENTREGA = ds.Tables[0].Rows[0]["ID_DIRECCION_ENTREGA"].ToString();
            ID_HISTORIAL_RENDICION = ds.Tables[0].Rows[0]["ID_HISTORIAL_RENDICION"].ToString();
            IMPUTACION_MODIFICADA = ds.Tables[0].Rows[0]["IMPUTACION_MODIFICADA"].ToString();
            PUBLICADO_WEB_CLIENTES = ds.Tables[0].Rows[0]["PUBLICADO_WEB_CLIENTES"].ToString();
            RG_3572_TIPO_OPERACION_HABITUAL_VENTAS = ds.Tables[0].Rows[0]["RG_3572_TIPO_OPERACION_HABITUAL_VENTAS"].ToString();
            RG_3685_TIPO_OPERACION_VENTAS = ds.Tables[0].Rows[0]["RG_3685_TIPO_OPERACION_VENTAS"].ToString();
            DESCRIPCION_FACTURA = ds.Tables[0].Rows[0]["DESCRIPCION_FACTURA"].ToString();
            ID_NEXO_COBRANZAS_PAGO = ds.Tables[0].Rows[0]["ID_NEXO_COBRANZAS_PAGO"].ToString();
            TIPO_TRANSACCION_VENTA = ds.Tables[0].Rows[0]["TIPO_TRANSACCION_VENTA"].ToString();
            TIPO_TRANSACCION_COMPRA = ds.Tables[0].Rows[0]["TIPO_TRANSACCION_COMPRA"].ToString();
            ds.Dispose();
        }

        public string TOGVA07()
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
            ,CONVERT(DATETIME,'" + FECHA_EMIS + @"',103)
            ," + IMPORTE + @" 
            ," + IMPORTE + @" 
            , 1 
           ,'" + N_COMP_FAC + @"'
           ,'" + N_COMP + @"'
           ,'" + T_COMP_FAC + @"'
           ,'" + T_COMP + @"'
            ," + IMPORTE + @" 
            ," + IMPORTE + @" 
            ,0
            ,0
            ,0
            ,0
            ," + ID_GVA12_CAN + @" 
           ,''
            )
            ";
            return sql;
        }
    }
}
