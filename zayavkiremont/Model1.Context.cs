﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zayavkiremont
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        private static Entities _context; public Entities() :
            base("name=Entities")
        {
        }
        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Executors> Executors { get; set; }
        public virtual DbSet<FaultTypes> FaultTypes { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
    }
}