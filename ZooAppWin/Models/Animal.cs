using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAppWin.Models
{
    internal class Animal
    {
        public int animalID { get; set; }
        public string nombre { get; set; }
        public string especie { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public DateTime fechaLlegada { get; set; }
        public string habitat { get; set; }

    }
}
