//using Aspose.BarCode.Generation;
//using SkiaSharp;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace AsposeTest
//{
//    public class QRCode
//    {
//        public static void run()
//        {
//            //asp();
//            SkiaQR();
//        }

//        static void skiaimg()
//        {
//            //using SkiaSharp;
//            //using System.IO;

//            // open a stream from a file
//            Stream fileStream = File.OpenRead("MyImage.png");

//            // decode the bitmap from the stream
//            using var bitmap = SKBitmap.Decode(fileStream);

//            // create a surface with the same dimensions as the bitmap
//            var surface = SKSurface.Create(bitmap.Info);

//            // get the canvas from the surface
//            var canvas = surface.Canvas;

//            // clear the canvas / fill with white
//            canvas.DrawColor(SKColors.White);

//            // draw the bitmap on the canvas
//            canvas.DrawBitmap(bitmap, SKRect.Create(bitmap.Width, bitmap.Height));

//            // get the image from the surface
//            var image = surface.Snapshot();


//            /////////////
//            ///// create an image info with the desired dimensions and color type
//            var imageInfo = new SKImageInfo(width: 800, height: 600, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a surface with the image info
//            var surface = SKSurface.Create(imageInfo);

//            // get the canvas from the surface
//            var canvas = surface.Canvas;

//            // draw something on the canvas
//            canvas.DrawCircle(400, 300, 200, new SKPaint { Color = SKColors.Red });

//            // get the image from the surface
//            var image = surface.Snapshot();

//            // encode the image as PNG
//            var data = image.Encode(SKEncodedImageFormat.Png, 100);

//            // get the stream from the data
//            var stream = data.AsStream();

//            ////////////
//            ///
//            // create an image info with the desired dimensions and color type
//            var imageInfo = new SKImageInfo(width: 800, height: 600, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a surface with the image info
//            var surface = SKSurface.Create(imageInfo);

//            // get the canvas from the surface
//            var canvas = surface.Canvas;

//            // draw something on the canvas
//            canvas.DrawCircle(400, 300, 200, new SKPaint { Color = SKColors.Red });

//            // get the image from the surface
//            var image = surface.Snapshot();

//            // create a new size
//            var newSize = new SKSizeI(width: 400, height: 300);

//            // resize the image to the new size and get a new image object
//            var resizedImage = image.Resize(newSize, SKFilterQuality.High);

//            //////////
//            ///
//            using SkiaSharp;

//            // create an image info with the desired dimensions and color type
//            var imageInfo = new SKImageInfo(width: 800, height: 600, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a surface with the image info
//            var surface = SKSurface.Create(imageInfo);

//            // get the canvas from the surface
//            var canvas = surface.Canvas;

//            // draw something on the canvas
//            canvas.DrawCircle(400, 300, 200, new SKPaint { Color = SKColors.Red });

//            // get the image from the surface
//            var image = surface.Snapshot();

//            // create a new image info with a different size
//            var resizedImageInfo = new SKImageInfo(width: 400, height: 300, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a new bitmap with the resized image info
//            var resizedBitmap = new SKBitmap(resizedImageInfo);

//            // resize the image to the new bitmap
//            image.Resize(resizedBitmap, SKFilterQuality.High);


//            // create an image info with the desired dimensions and color type
//            var resizedImageInfo = new SKImageInfo(width: 400, height: 300, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a bitmap with the resized image info
//            var resizedBitmap = new SKBitmap(resizedImageInfo);

//            // scale the pixels of the original bitmap into the resized bitmap using high quality filter
//            originalBitmap.ScalePixels(resizedBitmap, SKFilterQuality.High);

//            // save the resized bitmap to a file
//            resizedBitmap.Save("output.png", SKEncodedImageFormat.Png, 100);



//            ////
//            var originalImageInfo = new SKImageInfo(width: 800, height: 600, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a bitmap with the original image info
//            var originalBitmap = new SKBitmap(originalImageInfo);

//            // load an image from a file into the bitmap
//            originalBitmap.Load("input.png");

//            // create a deep copy of the original bitmap with the same image info
//            var copiedBitmap = originalBitmap.Copy(originalImageInfo);

//            // scale the pixels of the copied bitmap using high quality filter
//            copiedBitmap.ScalePixels(SKFilterQuality.High);

//            // save the copied bitmap to a file
//            copiedBitmap.Save("output.png", SKEncodedImageFormat.Png, 100);


//            //
//            using SkiaSharp;

//            // create an image info with the original dimensions and color type
//            var originalImageInfo = new SKImageInfo(width: 800, height: 600, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a bitmap with the original image info
//            var originalBitmap = new SKBitmap(originalImageInfo);

//            // load an image from a file into the bitmap
//            originalBitmap.Load("input.png");

//            // create an image info with the desired dimensions and color type
//            var resizedImageInfo = new SKImageInfo(width: 500, height: 500, colorType: SKColorType.Rgba8888, alphaType: SKAlphaType.Premul);

//            // create a bitmap with the resized image info
//            var resizedBitmap = new SKBitmap(resizedImageInfo);

//            // scale the pixels of the original bitmap into the resized bitmap using high quality filter
//            originalBitmap.ScalePixels(resizedBitmap, SKFilterQuality.High);

