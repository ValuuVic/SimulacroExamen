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
    public partial class Inscripcion: Form
    {
        List<InscripcionTaller> inscripciones = new List<InscripcionTaller> ();
        public Inscripcion()
        {
            InitializeComponent();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mostrar()
        {
            InscripcionArchivo inscripcionArchivo = new InscripcionArchivo();
            inscripciones = inscripcionArchivo.Leer("../../Inscripciones.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inscripciones;
            dataGridView1.Refresh();
        }

        private void buttonInscripcion_Click(object sender, EventArgs e)
        {
            InscripcionTaller inscripcion = new InscripcionTaller();
            inscripcion.DPI = comboBox1.SelectedValue.ToString();
            inscripcion.Codigo = comboBox2.SelectedValue.ToString();
            inscripcion.inscripcion = DateTime.Now;
            inscripciones.Add(inscripcion);
            InscripcionArchivo inscripcionArchivo = new InscripcionArchivo();
            inscripcionArchivo.guardar("../../Inscripciones.json", inscripciones);
            mostrar();

        }

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            mostrar();
            List<Alumno> alumnos = new List<Alumno>();
            AlumnoArchivo alumnoArchivo = new AlumnoArchivo();
            alumnos = alumnoArchivo.Leer("../../Alumnos.json");
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "DPI";
            comboBox1.DataSource = alumnos;
            List<Taller> talleres = new List<Taller>();
            TallerArchivo tallerArchivo = new TallerArchivo();
            talleres = tallerArchivo.Leer("../../Talleres.json");
            comboBox2.DisplayMember = "nombreTaller";
            comboBox2.ValueMember = "Codigo";
            comboBox2.DataSource = talleres;
        }
    }
}
