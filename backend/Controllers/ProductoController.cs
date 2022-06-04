using AutoMapper;
using backend.AccesoDatos;
using backend.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly PruebaTecnica01Context _bd;

    public ProductoController(PruebaTecnica01Context bd) {
        _bd = bd;
    }

    [Route("[action]")]
    [HttpGet]
    public ActionResult ConsultarProductos()
    {
        List<DTOProducto> dtoproductos = new List<DTOProducto>();

        var productos = _bd.Producto.ToList();                
        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<Producto, DTOProducto>()
        ));
        dtoproductos = mapper.Map<List<Producto>, List<DTOProducto>>(productos);
        foreach(var p in dtoproductos) {
            p.NombreEstado = _bd.Estado.Find(p.CodigoEstado).NombreEstado;
        }

        return Ok(dtoproductos);        
    }

    [Route("[action]/{id?}")]
    [HttpGet]
    public ActionResult ConsultarProducto(long id)
    {
        Producto producto = default;
        DTOProducto dtoproducto = default;

        producto = _bd.Producto.Find(id);

        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<Producto, DTOProducto>()
        ));
        dtoproducto = mapper.Map<Producto, DTOProducto>(producto);
        dtoproducto.MensajeAccion = "ok-consultado";

        return Ok(dtoproducto);
    }

    [Route("[action]")]
    [HttpPost]
    public ActionResult CrearProducto([FromBody]DTOProducto dtoproducto)
    {
        Producto producto = default;

        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<DTOProducto, Producto>()
        ));
        producto = mapper.Map<DTOProducto, Producto>(dtoproducto);
        dtoproducto.MensajeAccion = "ok-creado";
        _bd.Add<Producto>(producto);
        _bd.SaveChanges();

        return Ok(dtoproducto);       
    }

    [Route("[action]")]
    [HttpPost]
    public ActionResult ActualizarProducto([FromBody]DTOProducto dtoproducto)
    {
        Producto producto = default;

        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<DTOProducto, Producto>()
        ));
        producto = mapper.Map<DTOProducto, Producto>(dtoproducto);
        dtoproducto.MensajeAccion = "ok-actualizado";
        _bd.Update<Producto>(producto);
        _bd.SaveChanges();

        return Ok(dtoproducto);       
    }

    [Route("[action]/{id?}")]
    [HttpGet]
    public ActionResult InactivarProducto(long id)
    {
        Producto producto = default;
        DTOProducto dtoproducto = default;

        producto = _bd.Producto.Find(id);
        producto.CodigoEstado = 2;
        _bd.Update<Producto>(producto);
        _bd.SaveChanges();

        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<Producto, DTOProducto>()
        ));
        dtoproducto = mapper.Map<Producto, DTOProducto>(producto);
        dtoproducto.MensajeAccion = "ok-inactivo";

        return Ok(dtoproducto);       
    }
}
