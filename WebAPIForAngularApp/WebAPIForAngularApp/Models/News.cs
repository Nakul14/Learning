//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIForAngularApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public long NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> DisplayAtHome { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string NewsDescription { get; set; }
    }
}
