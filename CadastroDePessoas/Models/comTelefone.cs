using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroDePessoas.Models
{
    public class comTelefone
    {
        [Key]
        protected int idTelefone { get; set; }
        public int numero { get; set; }
        public int ddd { get; set; }
        public comTelefoneTipo tipo { get; set; }
    }
}