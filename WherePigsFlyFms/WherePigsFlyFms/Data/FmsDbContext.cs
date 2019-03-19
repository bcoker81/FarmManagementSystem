using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Models;

namespace WherePigsFlyFms.Data
{
    public class FmsDbContext : DbContext
    {
        public FmsDbContext() : base("name=FmsDb")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Animals> Animals { get; set; }
        //public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<VaccinationModel> Vaccines { get; set; }
        public DbSet<MedLookupModel> LookupValues { get; set; }
        public DbSet<AttachmentModel> Attachments { get; set; }
        public DbSet<PickListModel> PickList { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}