using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchollAPI.Data;
using SmartSchollAPI.Models;
using SmartSchollAPI.Repository.Contracts;

namespace SmartSchollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public readonly IBaseRepository _baseRepository;

        //Construtor injetando o Repository
        public ProfessorController(IBaseRepository baseRepository)
        {          
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _baseRepository.GetAllProfessores(false);

            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _baseRepository.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _baseRepository.Add(professor);
            if (_baseRepository.SaveChanges())
            {
                return Ok(professor);
            }

            //Falhou
            return BadRequest("Professor não foi cadastrado");
        }

        [HttpPut ("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            professor.Id = id;

            _baseRepository.Update(professor);
            if (_baseRepository.SaveChanges())
            {
                return Ok(professor);
            }

            //Falhou
            return BadRequest("Professor não foi atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _baseRepository.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não foi encontrado");

            _baseRepository.Delete(professor);
            if (_baseRepository.SaveChanges())
            {
                return Ok("Professor excluido com sucesso");
            }

            //Falhou
            return BadRequest("Professor não foi excluido");
        }
    }
}