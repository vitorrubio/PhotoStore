﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoStore.CrossCutting.Test
{


	[TestClass]
	public class PhotoResizerTest
	{
		[TestMethod]
		public void ResizeHorizontalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.jpg");
			pr.ResizeAndWatermark(
				original.ToStream(ImageFormat.Jpeg),
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\horizontal.png",
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\vertical.png",
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.thumb.jpg",
				450);

		}

		[TestMethod]
		public void ResizeVerticalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099327.jpg");
			pr.ResizeAndWatermark(
				original.ToStream(ImageFormat.Jpeg),
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\horizontal.png",
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\vertical.png",
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099327.thumb.jpg",
				450);

		}




		[TestMethod]
		public void CapaHorizontalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.jpg");
			pr.Crop(
				original.ToStream(ImageFormat.Jpeg),
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\DY5A3810.cover.jpg",
				450);

		}

		[TestMethod]
		public void CapaVerticalTest()
		{
			PhotoResizer pr = new PhotoResizer();
			Image original = Image.FromFile(@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099327.jpg");
			pr.Crop(
				original.ToStream(ImageFormat.Jpeg),
				@"C:\Users\vitor\Dropbox\Projetos\FotUp\Testes\1099327.cover.jpg",
				450);

		}
	}
}
