using PhotoStore.Core.Model;
using PhotoStore.ViewModel;
using System.Threading.Tasks;

namespace PhotoStore.ApplicationServices.Interfaces
{
	public interface IEventoApplicationService : IGenericApplicationService<Evento>
    {

		Task<Evento> UploadAndSaveAsync(EventoViewModel evVm, int size);
		Evento UploadAndSave(EventoViewModel evVm, int size);

	}
}
