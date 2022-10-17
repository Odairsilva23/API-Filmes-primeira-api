using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
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
        private FilmeService _filmeService;
        public FilmeController(FilmeService service)
        {
            _filmeService = service;
        }
       
        // palavra reservada do método Rest, que significa CRIAR alguma coisa
        [HttpPost] // estou dizendo que a inf enviada pelo Programa Postman vai postar a info no server da minha API
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) // recebe a inf enviada pelo postman pelo seu "Body"
        {
           ReadFilmeDto readFilmeDto = _filmeService.AdicionaFilme(filmeDto);
            
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }
        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoetaria = null)
        {
           List<ReadFilmeDto> readFilmeDtos = _filmeService.RecuperaFilmes(classificacaoetaria);
            if (readFilmeDtos != null) return Ok(readFilmeDtos);
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperarFilmePorId(id);
            if (readFilmeDto != null) return Ok(id);
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id,[FromBody] UpdateFilmeDto FilmeAtualizaDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(FilmeAtualizaDto,filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
