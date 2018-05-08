using PhotoStore.Core.Model;
using PhotoStore.ViewModel;
using System.IO;

namespace PhotoStore.ApplicationServices.Interfaces
{
	public interface IFotoApplicationService : IGenericApplicationService<Foto>
	{
		Foto UpoadDeFotoViaAplicativo(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		Foto UpoadDeFoto(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		Foto SavePhoto(UploadFotoViewModel upl, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		Foto EditPhoto(FotoViewModel fotoVm, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		void GenerateThumbs(string watermarkHorizontal, string watermarkVertical, string destination, int newSize, Foto foto, MemoryStream mem);
	}
}
