using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidoDetalle
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdPedido { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }
        
        public decimal PrecioUnitario {  get; set; }

        public decimal SubTotal { get; set; }

        public string NombreProducto { get; set; }

        public string Color {  get; set; }

    }
}
