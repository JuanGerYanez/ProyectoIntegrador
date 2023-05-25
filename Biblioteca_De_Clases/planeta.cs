using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_De_Clases
{
    public class planeta
    {
        [Key]
        public string codigo_planeta { get; set; }
        public string nombre_planeta { get; set; }
        public double volumen_planeta { get; set; }
        public double densidad_planeta { get; set; }
        public int edad_años_planeta { get; set; }

        public string? galaxia_planetacodigo_galaxia { get; set; }
        public galaxia? galaxia_planeta { get; set; }
        public List<luna>? lunas_planeta { get; set; }
    }
}