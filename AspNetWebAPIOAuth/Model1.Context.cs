﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetWebAPIOAuth
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KullaniciEntities1 : DbContext
    {
        public KullaniciEntities1()
            : base("name=KullaniciEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<kullanicilar> kullanicilar { get; set; }
        public virtual DbSet<oturumSuresi> oturumSuresi { get; set; }
    }
}