//            // save the resized bitmap to a file
//            resizedBitmap.Save("output.png", SKEncodedImageFormat.Png, 100);


//        }

//        static MainSkia()
//        {
//            string imagePath = "path_to_your_image.png";
//            int desiredWidth = 300;
//            int desiredHeight = 400;

//            // Load the original image using SkiaSharp
//            using (SKBitmap originalBitmap = SKBitmap.Decode(imagePath))
//            {
//                // Calculate the new dimensions while maintaining aspect ratio
//                float aspectRatio = (float)originalBitmap.Width / originalBitmap.Height;
//                int newWidth = desiredWidth;
//                int newHeight = (int)(newWidth / aspectRatio);

//                // Check if the new height exceeds the desired height, adjust if needed
//                if (newHeight > desiredHeight)
//                {
//                    newHeight = desiredHeight;
//                    newWidth = (int)(newHeight * aspectRatio);
//                }

//                // Create a new bitmap with the resized dimensions
//                using (SKBitmap resizedBitmap = originalBitmap.Resize(new SKImageInfo(newWidth, newHeight), SKFilterQuality.High))
//                {
//                    // Convert the resized bitmap to a byte array (PNG format)
//                    using (SKImage resizedImage = SKImage.FromBitmap(resizedBitmap))
//                    using (SKPixmap pixmap = resizedImage.PeekPixels())
//                    {
//                        byte[] pngData = pixmap.Encode(SKEncodedImageFormat.Png, 100).ToArray();

//                        // Save the byte array as a PNG file
//                        File.WriteAllBytes("resized_image.png", pngData);
//                    }
//                }
//            }
//        }

//        static void qrcoder()
//        {
//            string dataToEncode = "Hello, QRCoder QR Code!";

//            // Create a QRCodeGenerator instance
//            using (var qrGenerator = new QRCodeGenerator())
//            {
//                // Generate the QR code
//                var qrCodeData = qrGenerator.CreateQrCode(dataToEncode, QRCodeGenerator.ECCLevel.Q);

//                // Create a QR code handler to render the QR code as a bitmap
//                var qrCodeHandler = new BitmapByteQRCode(qrCodeData);

//                // Set the size of the QR code image (width and height in pixels)
//                int qrCodeSize = 300; // You can adjust the size according to your needs

//                // Generate the QR code bitmap
//                byte[] qrCodeBytes = qrCodeHandler.GetGraphic(qrCodeSize);

//                // Save the QR code image to a file (PNG format)
//                System.IO.File.WriteAllBytes("QRCode.png", qrCodeBytes);

//                Console.WriteLine("QR code generated and saved as QRCode.png.");

//            }
//            static void SkiaQR()
//            {
//                // Replace this string with the data you want to encode in the QR code
//                string dataToEncode = "Hello, SkiaSharp QR Code!";

//                // Create a QR code generator instance
//                using (var qrGenerator = new SkiaSharp.QrCode.SkiaSharpQRCodeGenerator())
//                {
//                    // Set the data to be encoded
//                    qrGenerator.Text = dataToEncode;

//                    // Set the size of the QR code image (width and height in pixels)
//                    qrGenerator.Size = 300; // You can adjust the size according to your needs

//                    // Generate the QR code
//                    using (var qrCode = qrGenerator.CreateQRCode())
//                    {
//                        // Convert the QR code to a SkiaSharp bitmap
//                        using (var qrBitmap = qrCode.ToBitmap())
//                        {
//                            // Save the QR code image to a file (PNG format)
//                            using (var image = SKImage.FromBitmap(qrBitmap))
//                            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
//                            using (var stream = System.IO.File.OpenWrite("QRCode.png"))
//                            {
//                                data.SaveTo(stream);
//                            }

//                            Console.WriteLine("QR code generated and saved as QRCode.png.");
//                        }
//                    }
//                }
//            }
//            static void asp()
//            {
//                // Set your Aspose.BarCode license here if you have one
//                // License license = new License();
//                // license.SetLicense("Aspose.BarCode.lic");

//                // Create an instance of the BarcodeGenerator class
//                BarcodeGenerator generator = new BarcodeGenerator(EncodeTypes.QR);

//                // Set the barcode value (data)
//                string barcodeValue = "Hello, World!";
//                generator.CodeText = barcodeValue;

//                // Set the QR code size in pixels
//                int widthInPixels = 14;
//                int heightInPixels = 14;
//                generator.Parameters.Barcode.XDimension.Millimeters = 0.264583f * widthInPixels;
//                generator.Parameters.Barcode.BarHeight.Millimeters = 0.264583f * heightInPixels;

//                // Generate the QR code image
//                Bitmap barcodeImage = generator.GenerateBarCodeImage();

//                // Save the generated QR code image to a file (optional)
//                string outputPath = "QRCode.png";
//                barcodeImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

//                // Display a message indicating success
//                Console.WriteLine($"QR code with size {widthInPixels}x{heightInPixels} pixels generated and saved as {outputPath}");

//                // Pause the console to see the output
//                Console.ReadLine();
//            }
//        }
//    }

