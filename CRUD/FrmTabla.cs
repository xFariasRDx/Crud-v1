using CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FrmTabla : Form
    {
        public int? Id;
        Datos datos = null;
        public FrmTabla(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (Id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            using (TestingEntities db = new TestingEntities())
            {
                datos=db.Datos.Find(Id);
                txtname.Text = datos.Name;
                txtLastName.Text = datos.Apellido;
                dtpFechaNacimiento.Value = datos.Fecha_de_nacimiento.Value;
                txtGenres.Text = datos.Genero;
                txtMail.Text = datos.Correo_Electronico;
                txtDiretion.Text = datos.Direccion;
                txtEstadoCivil.Text = datos.Estado_Civil;
                txtCell.Text = datos.Movil;
                txtPhone.Text = datos.Telefono;

                db.SaveChanges();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (TestingEntities db = new TestingEntities())
            {
                if(Id == null)
                     datos = new Datos();
                datos.Name = txtname.Text;
                datos.Apellido = txtLastName.Text;
                datos.Fecha_de_nacimiento = dtpFechaNacimiento.Value;
                datos.Genero = txtGenres.Text;
                datos.Correo_Electronico = txtMail.Text;
                datos.Direccion = txtDiretion.Text;
                datos.Estado_Civil = txtEstadoCivil.Text;
                datos.Movil = txtCell.Text;
                datos.Telefono = txtPhone.Text;
                if (Id == null)
                    db.Datos.Add(datos);
                else
                {
                    db.Entry(datos).State = System.Data.Entity.EntityState.Modified;
                }

                //db.Datos.Add(datos);
                db.SaveChanges();
                
                this.Close(); 
            }
        }
    }
}   
