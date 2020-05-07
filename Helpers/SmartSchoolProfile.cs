using AutoMapper;
using SmartSchollAPI.DTOs;
using SmartSchollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {

        //Construtor
        public SmartSchoolProfile()
        {
            //Mapeamento entre Aluno Models e AlunoDto. Para o mapeamento funcionar,
            //os elementos (nomes) devem estar iguais nas 2 classes.
            CreateMap<Aluno, AlunoDto>()
                //Mapeamento para adiconar Nome e Sobrenome ao elemento Nome
                .ForMember(
                    destino => destino.Nome,
                    opcional => opcional.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                //Mapeamento para calcular a Idade utilizando o Helper DateTimeExtensions
                .ForMember(
                    destino => destino.Idade,
                    opcional => opcional.MapFrom(src => src.DataNascimento.GetIdadeAtual())
                );

            //Mapeando de AlunoDTO para Aluno
            CreateMap<AlunoDto, Aluno>();
        }
    }
}
