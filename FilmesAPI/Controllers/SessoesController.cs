using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessoesController : ControllerBase
    {
        private SessoesService _sessoesService;
        public SessoesController(SessoesService sessoesService)
        {
            _sessoesService = sessoesService;
        }
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessoesService.AdicionaSessao(sessaoDto);
           
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readSessaoDto.Id }, readSessaoDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _sessoesService.RecuperaSessaoPorId(id);
            if (readSessaoDto != null) return Ok(id);
            return NotFound();
        }
    }
}
