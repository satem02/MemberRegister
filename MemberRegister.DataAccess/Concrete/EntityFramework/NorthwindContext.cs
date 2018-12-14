using System;
using MemberRegister.Core.DataAccess;
using MemberRegister.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MemberRegister.DataAccess.Concrete.EntityFramework {
    public class NorthwindContext : DbContext {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseSqlServer (@"Server=(localdb)\mssqllocaldb;Database=Northwind; Trusted_Connection=true");
        }

        public DbSet<Member> Members { get; set; }

    }
}