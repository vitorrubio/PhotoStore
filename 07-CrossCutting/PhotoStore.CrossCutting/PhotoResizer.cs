using System;
using System.Drawing;
using System.IO;


namespace PhotoStore.CrossCutting
{
    public class PhotoResizer
    {
		public virtual void ResizeAndWatermark(Stream stream, string destination, string watermark)
		{
			stream.Position = 0;
			Image image = Image.FromStream(stream);
			Bitmap marcadagua = new Bitmap(Image.FromFile(watermark));
			var size = GetThumbnailSize(image);
			Image thumb = image.GetThumbnailImage(size.Width, size.Height, () => false, IntPtr.Zero);
			Bitmap thumbMarcado = new Bitmap(thumb);
			DrawWatermark(marcadagua, thumbMarcado, 0, 0);

			thumb.Save(destination);
		}



		public virtual Size GetThumbnailSize(Image original)
		{
			// Maximum size of any dimension.
			const int maxPixels = 450;

			// Width and height.
			int originalWidth = original.Width;
			int originalHeight = original.Height;

			// Compute best factor to scale entire image based on larger dimension.
			double factor;
			if (originalWidth > originalHeight)
			{
				factor = (double)maxPixels / originalWidth;
			}
			else
			{
				factor = (double)maxPixels / originalHeight;
			}

			// Return thumbnail size.
			return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
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
