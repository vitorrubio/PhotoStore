﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhotoStore.Core.Model
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }

        [Index("ix_ApplicationUser_CPF", IsUnique = true)]
        [MaxLength(11)]
        public virtual string CPF { get; set; }

        [Required]
        public virtual string Nome { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\([0-9]{2}\))\s([0-9]{4})-([0-9]{4,5})$", ErrorMessage = "Celular Inválido")]
        public virtual string Celular { get; set; }

		[Display(Name = "Fotos deste fotógrafo")]
		public virtual ICollection<Foto> Fotos { get; set; }

		[Display(Name = "Eventos deste fotógrafo")]
		public virtual ICollection<Evento> Eventos { get; set; }

    }
}
