using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set;}
        [Range(18,140, ErrorMessage = "Idade nao pode ser menor que 18")]
        public int Idade { get; set; }  
    }

