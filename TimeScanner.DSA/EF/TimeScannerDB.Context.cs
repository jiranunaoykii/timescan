﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeScanner.DSA.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TimeScannerDBContainer : DbContext
    {
        public TimeScannerDBContainer()
            : base("name=TimeScannerDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TimeScan> TimeScanSet { get; set; }
        public virtual DbSet<Absence> AbsenceSet { get; set; }
        public virtual DbSet<Calendar> CalendarSet { get; set; }
        public virtual DbSet<Employee> EmployeeSet { get; set; }
        public virtual DbSet<TempEmployee> TempEmployeeSet { get; set; }
    }
}
