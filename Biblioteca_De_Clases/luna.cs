using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_De_Clases
{
    public class luna
    {
        [Key]
        public string codigo_luna { get; set; }
        public string nombre_luna { get; set; }
        public double distancia_km_planeta_luna { get; set; }
        public int edad_años_luna { get; set; }

        public string? planeta_lunacodigo_planeta { get; set; }
        public planeta? planeta_luna { get; set; }
    }
}
