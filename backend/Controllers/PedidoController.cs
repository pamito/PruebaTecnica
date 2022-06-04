using AutoMapper;
using backend.AccesoDatos;
using backend.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PruebaTecnica01Context _bd;

    public PedidoController(PruebaTecnica01Context bd) {
        _bd = bd;
    }

    [Route("[action]")]
    [HttpGet]
    public ActionResult ConsultarPedidos()
    {
        List<DTOPedido> dtopedidos = new List<DTOPedido>();

        var pedidos = _bd.Pedido.ToList();
        var mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<Pedido, DTOPedido>()
        ));        
        dtopedidos = mapper.Map<List<Pedido>, List<DTOPedido>>(pedidos);
        foreach (var p in dtopedidos)
        {
            var cliente = _bd.Cliente.Find(p.IdCliente);
            p.Nit = cliente.Nit;
            p.NombreCliente = cliente.Nombres;
        }

        return Ok(dtopedidos);        
    }
}
