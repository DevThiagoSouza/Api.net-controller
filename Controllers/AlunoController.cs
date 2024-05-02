using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Data;
using api.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id:int}")] //pode ser usado com  [HttpGet("{ById/{id}")] 
        public IActionResult GetById(int id)
        {
            //var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            var aluno = _repository.GetAlunoId(id, false);
            if (aluno == null) return BadRequest("Aluno n�o encotrado");
            return Ok(aluno);
        }

        // [HttpGet("ByName")]
        // public IActionResult GetByName (string nome, string sobrenome)
        // {
        //     var nomeAluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
        //     if (nomeAluno == null) return BadRequest("Aluno n�o encontrado");
        //     return Ok(nomeAluno);
        // }

        [HttpPost("{id}")]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");

            // _context.Add(aluno);
            // _context.SaveChanges();
            // return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var alunos = _repository.GetAlunoId(id);
            if (alunos == null) return BadRequest("aluno n�o encotrado");

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");

            // _context.Update(aluno);
            // _context.SaveChanges();
            // return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            // var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var alunos = _repository.GetAlunoId(id);
            if (alunos == null) return BadRequest("aluno n�o encotrado");

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");

            // _context.Update(aluno);
            // _context.SaveChanges();
            // return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            var aluno = _repository.GetAlunoId(id);
            if (aluno == null) return BadRequest("aluno n�o encotrado");

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
            {
                return Ok("Aluno Deletado");
            }
            return BadRequest("Aluno não Deletado");

            // _context.Remove(aluno);
            // _context.SaveChanges();
            // return Ok();
        }
    }
}