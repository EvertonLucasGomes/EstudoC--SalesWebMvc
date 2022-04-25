using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Corrida
    {
        public int Id { get; set; }
        public String NomeColaborador { get; set; }
        public String Origem { get; set; }
        public String Destino { get; set; }
        public int Valor { get; set; }

    }
}
