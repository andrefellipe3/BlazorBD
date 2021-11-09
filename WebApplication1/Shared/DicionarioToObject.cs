using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Shared
{
    public static class DicionarioToObject
    {
        public static Pessoa DictionaryToPessoa(Pessoa pessoa, IDictionary<string, object> value)
        {
            //pessoa = new Pessoa { Id = 5, Nome = "Em nome de jesus", Idade = 40 };
            if (pessoa == null)
            {
                pessoa = new Pessoa();
            }

            foreach (string field in value.Keys)
            {
                switch (field)
                {
                    case "Id":
                        pessoa.Id = (int)value[nameof(Pessoa.Id)];
                        break;
                    case "Nome":
                        pessoa.Nome = (string)value[nameof(Pessoa.Nome)]; ;
                        break;
                    case "Idade":
                        pessoa.Idade = (int)value[nameof(Pessoa.Idade)]; ;
                        break;

                }
            }
            return pessoa;
        }
    }
}