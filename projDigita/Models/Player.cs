using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace projDigita.Models
{
    public class Player
    {
        public int Id { get; set; }


        [Remote("LoginUnico", "Home", ErrorMessage = "Este nome já existe.")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha.")]
        public string SenhaConfirma { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório.")]
        public short Serie { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório.")]
        public string Sexo { get; set; }


        [Range(1, 100, ErrorMessage = "A idade minima é 1 ano.")]
        [Required(ErrorMessage = "O campo idade é obrigatório. [Somente números]")]
        public short Idade { get; set; }
    }
}