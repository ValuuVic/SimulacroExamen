using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacroExamen
{
    public partial class TallerIngreso: Form
    {
        List <Taller> talleres = new List <Taller> ();
        public TallerIngreso()
        {
            InitializeComponent();
        }
        private void mostrar()
        {
            TallerArchivo tallerArchivo = new TallerArchivo();
            talleres = tallerArchivo.Leer("../../Talleres.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = talleres;
            dataGridView1.Refresh();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Taller taller = new Taller();
            taller.Codigo = textBoxCodigo.Text;
            taller.nombreTaller = textBoxNombre.Text;
            taller.costo = Convert.ToDecimal(textBoxCosto.Text);
            talleres.Add(taller);
            TallerArchivo archivo = new TallerArchivo();
            archivo.guardar("../../Talleres.json", talleres);
            mostrar();

        }

        private void TallerIngreso_Load(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
