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
			stream.Seek(0, SeekOrigin.Begin);

			using (Bitmap original = new Bitmap(Image.FromStream(stream)))
			{
				ResizeAndWatermark(original, watermarkHorizontal, watermarkVertical, destination, newSize);
			}

		}
		public virtual void ResizeAndWatermark(string fileName, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{
			using (Bitmap original = new Bitmap(Image.FromFile(fileName)))
			{
				ResizeAndWatermark(original, watermarkHorizontal, watermarkVertical, destination, newSize);
			}
		}
		public virtual void ResizeAndWatermark(Bitmap original, string watermarkHorizontal, string watermarkVertical, string destination, int newSize)
		{			
			var size = GetNewThumbnailSize(original, newSize);

			using (Bitmap thumb = CreateThumbnail(original, size, out bool isPortrait))
			{
				using (Bitmap marcadagua = (isPortrait) ? new Bitmap(Image.FromFile(watermarkVertical)) : new Bitmap(Image.FromFile(watermarkHorizontal)))
				{

					DrawWatermark(marcadagua, thumb, 1, 1);

					thumb.Save(destination, ImageFormat.Jpeg);
				}
			}

		}



		public virtual void JustResize(Stream stream, string destination, int newSize)
		{

			stream.Seek(0, SeekOrigin.Begin);

			using (Bitmap original = new Bitmap(Image.FromStream(stream)))
			{

				JustResize(original, destination, newSize);

			}

		}
		public virtual void JustResize(string fileName, string destination, int newSize)
		{
			using (Bitmap original = new Bitmap(Image.FromFile(fileName)))
			{

				JustResize(original, destination, newSize);

			}

		}
		public virtual void JustResize(Bitmap original, string destination, int newSize)
		{

			var size = GetNewThumbnailSize(original, newSize);

			using (Bitmap thumb = CreateThumbnail(original, size, out bool isPortrait))
			{

				thumb.Save(destination, ImageFormat.Jpeg);

			}

		}



		public virtual void Crop(Stream stream, string destination, int newSize)
		{
			stream.Seek(0, SeekOrigin.Begin);

			using (Bitmap original = new Bitmap(Image.FromStream(stream)))
			{

				Crop(original, destination, newSize);

			}
		}
		public virtual void Crop(string fileName, string destination, int newSize)
		{
			using (Bitmap original = new Bitmap(Image.FromFile(fileName)))
			{
				Crop(original, destination, newSize);
			}
		}
		public virtual void Crop(Bitmap original, string destination, int newSize)
		{

			// Check if it is a bitmap:
			if (original == null)
				throw new ArgumentException("No valid bitmap");

			var size = GetNewThumbnailSize(original, newSize);

			using (Bitmap thumb = CreateThumbnail(original, size, out bool isPortrait))
			{

				if (size.Height > size.Width)
				{
					Rectangle selection = new Rectangle(0, ((int)((size.Height - size.Width) / 2)), size.Width, size.Width);
					using (Bitmap bmp = new Bitmap(selection.Width, selection.Height))
					{
						using (Graphics gph = Graphics.FromImage(bmp))
						{
							gph.DrawImage(thumb, new Rectangle(0, 0, bmp.Width, bmp.Height), selection, GraphicsUnit.Pixel);
						}
						bmp.Save(destination, ImageFormat.Jpeg);
					}
					//using (Bitmap cropBmp = thumb.Clone(selection, thumb.PixelFormat))
					//{
					//	cropBmp.Save(destination, ImageFormat.Jpeg);
					//}
				}
				else if (size.Height < size.Width)
				{
					Rectangle selection = new Rectangle((size.Width - size.Height) / 2, 0, size.Height, size.Height);
					using (Bitmap bmp = new Bitmap(selection.Width, selection.Height))
					{
						using (Graphics gph = Graphics.FromImage(bmp))
						{
							gph.DrawImage(thumb, new Rectangle(0, 0, bmp.Width, bmp.Height), selection, GraphicsUnit.Pixel);
						}
						bmp.Save(destination, ImageFormat.Jpeg);
					}
					//using (Bitmap cropBmp = thumb.Clone(selection, thumb.PixelFormat))
					//{
					//	cropBmp.Save(destination, ImageFormat.Jpeg);
					//}
				}
				else
				{
					thumb.Save(destination, ImageFormat.Jpeg);
				}

			}
		}


		public virtual bool IsPortrait(Stream stream)
		{
			stream.Seek(0, SeekOrigin.Begin);

			using (Bitmap original = new Bitmap(Image.FromStream(stream)))
			{

				return IsPortrait(original);

			}
		}
		public virtual bool IsPortrait(string fileName)
		{
			using (Bitmap original = new Bitmap(Image.FromFile(fileName)))
			{
				return IsPortrait(original);
			}
		}
		public virtual bool IsPortrait(Bitmap original)
		{
			return original.Height > original.Width;
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



















		public virtual MemoryStream CropStream(Stream stream, int newSize)
		{
			stream.Seek(0, SeekOrigin.Begin);

			using (Bitmap original = new Bitmap(Image.FromStream(stream)))
			{

				return CropStream(original, newSize);

			}
		}
		public virtual MemoryStream CropStream(string fileName, int newSize)
		{
			using (Bitmap original = new Bitmap(Image.FromFile(fileName)))
			{
				return CropStream(original, newSize);
			}
		}
		public virtual MemoryStream CropStream(Bitmap original, int newSize)
		{

			// Check if it is a bitmap:
			if (original == null)
				throw new ArgumentException("No valid bitmap");

			var size = GetNewThumbnailSize(original, newSize);

			MemoryStream result = new MemoryStream();

			using (Bitmap thumb = CreateThumbnail(original, size, out bool isPortrait))
			{

				if (size.Height > size.Width)
				{
					Rectangle selection = new Rectangle(0, ((int)((size.Height - size.Width) / 2)), size.Width, size.Width);
					using (Bitmap bmp = new Bitmap(selection.Width, selection.Height))
					{
						using (Graphics gph = Graphics.FromImage(bmp))
						{
							gph.DrawImage(thumb, new Rectangle(0, 0, bmp.Width, bmp.Height), selection, GraphicsUnit.Pixel);
						}
						bmp.Save(result, ImageFormat.Jpeg);
					}

				}
				else if (size.Height < size.Width)
				{
					Rectangle selection = new Rectangle((size.Width - size.Height) / 2, 0, size.Height, size.Height);
					using (Bitmap bmp = new Bitmap(selection.Width, selection.Height))
					{
						using (Graphics gph = Graphics.FromImage(bmp))
						{
							gph.DrawImage(thumb, new Rectangle(0, 0, bmp.Width, bmp.Height), selection, GraphicsUnit.Pixel);
						}
						bmp.Save(result, ImageFormat.Jpeg);
					}

				}
				else
				{
					thumb.Save(result, ImageFormat.Jpeg);
				}

			}


			return result;
		}
	}
}
