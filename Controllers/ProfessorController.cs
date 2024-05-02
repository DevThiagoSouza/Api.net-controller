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
        private readonly IRepository _repository;
        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id:int}")] //pode ser usado com  [HttpGet("{ById/{id}")] 
        public IActionResult GetById(int id)
        {
            //var professor = _context.Alunos.FirstOrDefault(a => a.Id == id);
            var professor = _repository.GetProfessorId(id, false);
            if (professor == null) return BadRequest("Aluno n�o encotrado");
            return Ok(professor);
        }

        // [HttpGet("ByName")]
        // public IActionResult GetByName(string nome, string sobrenome)
        // {
        //     var nomeProfessor = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
        //     if (nomeProfessor == null) return BadRequest("Aluno n�o encontrado");
        //     return Ok(nomeProfessor);
        // }

        [HttpPost("{id}")]
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado");


            // _context.Add(professor);
            // _context.SaveChanges();
            // return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            //var professores = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var professores = _repository.GetProfessorId(id);
            if (professores == null) return BadRequest("Professor n�o encotrado");

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encotrado");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            // var rofessores = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var professores = _repository.GetProfessorId(id);
            if (professores == null) return BadRequest("Professor n�o encotrado");


            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encotrado");
            // _context.Update(professor);
            // _context.SaveChanges();
            // return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var professor = _context.Alunos.FirstOrDefault(a => a.Id == id);
            var professor = _repository.GetProfessorId(id);
            if (professor == null) return BadRequest("Professor n�o encotrado");

            _repository.Delete(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encotrado");
            // _context.Remove(professor);
            // _context.SaveChanges();
            // return Ok();
        }
    }
}