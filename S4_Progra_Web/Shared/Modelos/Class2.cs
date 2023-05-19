using S4_Progra_Web.Shared.Modelos;
using S4_Progra_Web.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace S4_Progra_Web.Shared.Modelos
{
    public class Pedidos
    {
        //nombre, dirección de envío, fecha de
        //pedido, cantidad y modelo de cubos solicitados
        public int PedidosId { get; set; }
        [Required]
        public string PedidosDireccion { get; set;}
        [Required]
        public DateTime PedidosFecha { get; set;}
        [Required]
        [Range(0, 3)] // 0 - Pedido; 1 - Pagado; 2 - Enviado; 3 - Recibido;
        public int PedidosEstado { get; set; }
        // -----------------------------
        public virtual ICollection<CubePedidos> OrderDetails { get; set; }
    }
}
