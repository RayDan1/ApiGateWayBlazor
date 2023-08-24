using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models;

public partial class Venta
{
    [Key]
    public int IdVenta { get; set; }

    public int IdProducto { get; set; } = new int();

    public int IdCliente { get; set; } = new int();

    public int Cantidad { get; set; } = new int();
}