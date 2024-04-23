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
        private readonly Context _context;
        public AlunoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{id:int}")] //pode ser usado com  [HttpGet("{ById/{id}")] 
        public IActionResult GetById (int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encotrado");
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName (string nome, string sobrenome)
        {
            var nomeAluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (nomeAluno == null) return BadRequest("Aluno não encontrado");
            return Ok(nomeAluno);
        }

        [HttpPost("{id}")]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunos == null) return BadRequest("aluno não encotrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunos == null) return BadRequest("aluno não encotrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("aluno não encotrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}