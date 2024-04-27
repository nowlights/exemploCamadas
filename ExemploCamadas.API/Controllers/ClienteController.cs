using ExemploCamadas.Application.Modules.Cliente.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[Route("clientes")]
public class ClienteController(
    IClienteService _clienteService
    ) : Controller
{
    [HttpGet("lista")]
    public async Task<IActionResult> GetClientes()
        => Ok(await _clienteService.GetList());
}