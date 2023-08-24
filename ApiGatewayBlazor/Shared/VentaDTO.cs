using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGatewayBlazor.Shared
{
    public class VentaDTO
    {

        public int IdVenta { get; set; }

        public int IdProducto { get; set; } = new int();

        public int IdCliente { get; set; } = new int();

        public int Cantidad { get; set; } = new int();
    }
}
