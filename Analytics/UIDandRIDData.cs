//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analytics
{
    using System;
    using System.Collections.Generic;
    
    public partial class UIDandRIDData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UIDandRIDData()
        {
            this.SHORTURLDATAs = new HashSet<SHORTURLDATA>();
        }
    
        public int PK_UniqueId { get; set; }
        public string TypeDiff { get; set; }
        public Nullable<int> UIDorRID { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHORTURLDATA> SHORTURLDATAs { get; set; }
    }
}
