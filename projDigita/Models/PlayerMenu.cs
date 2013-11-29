using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace projDigita.Models
{
    public class PlayerMenu
    {
        public int Id { get; set; }

        public List<Fase> Fases { get; set; }

        public short Pontos { get; set; }

        public bool IsFacil { get; set; }

        public int Escolida { get; set; }

    }
}