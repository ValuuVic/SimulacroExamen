using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimulacroExamen
{
    class AlumnoArchivo
    {
        public void guardar(String archivo, List<Alumno> alumnos)
        {
            string json = JsonConvert.SerializeObject(alumnos);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<Alumno> Leer(string archivo)
        {
            List<Alumno> lista = new List<Alumno>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Alumno>>(json);
            return lista;
        }
    }
}
