﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Machete.Domain
{
    public class Image : Record
    {
        public int ID { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string filename { get; set; }
        public byte[] Thumbnail { get; set; }
        public string ThumbnailMimeType { get; set; }
        public string parenttable { get; set; }
        public string recordkey { get; set; }

        //public void make_thumbnail()
        //{
        //    Thumbnail = ResizeImage(ImageData, 100, 100);
        //}
        //private Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
        //{
        //    Bitmap originalImage = new Bitmap(streamImage);
        //    int newWidth = originalImage.Width;
        //    int newHeight = originalImage.Height;
        //    double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

        //    if (aspectRatio <= 1 && originalImage.Width > maxWidth)
        //    {
        //        newWidth = maxWidth;
        //        newHeight = (int)Math.Round(newWidth / aspectRatio);
        //    }
        //    else if (aspectRatio > 1 && originalImage.Height > maxHeight)
        //    {
        //        newHeight = maxHeight;
        //        newWidth = (int)Math.Round(newHeight * aspectRatio);
        //    }

        //    Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);

        //    Graphics g = Graphics.FromImage(newImage);
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        //    g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);

        //    originalImage.Dispose();

        //    return newImage;
        //}
    }
}
