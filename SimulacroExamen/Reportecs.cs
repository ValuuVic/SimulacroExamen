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
    public partial class Reportecs: Form
    {
        List<Alumno> alumnos = new List<Alumno>();
        List<Taller> talleres = new List<Taller>();
        List<InscripcionTaller> inscripciones = new List<InscripcionTaller>();
        List<Reporte> reportes = new List<Reporte>();
        public Reportecs()
        {
            InitializeComponent();
        }
        private void CargarAlumnos()
        {
            AlumnoArchivo alumnoArchivo = new AlumnoArchivo();
            alumnos = alumnoArchivo.Leer("../../Alumnos.json");
        }
        private void CargarTaller()
        {
            TallerArchivo tallerArchivo = new TallerArchivo();
            talleres = tallerArchivo.Leer("../../Talleres.json");
        }
        private void CargarInscripcion()
        {
            InscripcionArchivo inscripcionArchivo = new InscripcionArchivo();
            inscripciones = inscripcionArchivo.Leer("../../Inscripciones.json");
        }
        private void CrearReporte()
        {
            reportes.Clear();
            foreach(var alumno in alumnos)
            {
                foreach(var taller in talleres)
                {
                    foreach(var InscripcionTaller in inscripciones)
                    {
                        if((alumno.DPI== InscripcionTaller.DPI) && (taller.Codigo == InscripcionTaller.Codigo))
                        {
                            Reporte reporte = new Reporte();
                            reporte.nombre = alumno.nombre;
                            reporte.taller = taller.nombreTaller;
                            reportes.Add(reporte);
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            CrearReporte();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }

        private void Reportecs_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            CargarTaller();
            CargarInscripcion();
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            CrearReporte();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes.OrderBy(a => a.nombre).ToList();
            dataGridView1.Refresh();

        }
    }
}
