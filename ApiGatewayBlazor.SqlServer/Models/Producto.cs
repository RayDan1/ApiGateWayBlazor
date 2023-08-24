using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models;

public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = string.Empty;

    public int Precio { get; set; } = new int();

}