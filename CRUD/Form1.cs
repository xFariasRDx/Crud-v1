using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.Models;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        #region HELPER
        private void Refrescar()
        {
            using (TestingEntities db = new TestingEntities())
            {
                var lista = from d in db.Datos
                            select d;
                dataGridView1.DataSource = lista.ToList();
            }

        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmTabla frmTabla = new FrmTabla();
            frmTabla.ShowDialog();
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                FrmTabla frmTabla = new FrmTabla(Id);
                frmTabla.ShowDialog();
                Refrescar();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                using (TestingEntities db = new TestingEntities())
                {
                    Datos datos = db.Datos.Find(Id);
                    db.Datos.Remove(datos);

                    db.SaveChanges();
                }
                Refrescar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
