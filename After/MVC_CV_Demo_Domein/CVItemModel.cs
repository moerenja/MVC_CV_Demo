using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CV_Demo_Domein
{
    public class CVItemModel
    {

        public Guid CVItemId { get; set; }
        public Guid PersoonID { get; set; }
        public string Functienaam { get; set; }
		[DataType(DataType.Date)]
		[UIHint("DateTimeddMMyyyy")]
		public System.DateTime PeriodeVan { get; set; }
		[DataType(DataType.Date)]
		[UIHint("DateTimeddMMyyyy")]
		public System.DateTime PeriodeTot { get; set; }
        public string Beschrijving { get; set; }
        public Guid BedrijfsID { get; set; }
		public BedrijfModel Bedrijf { get; set; }
		public PersoonModel Persoon { get; set; }
	}
}