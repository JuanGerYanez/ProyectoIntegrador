using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_De_Clases
{
    public class galaxia
    {
        [Key]
        public string codigo_galaxia { get; set; }
        public string nombre_galaxia { get; set; }

        public int edad_millones_años_galaxia { get; set; }
        public List<planeta>? planetas_galaxia { get; set; }
    }
}
