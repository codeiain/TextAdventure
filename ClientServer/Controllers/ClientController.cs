using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers
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