using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession
{
    using System;
    using System.IO;

    class XorDecrypt
    {
        public static void run()
        {
            var rootPath = @"C:\Users\vinay\Documents\files\";
            //string inputFile = rootPath + "input.txt";
            //string encryptedFile = rootPath + "encrypted.txt";
            //string decryptedFile = rootPath + "decrypted.txt";

            string filePath = rootPath + "data.txt";
            string encryptedFilePath = rootPath + "encrypted_data.txt";
            string decryptedFilePath = rootPath + "decrypted_data.txt";
            //int encryptionKey = 0x55; // XOR encryption key
            int encryptionKey = -2323123; // XOR encryption key
            EncryptFile(filePath, encryptedFilePath, encryptionKey);
            DecryptFile(encryptedFilePath, decryptedFilePath, encryptionKey);

            Console.WriteLine("Encryption and decryption completed.");
        }

        static void EncryptFile(string inputFilePath, string outputFilePath, int encryptionKey)
        {
            using (FileStream inputFileStream = File.OpenRead(inputFilePath))
            using (FileStream outputFileStream = File.Create(outputFilePath))
            {
                int data;
                while ((data = inputFileStream.ReadByte()) != -1)
                {
                    int encryptedData = data ^ encryptionKey;
                    outputFileStream.WriteByte((byte)encryptedData);
                }
            }
        }

        static void DecryptFile(string inputFilePath, string outputFilePath, int encryptionKey)
        {
            EncryptFile(inputFilePath, outputFilePath, encryptionKey); // XOR encryption and decryption are the same
        }
    }
}