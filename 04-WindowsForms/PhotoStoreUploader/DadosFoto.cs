using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStoreUploader
{
	public class DadosFoto
	{
		public virtual string Nome { get; set; }
		public virtual string Numero { get; set;}
		public virtual string Caminho { get; set; }

		public virtual bool IsValid()
		{
			return (
				!string.IsNullOrWhiteSpace(Nome) &&
				!string.IsNullOrWhiteSpace(Numero) &&
				!string.IsNullOrWhiteSpace(Caminho));
		}
	}
}
