using API.Data;
using API.Data.Dtos;
using API.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [ApiController]//Definir a classe como um controlador
    [Route("[Controller]")]//Insplicitar a rota de acesso web; Procurar rota por com "controller"
    public class Filme_controller : ControllerBase//Fazer heranca para pegar funcaos basicas de controladores
    {

        FilmeContextcs Contextcs;
        IMapper Mapper;

        public Filme_controller(FilmeContextcs contextcs, IMapper mapper)
        {
            Contextcs = contextcs;
            Mapper = mapper;
        }

        [HttpPost]//Indicar ação HTTP, como get e set, oque quer realizar na web
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = Mapper.Map<Filme>(filmeDto);

            Contextcs.Filmes.Add(filme);
            return CreatedAtAction(nameof(LocalizarId), new { filme.Id }, filme);//o "CreatedAtAction" ta falando qual é acão que crio esse recurso
            //Parametros: o metodo que encontra , os requisitos que sustenta esse metodo, e o criamos propriamente dito
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return Contextcs.Filmes;
        }

        [HttpGet("{id}")]//Diferenciar do get acima, solicitando um parametro na url,no caso, "id"
        public IActionResult LocalizarId(int id)
        {
            Filme filme = Contextcs.Filmes.FirstOrDefault(filme => filme.Id == id);// Da lista de filmes o FirstOrDefault, ou seja, o primeiro que ele encontrar ou Default

            if (filme == null)
                return NotFound();
            ReadFilmeDto filmeDto = Mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);

            //foreach (Filme filme in filmes)//intanciar a variavel filme e fazela percorrer o filmes
            //{
            //    if (filme.Id==id)
            //    {
            //        return filme;
            //    }
            //}
            //return null;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = Contextcs.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();
            Mapper.Map(filmeDto, filme);
            Contextcs.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = Contextcs.Filmes.FirstOrDefault(filme => filme.Id==id);
            if (filme == null)
                return NotFound();
            Contextcs.Remove(filme);
            Contextcs.SaveChanges();
            return NoContent();
        }
    }
}
