using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Shared
{
    public class Pessoa
    {

        
        
        public int Id { get; set; }

        public string Nome { get; set;}
      
        public int Idade { get; set; }

        public Pessoa()
        {
      

        }
    }
}
