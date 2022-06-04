using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using frontend.Data;

namespace frontend.Pages.Producto;

public class ConsultarModel : PageModel
{
    public List<DTOProducto> productos { get; set; }

    private HttpClient client;

    private IConfiguration _conf;

    public ConsultarModel(IConfiguration conf) {
        client = new HttpClient();
        _conf = conf;
    }

    public async Task OnGet()
    {
        productos = new List<DTOProducto>();

        HttpResponseMessage respuestaHttp = await client.GetAsync($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/ConsultarProductos");
        if(respuestaHttp.IsSuccessStatusCode) {
            productos = await respuestaHttp.Content.ReadFromJsonAsync<List<DTOProducto>>();
        }
    }

    public IActionResult OnPostEditar(long IdProducto)
    {
        return Redirect($"/Producto/Editar/{IdProducto}");
    }

    public async Task<IActionResult> OnPostInactivar(long IdProducto)
    {
        HttpResponseMessage respuestaHttp = await client.GetAsync($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/InactivarProducto/{IdProducto}");
        if(respuestaHttp.IsSuccessStatusCode) {
            await respuestaHttp.Content.ReadFromJsonAsync<DTOProducto>();
        }
        return Redirect($"/Producto/Consultar");
    }

    public IActionResult OnPostNuevo()
    {
        return Redirect($"/Producto/Crear");
    }
}
