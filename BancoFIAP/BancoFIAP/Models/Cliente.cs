using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BancoFIAP.Models
{
    public class Cliente
    {
        [HiddenInput]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "Valor do depósito")]
        public decimal VlDeposito { get; set; }

        public Sexo Sexo { get; set; }

        [Display(Name = "Tipo conta")]
        public string TipoConta { get; set; }

        public bool NewsLetter { get; set; }

    }
}
