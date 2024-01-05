using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-SDVG61S\\SQLEXPRESS;database=TraversalDb2024;integrated security=true;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("workstation id=ZahirTraversalDb.mssql.somee.com;packet size=4096;user id=traversal_SQLLogin_2;pwd=ntnlqigrsv;data source=ZahirTraversalDb.mssql.somee.com;persist security info=False;initial catalog=ZahirTraversalDb;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("workstation id=Traversal2024.mssql.somee.com;packet size=4096;user id=traversal_SQLLogin_1;pwd=ssm33b4bil;data source=Traversal2024.mssql.somee.com;persist security info=False;initial catalog=Traversal2024;TrustServerCertificate=True;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
