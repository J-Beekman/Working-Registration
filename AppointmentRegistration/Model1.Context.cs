﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppointmentRegistration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppointmentDatabaseEntities : DbContext
    {
        
        public AppointmentDatabaseEntities()
            : base("name=AppointmentDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        
    }
}
