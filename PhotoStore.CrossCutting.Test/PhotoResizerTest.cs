using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoStore.CrossCutting.Test
{
	public static class ImageExtensions
	{
		public static Stream ToStream(this Image image, ImageFormat format)
		{
			var stream = new System.IO.MemoryStream();
			image.Save(stream, format);
			stream.Position = 0;
			return stream;
		}
	}

	[TestClass]
	public class PhotoResizerTest
	{
		[TestMethod]
		public void ResizeVerticalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099326.jpg");
			pr.ResizeAndWatermark(original.ToStream(ImageFormat.Jpeg), @"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099326.thumb.jpg");

		}

		[TestMethod]
		public void ResizeHorizontalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.jpg");
			pr.ResizeAndWatermark(original.ToStream(ImageFormat.Jpeg), @"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.thumb.jpg");

		}
	}
}
