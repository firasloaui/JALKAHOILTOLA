//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JALKAHOITLOA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recieved_ammount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recieved_ammount()
        {
            this.Stocks = new HashSet<Stock>();
        }
    
        public int SaapumiseränId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string Price { get; set; }
        public string VendorName { get; set; }
        public string LocationCode { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
