using Microsoft.AspNetCore.Mvc;
using PruebaClaro.Modelos;
using PruebaClaro.Solicitudes;
using System.ComponentModel.DataAnnotations;

namespace PruebaClaro.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : Controller
    {
        [HttpGet("Get/cliente")]
        public IEnumerable<Cliente> Get()
        {
            return UserLogistica.GetClientes();
        }

        [HttpGet("Get/{id}")]
        public IEnumerable<Cliente> GetById([Required]int id) 
        {
        return UserLogistica.GetClienteById(id);
        }

        [HttpGet("Get/cliente/{nombre}")]
        public IEnumerable<Cliente> GetById([Required] string nombre)
        {
            return UserLogistica.GetClienteByName(nombre);
        }

        [HttpPost("post/cliente")]
        public ActionResult GuardarCliente([Required]string nombre,[Required]string clave)
        {
            Cliente cliente = new Cliente() {
            nombre = nombre,
            clave = clave
            };


        return UserLogistica.GuardarCliente(cliente);
        }
    }
}
