//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Studsharp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher_Discipline
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher_Discipline()
        {
            this.Evaluation = new HashSet<Evaluation>();
        }
    
        public int ID { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public Nullable<int> DisciplineID { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
