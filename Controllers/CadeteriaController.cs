using Microsoft.AspNetCore.Mvc;
using spaceCadeteria;
using spaceInforme;
using spacePedido;
namespace tl2_tp4_2023_AlarconMario.Controllers
{
    [ApiController]
    [Route("cadeteria")]
    public class CadeteriaController : ControllerBase
    {
        private Cadeteria cadeteria;
        private readonly ILogger<CadeteriaController> _logger;
        public CadeteriaController(ILogger<CadeteriaController> logger)
        {
            _logger = logger;
            cadeteria = Cadeteria.Instance;
        }
       
        [HttpGet("pedidos")]
        public IActionResult listapedidos()
        {
            return Ok(cadeteria.Pedidos);
        }

        [HttpGet("cadete")]
        public IActionResult listaCadetes()
        {
            return Ok(cadeteria.Cadetes);
        }

        [HttpGet("informe")]
        public IActionResult GetInforme()
        {
            Informe inf = new Informe(cadeteria.Pedidos, cadeteria.Cadetes);
            if(inf.TotalDePedidos > 0)
            {
                return Ok(inf);
            }
            else
            {
                return StatusCode(500, "Ha ocurrido un error agregando el pedido.");
            }
            
        }

        [HttpPost("agregar_pedido")]
        public IActionResult crearPedido()
        {
            int cantPedidos = cadeteria.Pedidos.Count;
            cadeteria.AgregarPeido();
            if (cadeteria.Pedidos.Count == cantPedidos + 1)
            {
                return Ok("Pedido agregado correctamente");
            }
            else
            {
                return StatusCode(500, "Ha ocurrido un error agregando el pedido.");
            }
        }

        [HttpPut("asignar_pedido")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            if(idPedido <= 0 || idPedido > cadeteria.Pedidos.Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(idCadete <= 0 || idCadete > cadeteria.Cadetes.Count)
            {
                return BadRequest("Parámetro idCadete inválido.");
            }
            else
            {
                cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                return Ok($"El pedido Nro: {idPedido} fue asignado al cadete Id: {idCadete}");
            }    
        }

        [HttpPut("cambiar_estado")]
        public IActionResult CambiarEstadoPedido(int idPedido,int NuevoEstado)
        {
            int cantidadElementos = Enum.GetValues(typeof(Pedido.estadoPedido)).Length;
             if(idPedido <= 0 || idPedido > cadeteria.Pedidos.Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(NuevoEstado < 0 || NuevoEstado >= cantidadElementos)
            {
                return BadRequest("Parámetro del NuevoEstado inválido.");
            }
            else
            {
                cadeteria.cambiarEstado(idPedido, NuevoEstado);
                return Ok($"El estado del pedido nro: {idPedido} cambio a {(Pedido.estadoPedido)NuevoEstado}");
            }
        }

        [HttpPut ("reasignar_pedido")] 
        public IActionResult CambiarCadetePedido(int idPedido,int idNuevoCadete)
        {
            if(idPedido <= 0 || idPedido > cadeteria.pedidosAsignado().Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(idNuevoCadete <= 0 || idNuevoCadete > cadeteria.Cadetes.Count)
            {
                return BadRequest("Parámetro idCadete inválido.");
            }

            else
            {
                var pedidoAsignado = cadeteria.pedidosAsignado().FirstOrDefault(p => p.Nro == idPedido);
                if (pedidoAsignado != null)
                {
                    cadeteria.reasignarPedido(idPedido, idNuevoCadete);
                    return Ok($"El pedido Nro: {idPedido} fue Reasignado al cadete Id: {idNuevoCadete}");
                }
                else
                {
                    return BadRequest($"El pedido Nro: {idPedido} no está asignado a ningún cadete y no es posible reasignarlo.");
                }
            }  
        }
    }
}