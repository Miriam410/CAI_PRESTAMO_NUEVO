using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLayer_Entidades;
using NLayer_Negocio;
using NLayer_Negocio.ValidacionHelper;

namespace NLayer_Formulario
{
    public partial class Form1 : Form
    {
        private PrestamoServicio _prestamoServicio;
        private List<Prestamo> _prestamoServ;
        private TipoPrestamoServicio _tipoPrestamoServicio;
        private List<TipoPrestamo> _tipoPrestamoServ;
        public Form1()
        {
            this._prestamoServicio=new PrestamoServicio();
            this._tipoPrestamoServicio = new TipoPrestamoServicio();

            InitializeComponent();

            this._prestamoServ = this._prestamoServicio.TraerTodos();
            this._tipoPrestamoServ = this._tipoPrestamoServicio.TraerTodos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lst_TipoPrestamo.DataSource = this._tipoPrestamoServ = this._tipoPrestamoServicio.TraerTodos();
        }

        private void lst_TipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_TipoPrestamo.Items.Count == 0)
            {
                MessageBox.Show("No hay items en la lista", "Error");
            }
            else if (lst_TipoPrestamo.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un item", "Error");
            }
            else
            {
                TipoPrestamo tipoPrestamo =new TipoPrestamo();
                tipoPrestamo.Linea = txt_Linea.Text;
                tipoPrestamo.Tna = Convert.ToDouble(txt_Tna.Text);

                bool Flag = Validacion.Validar(txt_Monto.Text, txt_Plazo.Text);
                if (Flag)
                {
                    txt_Monto.Enabled = true;
                    double monto = Convert.ToDouble(txt_Monto.Text);
                    txt_Plazo.Enabled = true;
                    int plazo = Convert.ToInt32(txt_Plazo.Text);
                }

                this._tipoPrestamoServicio.Insertar(tipoPrestamo);
                this._tipoPrestamoServ = this._tipoPrestamoServicio.TraerTodos();
            }
        }
        private void btn_Simular_Click(object sender, EventArgs e)
        {
            
            if (lst_TipoPrestamo.Items.Count == 0)
            {
                MessageBox.Show("No hay items en la lista", "Error");
            }
            else if (lst_TipoPrestamo.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un item", "Error");
            }
            else
            {
                Prestamo prestamo = new Prestamo();
                prestamo.Monto = Convert.ToDouble(txt_Monto.Text);

                double CC = prestamo.CuotaCapital();
                CC = Convert.ToDouble(txt_CuotaCapital.Text);

                double CI = prestamo.CuotaInteres();
                CI = Convert.ToDouble(txt_CuotaInteres.Text);
               
                this._prestamoServicio.Insertar(prestamo);
                this._prestamoServ = this._prestamoServicio.TraerTodos();

            }
          
        }

       
    }
}
