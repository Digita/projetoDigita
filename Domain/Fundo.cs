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
    
    public partial class Fundo
    {
        public Fundo()
        {
            this.Cenario = new HashSet<Cenario>();
        }
    
        public int Id { get; set; }
        public string Som { get; set; }
    
        public virtual ICollection<Cenario> Cenario { get; set; }
        public virtual Figura Figura { get; set; }
    }
}
