using System.ComponentModel.DataAnnotations;

namespace API___Tarefa1.TTO
{
    public class TarefaDTO
    {
        [Required]
        [MinLength(5)]
        public string Descricao { get; set; }
        public bool Feito { get; set; } = false;
    }
}
