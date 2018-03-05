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
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;

namespace PhotoStore.ApplicationServices
{
    public class FotoApplicationService : GenericApplicationService<Foto>, IFotoApplicationService
    {
		private IEventoService _eventSvc;
		private IFotoService _fotoSvc;
		private ApplicationUserManager _userMng;
		private ApplicationSignInManager _sigMng;

		public FotoApplicationService(
			IEventoService evtsvc,
			IFotoService fotoSvc,
			ApplicationUserManager usermng,
			ApplicationSignInManager sigmng) : base(fotoSvc)
        {
			this._eventSvc = evtsvc;
			this._fotoSvc = fotoSvc;

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
				Fotografo = user,
				
			};

			ArquivoFoto arquivo = new ArquivoFoto();
			arquivo.Foto = foto;
			arquivo.Id = foto.Id;
			foto.ArquivoFoto = arquivo;

			byte[] fileData = null;
			using (var binaryReader = new BinaryReader(upl.ArquivoAnexo.InputStream))
			{
				fileData = binaryReader.ReadBytes(upl.ArquivoAnexo.ContentLength);
			}
			arquivo.Bytes = fileData;

			this.Save(foto);


			return foto;

		}
    }
}
