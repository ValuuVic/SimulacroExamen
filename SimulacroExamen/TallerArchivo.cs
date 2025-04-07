﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimulacroExamen
{
    class TallerArchivo
    {
        public void guardar(String archivo, List<Taller> talleres)
        {
            string json = JsonConvert.SerializeObject(talleres);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<Taller> Leer(string archivo)
        {
            List<Taller> lista = new List<Taller>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Taller>>(json);
            return lista;
        }
    }
}
