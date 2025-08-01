using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime FechaPedido { get; set; }

        public int IdCliente { get; set; }

        public string Estado { get; set; }

        public decimal? TotalPedido { get; set; }

        public int TotalUnidades { get; set; }
        public string? Cliente { get; set; }
        public string? DireccionEntrega { get; set; }

        public List<PedidoDetalle> Detalles { get; set; }
    }
}
