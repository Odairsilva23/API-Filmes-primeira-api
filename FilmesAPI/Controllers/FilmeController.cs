using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController] // classe para criar a API
    [Route("[controller]")] // define q a rota para acessa a API será sempre 'nome' + 'Controller', ou seja, FilmeController
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int Id = 1;
        // palavra reservada do método Rest, que significa CRIAR alguma coisa
        [HttpPost] // estou dizendo que a inf enviada pelo Programa Postman vai postar a info no server da minha API
        public IActionResult AdicionaFilme([FromBody] Filme filme) // recebe a inf enviada pelo postman pelo seu "Body"
        {
            filme.Id = Id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            //foreach (Filme filme in filmes)
            //{
            //    if (filme.Id == id)
            //    {
            //        return filme;
            //    }
            //}
            //return null;

           Filme filme = filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

    }
}
