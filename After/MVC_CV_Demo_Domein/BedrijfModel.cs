using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CV_Demo_Domein
{

	public class BedrijfModel
    {
		[ScaffoldColumn(false)]
		public System.Guid BedrijfsId { get; set; }
        public string Bedrijfsnaam { get; set; }
    }
}