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
		void ResizeAndWatermark(Stream stream, string watermark, string destination, int newWidth);
		void ResizeAndWatermark(string fileName, string watermark, string destination, int newWidth);
		void ResizeAndWatermark(Bitmap bmp, string watermark, string destination, int newWidth);
	}
}
