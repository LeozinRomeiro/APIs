using System.ComponentModel.DataAnnotations;
namespace API.Modelos
{
    public class Filme
    {
        [Required][Key] public int Id { get; internal set; }

        [Required(ErrorMessage ="O campo titulo é obrigatorio!")]//Dita que a propriedade não deve ser nula
        public string Titulo { get; set; }
        
        [Required] public string Diretor{ get; set; }

        [StringLength(50)]//Definir um tamanho maximo para a string
        public string Genero { get; set; }

        [Range(0, 500)] public int Duracao { get; set; }
    }
}
