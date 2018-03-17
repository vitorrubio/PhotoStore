using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace PhotoStore.CrossCutting
{
	/// <summary>
	/// https://www.codeproject.com/Tips/626124/Create-a-thumbnail-of-a-large-size-image-in-Csharp
	/// </summary>
	public class PhotoResizer : IPhotoResizer
    {
		public virtual void ResizeAndWatermark(Stream stream, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			stream.Position = 0;

			Bitmap original = new Bitmap(Image.FromStream(stream));

			ResizeAndWatermark(original, watermarkHorizontal, watermarkVertical,  destination, newSize);

			try
			{
				original.Dispose();
			}
			catch { }
		}



		public virtual void ResizeAndWatermark(string fileName, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			Bitmap original = new Bitmap(Image.FromFile(fileName));

			ResizeAndWatermark(original, watermarkHorizontal, watermarkVertical, destination, newSize);

			try
			{
				original.Dispose();
			}
			catch { }
		}



		public virtual void ResizeAndWatermark(Bitmap original, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			
			var size = GetNewThumbnailSize(original, newSize);

			Bitmap thumb = CreateThumbnail(original, size, out bool isPortrait);

			Bitmap marcadagua = (isPortrait)? new Bitmap(Image.FromFile(watermarkVertical)) : new Bitmap(Image.FromFile(watermarkHorizontal));

			DrawWatermark(marcadagua, thumb, 1, 1);

			thumb.Save(destination, ImageFormat.Jpeg);

			try
			{
				thumb.Dispose();
			}
			catch { }


			try
			{
				marcadagua.Dispose();
			}
			catch { }
		}



		private  Bitmap CreateThumbnail(Bitmap loBMP, Size tamanho, out bool isPortrait)
		{
			System.Drawing.Bitmap bmpOut = null;
			try
			{
				ImageFormat loFormat = loBMP.RawFormat;

				decimal lnRatio;
				int lnNewWidth = 0;
				int lnNewHeight = 0;

				isPortrait = (loBMP.Height > loBMP.Width);


				//*** If the image is smaller than a thumbnail just return it
				if (loBMP.Width < tamanho.Width && loBMP.Height < tamanho.Height)
				{
					return loBMP;
				}

				if (!isPortrait)
				{
					lnRatio = (decimal)tamanho.Width / loBMP.Width;
					lnNewWidth = tamanho.Width;
					decimal lnTemp = loBMP.Height * lnRatio;
					lnNewHeight = (int)lnTemp;
				}
				else
				{
					lnRatio = (decimal)tamanho.Height / loBMP.Height;
					lnNewHeight = tamanho.Height;
					decimal lnTemp = loBMP.Width * lnRatio;
					lnNewWidth = (int)lnTemp;
				}
				bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
				Graphics g = Graphics.FromImage(bmpOut);
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
				g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

			}
			catch
			{
				throw;
			}

			return bmpOut;
		}


		private Size GetNewThumbnailSize(Bitmap original, int newSize)
		{


			int originalWidth = original.Width;
			int originalHeight = original.Height;

			if (originalWidth > originalHeight)
			{
				int largura2 = (int)(newSize * (double)originalWidth / (double)originalHeight);

				return new Size
				{
					Height = newSize,
					Width = largura2
				};
			}
			else
			{

				int altura2 = (int)(newSize * (double)originalHeight / (double)originalWidth);

				return new Size
				{
					Height = altura2,
					Width = newSize
				};
			}
		}


		private void DrawWatermark(Bitmap watermark_bm, Bitmap result_bm, int x, int y)
		{
			const byte ALPHA = 128;
			// Set the watermark's pixels' Alpha components.
			Color clr;
			for (int py = 0; py < watermark_bm.Height; py++)
			{
				for (int px = 0; px < watermark_bm.Width; px++)
				{
					clr = watermark_bm.GetPixel(px, py);
					watermark_bm.SetPixel(px, py,
						Color.FromArgb(ALPHA, clr.R, clr.G, clr.B));
				}
			}

			// Set the watermark's transparent color.
			watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

			// Copy onto the result image.
			using (Graphics gr = Graphics.FromImage(result_bm))
			{
				gr.DrawImage(watermark_bm, x, y);
			}
		}
	}
}
