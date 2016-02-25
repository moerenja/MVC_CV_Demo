using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CV_Demo_Domein
{
    public class PersoonModel
    {
		[ScaffoldColumn(false)]
		public Guid PersoonId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Voorvoegsels { get; set; }
    }
}