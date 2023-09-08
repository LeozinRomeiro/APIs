using API.Data;
using API.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [ApiController]//Definir a classe como um controlador
    [Route("[Controller]")]//Insplicitar a rota de acesso web; Procurar rota por com "controller"
    public class Filme_controller : ControllerBase//Fazer heranca para pegar funcaos basicas de controladores
    {

        FilmeContextcs Contextcs;

        public Filme_controller(FilmeContextcs contextcs)
        {
            Contextcs = contextcs;
        }

        [HttpPost]//Indicar ação HTTP, como get e set, oque quer realizar na web
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
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
            return Ok(filme);

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
        public IActionResult AtualizarFilme(int id, [FromBody] Filme filme)
        {
            Filme filmeOld = Contextcs.Filmes.FirstOrDefault(f => f.Id == id);
            if (filmeOld == null)
                return NotFound();
            filmeOld.Titulo = filme.Titulo;
            filmeOld.Genero = filme.Genero;
            filmeOld.Diretor = filme.Diretor;
            filmeOld.Duracao = filme.Duracao;
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
