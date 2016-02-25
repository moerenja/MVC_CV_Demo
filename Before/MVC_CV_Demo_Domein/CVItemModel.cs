using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CV_Demo_Domein
{
    public class CVItemModel
    {
        public Guid CVItemId { get; set; }
        public Guid PersoonID { get; set; }
        public string Functienaam { get; set; }
        public System.DateTime PeriodeVan { get; set; }
        public System.DateTime PeriodeTot { get; set; }
        public string Beschrijving { get; set; }
        public Guid BedrijfsID { get; set; }
    }
}