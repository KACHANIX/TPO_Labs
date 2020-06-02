using Microsoft.AspNetCore.Mvc;
using TPO_Lab3_Backend.Entities;
using TPO_Lab3_Backend.Services;

namespace TPO_Lab3_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BearerController : ControllerBase
    {
        private readonly BearerService _bearerService;

        public BearerController(BearerService bearerService)
        {
            _bearerService = bearerService;
        }

        [HttpGet("is-free/{nickname}")]
        public bool IsNicknameFree(string nickname)
        {
            return _bearerService.CheckNicknameIsFree(nickname);
        }

        [HttpGet("get-profile/{bearerId}")]
        public BearerProfile GetBearerProfile(int bearerId)
        { 
            return _bearerService.GetBearerProfile(bearerId);
        }

        [HttpPost("add-bearer")]
        public bool RegisterBearer(BearerInEntity bearer)
        {
            return _bearerService.RegisterBearer(bearer);
        }

        [HttpPost("auth")]
        public bool Authenticate(BearerInEntity bearer)
        {
            return _bearerService.AutheticateBearer(bearer);
        }
    }
}