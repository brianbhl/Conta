using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Compra_sin_factura : Form
    {
        public Compra_sin_factura()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }
        string[] nombre = { "Servicios", "IUE", "IT retencion", "Caja M/N" };
        double[] datos = new double[4];

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Recibo")
            {
                if (comboBox2.Text == "Bienes")
                {
                    double a = double.Parse(textBox1.Text);
                    double iue5 = a * 0.05;
                    double it = a * 0.03;
                    double caja = a - (iue5 + it);
                    llenarRecibo(a, iue5, it, caja);
                }
                else
                {
                    double a = double.Parse(textBox1.Text);
                    double iue5 = a * 0.125;
                    double it = a * 0.03;
                    double caja = a - (iue5 + it);
                    llenarRecibo(a, iue5, it, caja);
                }
            }
            else
            {
                if (comboBox2.Text=="Bienes")
                {
                    double a = double.Parse(textBox1.Text);
                    double aux = a/0.92;
                    int iue5 = Convert.ToInt32(aux * 0.05);
                    int it = Convert.ToInt32(aux * 0.03);
                    int caja = Convert.ToInt32(aux - (iue5 + it));
                    if ((caja+iue5+it)==(aux = Convert.ToInt32(aux)))
                    {
                        if (caja==a)
                        {
                            llenarRecibo(Convert.ToInt32(aux), iue5, it, caja);
                        }
                        else
                        {
                            caja += 1;
                            aux += 1;
                            llenarRecibo(Convert.ToInt32(aux), iue5, it, caja);
                        }
                    }
                    else
                    {
                        llenarRecibo(Convert.ToInt32(aux), iue5, it, caja);
                    }
                }
                else
                {
                    double a = double.Parse(textBox1.Text);
                    double aux1 = a / 0.845;
                    int iue5 = Convert.ToInt32(aux1 * 0.125);
                    int it = Convert.ToInt32(aux1 * 0.03);
                    int caja = Convert.ToInt32(aux1 - (iue5 + it));
                    if ((caja + iue5 + it) == (aux1=Convert.ToInt32(aux1)))
                    {
                        if (caja == a)
                        {
                            llenarRecibo(Convert.ToInt32(aux1), iue5, it, caja);
                        }
                        else
                        {
                            caja += 1;
                            aux1 += 1;
                            llenarRecibo(Convert.ToInt32(aux1), iue5, it, caja);
                        }

                    }
                    else
                    {
                        llenarRecibo(Convert.ToInt32(aux1), iue5, it, caja);
                    }
                }
            }
        }

        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.RowCount = 4;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void llenarRecibo(double a, double b, double c, double d)
        {

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    datos[i] = a;
                }
                if (i == 1)
                {
                    datos[i] = b;
                }
                if (i == 2)
                    datos[i] = c;
                if (i == 3)
                    datos[i] = d;
                DatosCompra o = new DatosCompra();
                dataGridView1[0, i].Value = nombre[i];
                if (i < 1)
                {
                    dataGridView1[1, i].Value = datos[i];
                    o.compra = datos[i];
                    o.estado = true;
                }
                else
                {
                    dataGridView1[2, i].Value = datos[i];
                    o.compra = datos[i];
                    o.estado = false;
                }
                DatosCompra.lista.Add(o);
            }
        }
    }
}
