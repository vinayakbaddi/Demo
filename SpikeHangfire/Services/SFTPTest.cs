////using Renci.SshNet;
//using System;
//using System.IO;

//namespace SpikeHangfire.Services
//{

//    public class SFTPTest
//    {

//        static void Main(string[] args)
//        {
//            string host = "your_sftp_host";
//            int port = 22;
//            string username = "your_username";
//            string password = "your_password";
//            string remoteDirectory = "/path/to/remote/directory";
//            string localFilePath = @"C:\path\to\your\file.txt"; // Change this to your local file path

//            using (var client = new SftpClient(host, port, username, password))
//            {
//                client.Connect();

//                if (client.IsConnected)
//                {
//                    Console.WriteLine("Connected to SFTP.");

//                    try
//                    {
//                        using (var fileStream = new FileStream(localFilePath, FileMode.Open))
//                        {
//                            client.UploadFile(fileStream, Path.GetFileName(localFilePath), remoteDirectory);
//                            Console.WriteLine("File uploaded successfully.");
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Error: {ex.Message}");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Unable to connect to SFTP.");
//                }

//                client.Disconnect();
//                Console.WriteLine("Disconnected from SFTP.");
//            }
//        }
//    }

//}


////using Renci.SshNet;
////using System;
////using System.IO;

////class Program
////{
////    static void Main(string[] args)
////    {
////        string host = "your_sftp_host";
////        int port = 22;
////        string username = "your_username";
////        string password = "your_password";
////        string remoteDirectory = "/path/to/remote/directory";
////        string localFilePath = @"C:\path\to\your\file.txt"; // Change this to your local file path

////        using (var client = new SftpClient(host, port, username, password))
////        {
////            client.Connect();

////            if (client.IsConnected)
////            {
////                Console.WriteLine("Connected to SFTP.");

////                try
////                {
////                    using (var fileStream = new FileStream(localFilePath, FileMode.Open))
////                    {
////                        client.UploadFile(fileStream, Path.GetFileName(localFilePath), remoteDirectory);
////                        Console.WriteLine("File uploaded successfully.");
////                    }
////                }
////                catch (Exception ex)
////                {
////                    Console.WriteLine($"Error: {ex.Message}");
////                }
////            }
////            else
////            {
////                Console.WriteLine("Unable to connect to SFTP.");
////            }

////            client.Disconnect();
////            Console.WriteLine("Disconnected from SFTP.");
////        }
////    }
////}