using Microsoft.AspNetCore.Mvc;

namespace ClientApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public void NewClient()
        {
            
        }
    }
}