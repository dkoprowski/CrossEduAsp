using System;
using System.Collections.Generic;
using System.Data.Entity;
using CrossEduAsp.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrossEduAsp.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public string Mail { get; set; }
		public DateTime RegistrationDate { get; set; }

		public virtual List<CommentEntity> Comments { get; set; }
		public virtual List<GameEntity> Games { get; set; }
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema:false)
		{
		}

		public DbSet<GameEntity> GameEntities { get; set; }
		public DbSet<CommentEntity> CommentEntities { get; set; }

		
		//TODO: Why resharper added this line?
		//public System.Data.Entity.DbSet<CrossEduAsp.Models.ApplicationUser> IdentityUsers { get; set; }

	}
}