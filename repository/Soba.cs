//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Soba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soba()
        {
            this.Smjestajs = new HashSet<Smjestaj>();
        }
    
        public int Br_Sobe { get; set; }
        public string Tip { get; set; }
        public string Opis { get; set; }
        public string Napomena { get; set; }
        public int HotelId_Hot { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Smjestaj> Smjestajs { get; set; }
    }
}
