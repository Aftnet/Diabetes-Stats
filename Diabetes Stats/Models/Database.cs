using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DiabetesStats.Models
{
    public class Database : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ExamRecord> ExamRecords { get; set; }
    }
}
