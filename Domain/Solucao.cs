//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solucao
    {
        public Solucao()
        {
            this.Acerto = new HashSet<Acerto>();
            this.Cenario = new HashSet<Cenario>();
            this.Formacao = new HashSet<Formacao>();
        }
    
        public int Id { get; set; }
    
        public virtual ICollection<Acerto> Acerto { get; set; }
        public virtual ICollection<Cenario> Cenario { get; set; }
        public virtual ICollection<Formacao> Formacao { get; set; }
        public virtual Objeto Objeto { get; set; }
    }
}
