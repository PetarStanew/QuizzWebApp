//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizzWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionTable()
        {
            this.ChoiceTables = new HashSet<ChoiceTable>();
        }
    
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChoiceTable> ChoiceTables { get; set; }
    }
}
