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
    
    public partial class Factuurregel
    {
        public System.Guid Id { get; set; }
        public System.Guid FactuurId { get; set; }
        public System.Guid TenantId { get; set; }
        public string Product { get; set; }
        public Nullable<decimal> PrijsExBTW { get; set; }
        public Nullable<int> BTWId { get; set; }
        public Nullable<long> Aantal { get; set; }
        public Nullable<int> ProductSoortId { get; set; }
        public Nullable<decimal> MargeInkoop { get; set; }
    
        public virtual BTWType BTW { get; set; }
        public virtual Factuur Factuur { get; set; }
        public virtual Productsoort ProductSoort { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}