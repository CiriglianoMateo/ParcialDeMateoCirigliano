using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esferas.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
                Form2 frm = new Form2() { Text = "Nueva Esfera" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

            }
    }
}
       
