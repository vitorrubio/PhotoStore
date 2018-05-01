using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.CrossCutting
{
	public interface IPhotoResizer
	{
		void ResizeAndWatermark(Stream stream, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);
		void ResizeAndWatermark(string fileName, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);
		void ResizeAndWatermark(Bitmap bmp, string watermarkHorizontal, string watermarkVertical, string destination, int newSize);

		void JustResize(Stream stream, string destination, int newSize);
		void JustResize(string fileName, string destination, int newSize);
		void JustResize(Bitmap original, string destination, int newSize);

	}
}
