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
    
    public partial class Event
    {
        public long EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDetail { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreateBy { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public Nullable<long> UpdateBy { get; set; }
    }
}