using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projDigita.Models
{
    public class Fase
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool solucao1 { get; set; }
        public bool solucao2 { get; set; }
        public bool solucao3 { get; set; }
        public bool solucao4 { get; set; }
        public bool solucao5 { get; set; }
        public bool acertou { get; set; }
    }
}
