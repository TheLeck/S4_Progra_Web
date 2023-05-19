using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Progra_Web.Shared.Modelos
{
    public class CubePedidos
    {
        [Required]
        public int PrecioVenta { get; set; }
        [Required]
        public int Cantidad { get; set; }
        // ------------------------------------------
        public int CubeId { get; set; }
        public virtual Cube CubeData { get; set; }
        //
        public int PedidosId { get; set; }
        public virtual Pedidos PedidosData { get; set; }
    }
}
