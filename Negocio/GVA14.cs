using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class GVA14
    {
        public DIRECCION_ENTREGA direccion_entrega = new DIRECCION_ENTREGA();
        public string FILLER = "";
        public string ADJUNTO = "";
        public string ALI_NO_CAT = "";
        public string BMP = "";
        public string C_POSTAL = "";
        public string CALLE = "";
        public string CALLE2_ENV = "";
        public string CLAUSULA = "";
        public string CLAVE_IS = "";
        public string COD_CLIENT = "";
        public string COD_PROVIN = "";
        public string COD_TRANSP = "";
        public string COD_VENDED = "";
        public string COD_ZONA = "";
        public string COND_VTA = "";
        public string CUIT = "";
        public string CUMPLEANIO = "";
        public string CUPO_CREDI = "";
        public string DIR_COM = "";
        public string DOMICILIO = "";
        public string DTO_ENVIO = "";
        public string DTO_LEGAL = "";
        public string E_MAIL = "";
        public string ENV_DOMIC = "";
        public string ENV_LOCAL = "";
        public string ENV_POSTAL = "";
        public string ENV_PROV = "";
        public string EXPORTA = "";
        public string FECHA_ALTA = "";
        public string FECHA_ANT = "";
        public string FECHA_DESD = "";
        public string FECHA_HAST = "";
        public string FECHA_INHA = "";
        public string FECHA_VTO = "";
        public string GRUPO_EMPR = "";
        public string ID_EXTERNO = "";
        public string ID_INTERNO = "";
        public string II_D = "";
        public string II_L = "";
        public string IVA_D = "";
        public string IVA_L = "";
        public string LOCALIDAD = "";
        public string N_IMPUESTO = "";
        public string N_ING_BRUT = "";
        public string NOM_COM = "";
        public string NRO_ENVIO = "";
        public string NRO_LEGAL = "";
        public string NRO_LISTA = "";
        public string OBSERVACIO = "";
        public string PARTIDOENV = "";
        public string PERMITE_IS = "";
        public string PISO_ENVIO = "";
        public string PISO_LEGAL = "";
        public string PORC_DESC = "";
        public string PORC_EXCL = "";
        public string PORC_RECAR = "";
        public string PUNTAJE = "";
        public string RAZON_SOCI = "";
        public string SALDO_ANT = "";
        public string SALDO_CC = "";
        public string SALDO_DOC = "";
        public string SALDO_D_UN = "";
        public string SOBRE_II = "";
        public string SOBRE_IVA = "";
        public string TELEFONO_1 = "";
        public string TELEFONO_2 = "";
        public string TIPO = "";
        public string TIPO_DOC = "";
        public string ZONA_ENVIO = "";
        public string FECHA_MODI = "";
        public string EXP_SALDO = "";
        public string N_PAGOELEC = "";
        public string MON_CTE = "";
        public string SAL_AN_UN = "";
        public string SALDO_CC_U = "";
        public string SUCUR_ORI = "";
        public string LIMCRE_EN = "";
        public string RG_1361 = "";
        public string CAL_DEB_IN = "";
        public string PORCE_INT = "";
        public string MON_MI_IN = "";
        public string DIAS_MI_IN = "";
        public string DESTINO_DE = "";
        public string CLA_IMP_CL = "";
        public string RECIBE_DE = "";
        public string AUT_DE = "";
        public string MAIL_DE = "";
        public string WEB = "";
        public string COD_RUBRO = "";
        public string CTA_CLI = "";
        public string CTO_CLI = "";
        public string COD_GVA14 = "";
        public string CBU = "";
        public string IDENTIF_AFIP = "";
        public string IDIOMA_CTE = "";
        public string DET_ARTIC = "";
        public string INC_COMENT = "";
        public string ID_GVA44_FEX = "";
        public string ID_GVA44_NCEX = "";
        public string ID_GVA44_NDEX = "";
        public string CIUDAD = "";
        public string CIUDAD_ENVIO = "";
        public string APLICA_MORA = "";
        public string ID_INTERES_POR_MORA = "";
        public string PUBLICA_WEB_CLIENTES = "";
        public string MAIL_NEXO = "";
        public string AUTORIZADO_WEB_CLIENTES = "";
        public string OBSERVACIONES = "";
        public string COD_GVA18 = "";
        public string COD_GVA24 = "";
        public string COD_GVA23 = "";
        public string COD_GVA05 = "";
        public string COD_GVA62 = "";
        public string COD_GVA151 = "";
        public string COBRA_LUNES = "";
        public string COBRA_MARTES = "";
        public string COBRA_MIERCOLES = "";
        public string COBRA_JUEVES = "";
        public string COBRA_VIERNES = "";
        public string COBRA_SABADO = "";
        public string COBRA_DOMINGO = "";
        public string HORARIO_COBRANZA = "";
        public string COMENTARIO_TYP_FAC = "";
        public string COMENTARIO_TYP_ND = "";
        public string COMENTARIO_TYP_NC = "";
        public string TELEFONO_MOVIL = "";
        public string ID_CATEGORIA_IVA = "";
        public string ID_GVA14 = "";
        public string COD_GVA150 = "";
        public string TYP_FEX = "";
        public string TYP_NCEX = "";
        public string TYP_NDEX = "";
        public string COD_ACT_CNA25 = "";
        public string COD_GVA05_ENV = "";
        public string COD_GVA18_ENV = "";
        public string RG_3572_EMPRESA_VINCULADA_CLIENTE = "";
        public string RG_3572_TIPO_OPERACION_HABITUAL_VENTAS = "";
        public string INHABILITADO_NEXO_PEDIDOS = "";
        public string ID_TIPO_DOCUMENTO_EXTERIOR = "";
        public string NUMERO_DOCUMENTO_EXTERIOR = "";
        public string WEB_CLIENT_ID = "";
        public string RG_3685_TIPO_OPERACION_VENTAS = "";
        public string REQUIERE_INFORMACION_ADICIONAL = "";
        public string NRO_INSCR_RG1817 = "";
        public string INHABILITADO_NEXO_COBRANZAS = "";
        public string CA_1096_CARNET_SOCIO = "";
        public string CODIGO_AFINIDAD = "";
        public string ID_TRA_ORIGEN_INFORMACION = "";
      
        public string insert()
        {
            string sql = "";
            sql = @"
            INSERT INTO GVA14 
            (
            FILLER
            ,ADJUNTO
            ,ALI_NO_CAT
            ,BMP
            ,C_POSTAL
            ,CALLE
            ,CALLE2_ENV
            ,CLAUSULA
            ,CLAVE_IS
            ,COD_CLIENT
            ,COD_PROVIN
            ,COD_TRANSP
            ,COD_VENDED
            ,COD_ZONA
            ,COND_VTA
            ,CUIT
            ,CUMPLEANIO
            ,CUPO_CREDI
            ,DIR_COM
            ,DOMICILIO
            ,DTO_ENVIO
            ,DTO_LEGAL
            ,E_MAIL
            ,ENV_DOMIC
            ,ENV_LOCAL
            ,ENV_POSTAL
            ,ENV_PROV
            ,EXPORTA
            ,FECHA_ALTA
            ,FECHA_ANT
            ,FECHA_DESD
            ,FECHA_HAST
            ,FECHA_INHA
            ,FECHA_VTO
            ,GRUPO_EMPR
            ,ID_EXTERNO
            ,ID_INTERNO
            ,II_D
            ,II_L
            ,IVA_D
            ,IVA_L
            ,LOCALIDAD
            ,N_IMPUESTO
            ,N_ING_BRUT
            ,NOM_COM
            ,NRO_ENVIO
            ,NRO_LEGAL
            ,NRO_LISTA
            ,OBSERVACIO
            ,PARTIDOENV
            ,PERMITE_IS
            ,PISO_ENVIO
            ,PISO_LEGAL
            ,PORC_DESC
            ,PORC_EXCL
            ,PORC_RECAR
            ,PUNTAJE
            ,RAZON_SOCI
            ,SALDO_ANT
            ,SALDO_CC
            ,SALDO_DOC
            ,SALDO_D_UN
            ,SOBRE_II
            ,SOBRE_IVA
            ,TELEFONO_1
            ,TELEFONO_2
            ,TIPO
            ,TIPO_DOC
            ,ZONA_ENVIO
            ,FECHA_MODI
            ,EXP_SALDO
            ,N_PAGOELEC
            ,MON_CTE
            ,SAL_AN_UN
            ,SALDO_CC_U
            ,SUCUR_ORI
            ,LIMCRE_EN
            ,RG_1361
            ,CAL_DEB_IN
            ,PORCE_INT
            ,MON_MI_IN
            ,DIAS_MI_IN
            ,DESTINO_DE
            ,CLA_IMP_CL
            ,RECIBE_DE
            ,AUT_DE
            ,MAIL_DE
            ,WEB
            ,COD_RUBRO
            ,CTA_CLI
            ,CTO_CLI
            ,COD_GVA14
            ,CBU
            ,IDENTIF_AFIP
            ,IDIOMA_CTE
            ,DET_ARTIC
            ,INC_COMENT
            ,ID_GVA44_FEX
            ,ID_GVA44_NCEX
            ,ID_GVA44_NDEX
            ,CIUDAD
            ,CIUDAD_ENVIO
            ,APLICA_MORA
            ,ID_INTERES_POR_MORA
            ,PUBLICA_WEB_CLIENTES
            ,MAIL_NEXO
            ,AUTORIZADO_WEB_CLIENTES
            ,OBSERVACIONES
            ,COD_GVA18
            ,COD_GVA24
            ,COD_GVA23
            ,COD_GVA05
            ,COD_GVA62
            ,COD_GVA151
            ,COBRA_LUNES
            ,COBRA_MARTES
            ,COBRA_MIERCOLES
            ,COBRA_JUEVES
            ,COBRA_VIERNES
            ,COBRA_SABADO
            ,COBRA_DOMINGO
            ,HORARIO_COBRANZA
            ,COMENTARIO_TYP_FAC
            ,COMENTARIO_TYP_ND
            ,COMENTARIO_TYP_NC
            ,TELEFONO_MOVIL
            ,ID_CATEGORIA_IVA
            ,ID_GVA14
            ,COD_GVA150
            ,TYP_FEX
            ,TYP_NCEX
            ,TYP_NDEX
            ,COD_ACT_CNA25
            ,COD_GVA05_ENV
            ,COD_GVA18_ENV
            ,RG_3572_EMPRESA_VINCULADA_CLIENTE
            ,RG_3572_TIPO_OPERACION_HABITUAL_VENTAS
            ,INHABILITADO_NEXO_PEDIDOS
            ,ID_TIPO_DOCUMENTO_EXTERIOR
            ,NUMERO_DOCUMENTO_EXTERIOR
            ,WEB_CLIENT_ID
            ,RG_3685_TIPO_OPERACION_VENTAS
            ,REQUIERE_INFORMACION_ADICIONAL
            ,NRO_INSCR_RG1817
            ,INHABILITADO_NEXO_COBRANZAS
            ,CODIGO_AFINIDAD
            ) VALUES (
           '" + FILLER + @"'
           ,'" + ADJUNTO + @"'
            ," + ALI_NO_CAT + @" 
           ,'" + BMP + @"'
           ,'" + C_POSTAL + @"'
           ,'" + CALLE + @"'
           ,'" + CALLE2_ENV + @"'
            ," + CLAUSULA + @" 
           ,'" + CLAVE_IS + @"'
           ,'" + COD_CLIENT + @"'
           ,'" + COD_PROVIN + @"'
           ,'" + COD_TRANSP + @"'
           ,'" + COD_VENDED + @"'
           ,'" + COD_ZONA + @"'
            ," + COND_VTA + @" 
           ,'" + CUIT + @"'
            ,CONVERT(DATETIME,'" + CUMPLEANIO + @"',103)
            ," + CUPO_CREDI + @" 
           ,'" + DIR_COM + @"'
           ,'" + DOMICILIO + @"'
           ,'" + DTO_ENVIO + @"'
           ,'" + DTO_LEGAL + @"'
           ,'" + E_MAIL + @"'
           ,'" + ENV_DOMIC + @"'
           ,'" + ENV_LOCAL + @"'
           ,'" + ENV_POSTAL + @"'
           ,'" + ENV_PROV + @"'
            ," + EXPORTA + @" 
            ,CONVERT(DATETIME,'" + FECHA_ALTA + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_ANT + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_DESD + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_HAST + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_INHA + @"',103)
            ,CONVERT(DATETIME,'" + FECHA_VTO + @"',103)
           ,'" + GRUPO_EMPR + @"'
           ,'" + ID_EXTERNO + @"'
           ,'" + ID_INTERNO + @"'
           ,'" + II_D + @"'
           ,'" + II_L + @"'
           ,'" + IVA_D + @"'
           ,'" + IVA_L + @"'
           ,'" + LOCALIDAD + @"'
           ,'" + N_IMPUESTO + @"'
           ,'" + N_ING_BRUT + @"'
           ,'" + NOM_COM + @"'
           ,'" + NRO_ENVIO + @"'
           ,'" + NRO_LEGAL + @"'
            ," + NRO_LISTA + @" 
           ,'" + OBSERVACIO + @"'
           ,'" + PARTIDOENV + @"'
            ," + PERMITE_IS + @" 
           ,'" + PISO_ENVIO + @"'
           ,'" + PISO_LEGAL + @"'
            ," + PORC_DESC + @" 
            ," + PORC_EXCL + @" 
            ," + PORC_RECAR + @" 
            ," + PUNTAJE + @" 
           ,'" + RAZON_SOCI + @"'
            ," + SALDO_ANT + @" 
            ," + SALDO_CC + @" 
            ," + SALDO_DOC + @" 
            ," + SALDO_D_UN + @" 
           ,'" + SOBRE_II + @"'
           ,'" + SOBRE_IVA + @"'
           ,'" + TELEFONO_1 + @"'
           ,'" + TELEFONO_2 + @"'
           ,'" + TIPO + @"'
            ," + TIPO_DOC + @" 
           ,'" + ZONA_ENVIO + @"'
            ,CONVERT(DATETIME,'" + FECHA_MODI + @"',103)
            ," + EXP_SALDO + @" 
           ,'" + N_PAGOELEC + @"'
            ," + MON_CTE + @" 
            ," + SAL_AN_UN + @" 
            ," + SALDO_CC_U + @" 
            ," + SUCUR_ORI + @" 
           ,'" + LIMCRE_EN + @"'
            ," + RG_1361 + @" 
            ," + CAL_DEB_IN + @" 
            ," + PORCE_INT + @" 
            ," + MON_MI_IN + @" 
            ," + DIAS_MI_IN + @" 
           ,'" + DESTINO_DE + @"'
           ,'" + CLA_IMP_CL + @"'
            ," + RECIBE_DE + @" 
            ," + AUT_DE + @" 
           ,'" + MAIL_DE + @"'
           ,'" + WEB + @"'
           ,'" + COD_RUBRO + @"'
            ," + CTA_CLI + @" 
           ,'" + CTO_CLI + @"'
           ,'" + COD_CLIENT + @"'
           ,'" + CBU + @"'
           ,'" + IDENTIF_AFIP + @"'
           ,'" + IDIOMA_CTE + @"'
           ,'" + DET_ARTIC + @"'
           ,'" + INC_COMENT + @"'
            ," + ID_GVA44_FEX + @" 
            ," + ID_GVA44_NCEX + @" 
            ," + ID_GVA44_NDEX + @" 
           ,'" + CIUDAD + @"'
           ,'" + CIUDAD_ENVIO + @"'
           ,'" + APLICA_MORA + @"'
            ," + ID_INTERES_POR_MORA + @" 
           ,'" + PUBLICA_WEB_CLIENTES + @"'
           ,'" + MAIL_NEXO + @"'
           ," + AUTORIZADO_WEB_CLIENTES + @"
           ,'" + OBSERVACIONES + @"'
           ,'" + COD_PROVIN + @"'
           ,'" + COD_TRANSP + @"'
           ,'" + COD_VENDED + @"'
           ,'" + COD_ZONA + @"'
           ,'" + COD_GVA62 + @"'
           ,'" + COD_GVA151 + @"'
           ,'" + COBRA_LUNES + @"'
           ,'" + COBRA_MARTES + @"'
           ,'" + COBRA_MIERCOLES + @"'
           ,'" + COBRA_JUEVES + @"'
           ,'" + COBRA_VIERNES + @"'
           ,'" + COBRA_SABADO + @"'
           ,'" + COBRA_DOMINGO + @"'
           ,'" + HORARIO_COBRANZA + @"'
           ,'" + COMENTARIO_TYP_FAC + @"'
           ,'" + COMENTARIO_TYP_ND + @"'
           ,'" + COMENTARIO_TYP_NC + @"'
           ,'" + TELEFONO_MOVIL + @"'
            ," + ID_CATEGORIA_IVA + @" 
            ,(next value for sequence_gva14)
           ,'" + COD_GVA150 + @"'
           ,'" + TYP_FEX + @"'
           ,'" + TYP_NCEX + @"'
           ,'" + TYP_NDEX + @"'
           ,'" + COD_ACT_CNA25 + @"'
           ,'" + COD_GVA05_ENV + @"'
           ,'" + COD_GVA18_ENV + @"'
            ," + RG_3572_EMPRESA_VINCULADA_CLIENTE + @" 
           ,'" + RG_3572_TIPO_OPERACION_HABITUAL_VENTAS + @"'
           ,'" + INHABILITADO_NEXO_PEDIDOS + @"'
            ," + ID_TIPO_DOCUMENTO_EXTERIOR + @" 
           ," + NUMERO_DOCUMENTO_EXTERIOR + @"
            ," + WEB_CLIENT_ID + @"
           ,'" + RG_3685_TIPO_OPERACION_VENTAS + @"'
           ,'" + REQUIERE_INFORMACION_ADICIONAL + @"'
           ,'" + NRO_INSCR_RG1817 + @"'
           ,'" + INHABILITADO_NEXO_COBRANZAS + @"'
           ,'" + CODIGO_AFINIDAD + @"'
            )
            ";
            return sql;
        }
     
        public GVA14()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("CONFIG\\GVA14.xml");
            FILLER = ds.Tables[0].Rows[0]["FILLER"].ToString();
            ADJUNTO = ds.Tables[0].Rows[0]["ADJUNTO"].ToString();
            ALI_NO_CAT = ds.Tables[0].Rows[0]["ALI_NO_CAT"].ToString();
            BMP = ds.Tables[0].Rows[0]["BMP"].ToString();
            C_POSTAL = ds.Tables[0].Rows[0]["C_POSTAL"].ToString();
            CALLE = ds.Tables[0].Rows[0]["CALLE"].ToString();
            CALLE2_ENV = ds.Tables[0].Rows[0]["CALLE2_ENV"].ToString();
            CLAUSULA = ds.Tables[0].Rows[0]["CLAUSULA"].ToString();
            CLAVE_IS = ds.Tables[0].Rows[0]["CLAVE_IS"].ToString();
            COD_CLIENT = ds.Tables[0].Rows[0]["COD_CLIENT"].ToString();
            COD_PROVIN = ds.Tables[0].Rows[0]["COD_PROVIN"].ToString();
            COD_TRANSP = ds.Tables[0].Rows[0]["COD_TRANSP"].ToString();
            COD_VENDED = ds.Tables[0].Rows[0]["COD_VENDED"].ToString();
            COD_ZONA = ds.Tables[0].Rows[0]["COD_ZONA"].ToString();
            COND_VTA = ds.Tables[0].Rows[0]["COND_VTA"].ToString();
            CUIT = ds.Tables[0].Rows[0]["CUIT"].ToString();
            CUMPLEANIO = ds.Tables[0].Rows[0]["CUMPLEANIO"].ToString();
            CUPO_CREDI = ds.Tables[0].Rows[0]["CUPO_CREDI"].ToString();
            DIR_COM = ds.Tables[0].Rows[0]["DIR_COM"].ToString();
            DOMICILIO = ds.Tables[0].Rows[0]["DOMICILIO"].ToString();
            DTO_ENVIO = ds.Tables[0].Rows[0]["DTO_ENVIO"].ToString();
            DTO_LEGAL = ds.Tables[0].Rows[0]["DTO_LEGAL"].ToString();
            E_MAIL = ds.Tables[0].Rows[0]["E_MAIL"].ToString();
            ENV_DOMIC = ds.Tables[0].Rows[0]["ENV_DOMIC"].ToString();
            ENV_LOCAL = ds.Tables[0].Rows[0]["ENV_LOCAL"].ToString();
            ENV_POSTAL = ds.Tables[0].Rows[0]["ENV_POSTAL"].ToString();
            ENV_PROV = ds.Tables[0].Rows[0]["ENV_PROV"].ToString();
            EXPORTA = ds.Tables[0].Rows[0]["EXPORTA"].ToString();
            FECHA_ALTA = ds.Tables[0].Rows[0]["FECHA_ALTA"].ToString();
            FECHA_ANT = ds.Tables[0].Rows[0]["FECHA_ANT"].ToString();
            FECHA_DESD = ds.Tables[0].Rows[0]["FECHA_DESD"].ToString();
            FECHA_HAST = ds.Tables[0].Rows[0]["FECHA_HAST"].ToString();
            FECHA_INHA = ds.Tables[0].Rows[0]["FECHA_INHA"].ToString();
            FECHA_VTO = ds.Tables[0].Rows[0]["FECHA_VTO"].ToString();
            GRUPO_EMPR = ds.Tables[0].Rows[0]["GRUPO_EMPR"].ToString();
            ID_EXTERNO = ds.Tables[0].Rows[0]["ID_EXTERNO"].ToString();
            ID_INTERNO = ds.Tables[0].Rows[0]["ID_INTERNO"].ToString();
            II_D = ds.Tables[0].Rows[0]["II_D"].ToString();
            II_L = ds.Tables[0].Rows[0]["II_L"].ToString();
            IVA_D = ds.Tables[0].Rows[0]["IVA_D"].ToString();
            IVA_L = ds.Tables[0].Rows[0]["IVA_L"].ToString();
            LOCALIDAD = ds.Tables[0].Rows[0]["LOCALIDAD"].ToString();
            N_IMPUESTO = ds.Tables[0].Rows[0]["N_IMPUESTO"].ToString();
            N_ING_BRUT = ds.Tables[0].Rows[0]["N_ING_BRUT"].ToString();
            NOM_COM = ds.Tables[0].Rows[0]["NOM_COM"].ToString();
            NRO_ENVIO = ds.Tables[0].Rows[0]["NRO_ENVIO"].ToString();
            NRO_LEGAL = ds.Tables[0].Rows[0]["NRO_LEGAL"].ToString();
            NRO_LISTA = ds.Tables[0].Rows[0]["NRO_LISTA"].ToString();
            OBSERVACIO = ds.Tables[0].Rows[0]["OBSERVACIO"].ToString();
            PARTIDOENV = ds.Tables[0].Rows[0]["PARTIDOENV"].ToString();
            PERMITE_IS = ds.Tables[0].Rows[0]["PERMITE_IS"].ToString();
            PISO_ENVIO = ds.Tables[0].Rows[0]["PISO_ENVIO"].ToString();
            PISO_LEGAL = ds.Tables[0].Rows[0]["PISO_LEGAL"].ToString();
            PORC_DESC = ds.Tables[0].Rows[0]["PORC_DESC"].ToString();
            PORC_EXCL = ds.Tables[0].Rows[0]["PORC_EXCL"].ToString();
            PORC_RECAR = ds.Tables[0].Rows[0]["PORC_RECAR"].ToString();
            PUNTAJE = ds.Tables[0].Rows[0]["PUNTAJE"].ToString();
            RAZON_SOCI = ds.Tables[0].Rows[0]["RAZON_SOCI"].ToString();
            SALDO_ANT = ds.Tables[0].Rows[0]["SALDO_ANT"].ToString();
            SALDO_CC = ds.Tables[0].Rows[0]["SALDO_CC"].ToString();
            SALDO_DOC = ds.Tables[0].Rows[0]["SALDO_DOC"].ToString();
            SALDO_D_UN = ds.Tables[0].Rows[0]["SALDO_D_UN"].ToString();
            SOBRE_II = ds.Tables[0].Rows[0]["SOBRE_II"].ToString();
            SOBRE_IVA = ds.Tables[0].Rows[0]["SOBRE_IVA"].ToString();
            TELEFONO_1 = ds.Tables[0].Rows[0]["TELEFONO_1"].ToString();
            TELEFONO_2 = ds.Tables[0].Rows[0]["TELEFONO_2"].ToString();
            TIPO = ds.Tables[0].Rows[0]["TIPO"].ToString();
            TIPO_DOC = ds.Tables[0].Rows[0]["TIPO_DOC"].ToString();
            ZONA_ENVIO = ds.Tables[0].Rows[0]["ZONA_ENVIO"].ToString();
            FECHA_MODI = ds.Tables[0].Rows[0]["FECHA_MODI"].ToString();
            EXP_SALDO = ds.Tables[0].Rows[0]["EXP_SALDO"].ToString();
            N_PAGOELEC = ds.Tables[0].Rows[0]["N_PAGOELEC"].ToString();
            MON_CTE = ds.Tables[0].Rows[0]["MON_CTE"].ToString();
            SAL_AN_UN = ds.Tables[0].Rows[0]["SAL_AN_UN"].ToString();
            SALDO_CC_U = ds.Tables[0].Rows[0]["SALDO_CC_U"].ToString();
            SUCUR_ORI = ds.Tables[0].Rows[0]["SUCUR_ORI"].ToString();
            LIMCRE_EN = ds.Tables[0].Rows[0]["LIMCRE_EN"].ToString();
            RG_1361 = ds.Tables[0].Rows[0]["RG_1361"].ToString();
            CAL_DEB_IN = ds.Tables[0].Rows[0]["CAL_DEB_IN"].ToString();
            PORCE_INT = ds.Tables[0].Rows[0]["PORCE_INT"].ToString();
            MON_MI_IN = ds.Tables[0].Rows[0]["MON_MI_IN"].ToString();
            DIAS_MI_IN = ds.Tables[0].Rows[0]["DIAS_MI_IN"].ToString();
            DESTINO_DE = ds.Tables[0].Rows[0]["DESTINO_DE"].ToString();
            CLA_IMP_CL = ds.Tables[0].Rows[0]["CLA_IMP_CL"].ToString();
            RECIBE_DE = ds.Tables[0].Rows[0]["RECIBE_DE"].ToString();
            AUT_DE = ds.Tables[0].Rows[0]["AUT_DE"].ToString();
            MAIL_DE = ds.Tables[0].Rows[0]["MAIL_DE"].ToString();
            WEB = ds.Tables[0].Rows[0]["WEB"].ToString();
            COD_RUBRO = ds.Tables[0].Rows[0]["COD_RUBRO"].ToString();
            CTA_CLI = ds.Tables[0].Rows[0]["CTA_CLI"].ToString();
            CTO_CLI = ds.Tables[0].Rows[0]["CTO_CLI"].ToString();
            COD_GVA14 = ds.Tables[0].Rows[0]["COD_GVA14"].ToString();
            CBU = ds.Tables[0].Rows[0]["CBU"].ToString();
            IDENTIF_AFIP = ds.Tables[0].Rows[0]["IDENTIF_AFIP"].ToString();
            IDIOMA_CTE = ds.Tables[0].Rows[0]["IDIOMA_CTE"].ToString();
            DET_ARTIC = ds.Tables[0].Rows[0]["DET_ARTIC"].ToString();
            INC_COMENT = ds.Tables[0].Rows[0]["INC_COMENT"].ToString();
            ID_GVA44_FEX = ds.Tables[0].Rows[0]["ID_GVA44_FEX"].ToString();
            ID_GVA44_NCEX = ds.Tables[0].Rows[0]["ID_GVA44_NCEX"].ToString();
            ID_GVA44_NDEX = ds.Tables[0].Rows[0]["ID_GVA44_NDEX"].ToString();
            CIUDAD = ds.Tables[0].Rows[0]["CIUDAD"].ToString();
            CIUDAD_ENVIO = ds.Tables[0].Rows[0]["CIUDAD_ENVIO"].ToString();
            APLICA_MORA = ds.Tables[0].Rows[0]["APLICA_MORA"].ToString();
            ID_INTERES_POR_MORA = ds.Tables[0].Rows[0]["ID_INTERES_POR_MORA"].ToString();
            PUBLICA_WEB_CLIENTES = ds.Tables[0].Rows[0]["PUBLICA_WEB_CLIENTES"].ToString();
            MAIL_NEXO = ds.Tables[0].Rows[0]["MAIL_NEXO"].ToString();
            AUTORIZADO_WEB_CLIENTES = ds.Tables[0].Rows[0]["AUTORIZADO_WEB_CLIENTES"].ToString();
            OBSERVACIONES = ds.Tables[0].Rows[0]["OBSERVACIONES"].ToString();
            COD_GVA18 = ds.Tables[0].Rows[0]["COD_GVA18"].ToString();
            COD_GVA24 = ds.Tables[0].Rows[0]["COD_GVA24"].ToString();
            COD_GVA23 = ds.Tables[0].Rows[0]["COD_GVA23"].ToString();
            COD_GVA05 = ds.Tables[0].Rows[0]["COD_GVA05"].ToString();
            COD_GVA62 = ds.Tables[0].Rows[0]["COD_GVA62"].ToString();
            COD_GVA151 = ds.Tables[0].Rows[0]["COD_GVA151"].ToString();
            COBRA_LUNES = ds.Tables[0].Rows[0]["COBRA_LUNES"].ToString();
            COBRA_MARTES = ds.Tables[0].Rows[0]["COBRA_MARTES"].ToString();
            COBRA_MIERCOLES = ds.Tables[0].Rows[0]["COBRA_MIERCOLES"].ToString();
            COBRA_JUEVES = ds.Tables[0].Rows[0]["COBRA_JUEVES"].ToString();
            COBRA_VIERNES = ds.Tables[0].Rows[0]["COBRA_VIERNES"].ToString();
            COBRA_SABADO = ds.Tables[0].Rows[0]["COBRA_SABADO"].ToString();
            COBRA_DOMINGO = ds.Tables[0].Rows[0]["COBRA_DOMINGO"].ToString();
            HORARIO_COBRANZA = ds.Tables[0].Rows[0]["HORARIO_COBRANZA"].ToString();
            COMENTARIO_TYP_FAC = ds.Tables[0].Rows[0]["COMENTARIO_TYP_FAC"].ToString();
            COMENTARIO_TYP_ND = ds.Tables[0].Rows[0]["COMENTARIO_TYP_ND"].ToString();
            COMENTARIO_TYP_NC = ds.Tables[0].Rows[0]["COMENTARIO_TYP_NC"].ToString();
            TELEFONO_MOVIL = ds.Tables[0].Rows[0]["TELEFONO_MOVIL"].ToString();
            ID_CATEGORIA_IVA = ds.Tables[0].Rows[0]["ID_CATEGORIA_IVA"].ToString();
            ID_GVA14 = ds.Tables[0].Rows[0]["ID_GVA14"].ToString();
            COD_GVA150 = ds.Tables[0].Rows[0]["COD_GVA150"].ToString();
            TYP_FEX = ds.Tables[0].Rows[0]["TYP_FEX"].ToString();
            TYP_NCEX = ds.Tables[0].Rows[0]["TYP_NCEX"].ToString();
            TYP_NDEX = ds.Tables[0].Rows[0]["TYP_NDEX"].ToString();
            COD_ACT_CNA25 = ds.Tables[0].Rows[0]["COD_ACT_CNA25"].ToString();
            COD_GVA05_ENV = ds.Tables[0].Rows[0]["COD_GVA05_ENV"].ToString();
            COD_GVA18_ENV = ds.Tables[0].Rows[0]["COD_GVA18_ENV"].ToString();
            RG_3572_EMPRESA_VINCULADA_CLIENTE = ds.Tables[0].Rows[0]["RG_3572_EMPRESA_VINCULADA_CLIENTE"].ToString();
            RG_3572_TIPO_OPERACION_HABITUAL_VENTAS = ds.Tables[0].Rows[0]["RG_3572_TIPO_OPERACION_HABITUAL_VENTAS"].ToString();
            INHABILITADO_NEXO_PEDIDOS = ds.Tables[0].Rows[0]["INHABILITADO_NEXO_PEDIDOS"].ToString();
            ID_TIPO_DOCUMENTO_EXTERIOR = ds.Tables[0].Rows[0]["ID_TIPO_DOCUMENTO_EXTERIOR"].ToString();
            NUMERO_DOCUMENTO_EXTERIOR = ds.Tables[0].Rows[0]["NUMERO_DOCUMENTO_EXTERIOR"].ToString();
            WEB_CLIENT_ID = ds.Tables[0].Rows[0]["WEB_CLIENT_ID"].ToString();
            RG_3685_TIPO_OPERACION_VENTAS = ds.Tables[0].Rows[0]["RG_3685_TIPO_OPERACION_VENTAS"].ToString();
            REQUIERE_INFORMACION_ADICIONAL = ds.Tables[0].Rows[0]["REQUIERE_INFORMACION_ADICIONAL"].ToString();
            NRO_INSCR_RG1817 = ds.Tables[0].Rows[0]["NRO_INSCR_RG1817"].ToString();
            INHABILITADO_NEXO_COBRANZAS = ds.Tables[0].Rows[0]["INHABILITADO_NEXO_COBRANZAS"].ToString();
            CODIGO_AFINIDAD = ds.Tables[0].Rows[0]["CODIGO_AFINIDAD"].ToString();
            ID_TRA_ORIGEN_INFORMACION = ds.Tables[0].Rows[0]["ID_TRA_ORIGEN_INFORMACION"].ToString();
            ds.Dispose();
        }
    }

}
