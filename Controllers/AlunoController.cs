using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchollAPI.Data;
using SmartSchollAPI.DTOs;
using SmartSchollAPI.Models;
using SmartSchollAPI.Repository.Contracts;

namespace SmartSchollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        //Construtor injetando o DataContext e AutoMapper
        public AlunoController( IBaseRepository baseRepository, IMapper mapper)
        {           
            _baseRepository = baseRepository;
            _mapper = mapper;
        }



        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _baseRepository.GetAllAlunos(true);
            
            //Retornando o DTO pelo mapeamento do AutoMapper
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }


        // GET: api/Aluno/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //O AsNoTrackig serve para não preender a variavel da busca
            var aluno = _baseRepository.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            //Retornando o DTO pelo mapeamento do AutoMapper
            var alunoDTO = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDTO);
        }

        // POST: api/Aluno
        [HttpPost]
        public IActionResult Post([FromBody] AlunoDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _baseRepository.Add(aluno);
            if (_baseRepository.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            //Falhou
            return BadRequest("Aluno não foi cadastrado");
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoDto model)
        {
            var aluno = _baseRepository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            _mapper.Map(model, aluno);

            _baseRepository.Update(aluno);
            if (_baseRepository.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            //Falhou
            return BadRequest("Aluno não foi atualizado");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var aluno = _baseRepository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _baseRepository.Delete(aluno);
            if (_baseRepository.SaveChanges())
            {
                return Ok("Aluno excluido com sucesso");
            }

            //Falhou
            return BadRequest("Aluno não foi excluido");
        }
    }
}
