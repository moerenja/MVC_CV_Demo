﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_CV_Demo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVC_CV_DemoEntities : DbContext
    {
        public MVC_CV_DemoEntities()
            : base("name=MVC_CV_DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bedrijf> Bedrijf { get; set; }
        public virtual DbSet<CVItem> CVItem { get; set; }
        public virtual DbSet<Persoon> Persoon { get; set; }
    }
}
