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
    
    public partial class CostOfWork
    {
        public int MycroobjectId { get; set; }
        public int TypeOfWorkId { get; set; }
        public Nullable<decimal> Cost_h_ { get; set; }
    
        public virtual Mycroobject Mycroobject { get; set; }
        public virtual TypeOfWork TypeOfWork { get; set; }
    }
}
