using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using frontend.Data;
using AutoMapper;

namespace frontend.Pages.Producto;

public class EditarModel : PageModel
{
    [BindProperty]
    public DTOProducto producto { get; set; }

    private HttpClient client;

    private IConfiguration _conf;

    public EditarModel(IConfiguration conf) {
        client = new HttpClient();
        _conf = conf;
    }

    public async Task OnGet(long IdProducto)
    {
        producto = new DTOProducto();

        HttpResponseMessage respuestaHttp = await client.GetAsync($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/ConsultarProducto/{IdProducto}");
        if(respuestaHttp.IsSuccessStatusCode) {
            producto = await respuestaHttp.Content.ReadFromJsonAsync<DTOProducto>();            
        }
    }

    public async Task<IActionResult> OnPostEditar(DTOProducto productoActualizar)
    {
        DTOProducto productoActual = new DTOProducto();

        HttpResponseMessage respuestaHttp = await client.GetAsync($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/ConsultarProducto/{producto.IdProducto}");
        if(respuestaHttp.IsSuccessStatusCode) {
            productoActual = await respuestaHttp.Content.ReadFromJsonAsync<DTOProducto>();
            productoActual.Eanproducto = productoActualizar.Eanproducto;
            productoActual.Nombre = productoActualizar.Nombre;
            productoActual.Precio = productoActualizar.Precio;
            respuestaHttp = await client.PostAsJsonAsync<DTOProducto>($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/ActualizarProducto",productoActual);
            if(respuestaHttp.IsSuccessStatusCode) {
                productoActual = await respuestaHttp.Content.ReadFromJsonAsync<DTOProducto>();
            }
        }
        return Redirect($"/Producto/Consultar");
    }
}
