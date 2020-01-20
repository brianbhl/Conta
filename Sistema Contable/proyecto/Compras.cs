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
        public Compras()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Compra")
            {
                 a = double.Parse(textBox1.Text);
                 b = a*0.87;
                 c = a * 0.13;
                llenar(a, b, c);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DatosCompra d = new DatosCompra();
            d.total = a;
            d.compra = b;
            d.iva =c;
            DatosCompra.lista.Add(d);
            //l.Show();
            this.Close();
        }
        void grilla( DataGridView dgv) {
            dgv.ColumnCount = 3;
            dgv.RowCount = 1;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

        void llenar(double a, double b, double c){
            dataGridView1[0, 0].Value = a;
            dataGridView1[1, 0].Value = b;
            dataGridView1[2, 0].Value = c;
        }
    }
}
