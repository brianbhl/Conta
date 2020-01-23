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
    public partial class Compras : Form
    {
        double a, b, c;
        libro_diario l = new libro_diario();
        double[] datos = new double[6];
        string[] nombre = { "compra", "C.F. IVA", "total" };
        string[] nombre1 = { "compra", "total" };
        public Compras()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Compra sin Factura")
            {
                Compra_sin_factura c = new Compra_sin_factura();
                c.Show();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Compra")
            {

                a = double.Parse(textBox1.Text);
                b = a * 0.87;
                c = a * 0.13;
                llenarCompra(a, b, c);
            }
            if (comboBox1.Text == "Compra Combustible")
            {

                a = double.Parse(textBox1.Text);
                double aux = a * 0.70;
                c = aux * 0.13;
                double aux1 = a - c;
                llenarCompra(a, aux1, c);
            }
            if (comboBox1.Text == "Compra Biblioteca")
            {
                a = double.Parse(textBox1.Text);
                b = a;
                llenarCompraLibro(a, a);
            }
        }

        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.RowCount = 3;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void llenarCompra(double a, double b, double c)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    datos[i] = b;
                }
                if (i == 1)
                {
                    datos[i] = c;
                }
                if (i == 2)
                    datos[i] = a;
                DatosCompra o = new DatosCompra();
                dataGridView1[0, i].Value = nombre[i];
                if (i < 2)
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

        private void Compras_Load(object sender, EventArgs e)
        {

        }

        void llenarCompraLibro(double a, double b)
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    datos[i] = b;
                }
                if (i == 1)
                {
                    datos[i] = a;
                }
                DatosCompra o = new DatosCompra();
                dataGridView1[0, i].Value = nombre1[i];
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

        void llenarCompraGaso(double aux, double c, double a)
        {
            dataGridView1[0, 0].Value = a;
            dataGridView1[1, 0].Value = aux;
            dataGridView1[2, 0].Value = c;
            DatosCompra d = new DatosCompra();
            d.total = a;
            d.compra = aux;
            d.iva = c;
            DatosCompra.lista.Add(d);
        }
    }
}
