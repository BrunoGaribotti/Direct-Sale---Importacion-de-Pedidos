using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseDatos;
using System.Data.Common;

namespace Negocio
{
    public class Procesos
    {
        public int error = 0;

        public string CTA_DPV = "";
        public string TALON_REC = "";
        public string TALON_PED = "";
        public string TALON_A = "";
        public string TALON_B = "";

        TGFunc oTgFunc = new TGFunc();

        public string CargarConfig()
        {
            string ret = "";
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("CONFIG\\CONFIG.XML");

                db.cadenaConexion = ds.Tables[0].Rows[0]["SQLSTRING"].ToString();
                
                CTA_DPV = ds.Tables[0].Rows[0]["CTA_DPV"].ToString();
                TALON_REC = ds.Tables[0].Rows[0]["TALON_REC"].ToString();
                TALON_PED = ds.Tables[0].Rows[0]["TALON_PED"].ToString();
                TALON_A = ds.Tables[0].Rows[0]["TALON_A"].ToString();
                TALON_B = ds.Tables[0].Rows[0]["TALON_B"].ToString();

                db.Configurar();
                db.Conectar();

            }
            catch (Exception ex)
            {
                ret = ex.Message.ToString();
            }
            return ret;
        }

        public void ValidarPedidos(List<GVA21> cPedidos)
        {
            foreach(GVA21 pedido in cPedidos)
            {

                if (pedido.NRO_PEDIDO.ToString().Equals(""))
                {
                    pedido.error.Add("Debe Ingresar un nro de pedido!");
                }
                
                pedido.TALON_PED = TraerTalonario(TALON_PED);
                pedido.COD_SUCURS = TraerDeposito(pedido.COD_SUCURS);
                pedido.NRO_PEDIDO = " " + pedido.NRO_PEDIDO.ToString().PadLeft(13, '0');
                pedido.Cliente.TIPO_DOC = TraerTipoDoc(pedido.Cliente.TIPO_DOC);
                pedido.Cliente.ID_CATEGORIA_IVA = TraerCategoriaIva(pedido.Cliente.ID_CATEGORIA_IVA);
                pedido.COD_VENDED = TraerVendedor(pedido.COD_VENDED);
                pedido.Cliente.COD_PROVIN = TraerCodProvincia(pedido.Cliente.COD_PROVIN);
                pedido.COD_TRANSP = TrearTransporte(pedido.COD_TRANSP);
                pedido.Cliente.IVA_L = "S";
                pedido.Cliente.IVA_D = "S";
                pedido.TALONARIO = TALON_A;
                pedido.Cliente.TIPO_DOC = "80";
                pedido.ID_ASIENTO_MODELO_GV = TraerAsientoModelo("1");
                if (ExisteCliente(pedido.Cliente.CUIT))
                {
                    pedido.COD_CLIENT = TraerCliente(pedido.Cliente.CUIT);
                    pedido.Cliente.ID_CATEGORIA_IVA = TraerIdCategoriaIvaCliente(pedido.Cliente.CUIT);
                }

                if (TraerCodCategoriaIva(pedido.Cliente.ID_CATEGORIA_IVA).Equals("CF"))
                {
                    pedido.esA = false;
                    pedido.Cliente.IVA_D = "N";
                    pedido.TALONARIO = TALON_B;
                    pedido.Cliente.TIPO_DOC = "96";
                }

                if (!ExisteTalonario(pedido.TALONARIO))
                {
                    pedido.error.Add("Talonario de pedidos " + pedido.TALONARIO + @" no existe!");
                }
                
                string cta_teso = TraerCtaTesoreria(pedido.LEYENDA_4);
                

                if (pedido.COD_VENDED.Equals(""))
                {
                    pedido.error.Add("Vendedor no existe!");
                }

                if (pedido.COD_TRANSP.Equals(""))
                {
                    pedido.error.Add("Trasporte no existe!");
                }

                decimal suma = 0;

                if (pedido.esA)//(pedido.LEYENDA_4.Equals("") && pedido.TALONARIO == TALON_A)
                {
                    pedido.LEYENDA_5 = "";
                }
                else
                {
                    if (cta_teso.Equals(""))
                    {
                        pedido.error.Add("Cliente sin cuenta tesoreria! " + pedido.COD_CLIENT);
                    }
                    else
                    {
                        pedido.LEYENDA_4 = cta_teso;
                    }
                }

                foreach (GVA03 item in pedido.Renglones)
                {
                    item.TALON_PED = pedido.TALON_PED;
                    item.NRO_PEDIDO = pedido.NRO_PEDIDO;
                    
                    if(!ExisteArticulo(item.COD_ARTICU))
                    {
                        pedido.error.Add("El Articulo " + item.COD_ARTICU + " no existe!");
                    }
                    
                    int i = 0;
                    decimal precio = 0;
                    bool canprecio = true;
                    try
                    {
                        i = int.Parse(item.CANT_PEDID.Replace(".", ","));
                        item.CANT_PEDID = item.CANT_PEDID.Replace(",", ".");
                    }
                    catch (Exception ex)
                    {
                        pedido.error.Add("Cantidad incorrecta en articulo " + item.COD_ARTICU + " !");
                        canprecio = false;
                    }
                    
                    try
                    {
                        precio = decimal.Parse(item.PRECIO.Replace(".", ","));
                        item.PRECIO = item.PRECIO.Replace(",", ".");
                        item.PRECIO_LISTA = item.PRECIO;
                    }
                    catch (Exception ex)
                    {
                        pedido.error.Add("Precio incorrecto en articulo " + item.COD_ARTICU + " !");
                        canprecio = false;
                    }

                    if(canprecio)
                    {
                        suma += precio * i;
                    }
                    pedido.TOTAL_PEDI = suma.ToString().Replace(",", ".");
                }

                if (pedido.COD_TRANSP.Equals(""))
                {
                    pedido.error.Add("El Transporte no existe!");
                }

                if (pedido.Cliente.ID_CATEGORIA_IVA.Equals(""))
                {
                    pedido.error.Add("La categoría de iva no existe!");
                }
                if (pedido.LEYENDA_4.Equals("") && pedido.TALONARIO == TALON_B)
                {
                    pedido.error.Add("La Cuenta de tesorería no existe!");
                }

                if (pedido.TALON_PED.Equals(""))
                {
                    pedido.error.Add("El talonario de pedidos es Invalido!");
                }
                if (pedido.COD_SUCURS.Equals(""))
                {
                    pedido.error.Add("El depóstio es Invalido!");
                }

                if (pedido.Cliente.TIPO_DOC.Equals(""))
                {
                    pedido.error.Add("El tipo de Documento es Invalido!");
                }

                if (pedido.Cliente.CUIT.Length > 20)
                {
                    pedido.error.Add("La longitud delCuit excede a la de Tango (VARCHAR(20)");
                }
                if (pedido.Cliente.RAZON_SOCI.Length > 60)
                {
                    pedido.error.Add("La longitud de la Razon Social excede a la de Tango (VARCHAR(60)");
                }
                if (pedido.Cliente.DOMICILIO.Length > 30)
                {
                    pedido.error.Add("La longitud de DOMICILIO excede a la de Tango VARCHAR(30)");
                }
                if (pedido.Cliente.C_POSTAL.Length > 8)
                {
                    pedido.error.Add("La longitud del Código Postal excede a la de Tango VARCHAR(60)");
                }
                if (pedido.Cliente.LOCALIDAD.Length > 20)
                {
                    pedido.error.Add("La longitud de la localidad excede a la de Tango VARCHAR(20)");
                }
                if (pedido.Cliente.TELEFONO_1.Length > 30)
                {
                    pedido.error.Add("La longitud del Teléfono excede a la de Tango VARCHAR(60)");
                }

                if (ExistePedido(pedido.NRO_PEDIDO))
                {
                    pedido.error.Add("El Pedido ya existe en Tango ");
                }
                
                pedido.Cliente.COD_GVA05 = pedido.Cliente.COD_ZONA;
                pedido.Cliente.COD_GVA24 = pedido.Cliente.COD_TRANSP;
                pedido.Cliente.COD_GVA23 = pedido.Cliente.COD_VENDED;
                pedido.Cliente.COD_GVA18 = pedido.Cliente.COD_PROVIN;

                pedido.Cliente.direccion_entrega.COD_CLIENTE = pedido.Cliente.COD_CLIENT;
                pedido.Cliente.direccion_entrega.DIRECCION = pedido.Cliente.DOMICILIO;
                pedido.Cliente.direccion_entrega.CODIGO_POSTAL = pedido.Cliente.C_POSTAL;
                pedido.Cliente.direccion_entrega.LOCALIDAD = pedido.Cliente.LOCALIDAD;
                pedido.Cliente.direccion_entrega.COD_PROVINCIA = pedido.Cliente.COD_PROVIN;
            
            }
        }

