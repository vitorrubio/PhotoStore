﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
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
}
