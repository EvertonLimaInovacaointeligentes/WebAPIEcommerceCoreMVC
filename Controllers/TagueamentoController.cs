using Microsoft.AspNetCore.Mvc;
using WebAPIEcommerceCoreMVC.Model;
using WebAPIEcommerceCoreMVC.Service;

namespace WebAPIEcommerceCoreMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagueamentoController : ControllerBase
    {
        TegueamentoService srv = new TegueamentoService();
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tagueamentos tag)
        {
            bool resultado = await srv.add(tag);
            if (resultado)
            {
                return Ok("Sucesso");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
