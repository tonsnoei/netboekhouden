//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boekhouden
{
    using System;
    using System.Collections.Generic;
    
    public partial class RelatieType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RelatieType()
        {
            this.Relaties = new HashSet<Relatie>();
        }
    
        public long Id { get; set; }
        public string Naam { get; set; }
        public bool IsCrediteur { get; set; }
        public bool IsDebiteur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Relatie> Relaties { get; set; }
    }
}