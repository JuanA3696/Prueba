using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prueba.Controlador;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClsCrud Crud = new ClsCrud();
        private void btbInser_Click(object sender, EventArgs e)
        {
            Crud.Insert(txtname.Text,txtlastname.Text);
            Mostrar();
            MessageBox.Show("Se inserto");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void Mostrar()
        {

            dtgDATO.DataSource = Crud.Retornar();
            dtgDATO.Columns[0].Visible = false;
        }
        string Id;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Crud.Update(int.Parse(Id),txtname.Text,txtlastname.Text);
            Mostrar();
            MessageBox.Show("Editado");
        }
        private void Edit()
        {
            if (dtgDATO.SelectedRows.Count == 1)
            {
                Id = dtgDATO.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = dtgDATO.CurrentRow.Cells[1].Value.ToString();
                txtlastname.Text = dtgDATO.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dtgDATO_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtlastname.Clear();
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            Crud.Drop(int.Parse(Id));
            Mostrar();
        }

        private void dtgDATO_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }
    }
}
