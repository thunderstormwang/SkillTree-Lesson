//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workshop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photo
    {
        public System.Guid ID { get; set; }
        public System.Guid ArticleID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public System.Guid CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.Guid> UpdateUser { get; set; }
        public System.DateTime UpdateDate { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
