using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.IO;
using Aspose.BarCode.Generation;

namespace Profession.AsposeTest
{
    public class BarcodeTest
    {

        public static void run()
        {
            ex();
        }

        private static void ex()
        {
            t();
        }

        //public SKBitmap GenerateBarcode(string content, int width, int height)
        //{
        //    var barcodeWriter = new BarcodeWriter
        //    {
        //        Format = BarcodeFormat.CODE_128, // You can choose a different barcode format as needed
        //        Options = new ZXing.Common.EncodingOptions
        //        {
        //            Width = width,
        //            Height = height
        //        }
        //    };

        //    SKBitmap barcodeBitmap = barcodeWriter.Write(content);

        //    return barcodeBitmap;
        //}

        //public SKImage GeneratePDF417Barcode(string content, int width, int height)
        //{
        //    var surface = SKSurface.Create(new SKImageInfo(width, height));
        //    var canvas = surface.Canvas;

        //    var barcodePaint = new SKPaint
        //    {
        //        Color = SKColors.Black,
        //    };

        //    // Create a PDF417 barcode using the content
        //    var barcodeData = new SKBarcodeData
        //    {
        //        Type = SKBarcodeType.PDF417,
        //        Text = content,
        //    };

        //    // Define the barcode size and placement
        //    var barcodeBounds = new SKRect(0, 0, width, height);

        //    // Draw the PDF417 barcode
        //    canvas.Clear(SKColors.White);
        //    canvas.DrawBarcode(barcodeData, barcodeBounds, barcodePaint);

        //    // Finish rendering
        //    canvas.Flush();

        //    // Get the resulting image
        //    return surface.Snapshot();
        //}

        //public static SKBitmap GeneratePdf417Barcode(string data)
        //{
        //    var writer = new ZXing.SkiaSharp.BarcodeWriter()
        //    {
        //        form= BarcodeFormat.PDF417,
        //        Options = new EncodingOptions()
        //        {
        //            Width = 300,
        //            Height = 150
        //        }
        //    };

        //    return writer.Write(data);
        //}

        public static void t()
        {
            //var barcode = BarcodeGenerator.GeneratePdf417Barcode("Hello, world!");

            //using (var stream = new FileStream("i:\barcode.png", FileMode.Create))
            //{
            //    barcode.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
            //}
        }




    }
}
