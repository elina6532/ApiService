using ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly SkyMarketContext _context; // Поменяй на имя контекста базы данных

        public ClientController(SkyMarketContext context) // Имя конструктора и параметра может отличаться в зависимости от проекта
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            List<Client> clients = _context.Clients.ToList(); // Получаем список всех клиентов из базы данных

            if (clients.Count == 0)
            {
                return NotFound("No clients found"); // Возвращаем NotFound с сообщением о пустом списке клиентов
            }

            return Ok(clients); // Возвращаем список клиентов в случае успеха
        }
    }
}
