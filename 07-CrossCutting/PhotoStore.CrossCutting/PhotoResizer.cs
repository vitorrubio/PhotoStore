using System;
using System.Drawing;
using System.IO;


namespace PhotoStore.CrossCutting
{
    public class PhotoResizer
    {
		public virtual void ResizeAndWatermark(Stream stream, string destination)
		{
			stream.Position = 0;
			Image image = Image.FromStream(stream);
			int l1 = image.Width;
			int h1 = image.Height;
			int l2 = 450;
			double pct = (double)l2 / (double)l1 * 100;
			int h2 = (int)(h1 * pct / 100);
			Image thumb = image.GetThumbnailImage(l2, h2, () => false, IntPtr.Zero);
			thumb.Save(destination);
		}
    }
}
