using PhotoStore.Core.Model;
using PhotoStore.Infra;
using PhotoStore.Infra.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoStore.ApplicationServices
{
	/// <summary>
	/// conforme postado em 
	/// http://rion.io/2016/01/04/accessing-identity-info-using-dependency-injection-in-net-5/
	/// </summary>
	public class UserResolverService
	{
		//private readonly IHttpContextAccessor _context;
		//private readonly ApplicationUserManager _userManager;
		//public UserResolverService(IHttpContextAccessor context, ApplicationUserManager userManager)
		//{
		//	_context = context;
		//	_userManager = userManager;
		//}
		//public async Task<ApplicationUser> GetUser()
		//{
		//	return await _userManager.FindByEmailAsync(_context.HttpContext.User?.Identity?.Name);
		//}
	}
}