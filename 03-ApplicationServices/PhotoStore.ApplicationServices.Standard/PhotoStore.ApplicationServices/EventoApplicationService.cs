using AutoMapper;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using PhotoStore.CrossCutting;
using PhotoStore.ViewModel;
using System.Threading.Tasks;

namespace PhotoStore.ApplicationServices
{
    public class EventoApplicationService : GenericApplicationService<Evento>, IEventoApplicationService
    {
		private IPhotoResizer _resizer;
		public EventoApplicationService(IEventoService svc, IPhotoResizer resizer) : base(svc)
        {
			_resizer = resizer;

		}


		public virtual async Task<Evento> UploadAndSaveAsync(EventoViewModel evVm, int size)
		{
			if(evVm.ArquivoAnexo != null && evVm.ArquivoAnexo.ContentLength > 0)
			{
				using (var mem = _resizer.CropStream(evVm.ArquivoAnexo.InputStream, size))
				{
					evVm.ArquivoCapa = new ArquivoCapaViewModel
					{
						Evento = evVm,
						NomeDoArquivo = evVm.ArquivoAnexo.FileName,
						Bytes = mem.ToArray()
					};
				}

			}

			Evento ev = await GetByIdAsync(evVm.Id) ?? new Evento();
			Mapper.Map<EventoViewModel, Evento>(evVm, ev);

			await SaveAsync(ev);

			return ev;
		}


		public virtual Evento UploadAndSave(EventoViewModel evVm, int size)
		{
			if (evVm.ArquivoAnexo != null && evVm.ArquivoAnexo.ContentLength > 0)
			{
				using (var mem = _resizer.CropStream(evVm.ArquivoAnexo.InputStream, size))
				{
					evVm.ArquivoCapa = new ArquivoCapaViewModel
					{
						Evento = evVm,
						NomeDoArquivo = evVm.ArquivoAnexo.FileName,
						Bytes = mem.ToArray()
					};
				}

			}

			Evento ev =  GetById(evVm.Id) ?? new Evento();
			Mapper.Map<EventoViewModel, Evento>(evVm, ev);

			Save(ev);

			return ev;
		}
	}
}
