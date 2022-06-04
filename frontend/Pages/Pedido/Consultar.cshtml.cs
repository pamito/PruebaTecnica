using frontend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages.Pedido;

public class ConsultarModel : PageModel
{
    public List<DTOPedido> pedidos { get; set; }
    private HttpClient client;

    private IConfiguration _conf;

    public ConsultarModel(IConfiguration conf) {
        client = new HttpClient();
        _conf = conf;
    }

    public async Task OnGet()
    {
        pedidos = new List<DTOPedido>();

        HttpResponseMessage respuestaHttp = await client.GetAsync($"{_conf.GetValue<string>("servicios:urlBase")}/Pedido/ConsultarPedidos");
        if(respuestaHttp.IsSuccessStatusCode) {
            pedidos = await respuestaHttp.Content.ReadFromJsonAsync<List<DTOPedido>>();
        }
    }
}
