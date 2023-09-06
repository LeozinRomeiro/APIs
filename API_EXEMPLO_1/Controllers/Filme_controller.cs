using API.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [ApiController]//Definir a classe como um controlador
    [Route("[Controller]")]//Insplicitar a rota de acesso web; Procurar rota por com "controller"
    public class Filme_controller : ControllerBase//Fazer heranca para pegar funcaos basicas de controladores
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int Id = 1;

        [HttpPost]//Indicar ação HTTP, como get e set, oque quer realizar na web
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = Id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(LocalizarId), new { filme.Id }, filme);//o "CreatedAtAction" ta falando qual é acão que crio esse recurso
            //Parametros: o metodo que encontra , os requisitos que sustenta esse metodo, e o criamos propriamente dito
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Diretor);
            Console.WriteLine(filme.Duracao);
            Console.WriteLine(filme.Genero);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]//Diferenciar do get acima, solicitando um parametro na url,no caso, "id"
        public IActionResult LocalizarId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);// Da lista de filmes o FirstOrDefault, ou seja, o primeiro que ele encontrar ou Default

            if(filme==null)
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
    }
}
