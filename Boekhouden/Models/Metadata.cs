using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boekhouden
{
    public class BoekhoudingMetadata
    {
        [Required]
        [Display(Name = "Naam")]
        [StringLength(128)]
        public string Name { get; set; }
    }

    public class KostenplaatsMetadata
    {
        [Display(Name = "Boekhouding")]
        public Guid BoekhoudingId { get; set; }
    }

    public class RekeningMetadata
    {
        [Required]
        [StringLength(128)]
        public string Rekeningnummer { get; set; }

        [Display(Name = "Kostenplaats")]
        public Guid KostenplaatsId { get; set; }
    }

    public class FactuurMetadata
    {
        [Required]
        [StringLength(128)]
        public string Factuurnummer { get; set; }
    }

    public class FactuurregelMetadata
    {
        [Required]
        [StringLength(128)]
        [Display(Name = "Product / Dienst")]
        public string Product { get; set; }
    }

    public class RelatieMetadata
    {
        [Display(Name = "Boekhouding")]
        public System.Guid BoekhoudingId { get; set; }

        [Display(Name = "Relatietype")]
        public long RelatieTypeId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Naam 1")]
        public string Naam1 { get; set; }

        [Display(Name = "Naam 2")]
        public string Naam2 { get; set; }

        [Display(Name = "Volledige aanhef")]
        public int Aanhef { get; set; }

        [Display(Name = "Adres 1")]
        public string Adres1 { get; set; }

        [Display(Name = "Adres 2")]
        public string Adres2 { get; set; }

        [Display(Name = "BTW-nummer")]
        public string BTWNr { get; set; }

        [Display(Name = "Land")]
        public string LandId { get; set; }

        [Display(Name = "Landnaam")]
        public string LandNaam { get; set; }

        [Display(Name = "Standaard BTW-%")]
        public int BTWId { get; set; }
    }
}