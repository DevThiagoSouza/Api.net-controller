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
    public class ProfessorController : ControllerBase
    {
        private readonly Context _context;
        public ProfessorController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Professors);
        }

        [HttpGet("{id:int}")] //pode ser usado com  [HttpGet("{ById/{id}")] 
        public IActionResult GetById(int id)
        {
            var professor = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Aluno não encotrado");
            return Ok(professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var nomeProfessor = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (nomeProfessor == null) return BadRequest("Aluno não encontrado");
            return Ok(nomeProfessor);
        }

        [HttpPost("{id}")]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professores = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encotrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var rofessores = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (rofessores == null) return BadRequest("Professor não encotrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encotrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}