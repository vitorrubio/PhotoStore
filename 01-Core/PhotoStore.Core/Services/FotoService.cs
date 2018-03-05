using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.Core.Services
{
	public class FotoService : GenericService<Foto>, IFotoService
	{
		private readonly IFotoRepository _fotoRepository;

		public FotoService(IFotoRepository rep)
			: base(rep)
		{
			_fotoRepository = rep;
		}
	
	}
}
