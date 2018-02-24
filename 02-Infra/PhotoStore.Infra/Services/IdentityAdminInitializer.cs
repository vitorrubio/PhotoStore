using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStore.Infra.Services
{
    public class IdentityAdminInitializer
    {

        public virtual async Task Initialize()
        {
            const string adminRole = "Administrator";
            const string fotografoRole = "Fotografo";

            const string adminUserName = "ehnrique@hotmail.com";
            const string devUserName = "contato@vitorrubio.com.br";

            var devUser = new ApplicationUser() { UserName = devUserName, Email = devUserName, Nome = "Vitor Rubio", CPF = "29918516860", Celular = "(11) 9799-24544" };
            var adminUser = new ApplicationUser() { UserName = adminUserName, Email = adminUserName, Nome = "Henrique Matias", CPF = "25097895894", Celular = "(11) 9880-08036" };


            using (var context = new ApplicationDbContext())
            {
                await AdicionaUsuario(context, devUser, "#numb147", fotografoRole);
                await AdicionaUsuario(context, adminUser, "#numb147", adminRole);

                await context.SaveChangesAsync();
            }

        }


        public virtual async Task AdicionaUsuario(ApplicationDbContext context, ApplicationUser usuario, string senha, params string [] roles)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            string userName = usuario.UserName;
            if (!userManager.Users.Where(x => x.UserName == userName).Any())
            {
                var result = await userManager.CreateAsync(usuario, senha);
                if (!result.Succeeded)
                {
                    throw new Exception("Falha ao criar usuário Admin");
                }
                var verificar = context.Users.Where(u => u.UserName == userName).SingleOrDefault();
                if (verificar == null)
                {
                    throw new Exception("O usuário admin não está na base");
                }
                await context.SaveChangesAsync();
            }

            var user = context.Users.Where(u => u.UserName == userName).SingleOrDefault();
            foreach (string role in roles)
            {
                if (!context.Roles.Where(r => r.Name == role).Any())
                {
                    context.Roles.Add(new IdentityRole { Name = role });
                }

                await userManager.AddToRoleAsync(user.Id, role);

                await context.SaveChangesAsync();
            }
        }

    }
}