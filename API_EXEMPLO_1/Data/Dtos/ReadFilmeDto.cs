using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Required(ErrorMessage = "O campo titulo é obrigatorio!")]//Dita que a propriedade não deve ser nula
        public string Titulo { get; set; }

        [Required] public string Diretor { get; set; }

        [StringLength(50)]//Definir um tamanho maximo para a string
        public string Genero { get; set; }

        [Range(0, 500)] public int Duracao { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}
