using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
