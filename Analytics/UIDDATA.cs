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
    
    public partial class UIDDATA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UIDDATA()
        {
            this.SHORTURLDATAs = new HashSet<SHORTURLDATA>();
        }
    
        public int PK_Uid { get; set; }
        public string ReferenceNumber { get; set; }
        public string Longurl { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> FK_RID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual RIDDATA RIDDATA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHORTURLDATA> SHORTURLDATAs { get; set; }
    }
}
