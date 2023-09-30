using Microsoft.AspNetCore.Mvc;
using spaceCadeteria;
using spaceInforme;
using spacePedido;
namespace tl2_tp4_2023_AlarconMario.Controllers
{
    [ApiController]
    [Route("_cadeteria")]
    public class CadeteriaController : ControllerBase
    {
        private Cadeteria _cadeteria;
        private readonly ILogger<CadeteriaController> _logger;
        public CadeteriaController(ILogger<CadeteriaController> logger)
        {
            _logger = logger;
            _cadeteria = Cadeteria.Instance;
        }
       
        [HttpGet("pedidos")]
        public IActionResult listapedidos()
        {
            return Ok(_cadeteria.Pedidos);
        }

        [HttpGet("cadete")]
        public IActionResult listaCadetes()
        {
            return Ok(_cadeteria.Cadetes);
        }

        [HttpGet("informe")]
        public IActionResult GetInforme()
        {
            Informe inf = new Informe(_cadeteria.Pedidos, _cadeteria.Cadetes);
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
            int cantPedidos = _cadeteria.Pedidos.Count;
            _cadeteria.AgregarPedido();
            if (_cadeteria.Pedidos.Count == cantPedidos + 1)
            {
                _cadeteria.accesoADatosPedidos.guardar(_cadeteria.Pedidos);
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
            if(idPedido <= 0 || idPedido > _cadeteria.Pedidos.Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(idCadete <= 0 || idCadete > _cadeteria.Cadetes.Count)
            {
                return BadRequest("Parámetro idCadete inválido.");
            }
            else
            {
                var pedidoAsignado = _cadeteria.pedidosSinAsignar().FirstOrDefault(p => p.Nro == idPedido);
                if(pedidoAsignado != null)
                {
                    _cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                    _cadeteria.accesoADatosPedidos.guardar(_cadeteria.Pedidos);
                    return Ok($"El pedido Nro: {idPedido} fue asignado al cadete Id: {idCadete}");
                }    
                else
                {
                    return BadRequest($"El pedido Nro: {idPedido} ya esta asignado a un cadete, no es posible asignarlo.");
                }
            }    
        }

        [HttpPut("cambiar_estado")]
        public IActionResult CambiarEstadoPedido(int idPedido,int NuevoEstado)
        {
            int cantidadElementos = Enum.GetValues(typeof(Pedido.estadoPedido)).Length;
             if(idPedido <= 0 || idPedido > _cadeteria.Pedidos.Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(NuevoEstado < 0 || NuevoEstado >= cantidadElementos)
            {
                return BadRequest("Parámetro del NuevoEstado inválido.");
            }
            else
            {
                _cadeteria.cambiarEstado(idPedido, NuevoEstado);
                _cadeteria.accesoADatosPedidos.guardar(_cadeteria.Pedidos);
                return Ok($"El estado del pedido nro: {idPedido} cambio a {(Pedido.estadoPedido)NuevoEstado}");
            }
        }

        [HttpPut ("reasignar_pedido")] 
        public IActionResult CambiarCadetePedido(int idPedido,int idNuevoCadete)
        {
            if(idPedido <= 0 || idPedido > _cadeteria.Pedidos.Count)
            {
                return BadRequest("Parámetro idPedido inválido.");
            }
            else if(idNuevoCadete <= 0 || idNuevoCadete > _cadeteria.Cadetes.Count)
            {
                return BadRequest("Parámetro idCadete inválido.");
            }

            else
            {
                var pedidoAsignado = _cadeteria.pedidosAsignado().FirstOrDefault(p => p.Nro == idPedido);
                if (pedidoAsignado != null)
                {
                    _cadeteria.reasignarPedido(idPedido, idNuevoCadete);
                    _cadeteria.accesoADatosPedidos.guardar(_cadeteria.Pedidos);
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