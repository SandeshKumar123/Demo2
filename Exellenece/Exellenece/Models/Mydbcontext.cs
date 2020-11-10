using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext() :
            base("CONSTRING")
        {

        }
        public DbSet<AdminLogin> login { get; set; }
        public DbSet<Board> board { get; set; }
        public DbSet<AddClass> addclass { get; set; }
        public DbSet<Subject> subject { get; set; }
        public DbSet<Chapter> chapter { get; set; }
        public DbSet<SinglePackage> singlepackage { get; set; }
        public DbSet<ComboPackage> combopackage { get; set; }
        public DbSet<Exam> exam{ get; set; }
        public DbSet<Register> register { get; set; }

        public DbSet<UserScore> userscore { get; set; }

        public DbSet<Order> orders { get; set; }

    }
}