using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RemitoDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int RemitoId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public string NombreProducto { get; set; }

        public string Color { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal SubTotal { get; set; }
    }
}
