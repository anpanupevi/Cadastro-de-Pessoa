﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroDePessoas.Models
{
    public class comTelefoneTipo
    {
        [Key]
        protected int idTipoTelefone { get; set; }
        public string tipo { get; set; }

    }
}