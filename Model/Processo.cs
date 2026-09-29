using System.ComponentModel.DataAnnotations;

namespace AppWebAbraao.Model
{
    public class Processo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o número do processo.")]
        [StringLength(200, ErrorMessage = "O número pode ter até 200 caracteres.")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a data.")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Informe o interessado.")]
        [StringLength(200, ErrorMessage = "O interessado pode ter até 200 caracteres.")]
        public string Interessado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o assunto.")]
        [StringLength(200, ErrorMessage = "O assunto pode ter até 200 caracteres.")]
        public string Assunto { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "A descrição pode ter até 2000 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione a situação.")]
        [StringLength(50)]
        public string Situacao { get; set; } = "Aberto";
    }
}
