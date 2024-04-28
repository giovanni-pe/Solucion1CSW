using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string Habitat { get; set; }
    }
}
