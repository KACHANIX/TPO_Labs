using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TPO_Lab3_Backend.Entities;
using TPO_Lab3_Backend.Services;

namespace TPO_Lab3_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlmsController : ControllerBase
    {
        private readonly AlmsgivingService _almsgivingService;

        public AlmsController(AlmsgivingService almsgivingService)
        {
            _almsgivingService = almsgivingService;
        }

        [HttpGet("all")]
        public List<AlmsgivingsEntity> GetAllAlmsgivings()
        {
            return _almsgivingService.GetAll();
        }

        [HttpPost("search")]
        public List<AlmsgivingsEntity> SearchAlmsgivings(StringCarrier carrier)
        {
            return _almsgivingService.SearchAlms(carrier.SearchString);
        }

        [HttpGet("get-almsgiving/{id}")]
        public AlmsgivingEntity GetAlmsgiving(int id)
        {
            return _almsgivingService.GetAlms(id);
        }

        [HttpPost("add")]
        public bool AddAlmsgiving(AlmsgivingEntity alms)
        {
            return _almsgivingService.AddAlms(alms);
        }

        [HttpGet("delete/{id}")]
        public bool DeleteAlmsgiving(int id)
        {
            return _almsgivingService.DeleteAlms(id);
        }
    }
}