using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Services;
using PhotoStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Drawing;

namespace PhotoStore.ApplicationServices
{
    public class FotoApplicationService : GenericApplicationService<Foto>
    {
		private EventoApplicationService _eventSvc;
		private ApplicationUserManager _userMng;
		private ApplicationSignInManager _sigMng;

		public FotoApplicationService(
			ApplicationDbContext ctx, 
			EventoApplicationService evtsvc, 
			ApplicationUserManager usermng,
			ApplicationSignInManager sigmng) : base(ctx)
        {
			this._eventSvc = evtsvc;
			this._userMng = usermng;
			this._sigMng = sigmng;
        }


		public virtual  Foto UpoadDeFoto(UploadFotoViewModel upl)
		{
			var evento = _eventSvc.GetById(upl.IdEvento);
			var status = _sigMng.PasswordSignIn(upl.Login, upl.Senha, false, false);

			if (status != SignInStatus.Success)
				throw new Exception("Usuário ou Senha inválidos");

			var user = _userMng.FindByName(upl.Login);

			Foto foto = new Foto
			{
				Evento = evento,
				Nome = upl.Nome,
				NomeArquivo = upl.NomeArquivo,
				Numero = upl.Numero,
				Vitrine = true,
				Fotografo = user
			};

			this.Save(foto);

			ArquivoFoto arquivo = new ArquivoFoto();
			arquivo.Foto = foto;
			arquivo.Id = foto.Id;
			byte[] fileData = null;
			using (var binaryReader = new BinaryReader(upl.ArquivoAnexo.InputStream))
			{
				fileData = binaryReader.ReadBytes(upl.ArquivoAnexo.ContentLength);
			}
			arquivo.Bytes = fileData;
			GenericApplicationService<ArquivoFoto> arqSvc = new GenericApplicationService<ArquivoFoto>(this.Context);
			arqSvc.Save(arquivo);

			

			return foto;

		}
    }
}
