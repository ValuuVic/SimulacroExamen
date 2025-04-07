using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimulacroExamen
{
    class InscripcionArchivo
    {
        public void guardar(String archivo, List<InscripcionTaller> inscripciones)
        {
            string json = JsonConvert.SerializeObject(inscripciones);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<InscripcionTaller> Leer(string archivo)
        {
            List<InscripcionTaller> lista = new List<InscripcionTaller>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<InscripcionTaller>>(json);
            return lista;
        }
    }
}
