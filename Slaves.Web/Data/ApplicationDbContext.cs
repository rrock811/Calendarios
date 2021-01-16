using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slaves.Web.Models;

namespace Slaves.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		//dotnet ef migrations add migrationName

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Discipline> Disciplines { get; set; }
	}
}
