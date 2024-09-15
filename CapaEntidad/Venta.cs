using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int idVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; }
        public decimal MontoCambio { get; }
        public decimal MontoTotal { get; }
        public List<Detalle_Venta> oDetalle_Ventas { get; set; }
        public string FechaRegistro { get; }
    }
}
