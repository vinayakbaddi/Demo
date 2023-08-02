using Aspose.BarCode.Generation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TestDll.AsposeTest
{
    public class QRCode
    {
        
            public static void run()
            {
                asp();
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
