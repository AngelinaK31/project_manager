//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ExecutorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public System.DateTime Deadline { get; set; }
        public int MycroobjectId { get; set; }
        public int TypeOFWorkId { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        public virtual Mycroobject Mycroobject { get; set; }
        public virtual Project Project { get; set; }
        public virtual TypeOfWork TypeOfWork { get; set; }
        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
    }
}
