using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Gerentes;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionaGerente(gerenteDto);
           
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentesPorId(id);
            if (readGerenteDto != null) return Ok(id);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DelataGerente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
