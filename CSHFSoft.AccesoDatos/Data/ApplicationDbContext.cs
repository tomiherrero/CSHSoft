using System;
using System.Collections.Generic;
using System.Text;
using CSHSoft.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSHSoft.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Veterinario> Veterinario { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
