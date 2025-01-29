using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WebAPIEcommerceCoreMVC.Model;
using WebAPIEcommerceCoreMVC.Service;
using static System.Net.WebRequestMethods;

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
        [HttpPost("/teste")]
        public async Task<IActionResult> post2()
        {
            var valor = "";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://www.4devs.com.br/ferramentas_online.php");
            using ( var httpClient = new HttpClient())
            {
                var url = @"https://www.4devs.com.br/ferramentas_online.php";
                var content = new FormUrlEncodedContent(new[]
       {
             new KeyValuePair<string, string>("acao", "gerar_cpf"),
             new KeyValuePair<string, string>("pontuacao", "N"),
             new KeyValuePair<string, string>("sexo","H"),
             new KeyValuePair<string, string>("txt_qtde", "1"),
        });

       /*         var jsonString = @"{
formdata:[
{
 'key':'acao',
 'value':'gerar_cpf'
},
{
'key':'pontuacao',
'value':'N'
},
{
'key':'sexo',
'value':'M'
},
{
'key':'txt_qtde',
'value':'1'
}
 ]}";*/
                //var serializado = JsonSerializer.Serialize(jsonString);
                /*var content = new StringContent(jsonString, Encoding.UTF8,"application/json");
                content.Headers.Clear();                
                content.Headers.Add("Content-Type","application/form-data");*/
                
                var response = httpClient.PostAsync(url, content).Result;
                //var response =  httpClient.PostAsync(url,content).Result;

                 valor =  response.Content.ReadAsStringAsync().Result;
//                var valor3 = JsonSerializer.Deserialize<List<Usuario>>(valor);
                //var valor5 = httpClient.PostAsync(url, content).Result.Content.ReadFromJsonAsync<Usuario>().Result;
  //              var valor4 =JsonSerializer.Deserialize<Usuario>(valor);

                

    //            Usuario valor2 = new Usuario(); 
      //          valor2 = response.Content.ReadFromJsonAsync<Usuario>().Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Cpf:"+valor.ToString());
                   /* var response = await client.PostAsJsonAsync("api/menus", menu).Result;
                    Int32 Id = response.Content.ReadAsAsync<Int32>().Result;*/
                }
                else
                {
                    Console.WriteLine("e nao deu");
                }
            }

                return Ok("Cpf: "+valor);
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
