
using ApiGatewayBlazor.Shared;
using System.Text;
using System.Text.Json;

namespace ApiGatewayBlazor.Client.Pages
{
    public partial class Index
    {
        private async Task Comprar (int Idc,int Idp, int Can) {
            VentaDTO venta = new VentaDTO()
            {
                IdVenta = 0,
                IdCliente = Idc,
                IdProducto = Idp,
                Cantidad = Can
            };
            HttpClient client = new HttpClient();
            try{ 
                var v=JsonSerializer.Serialize(venta);
                var enviar=new StringContent(v, Encoding.UTF8, "application/json"); 
                var regresa=client.PostAsync("https://localhost:7152/api/Ventas", enviar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
    }
}
