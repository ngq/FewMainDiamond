﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FewMain.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FewMainDiamondEntities : DbContext
    {
        public FewMainDiamondEntities()
            : base("name=FewMainDiamondEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FewMainArticle> FewMainArticle { get; set; }
        public virtual DbSet<FewMainProType> FewMainProType { get; set; }
        public virtual DbSet<FewMainType> FewMainType { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<FewMainCart> FewMainCart { get; set; }
        public virtual DbSet<FewMainCartDetail> FewMainCartDetail { get; set; }
        public virtual DbSet<FewMainOrder> FewMainOrder { get; set; }
        public virtual DbSet<FewMainOrderDetail> FewMainOrderDetail { get; set; }
        public virtual DbSet<FewMainOrderType> FewMainOrderType { get; set; }
        public virtual DbSet<FewMainCartType> FewMainCartType { get; set; }
        public virtual DbSet<FewMainProduct> FewMainProduct { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
