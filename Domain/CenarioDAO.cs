using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class CenarioDAO
    {
        public Cenario ObterCenario(int id)
        {
            Model1Container mdl = new Model1Container();
            return mdl.CenarioSet.Find(id);
        }
    }
}