//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Guidant.Demo.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Security
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Security()
        {
            this.PortfolioSecurities = new HashSet<PortfolioSecurity>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual HashSet<PortfolioSecurity> PortfolioSecurities { get; set; }
    }
}
