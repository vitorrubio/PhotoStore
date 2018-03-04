using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Core.Model
{
	public enum StatusPedido
	{
		Realizado = 1,
		AguardandoPagamento = 2,
		Cancelado = 3,
		Entregue = 4
	}
}
