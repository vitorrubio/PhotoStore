﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Services
{
	public class ApplicationRoleManager : RoleManager<IdentityRole>
	{
		public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
		: base(roleStore) { }

		public static ApplicationRoleManager Create(
			IdentityFactoryOptions<ApplicationRoleManager> options,
			IOwinContext context)
		{
			var manager = new ApplicationRoleManager(
				new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
			return manager;
		}
	}
}
