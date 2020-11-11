using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Diğer controller bundan türüyor. Bu Controllerda "ControllerBase"'dan türüyor ve route işlemlerini buradan sağlıyoruz.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
       
    }
}
