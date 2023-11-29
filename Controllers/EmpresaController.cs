using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIEcommerceCoreMVC.Model;
using WebAPIEcommerceCoreMVC.Service;

namespace WebAPIEcommerceCoreMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        EmpresaService srv = new EmpresaService();
       
        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Empresa> emps = new List<Empresa>();
            //emps = srv.empresas().Result;
            emps = await Task.Run(() => srv.empresas());
            if (emps.Count() > 0)
            {
                return Ok(emps);
            }
            else
            {
                return BadRequest(emps);
            }

        }

        // GET api/<EmpresaController>/5 teste  rer
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            Empresa emp = new Empresa();

            //emp = srv.empresa(id);
            emp = await Task.Run(() => srv.empresa(id));
            if (emp.id != 0)
            {
                return Ok(emp);
            }
            else
            {
                return BadRequest();
            }

        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empresa emp)
        {
            bool resultado = await srv.AddOrUpdate(emp);
            if (resultado)
            {
                return Ok("Sucesso");
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Empresa emp)
        {
            bool retorno = await srv.AddOrUpdate(emp);
            if (retorno)
            {
                return Ok("Sucesso");
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            bool removeu = await srv.Remove(id);
            if (removeu)
            {
                return Ok("Sucesso");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("removeNome/{nome}")]
        public async Task<IActionResult> DeleteNome(string nome)
        {
            bool removeu = await srv.RemoveNome(nome);
            if(removeu)
            {
                return Ok("Sucesso");
            }
            else
            {
                return BadRequest("falha ao remover");
            }
        }
    }
}
