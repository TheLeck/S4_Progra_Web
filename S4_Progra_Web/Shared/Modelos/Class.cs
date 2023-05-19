using S4_Progra_Web.Shared.Modelos;
using System.ComponentModel.DataAnnotations;

namespace S4_Progra_Web.Shared.Modelos
{
    // nombre, modelo, precio, cantidad en stock, proveedor,
    public class Cube
    {
        public int id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int ProveedorId { get; set; }
        public virtual Proveedor ProveedorData { get; set; }
        //---------------------------------------------------

    }
}
