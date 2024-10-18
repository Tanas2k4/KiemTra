using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.QLsinhVien
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLSinhVien")
        {
        }

        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Sinhvien> Sinhviens { get; set; }

        public List<Sinhvien> GetAllSinhVien()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lop>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sinhvien>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sinhvien>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
