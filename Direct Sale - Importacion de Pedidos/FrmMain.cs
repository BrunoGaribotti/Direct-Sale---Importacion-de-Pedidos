using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using System.Threading;
using System.IO;

namespace Direct_Sale___Importacion_de_Pedidos
{
    public partial class FrmMain : Form
    {
        Procesos oProc = new Procesos();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pbProceso.Step = 1;
            pbProceso.Value = 0;
            toolStripStatusLabel1.Text = "Detenido";

            string log = oProc.CargarConfig();
            if (!log.Equals(""))
            {
                MessageBox.Show(log, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.xlsx) Archivo Excel| *.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("Archivo no existe!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExcelClass x = new ExcelClass();
            List<GVA21> cPedidos = x.leerExcel(textBox1.Text);

            oProc.ValidarPedidos(cPedidos);

            pbProceso.Step = 1;
            pbProceso.Value = 0;
            pbProceso.Maximum = cPedidos.Count;

            txtLog.Text += "";
            toolStripStatusLabel1.Text = "Importando Pedidos:";

            bool errorLote = false;
            txtLog.Text = "No se proceso el Archivo: " + Environment.NewLine;
            txtLog.Text += "Se encontraron los siguientes errores: " + Environment.NewLine;
            txtLog.Text +=  Environment.NewLine;
            
            foreach (GVA21 ped in cPedidos)
            {
                foreach (string error in ped.error)
                {
                    txtLog.Text += ped.NRO_PEDIDO + " - " + error + Environment.NewLine;
                    errorLote = true;
                }
            }

            if (!errorLote)
            {
                oProc.error = 0;
                oProc.ComenzarTransaccion();
                
                txtLog.Text = "";

                foreach (GVA21 pedido in cPedidos)
                {
                    string pedidoAux = pedido.TOTAL_PEDI.Replace(".", ",");
                    if (Decimal.Parse(pedidoAux) > 100000) pedido.TALONARIO = "13"; //(B) Descomentado
                    if (pedido.esA) pedido.COND_VTA = pedido.COND_AUX;
                    txtLog.Text += oProc.CargarPedidos(pedido);
                    pbProceso.PerformStep();
                    Application.DoEvents();
                    //Thread.Sleep(1000);
                }
                
                if(oProc.error == 0)
                {
                    oProc.ConfirmarTransaccion();
                    //oProc.CancelarTransaccion();
                    MessageBox.Show("Proceso Finalizado Correctamente!");
                } else {
                    oProc.CancelarTransaccion();
                    MessageBox.Show("No se proceso el archivo!");
                }

            }

            toolStripStatusLabel1.Text = "Detenido";
            pbProceso.Value = 0;

        }

        private void hacerREcibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbProceso.Step = 1;
            pbProceso.Value = 0;

            toolStripStatusLabel1.Text = "Cargando Recibos:";

            DataTable Venc = oProc.traerVencimientos();

            pbProceso.Maximum = Venc.Rows.Count;
            txtLog.Text += "";

            if (Venc.Rows.Count < 1)
            {
                MessageBox.Show("No hay recibos para realizar!");
                return;
            }

            for (int i = 0; i < Venc.Rows.Count; i++)
            {
                txtLog.Text += oProc.hacerReciboDePendientes(oProc.TALON_REC,oProc.CTA_DPV,Venc.Rows[i]);
                pbProceso.PerformStep();
                Application.DoEvents();
                //Thread.Sleep(1000);
            }

            toolStripStatusLabel1.Text = "Detenido";
            pbProceso.Value = 0;
            MessageBox.Show("Proceso Finalizado Correctamente!");        
        }

    }
}
