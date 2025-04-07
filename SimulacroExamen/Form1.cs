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
    public partial class Form1: Form
    {
        List<Alumno> alumnos = new List<Alumno>();
        public Form1()
        {
            InitializeComponent();
        }
        public void mostrar()
        {
            AlumnoArchivo alumnoArchivo = new AlumnoArchivo();
            alumnos = alumnoArchivo.Leer("../../Alumnos.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alumnos;
            dataGridView1.Refresh();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.nombre = textBoxNombre.Text;
            alumno.DPI = textBoxDPI.Text;
            alumno.direccion = textBoxDireccion.Text;
            alumnos.Add(alumno);
            AlumnoArchivo alumnoArchivo = new AlumnoArchivo();
            alumnoArchivo.guardar("../../Alumnos.json", alumnos);
            mostrar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTaller_Click(object sender, EventArgs e)
        {
            TallerIngreso tallerIngreso = new TallerIngreso();
            tallerIngreso.Show();
        }

        private void buttonInscripcion_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Show();
        }
    }
}
