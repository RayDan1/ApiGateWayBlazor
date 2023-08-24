using System;
using System.Collections.Generic;

namespace ApiGatewayBlazor.SqlServer.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; }=string.Empty;
}