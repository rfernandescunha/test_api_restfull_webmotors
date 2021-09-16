using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebMotors.Application.ViewModels.AnuncioWebMotors
{
    public class AnuncioWebMotorsViewModel:BaseViewModels
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Marca é campo obrigatorio.")]
        [MinLength(3)]
        [MaxLength(45)]
        [DisplayName("Marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Modelo é campo obrigatorio.")]
        [MinLength(3)]
        [MaxLength(45)]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Versão é campo obrigatorio.")]
        [MinLength(3)]
        [MaxLength(45)]
        [DisplayName("Versão")]
        public string Versao { get; set; }
        [Required(ErrorMessage = "Ano é campo obrigatorio.")]
        [DisplayName("Ano")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Quilometragem é campo obrigatorio.")]
        [DisplayName("Quilometragem")]
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "Observação é campo obrigatorio.")]
        [DisplayName("Observacao")]
        public string Observacao { get; set; }

    }
}
