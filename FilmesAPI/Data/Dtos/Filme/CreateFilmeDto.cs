using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório !")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório !")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(25, 300, ErrorMessage = "A Duração do deve estar entre 25 minutos e 300 minutos")]
        public int Duracao { get; set; }
    }
}