        private string TraerAsientoModelo(string p)
        {
            string asiento_modelo_gv = "";

            db.CrearComando(@"SELECT ID_ASIENTO_MODELO_GV FROM ASIENTO_MODELO_GV
                        WHERE COD_ASIENTO_MODELO_GV = '" + p + @"'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                asiento_modelo_gv = dt.Rows[0][0].ToString();
            }
            return asiento_modelo_gv;
        }

        private string TraerCliente(string p)
        {
            string COD_CLIENT = "";

            db.CrearComando(@"SELECT COD_CLIENT 
                            FROM GVA14 WHERE REPLACE(CUIT,'-','') = '" + p.Replace("-","") + @"'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                COD_CLIENT = dt.Rows[0][0].ToString();
            }
            return COD_CLIENT;
        }

        private string TraerIdCategoriaIvaCliente(string p)
        {
            string ID_CATEGORIA_IVA = "";

            db.CrearComando(@"SELECT ID_CATEGORIA_IVA 
                            FROM GVA14 WHERE  REPLACE(CUIT,'-','') = '" + p.Replace("-","") + @"'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                ID_CATEGORIA_IVA = dt.Rows[0][0].ToString();
            }
            return ID_CATEGORIA_IVA;
        }


        private bool ExisteTalonario(string p)
        {
            bool existe = false;

            db.CrearComando("SELECT TALONARIO FROM GVA43 WHERE TALONARIO = " + p + "");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                existe = true;
            }
            return existe;
        }

        private object TraerCodCategoriaIva(string p)
        {
            string COD_CATEGORIA_IVA = "";

            db.CrearComando("SELECT COD_CATEGORIA_IVA FROM CATEGORIA_IVA WHERE ID_CATEGORIA_IVA = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                COD_CATEGORIA_IVA = dt.Rows[0][0].ToString();
            }
            return COD_CATEGORIA_IVA;
        }

        private bool ExistePedido(string p)
        {
            bool existe = false;

            db.CrearComando("SELECT NRO_PEDIDO FROM GVA21 WHERE NRO_PEDIDO = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                existe = true;
            }
            return existe;
        }

        private string TrearTransporte(string p)
        {
            string COD_TRANSP = "";

            db.CrearComando(@"SELECT COD_TRANSP FROM GVA24 
                            WHERE ( NOMBRE_TRA = '" + p + @"' OR
                            COD_TRANSP = '" + p + @"' )
                            ");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                COD_TRANSP = dt.Rows[0][0].ToString();
            }
            return COD_TRANSP;
        }

        private bool ExisteArticulo(string p)
        {
            bool existe = false;

            db.CrearComando("SELECT COD_ARTICU FROM STA11 WHERE COD_ARTICU = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                existe = true;
            }
            return existe;
        }

        private string TraerCtaTesoreria(string p)
        {
            string cod_cta = "";

            db.CrearComando("SELECT COD_CTA FROM SBA01 WHERE DESCRIPCIO = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                cod_cta = dt.Rows[0][0].ToString();
            }
            return cod_cta;
        }

        private string TraerCodProvincia(string p)
        {
            //SELECT COD_PROVIN FROM GVA18 WHERE NOMBRE_PRO = 'CAPITAL FEDERAL'
            string cod_provin = "";

            db.CrearComando(@"SELECT COD_PROVIN FROM GVA18 
                            WHERE COD_PROVIN = '" + p + @"'
                            OR NOMBRE_PRO = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                cod_provin = dt.Rows[0][0].ToString();
            }
            return cod_provin;
        }

        private string TraerCategoriaIva(string p)
        {
            string id_categoria_iva = "";

            db.CrearComando("SELECT ID_CATEGORIA_IVA FROM CATEGORIA_IVA WHERE DESC_CATEGORIA_IVA = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                id_categoria_iva = dt.Rows[0][0].ToString();
            }
            return id_categoria_iva;
        }

        private string TraerTipoDoc(string p)
        {
            string tipo_doc = "";
            switch (p)
            {
                case "CUIT":
                    tipo_doc = "80";
                    break;
                case "DNI":
                    tipo_doc = "96";
                    break;
            }
            return tipo_doc;
        }

        private string TraerProximoCliente()
        {
            string cod_client = "";

            db.CrearComando(@"SELECT MAX(COD_CLIENT) + 1  FROM GVA14 where len(COD_CLIENT) = 6");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                cod_client = dt.Rows[0][0].ToString().PadLeft(6,'0');
            }
            return cod_client;
        }
        

        private string TraerVendedor(string p)
        {
            string cod_vended = "";

            db.CrearComando(@"
                            SELECT COD_VENDED,NOMBRE_VEN FROM GVA23
                            WHERE (COD_VENDED = '" + p + @"' 
                            OR NOMBRE_VEN = '" + p + @"')");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                cod_vended = dt.Rows[0][0].ToString();
            }
            return cod_vended;
        }

        private string TraerDeposito(string p)
        {
            string cod_deposi = "";

            db.CrearComando("SELECT COD_SUCURS FROM STA22 WHERE COD_SUCURS = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                cod_deposi = dt.Rows[0][0].ToString();
            }
            return cod_deposi;
        }

        private string TraerTalonario(string p)
        {
            string talon_ped = "";

            db.CrearComando("SELECT TALONARIO FROM GVA43 WHERE TALONARIO = '" + p + "'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                talon_ped = dt.Rows[0][0].ToString();
            }
            return talon_ped;
        }

        public void ComenzarTransaccion()
        {
            db.ComenzarTransaccion();
        }

        public void ConfirmarTransaccion()
        {
            db.ConfirmarTransaccion();
        }
        public void CancelarTransaccion()
        {
            db.CancelarTransaccion();
        }

        public string CargarPedidos(GVA21 pedido)
        {
            string log = "";

            log += "Pedido " + pedido.NRO_PEDIDO + Environment.NewLine;
            string errores = "";
            string donde = "";
            string consulta = "";
            foreach (string error in pedido.error)
            {
                errores += error + Environment.NewLine;
            }
            if (errores.Equals(""))
            {
                try
                {
                    //db.ComenzarTransaccion();
                    if (!ExisteCliente(pedido.Cliente.CUIT))
                    {
                        pedido.Cliente.COD_CLIENT = TraerProximoCliente();
                        donde = "Cliente";
                        consulta = pedido.Cliente.insert();
                        db.CrearComando(pedido.Cliente.insert());
                        db.EjecutarComando();
                        //db.CrearComando(ProviderId("GVA14"));
                        //db.EjecutarComando();
                        donde = "DIRECCION ENTREGA";
                        pedido.Cliente.direccion_entrega.COD_CLIENTE = pedido.Cliente.COD_CLIENT;
                        consulta = pedido.Cliente.direccion_entrega.insert();
                        db.CrearComando(consulta);
                        db.EjecutarComando();
                        //db.CrearComando(ProviderId("DIRECCION_ENTREGA"));
                        //db.EjecutarComando();
                        pedido.COD_CLIENT = pedido.Cliente.COD_CLIENT;
                    }

                    pedido.ID_DIRECCION_ENTREGA = TraerDireccionEntrega(pedido.COD_CLIENT);
                    
                    

                    db.CrearComando(@"update GVA21 SET TOTAL_PEDI = (select 
                                            CAST(
                                            SUM(CANT_PEDID * PRECIO)- ((SUM(CANT_PEDID * PRECIO) * PORC_DESC) / 100)
                                            AS DECIMAL(17,2))  
                                            from gva21 
                                            LEFT OUTER JOIN GVA03
                                            ON GVA21.TALON_PED = GVA03.TALON_PED
                                            AND GVA21.NRO_PEDIDO = GVA03.NRO_PEDIDO
                                            where GVA21.TALON_PED = " + pedido.TALON_PED + @"  
                                            AND GVA21.NRO_PEDIDO = '" + pedido.NRO_PEDIDO + @"'
                                            GROUP BY PORC_DESC) 
                                            WHERE TALON_PED = " + pedido.TALON_PED + @" 
                                            AND NRO_PEDIDO = '" + pedido.NRO_PEDIDO + @"'");
                    db.EjecutarComando();

                    donde = "Pedido";
                    consulta = pedido.insert();
                    db.CrearComando(pedido.insert());
                    db.EjecutarComando();
                    foreach (GVA03 item in pedido.Renglones)
                    {
                        donde = "Item";
                        consulta = item.insert();
                        db.CrearComando(item.insert());
                        db.EjecutarComando();
                    }
                    errores = "Ok" + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("Incorrect syntax near")) errores += donde + " - " + "No existe la Cond. Vta." + Environment.NewLine;
                    else errores += donde + " - " + ex.Message.ToString() + Environment.NewLine;
                    error++;
                }
            }

            log += errores;

            log += "*".PadLeft(30, '*') + Environment.NewLine;
                
            return log;

        }

        private string TraerDireccionEntrega(string p)
        {
            string id_de = "null";

            db.CrearComando(@"SELECT ID_DIRECCION_ENTREGA FROM DIRECCION_ENTREGA
                            WHERE COD_CLIENTE = '" + p + @"'
                            AND HABILITADO = 'S'
                            AND HABITUAL = 'S'");

            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                id_de = dt.Rows[0]["ID_DIRECCION_ENTREGA"].ToString();
            }
            return id_de;
        }

        private string ProviderId(string p)
        {
            string sql = @"UPDATE PROVIDERID SET ULTIMOID = (SELECT MAX(ID_" + p + @") FROM " + p + @")
                           WHERE TABLA = '" + p + @"'";
            return sql;
        }

        private bool ExisteCliente(string cuit)
        {
            bool existe = false;

            db.CrearComando(@"SELECT COD_CLIENT FROM GVA14 
                            WHERE  REPLACE(CUIT,'-','') = '" + cuit.Replace("-","") + @"'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                existe = true;
            }
            return existe;
        }


        //public string CargarRecibo(string id_factura)
        //{
        //    string log= "";

        //    GVA12 oGva12 = new GVA12();

        //    oGva12 = TraerDatosFactura(id_factura);

        //    SBA04 oSba04 = new SBA04();
        //    SBA05 oSba05H = new SBA05("H");
        //    SBA05 oSba05D = new SBA05("D");

        //    oGva12.N_COMP = TraerProximoRec(oGva12.TALONARIO);
        //    DateTime fecha = System.DateTime.Now;

        //    oSba04.FECHA = fecha.ToString("dd/MM/yyyy");

        //    //haber
        //    oSba04.N_COMP = oGva12.N_COMP;
        //    oSba04.TOTAL_IMPORTE_CTE = oGva12.IMPORTE;
        //    oSba04.TOTAL_IMPORTE_EXT = oGva12.IMPORTE;

        //    oSba05H.N_COMP = oGva12.N_COMP;
        //    oSba05H.FECHA = fecha.ToString("dd/MM/yyyy");
        //    oSba05H.COD_CTA = CTA_DPV;
        //    oSba05H.CANT_MONE = oGva12.IMPORTE;
        //    oSba05H.MONTO = oGva12.IMPORTE;
        //    oSba05H.UNIDADES = oGva12.IMPORTE;
            
        //    //debe
        //    oSba05D.N_COMP = oGva12.N_COMP;
        //    oSba05D.FECHA = fecha.ToString("dd/MM/yyyy");
        //    oSba05D.COD_CTA = oGva12.CUENTA;
        //    oSba05D.CANT_MONE = oGva12.IMPORTE;
        //    oSba05H.MONTO = oGva12.IMPORTE;
        //    oSba05H.UNIDADES = oGva12.IMPORTE;


        //    try
        //    {
        //        db.ComenzarTransaccion();

        //        db.CrearComando(oGva12.insert());
        //        db.EjecutarComando();

        //        string id_rec = TraerIdRecibo(oGva12);
        //        oGva12.ID_GVA12_CAN = id_rec;
        //        db.CrearComando(oGva12.TOGVA_SALDO());
        //        db.EjecutarComando();
        //        db.CrearComando(oGva12.TOGVA07());
        //        db.EjecutarComando();
                
        //        db.CrearComando(oSba04.insert());
        //        db.EjecutarComando();
                
        //        db.CrearComando(oSba04.TOASIENTO_COMPROBANTE_SB());
        //        db.EjecutarComando();
                
        //        db.CrearComando(ProviderId("ASIENTO_COMPROBANTE_SB"));
        //        db.EjecutarComando();

        //        db.CrearComando(oSba05H.insert());
        //        db.EjecutarComando();
        //        db.CrearComando(oSba05H.TOSBA01());
        //        db.EjecutarComando();
        //        db.CrearComando(oSba05D.insert());
        //        db.EjecutarComando();
        //        db.CrearComando(oSba05D.TOSBA01());
        //        db.EjecutarComando();

        //        db.CrearComando(GuardarProximoRec(oGva12.N_COMP,oGva12.TALONARIO));
        //        db.EjecutarComando();

        //        db.ConfirmarTransaccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        log = ex.Message.ToString();
        //        db.CancelarTransaccion();
        //    }
        //    return log;
        //}

        private GVA12 TraerDatosFactura(string id_factura)
        {
            GVA12 oGva12 = new GVA12();

            db.CrearComando("SELECT * FROM GVA12 WHERE ID_GVA12 = '" + id_factura + "'");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                oGva12.IMPORTE = (decimal)dt.Rows[0]["IMPORTE"];
                oGva12.T_COMP_FAC = dt.Rows[0]["T_COMP"].ToString();
                oGva12.N_COMP_FAC = dt.Rows[0]["N_COMP"].ToString();
            }

            return oGva12;
        }

        private string TraerIdRecibo(GVA12 oGva12)
        {
            string id_gva12 = "";

            db.CrearComando(@"SELECT ID_GVA12 FROM SBA01 
                            WHERE N_COMP = '" + oGva12.N_COMP + @"'
                            T_COMP = '" + oGva12.T_COMP + @"'");
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                id_gva12 = dt.Rows[0]["ID_GVA12"].ToString();
            }
            return id_gva12;
        }

        private string TraerProximoRec(string tal)
        {
            string temp = "";

            db.CrearComando(@"SELECT TIPO,SUCURSAL,PROXIMO FROM GVA43
                            WHERE TALONARIO = " + tal + "");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                temp = dt.Rows[0]["TIPO"].ToString() + dt.Rows[0]["SUCURSAL"].ToString()
                    + DocNumberDecrypt(dt.Rows[0]["PROXIMO"].ToString()).PadLeft(8, '0');
            }

            return temp;
        }

        private string GuardarProximoRec(string proximo, string talonario)
        {
            string ret = "";

            long prox = long.Parse(proximo.Substring(5, 8));

            string strProx = (prox + 1).ToString().PadLeft(8, '0');

            ret = @"UPDATE GVA43 SET  PROXIMO = '" + DocNumberEncrypt(strProx) + @"' 
                    WHERE TALONARIO = " + talonario + @"
                    ";

            return ret;
        }

        public int CodeConverter(int position, string code)
        {
            int CodeConverter = 0;

            List<string> vPosition1 = new List<string>();
            vPosition1.Add("74");
            vPosition1.Add("75");
            vPosition1.Add("76");
            vPosition1.Add("77");
            vPosition1.Add("70");
            vPosition1.Add("71");
            vPosition1.Add("72");
            vPosition1.Add("73");
            vPosition1.Add("7C");
            vPosition1.Add("7D");
            List<string> vPosition2 = new List<string>();
            vPosition2.Add("07");
            vPosition2.Add("06");
            vPosition2.Add("05");
            vPosition2.Add("04");
            vPosition2.Add("03");
            vPosition2.Add("02");
            vPosition2.Add("01");
            vPosition2.Add("00");
            vPosition2.Add("0F");
            vPosition2.Add("0E");

            List<string> vPosition3 = new List<string>();
            vPosition3.Add("43");
            vPosition3.Add("42");
            vPosition3.Add("41");
            vPosition3.Add("40");
            vPosition3.Add("47");
            vPosition3.Add("46");
            vPosition3.Add("45");
            vPosition3.Add("44");
            vPosition3.Add("4B");
            vPosition3.Add("4A");

            List<string> vPosition4 = new List<string>();
            vPosition4.Add("7B");
            vPosition4.Add("7A");
            vPosition4.Add("79");
            vPosition4.Add("78");
            vPosition4.Add("7F");
            vPosition4.Add("7E");
            vPosition4.Add("7D");
            vPosition4.Add("7C");
            vPosition4.Add("73");
            vPosition4.Add("72");

            List<string> vPosition5 = new List<string>();
            vPosition5.Add("51");
            vPosition5.Add("50");
            vPosition5.Add("53");
            vPosition5.Add("52");
            vPosition5.Add("55");
            vPosition5.Add("54");
            vPosition5.Add("57");
            vPosition5.Add("56");
            vPosition5.Add("59");
            vPosition5.Add("58");
            List<string> vPosition6 = new List<string>();
            vPosition6.Add("7E");
            vPosition6.Add("7F");
            vPosition6.Add("7C");
            vPosition6.Add("7D");
            vPosition6.Add("7A");
            vPosition6.Add("7B");
            vPosition6.Add("78");
            vPosition6.Add("79");
            vPosition6.Add("76");
            vPosition6.Add("77");
            List<string> vPosition7 = new List<string>();
            vPosition7.Add("07");
            vPosition7.Add("06");
            vPosition7.Add("05");
            vPosition7.Add("04");
            vPosition7.Add("03");
            vPosition7.Add("02");
            vPosition7.Add("01");
            vPosition7.Add("00");
            vPosition7.Add("0F");
            vPosition7.Add("0E");
            List<string> vPosition8 = new List<string>();
            vPosition8.Add("65");
            vPosition8.Add("64");
            vPosition8.Add("67");
            vPosition8.Add("66");
            vPosition8.Add("61");
            vPosition8.Add("60");
            vPosition8.Add("63");
            vPosition8.Add("62");
            vPosition8.Add("6D");
            vPosition8.Add("6C");

            switch (position)
            {
                case 1:
                    CodeConverter = vPosition1.IndexOf(code); break;
                case 2:
                    CodeConverter = vPosition2.IndexOf(code); break;
                case 3:
                    CodeConverter = vPosition3.IndexOf(code); break;
                case 4:
                    CodeConverter = vPosition4.IndexOf(code); break;
                case 5:
                    CodeConverter = vPosition5.IndexOf(code); break;
                case 6:
                    CodeConverter = vPosition6.IndexOf(code); break;
                case 7:
                    CodeConverter = vPosition7.IndexOf(code); break;
                case 8:
                    CodeConverter = vPosition8.IndexOf(code); break;
            }

            return CodeConverter;
        }

        public string DocNumberEncrypt(string pNumber)
        {
            string DocNumberEncrypt = "";
            string sText = "";
            string sAux = "";
            string sConv = "";
            int i = 0;

            sText = pNumber.PadLeft(8, '0');

            for (i = 0; i < 8; i++)
            {
                sAux = CharConverter(i, int.Parse(sText.Substring(i, 1)));
                sConv = sConv + sAux;
            }


            DocNumberEncrypt = sConv;

            return DocNumberEncrypt;
        }

        private string CharConverter(int iPosition, int iNumber)
        {
            string[] vPosition1 = { "74", "75", "76", "77", "70", "71", "72", "73", "7C", "7D" };

            string[] vPosition2 = { "07", "06", "05", "04", "03", "02", "01", "00", "0F", "0E" };

            string[] vPosition3 = { "43", "42", "41", "40", "47", "46", "45", "44", "4B", "4A" };

            string[] vPosition4 = { "7B", "7A", "79", "78", "7F", "7E", "7D", "7C", "73", "72" };

            string[] vPosition5 = { "51", "50", "53", "52", "55", "54", "57", "56", "59", "58" };

            string[] vPosition6 = { "7E", "7F", "7C", "7D", "7A", "7B", "78", "79", "76", "77" };

            string[] vPosition7 = { "07", "06", "05", "04", "03", "02", "01", "00", "0F", "0E" };

            string[] vPosition8 = { "65", "64", "67", "66", "61", "60", "63", "62", "6D", "6C" };

            string CharConverter = "";

            switch (iPosition + 1)
            {
                case 1:
                    CharConverter = vPosition1[iNumber]; break;
                case 2:
                    CharConverter = vPosition2[iNumber]; break;
                case 3:
                    CharConverter = vPosition3[iNumber]; break;
                case 4:
                    CharConverter = vPosition4[iNumber]; break;
                case 5:
                    CharConverter = vPosition5[iNumber]; break;
                case 6:
                    CharConverter = vPosition6[iNumber]; break;
                case 7:
                    CharConverter = vPosition7[iNumber]; break;
                case 8:
                    CharConverter = vPosition8[iNumber]; break;
                //case 9:
                //    CharConverter = vPosition9[iNumber]; break;
                //case 0:
                //    CharConverter = vPosition0[iNumber]; break;
            }
            return CharConverter;
        }

        public string DocNumberDecrypt(string pNumber)
        {

            string sText;
            int sAux;
            int iPos = 0;
            string sConv = "";
            int i;

            string DocNumberDecrypt = "";

            sText = pNumber.PadLeft(16, '0');

            if (sText.Length / 2 != 0)
            {
                sText = "0" + sText;
            }

            for (i = 1; i < sText.Length; i += 2)
            {
                iPos = iPos + 1;
                sAux = CodeConverter(iPos, sText.Substring(i, 2));
                sConv = sConv + sAux.ToString();
            }

            DocNumberDecrypt = sConv;

            return DocNumberDecrypt;
        }

        public string hacerReciboDePendientes(string talonario_rec, string cta_haber,DataRow linea)
        {
            string log = "";

            string log_aux = "";

            GVA12 oGva12 = new GVA12();
            SBA04 oSba04 = new SBA04();
            SBA05 oSba05h = new SBA05("H");
            SBA05 oSba05d = new SBA05("D");

            oGva12.COD_VENDED = "1";
            oGva12.COD_CLIENT = linea["COD_CLIENT"].ToString();
            oGva12.COD_VENDED = linea["COD_VENDED"].ToString();
            oGva12.FECHA_EMIS = linea["FECHA_EMIS"].ToString();//(B)
            //oGva12.FECHA_EMIS = DateTime.Now.ToString("dd/MM/yyyy"); 



            oGva12.COTIZ = "1";

            oGva12.TALONARIO = talonario_rec;
            oGva12.N_COMP = traerProximoGVA12_N_COMP(oGva12.TALONARIO);
            oGva12.NCOMP_IN_V = traerProximoGVA12_NCOMP_IN_V();
            //sba04
            oSba04.COD_GVA14 = oGva12.COD_CLIENT;
            oSba04.COTIZACION = "1";
            oSba04.FECHA_EMIS = oGva12.FECHA_EMIS;
            oSba04.FECHA = oSba04.FECHA_EMIS;
            oSba04.FECHA_ING = oSba04.FECHA_EMIS;
            oSba04.N_INTERNO = traerProximoSBA04_N_INTERNO();
            oSba04.FECHA_EMIS = oGva12.FECHA_EMIS;
            oSba04.FECHA_ING = oGva12.FECHA_EMIS;
            oSba04.N_COMP = oGva12.N_COMP;
            oSba04.COD_GVA14 = oGva12.COD_CLIENT;

            oSba05d.N_COMP = oGva12.N_COMP;
            oSba05d.COD_CTA = linea["LEYENDA_4"].ToString();
            //oSba05d.COD_CTA = TraerCtaTesoreria(oSba05d.COD_CTA);

            if (!existeCuenta(oSba05d.COD_CTA))
            {
                log_aux += "No existe cuenta " + oSba05d.COD_CTA + " en Tango - Modulo Tesoreria!" + Environment.NewLine;
            }

            decimal importe = decimal.Parse(linea["IMPORTE_VT"].ToString().Replace(".", ","));
            
            oSba05d.CANT_MONE = importe;
            oSba05d.MONTO = oSba05d.CANT_MONE;
            oSba05d.UNIDADES = oSba05d.CANT_MONE;
            oSba05d.COD_GVA14 = oSba04.COD_GVA14;
            oSba05d.D_H = "D";
            oSba05d.COD_OPERAC = "";
            oSba05d.ID_SBA11 = "null";
            oSba05d.RENGLON = (1).ToString();
            oSba05d.COD_GVA14 = oSba04.COD_GVA14;
            oSba05d.FECHA = DateTime.Now.ToString("dd/MM/yyyy");

            GVA07 oGva07 = new GVA07();

            oGva07.N_COMP_CAN = oGva12.N_COMP;
            oGva07.T_COMP_CAN = "REC";
            decimal importegva07 = decimal.Parse(linea["IMPORTE_VT"].ToString().Replace(".", ","));

            oGva07.IMPORT_CAN = importegva07.ToString().Replace(",", ".");
            oGva07.T_COMP = linea["T_COMP"].ToString();
            oGva07.N_COMP = linea["N_COMP"].ToString();
            oGva07.FECHA_VTO = ((DateTime)linea["FECHA_VTO"]).ToString("dd/MM/yyyy");
            oGva07.IMPORTE_VT = oGva07.IMPORT_CAN;
            oGva07.F_COMP_CAN = DateTime.Now.ToString("dd/MM/yyyy");
            oGva07.IMP_VT_UNI = oGva07.IMPORT_CAN;
            oGva07.IMP_CAN_UN = oGva07.IMPORT_CAN;

            //cGva07.Add(oGva07);
            //}
            oGva12.COTIZ = "1";
            oGva12.IMPORTE = decimal.Parse(linea["IMPORTE_VT"].ToString().Replace(".", ","));
            oGva12.UNIDADES = oGva12.IMPORTE;
            oSba04.TOTAL_IMPORTE_CTE = oGva12.IMPORTE;
            oSba04.TOTAL_IMPORTE_EXT = oGva12.IMPORTE;

            //Renglon_haber
            oSba05h.N_COMP = oGva12.N_COMP;
            oSba05h.MONTO = oSba04.TOTAL_IMPORTE_CTE;
            oSba05h.CANT_MONE = oSba05h.MONTO;
            oSba05h.UNIDADES = oSba05h.MONTO;
            oSba05h.RENGLON = "0";
            oSba05h.COD_CTA = cta_haber;
            oSba05h.D_H = "H";
            oSba05h.FECHA = oSba04.FECHA_EMIS;
            oSba05h.ID_SBA11 = "null";
            oSba05h.COD_GVA14 = oGva12.COD_CLIENT;
            oSba05h.COD_OPERAC = "";
            oSba05h.COD_CTA = cta_haber;
            if (!existeCuenta(oSba05h.COD_CTA))
            {
                log_aux += "No existe cuenta " + oSba05h.COD_CTA + " en Tango - Modulo Tesoreria!" + Environment.NewLine;
            }

            if (oSba05d.MONTO != oSba05h.MONTO)
            {
                log_aux += "No coinciden los Totales Vencimientos - Agrupado de Cuentas!" + Environment.NewLine;
            }
            if (oSba05d.MONTO != oSba04.TOTAL_IMPORTE_CTE)
            {
                log_aux += "No coinciden los Totales Vencimientos - Agrupado de Cuentas!" + Environment.NewLine;
            }

            try
            {
                if (log_aux != "")
                {
                    throw new Exception(log_aux);
                }
                log += log_aux;

                db.ComenzarTransaccion();
               
                db.CrearComando(oGva12.insert());
                db.EjecutarComando();

                db.CrearComando(oGva12.TOGVA_SALDO());
                db.EjecutarComando();

                db.CrearComando(oSba04.insert());
                db.EjecutarComando();

                //string ID_ASIENTO_COMPROBANTE_SB = traerProxId_Asiento_comprobante_sb();

                db.CrearComando(oSba04.TOASIENTO_COMPROBANTE_SB());
                db.EjecutarComando();

//                db.CrearComando(@"UPDATE PROVIDERID SET ULTIMOID = " + ID_ASIENTO_COMPROBANTE_SB + @" 
//                                      WHERE TABLA = 'ASIENTO_COMPROBANTE_SB'");
//                db.EjecutarComando();
                //db.CrearComando(ProviderId("ASIENTO_COMPROBANTE_SB"));
                //db.EjecutarComando();
                string temp = oSba05h.insert();
                db.CrearComando(oSba05h.insert());
                db.EjecutarComando();
                db.CrearComando(oSba05h.TOSBA01());
                db.EjecutarComando();

                db.CrearComando(oSba05d.insert());
                db.EjecutarComando();
                db.CrearComando(oSba05d.TOSBA01());
                db.EjecutarComando();


                oGva07.F_COMP_CAN = System.DateTime.Now.ToString("dd/MM/yyyy");
                oGva07.N_COMP_CAN = oGva12.N_COMP;
                oGva07.T_COMP_CAN = oGva12.T_COMP;
                db.CrearComando(oGva07.insert());
                db.EjecutarComando();
                db.CrearComando(oGva07.TOGVA46());
                db.EjecutarComando();
                db.CrearComando(@"UPDATE GVA12 SET ESTADO = 'CAN' ,ESTADO_UNI = 'CAN'
                                        WHERE T_COMP = '" + oGva07.T_COMP + @"' 
                                        AND N_COMP = '" + oGva07.N_COMP + @"'");
                db.EjecutarComando();

                db.CrearComando(guardarProxmoGV(oGva12.N_COMP, oGva12.TALONARIO));
                db.EjecutarComando();

                db.CrearComando(@"UPDATE INCREMENTAL_VALUE SET ULTIMOVALOR =  (SELECT MAX(N_INTERNO) FROM SBA04)
                                      WHERE TABLA = 'SBA04' AND CAMPO = 'N_INTERNO'");
                db.EjecutarComando();



                db.ConfirmarTransaccion();
                log += "Recibo " + oGva12.N_COMP + " generado correctamente para comprobante " + oGva07.N_COMP + "!." + Environment.NewLine;
            }


            catch (Exception ex)
            {
                log += "Error al escribir en la base de Datos : " + ex.Message.ToString()
                    + Environment.NewLine;
                log += db.comando.CommandText.ToString();
                db.CancelarTransaccion();
            }
            
            return log;

        }

        private bool existeCuenta(string p)
        {
            bool ret = false;
            string sql = @"SELECT ID_SBA01 FROM SBA01 WHERE COD_CTA = '" + p + "'";

            db.CrearComando(sql);
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                ret = true;
            }

            return ret;
        }

        private string guardarProxmoGV(string proximo, string talonario)
        {
            string ret = "";

            long prox = long.Parse(proximo.Substring(6, 8));

            string strProx = (prox + 1).ToString().PadLeft(8, '0');

            ret = @"UPDATE GVA43 SET PROXIMO = '" + oTgFunc.DocNumberEncrypt(strProx) + @"' 
                    WHERE TALONARIO = " + talonario + @"
                    ";

            return ret;
        }

        private string traerProxId_Asiento_comprobante_sb()
        {
            string temp = "1";

            db.CrearComando(@"select ultimoid + 1 from providerid where tabla='ASIENTO_COMPROBANTE_SB'");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                temp = dt.Rows[0][0].ToString();
            }

            return temp;
        }
     

        private string traerProximoSBA04_N_INTERNO()
        {
            string temp = "1";

            db.CrearComando(@"select ISNULL(MAX(n_interno),1) from sba04");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                int nro = int.Parse(dt.Rows[0][0].ToString());
                nro++;
                temp = nro.ToString();
            }

            return temp;
        }

        private string traerProximoGVA12_NCOMP_IN_V()
        {
            string temp = "1";

            db.CrearComando(@"select MAX(ncomp_in_v) from gva12");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                int nro = int.Parse(dt.Rows[0][0].ToString());
                nro++;
                temp = nro.ToString();
            }

            return temp;
        }

        private string traerProximoGVA12_N_COMP(string tal)
        {
            string temp = "";

            db.CrearComando(@"SELECT TIPO,SUCURSAL,PROXIMO FROM GVA43
                            WHERE TALONARIO = " + tal + "");
            DbDataReader dr = db.EjecutarConsulta();
            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count == 1)
            {
                temp = dt.Rows[0]["TIPO"].ToString().PadLeft(1, ' ') + dt.Rows[0]["SUCURSAL"].ToString()
                    + oTgFunc.DocNumberDecrypt(dt.Rows[0]["PROXIMO"].ToString()).PadLeft(8, '0');
            }

            return temp;
        }

        public DataTable traerVencimientos()
        {
            string sql = @"SELECT T2.COD_CLIENT,T1.T_COMP,T1.N_COMP,IMPORTE_VT,FECHA_VTO,LEYENDA_4,, T2.FECHA_EMIS
                            ,COD_VENDED
                            FROM GVA46 T1
                            INNER JOIN GVA12 T2
                            ON T1.T_COMP = T2.T_COMP 
                            AND T1.N_COMP = T2.N_COMP
                            WHERE ESTADO_VTO = 'PEN'
                            AND LEYENDA_5 ='BYA'
                            AND T2.TALONARIO = '4'
                            --AND COD_VENDED = '99'"; //(B) Agregado el T2.Talonario='4'
            
            db.CrearComando(sql);
            DataTable dt = new DataTable();
            DbDataReader dr = db.EjecutarConsulta();
            
            dt.Load(dr);
            
            return dt;

        }

        

    }
}
