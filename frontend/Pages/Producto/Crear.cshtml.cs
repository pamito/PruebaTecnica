using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using frontend.Data;

namespace frontend.Pages.Producto;

public class CrearModel : PageModel
{
    public DTOProducto producto { get; set; }

    private HttpClient client;

    private IConfiguration _conf;

    public CrearModel(IConfiguration conf) {
        client = new HttpClient();
        _conf = conf;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostCrear(DTOProducto dtoproducto)
    {
        dtoproducto.Descripcion = dtoproducto.Nombre;
        dtoproducto.CodigoEstado = 1;
        dtoproducto.FechaCreacion = DateTime.Now;
        dtoproducto.FechaModificacion = DateTime.Now;
        HttpResponseMessage respuestaHttp = await client.PostAsJsonAsync<DTOProducto>($"{_conf.GetValue<string>("servicios:urlBase")}/Producto/CrearProducto",dtoproducto);
        if(respuestaHttp.IsSuccessStatusCode) {
            dtoproducto = await respuestaHttp.Content.ReadFromJsonAsync<DTOProducto>();            
        }
        return Redirect($"/Producto/Consultar");
    }
}
