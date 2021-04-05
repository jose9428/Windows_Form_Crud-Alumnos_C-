using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFormCrudArrayNotas.models;

namespace WFormCrudArrayNotas
{
    public partial class Form1 : Form
    {
        AlumnoDAO obj;
        int posc;
        public Form1()
        {
            InitializeComponent();
            obj = new AlumnoDAO();
            Listado();
            Habilitar(true);
        }

        public void Listado() {
            GridTable.Rows.Clear();
            foreach (Alumno a in obj.Listar()) 
            {
                GridTable.Rows.Add(a.codigo , a.nombres , a.nota1 , a.nota2 , a.notaFinal , a.mensaje);
            }
        }

        public void Limpiar() 
        {
            txtNombre.Text = string.Empty;
            txtNota1.Text = string.Empty;
            txtNota2.Text = string.Empty;
            Habilitar(true);

            GridTable.ClearSelection();
        }

        public void Habilitar(bool estado) 
        {
            BtnModificar.Enabled = !estado;
            BtnEliminar.Enabled = !estado;
            BtnAdicionar.Enabled = estado;
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Alumno a = new Alumno();
            a.nombres = txtNombre.Text.Trim();
            a.nota1 = int.Parse(txtNota1.Text.Trim());
            a.nota2 = int.Parse(txtNota2.Text.Trim());
            a.Asignar();
            obj.Adicionar(a);
            Listado();
            Limpiar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GridTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posc = e.RowIndex;

            txtNombre.Text = GridTable.Rows[posc].Cells[1].Value.ToString();
            txtNota1.Text = GridTable.Rows[posc].Cells[2].Value.ToString();
            txtNota2.Text = GridTable.Rows[posc].Cells[3].Value.ToString();

            Habilitar(false);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int indice = GridTable.CurrentRow.Index;
            
            Alumno a = new Alumno();
            a.codigo = int.Parse(GridTable.Rows[posc].Cells[0].Value.ToString());
            a.nombres = txtNombre.Text.Trim();
            a.nota1 = int.Parse(txtNota1.Text.Trim());
            a.nota2 = int.Parse(txtNota2.Text.Trim());
            obj.Modificar(a , posc);
            Listado();
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            obj.Eliminar(posc);
            Listado();
            Limpiar();
        }
    }
}
