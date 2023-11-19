using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RubiconTask.Base.Controllers
{
    [Route("api")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, ILogger<BaseController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }


    }
}
