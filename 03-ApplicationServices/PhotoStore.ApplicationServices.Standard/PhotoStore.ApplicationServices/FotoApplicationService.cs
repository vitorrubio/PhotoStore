using PhotoStore.Core.Model;
using PhotoStore.Infra.Services;
using PhotoStore.ViewModel;
using System;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.IO;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.CrossCutting;
using System.Web;

namespace PhotoStore.ApplicationServices
{
    public class FotoApplicationService : GenericApplicationService<Foto>, IFotoApplicationService
    {
		private IEventoService _eventSvc;
		private IFotoService _fotoSvc;
		private IPhotoResizer _resizer;
		private ApplicationUserManager _userMng;
		private ApplicationSignInManager _sigMng;

		public FotoApplicationService(
			IEventoService evtsvc,
			IFotoService fotoSvc,
			IPhotoResizer resizer,
			ApplicationUserManager usermng,
			ApplicationSignInManager sigmng) : base(fotoSvc)
        {
			this._eventSvc = evtsvc;
			this._fotoSvc = fotoSvc;
			this._resizer = resizer;
			this._userMng = usermng;
			this._sigMng = sigmng;
        }


		public virtual  Foto UpoadDeFotoViaAplicativo(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			
			var status = _sigMng.PasswordSignIn(upl.Login, upl.Senha, false, false);

			if (status != SignInStatus.Success)
				throw new Exception("Usuário ou Senha inválidos");

			return SavePhoto(upl, watermarkHorizontal, watermarkVertical, destination, newSize);

		}

		public virtual Foto UpoadDeFoto(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			return SavePhoto(upl, watermarkHorizontal, watermarkVertical, destination, newSize);
		}


		private Foto SavePhoto(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{


			if(upl.ArquivoAnexo != null && upl.ArquivoAnexo.ContentLength > 0)
			{
				if (string.IsNullOrWhiteSpace(upl.NomeArquivo))
					upl.NomeArquivo = upl.ArquivoAnexo.FileName;

				var evento = _eventSvc.GetById(upl.EventoId);
				var user = _userMng.FindByName(upl.Login);

				Foto foto = new Foto
				{
					Evento = evento,
					Nome = upl.Nome,
					NomeArquivo = upl.NomeArquivo,
					Numero = upl.Numero,
					Vitrine = upl.Vitrine,
					CapaDeEvento = upl.CapaDeEvento,
					Fotografo = user,

				};



				ArquivoFoto arquivo = new ArquivoFoto();
				arquivo.Foto = foto;
				arquivo.Id = foto.Id;
				foto.ArquivoFoto = arquivo;

				using (MemoryStream mem = new MemoryStream())
				{

					upl.ArquivoAnexo.InputStream.CopyTo(mem);
					mem.Seek(0, SeekOrigin.Begin);
					arquivo.Bytes = mem.ToArray();

					this.Save(foto);

					if (!Directory.Exists(destination))
						Directory.CreateDirectory(destination);

					mem.Seek(0, SeekOrigin.Begin);
					_resizer.ResizeAndWatermark(
						mem,
						watermarkHorizontal,
						watermarkVertical,
						string.Format(destination + "{0}.watermark.jpg", foto.Id),
						newSize);

					mem.Seek(0, SeekOrigin.Begin);
					_resizer.JustResize(
						mem,
						string.Format(destination + "{0}.thumb.jpg", foto.Id),
						newSize);
				}

				

				return foto;
			}

			return null;
		}


	}
}
