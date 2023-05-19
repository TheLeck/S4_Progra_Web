using S4_Progra_Web.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Progra_Web.Shared.Modelos
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public string ProveedorName { get; set; }
        [Required]
        [EmailAddress]
        public string ProveedorCorreo { get; set; }
        [Required]
        public string ProveedorTelefono { get; set; }
        public virtual ICollection<Cube> Cubos { get; set; }
    }
}
