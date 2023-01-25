using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
namespace Negocio
{
    public class ExcelClass
    {
        public List<GVA21> leerExcel(string archivo)
        {
            List<GVA21> cPedidos = new List<GVA21>();

            Excel.Application oExcel = new Excel.Application();
            oExcel.Visible = true;
            Excel.Workbook WB = oExcel.Workbooks.Open(archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            string ExcelWorkbookname = WB.Name;

            int worksheetcount = WB.Worksheets.Count;

            Excel.Worksheet wks = (Excel.Worksheet)WB.Worksheets[1];

            try
            {
                    
                string firstworksheetname = wks.Name;
                var firstcellvalue = ((Excel.Range)wks.Cells[1, 1]).Value2;
                
                GVA21 pedido = new GVA21();
                string n_pedido = ((Excel.Range)wks.Cells[2, 4]).Value2.ToString();
                string cliente = ((Excel.Range)wks.Cells[2, 2]).Value2.ToString();
                int fila = 2;
                int renglon = 1;

                while (cliente != "")
                {
                    pedido.NRO_PEDIDO = n_pedido;
                    pedido.COD_CLIENT = "";
                    pedido.Cliente.COD_CLIENT = "";
                    pedido.COD_VENDED = ((Excel.Range)wks.Cells[fila, 2]).Value2.ToString();
                    pedido.Cliente.TIPO_DOC = ((Excel.Range)wks.Cells[fila, 6]).Value2.ToString();
                    pedido.Cliente.CUIT = ((Excel.Range)wks.Cells[fila, 7]).Value2.ToString();
                    pedido.Cliente.RAZON_SOCI = ((Excel.Range)wks.Cells[fila, 8]).Value2.ToString();
                    pedido.Cliente.ID_CATEGORIA_IVA = ((Excel.Range)wks.Cells[fila, 9]).Value2.ToString();
                    pedido.Cliente.NOM_COM = pedido.Cliente.RAZON_SOCI;
                    pedido.Cliente.DIR_COM = ((Excel.Range)wks.Cells[fila, 10]).Value2.ToString();
                    pedido.Cliente.DOMICILIO = pedido.Cliente.DIR_COM;
                    pedido.Cliente.NRO_LISTA = ((Excel.Range)wks.Cells[fila, 25]).Value2.ToString();
                    pedido.N_LISTA = ((Excel.Range)wks.Cells[fila, 25]).Value2.ToString();

                    if (pedido.Cliente.DIR_COM.Length > 60)
                    {
                        pedido.Cliente.DIR_COM = pedido.Cliente.DIR_COM.Substring(1, 60);
                    }
                    if (pedido.Cliente.DOMICILIO.Length > 30)
                    {
                        pedido.Cliente.DOMICILIO = pedido.Cliente.DOMICILIO.Substring(1, 30);
                    }
                                        
                    pedido.Cliente.LOCALIDAD = "";
                    if (((Excel.Range)wks.Cells[fila, 11]).Value2 != null)
                    {
                        pedido.Cliente.LOCALIDAD = ((Excel.Range)wks.Cells[fila, 11]).Value2.ToString();
                    }
                    pedido.Cliente.COD_PROVIN = ((Excel.Range)wks.Cells[fila, 12]).Value2.ToString();
                    pedido.Cliente.C_POSTAL = ((Excel.Range)wks.Cells[fila, 14]).Value2.ToString();
                    //pedido.Cliente.TELEFONO_1 = ((Excel.Range)wks.Cells[fila, 16]).Value2.ToString();
                    //pedido.Cliente.COND_VTA = ((Excel.Range)wks.Cells[fila, 17]).Value2.ToString();
                    pedido.Cliente.COND_VTA = "99";
                    //pedido.Cliente.E_MAIL = ((Excel.Range)wks.Cells[fila, 28]).Value2.ToString();
                    pedido.Cliente.FECHA_ALTA = System.DateTime.Now.ToString("dd/MM/yyyy");

                    pedido.Cliente.E_MAIL = "";
                    if (((Excel.Range)wks.Cells[fila, 27]).Value2 != null)
                    {
                        pedido.Cliente.E_MAIL = ((Excel.Range)wks.Cells[fila, 27]).Value2.ToString();
                        //(B) 03/06 agregado a pedido de Verónica Gabrielli
                        pedido.Cliente.MAIL_DE = ((Excel.Range)wks.Cells[fila, 27]).Value2.ToString();
                        //pedido.Cliente.PUBLICA_WEB_CLIENTES = "S";
                        //(B) Distinguir si el pedido es A o B
                        if (pedido.Cliente.ID_CATEGORIA_IVA.Contains("final")) pedido.esA = false;
                    }
                    //pedido.Cliente.COND_VTA = "";
                    //if (((Excel.Range)wks.Cells[fila, 27]).Value2 != null)
                    //{
                    //    pedido.LEYENDA_4 = ((Excel.Range)wks.Cells[fila, 17]).Value2.ToString();
                    //}
                    
                    pedido.Cliente.TELEFONO_1 = "";
                    if (((Excel.Range)wks.Cells[fila, 16]).Value2 != null)
                    {
                        pedido.Cliente.TELEFONO_1 = ((Excel.Range)wks.Cells[fila, 16]).Value2.ToString();
                    }

                    //pedido.TALON_PED = ((Excel.Range)wks.Cells[fila, 2]).Value2.ToString();
                    pedido.COD_SUCURS = ((Excel.Range)wks.Cells[fila, 3]).Value2.ToString();
                    pedido.NRO_PEDIDO = ((Excel.Range)wks.Cells[fila, 4]).Value2.ToString();

                    pedido.FECHA_PEDI = ((Excel.Range)wks.Cells[fila, 5]).Text.ToString();
                    
                    pedido.LEYENDA_5 = "BYA";
                    pedido.LEYENDA_4 = "";
                    if (((Excel.Range)wks.Cells[fila, 17]).Value2 != null)
                    {
                        pedido.LEYENDA_4 = ((Excel.Range)wks.Cells[fila, 17]).Value2.ToString();
                        pedido.COND_AUX = pedido.LEYENDA_4;
                    }

                    pedido.COD_TRANSP = ((Excel.Range)wks.Cells[fila, 24]).Value2.ToString();

                    GVA03 item = new GVA03();

                    item.N_RENGLON = renglon.ToString();

                    item.PRECIO = ((Excel.Range)wks.Cells[fila, 20]).Value2.ToString();
                    item.COD_ARTICU = ((Excel.Range)wks.Cells[fila, 18]).Value2.ToString();
                    item.CANT_PEDID = ((Excel.Range)wks.Cells[fila, 21]).Value2.ToString();
                    item.CANT_A_DES = item.CANT_PEDID;
                    item.CANT_A_FAC = item.CANT_PEDID;
                    item.CANT_PEN_D = item.CANT_PEDID;
                    item.CANT_PEN_F = item.CANT_PEDID;

                    pedido.Renglones.Add(item);
                    renglon++;

                    fila++;
                    if (((Excel.Range)wks.Cells[fila, 2]).Value2 == null)
                    {
                        n_pedido = "";
                        cliente = "";
                    }
                    else
                    {
                        cliente = ((Excel.Range)wks.Cells[fila, 2]).Value2.ToString();
                        n_pedido = ((Excel.Range)wks.Cells[fila, 4]).Value2.ToString();
                    }

                    if (pedido.NRO_PEDIDO != n_pedido)
                    {
                        cPedidos.Add(pedido);
                        pedido = new GVA21();
                        renglon = 1;
                    }
                }
          
            } catch (Exception ex)   
            {  
                //error = ex.Message;
                return new List<GVA21>();
            }
            finally
            {
                ////Marshal.ReleaseComObject(Range); 
                //Marshal.ReleaseComObject(wks);
                ////WRITE close and release
                //WB.Close(false, Missing.Value, Missing.Value);
                //Marshal.ReleaseComObject(WB);
                ////!WRITE quit and release
                //oExcel.Quit();
                //Marshal.ReleaseComObject(oExcel);
                ////cleanup
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
                return cPedidos;
        }

    }
}
