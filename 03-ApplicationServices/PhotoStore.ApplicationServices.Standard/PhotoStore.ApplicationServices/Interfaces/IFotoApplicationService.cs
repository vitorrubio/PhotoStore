using PhotoStore.Core.Model;
using PhotoStore.ViewModel;

namespace PhotoStore.ApplicationServices.Interfaces
{
	public interface IFotoApplicationService : IGenericApplicationService<Foto>
    {
		Foto UpoadDeFotoViaAplicativo(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		Foto UpoadDeFoto(UploadFotoViewModel upl, string userName, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);
	}
}
