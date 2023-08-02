using Aspose.BarCode.Generation;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AsposeTest
{
    public class QRCode
    {
        public static void run()
        {
            //asp();
            SkiaQR();
        }

        static void qrcoder()
        {
            string dataToEncode = "Hello, QRCoder QR Code!";

            // Create a QRCodeGenerator instance
            using (var qrGenerator = new QRCodeGenerator())
            {
                // Generate the QR code
                var qrCodeData = qrGenerator.CreateQrCode(dataToEncode, QRCodeGenerator.ECCLevel.Q);

                // Create a QR code handler to render the QR code as a bitmap
                var qrCodeHandler = new BitmapByteQRCode(qrCodeData);

                // Set the size of the QR code image (width and height in pixels)
                int qrCodeSize = 300; // You can adjust the size according to your needs

                // Generate the QR code bitmap
                byte[] qrCodeBytes = qrCodeHandler.GetGraphic(qrCodeSize);

                // Save the QR code image to a file (PNG format)
                System.IO.File.WriteAllBytes("QRCode.png", qrCodeBytes);

                Console.WriteLine("QR code generated and saved as QRCode.png.");

            }
            static void SkiaQR()
        {
            // Replace this string with the data you want to encode in the QR code
            string dataToEncode = "Hello, SkiaSharp QR Code!";

            // Create a QR code generator instance
            using (var qrGenerator = new SkiaSharp.QrCode.SkiaSharpQRCodeGenerator())
            {
                // Set the data to be encoded
                qrGenerator.Text = dataToEncode;

                // Set the size of the QR code image (width and height in pixels)
                qrGenerator.Size = 300; // You can adjust the size according to your needs

                // Generate the QR code
                using (var qrCode = qrGenerator.CreateQRCode())
                {
                    // Convert the QR code to a SkiaSharp bitmap
                    using (var qrBitmap = qrCode.ToBitmap())
                    {
                        // Save the QR code image to a file (PNG format)
                        using (var image = SKImage.FromBitmap(qrBitmap))
                        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        using (var stream = System.IO.File.OpenWrite("QRCode.png"))
                        {
                            data.SaveTo(stream);
                        }

                        Console.WriteLine("QR code generated and saved as QRCode.png.");
                    }
                }
            }
        }
        static void asp()
        {
            // Set your Aspose.BarCode license here if you have one
            // License license = new License();
            // license.SetLicense("Aspose.BarCode.lic");

            // Create an instance of the BarcodeGenerator class
            BarcodeGenerator generator = new BarcodeGenerator(EncodeTypes.QR);

            // Set the barcode value (data)
            string barcodeValue = "Hello, World!";
            generator.CodeText = barcodeValue;

            // Set the QR code size in pixels
            int widthInPixels = 14;
            int heightInPixels = 14;
            generator.Parameters.Barcode.XDimension.Millimeters = 0.264583f * widthInPixels;
            generator.Parameters.Barcode.BarHeight.Millimeters = 0.264583f * heightInPixels;

            // Generate the QR code image
            Bitmap barcodeImage = generator.GenerateBarCodeImage();

            // Save the generated QR code image to a file (optional)
            string outputPath = "QRCode.png";
            barcodeImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

            // Display a message indicating success
            Console.WriteLine($"QR code with size {widthInPixels}x{heightInPixels} pixels generated and saved as {outputPath}");

            // Pause the console to see the output
            Console.ReadLine();
        }
    }
}

