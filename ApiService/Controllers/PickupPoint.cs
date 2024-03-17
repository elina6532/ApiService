using ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PickupPointController : ControllerBase
    {
        private readonly SkyMarketContext _context; // Замени на имя контекста базы данных

        public PickupPointController(SkyMarketContext context) // Имя конструктора и параметра может отличаться в зависимости от проекта
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Pickuppoint> pickuppoints = _context.Pickuppoints.ToList(); // Получаем список всех продуктов из базы данных

            if (pickuppoints == null || pickuppoints.Count == 0)
            {
                return NotFound(); // Возвращаем NotFound, если список пуст
            }

            return Ok(pickuppoints); // Возвращаем список продуктов в случае успеха
        }
    }
}
