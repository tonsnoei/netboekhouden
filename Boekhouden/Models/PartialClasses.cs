using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boekhouden
{
    [MetadataType(typeof(BoekhoudingMetadata))]
    public partial class Boekhouding { }

    [MetadataType(typeof(KostenplaatsMetadata))]
    public partial class Kostenplaats { }

    [MetadataType(typeof(RekeningMetadata))]
    public partial class Rekening { }

    [MetadataType(typeof(FactuurMetadata))]
    public partial class Factuur { }

    [MetadataType(typeof(FactuurregelMetadata))]
    public partial class Factuurregel { }

    [MetadataType(typeof(RelatieMetadata))]
    public partial class Relatie { }


}