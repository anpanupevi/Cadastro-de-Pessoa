using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroDePessoas.Models
{
    public class comPessoa
    {
        [Key]
        protected int idPessoa { get; set; }
        public string nome { get; set; }
        public long cpf { get; set; }
        public Endereco endereco { get; set; }
        public comTelefone[] telefone { get; set; }


    }
}