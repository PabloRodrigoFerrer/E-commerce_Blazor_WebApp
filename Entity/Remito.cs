using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Remito
    {
        public Remito() 
        {
            Detalles = new List<RemitoDetalle>();
        }

        [Key]
        public int IdRemito { get; set; }

        public DateTime FechaRemito { get; set; }

        public int IdCliente { get; set; }

        public int IdPedido { get; set; }

        public Decimal TotalRemito { get; set; }

        public List<RemitoDetalle> Detalles { get; set;}
        
    }
}
