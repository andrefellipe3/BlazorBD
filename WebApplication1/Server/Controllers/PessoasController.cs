using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Server.Data;
using WebApplication1.Shared;


namespace WebApplication1.Server.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class PessoasController : ControllerBase
    {
        //Inject
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoasController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Insere no banco de dados (Funcionando)
        [HttpPost]
        public IActionResult AddPessoa(Pessoa p1)
        {
            _applicationDbContext.Pessoas.Add(p1); //Adiciona uma nova pessoa no banco de Dados
            _applicationDbContext.SaveChanges(); //Confirma a alteração feita
            return Ok(p1);
        }


        //Pega uma informação no banco de dados (Funcionando)
        [HttpGet]
        public IActionResult GetAll()
        {
            try {
                List<Pessoa> pessoasList = _applicationDbContext.Pessoas.ToList(); //Recebendo as informações como lista

                return Ok(pessoasList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //Deleta uma informação no banco de dados 
        [HttpDelete]
        public IActionResult DeletePessoa(int pessoaId)
        {
            Pessoa pessoaRemove = new Pessoa();
            try
            {
                //PessoaRemove recebe o objeto que irei remover no banco de dados
                 pessoaRemove = _applicationDbContext.Pessoas.FirstOrDefault(x => x.Id == pessoaId);
                _applicationDbContext.Remove(pessoaRemove);
                _applicationDbContext.SaveChanges();
                
            }
            catch
            {
                return BadRequest();
            }


            return Ok(pessoaRemove);
        }

        //Atualiza uma informação no banco de dados
        [HttpPut]
        public IActionResult UpdatePessoa(Pessoa p1)
        {
            try
            {
                var pessoaUpdate = _applicationDbContext.Pessoas.FirstOrDefault(x => x.Id == p1.Id);
                pessoaUpdate.Nome = p1.Nome;
                pessoaUpdate.Idade = p1.Idade;
                _applicationDbContext.SaveChanges();
            }
            catch
            {
                BadRequest();
            }
            return Ok();
        }
    }
}
