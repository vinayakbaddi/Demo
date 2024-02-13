using Microsoft.AspNetCore.Routing;
using System.IO.Compression;

namespace SpikeHangfire.Services
{
    public class AWSS3Zips
    {
    }
}


using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        // Initialize AWS S3 client
        AmazonS3Client s3Client = new AmazonS3Client("your_access_key", "your_secret_key", Amazon.RegionEndpoint.YOUR_REGION);

        // Download files from S3 bucket
        List<string> downloadedFiles = await DownloadFilesFromS3Async(s3Client, "your_bucket_name");

        // Track downloaded files in SQL table
        foreach (var file in downloadedFiles)
        {
            // Insert code to log file download in SQL table
            // You can use ADO.NET or any ORM like Entity Framework for this
        }

        // Sum up file sizes and zip them if total size exceeds 2GB
        string tempDirectory = Path.Combine(Path.GetTempPath(), "temp_zip");
        string zipFilePath = Path.Combine(tempDirectory, "combined.zip");
        CombineAndZipFiles(downloadedFiles, zipFilePath);

        // Upload zip file back to S3 bucket
        await UploadFileToS3Async(s3Client, zipFilePath, "your_bucket_name", "folder_name");

        // Track uploaded files in SQL table
        // Similar to tracking downloaded files, log file upload in SQL table

        // Clean up temp files
        Directory.Delete(tempDirectory, true);
    }

    static async Task<List<string>> DownloadFilesFromS3Async(AmazonS3Client s3Client, string bucketName)
    {
        List<string> downloadedFiles = new List<string>();

        ListObjectsV2Request request = new ListObjectsV2Request
        {
            BucketName = bucketName
        };

        ListObjectsV2Response response;
        do
        {
            response = await s3Client.ListObjectsV2Async(request);

            foreach (var obj in response.S3Objects)
            {
                if (obj.Key.EndsWith(".zip"))
                {
                    string downloadFilePath = Path.Combine(Path.GetTempPath(), obj.Key);
                    await s3Client.DownloadToFilePathAsync(bucketName, obj.Key, downloadFilePath, null);
                    downloadedFiles.Add(downloadFilePath);
                }
            }

            request.ContinuationToken = response.NextContinuationToken;
        } while (response.IsTruncated);

        return downloadedFiles;
    }

    static void CombineAndZipFiles(List<string> files, string zipFilePath)
    {
        using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                foreach (string file in files)
                {
                    archive.CreateEntryFromFile(file, Path.GetFileName(file));
                }
            }
        }
    }

    static async Task UploadFileToS3Async(AmazonS3Client s3Client, string filePath, string bucketName, string folderName)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            PutObjectRequest request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = folderName + "/" + Path.GetFileName(filePath),
                InputStream = fs
            };

            PutObjectResponse response = await s3Client.PutObjectAsync(request);
        }
    }
}

using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        // Connection string to your SQL Server database
        string connectionString = "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;";

        // Example file operations
        LogFileOperation(connectionString, "file1.zip", "downloaded");
        LogFileOperation(connectionString, "file2.zip", "downloaded");
        LogFileOperation(connectionString, "combined.zip", "uploaded");
    }

    static void LogFileOperation(string connectionString, string fileName, string operation)
    {
        string sql = "INSERT INTO FileOperations (FileName, Operation, Timestamp) VALUES (@FileName, @Operation, @Timestamp)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FileName", fileName);
            command.Parameters.AddWithValue("@Operation", operation);
            command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"File '{fileName}' {operation} successfully logged.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging file operation for '{fileName}': {ex.Message}");
            }
        }
    }
}
using Amazon.S3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Tests
{
    [TestClass]
    public class S3FileManagerTests
    {
        private readonly string _testBucketName = "your_test_bucket_name";
        private readonly string _testFolderName = "test_folder";
        private readonly AmazonS3Client _s3Client;

        public S3FileManagerTests()
        {
            // Initialize AWS S3 client with mock credentials or use mocking framework like Moq
            _s3Client = new AmazonS3Client("mock_access_key", "mock_secret_key", Amazon.RegionEndpoint.USEast1);
        }

        [TestMethod]
        public async Task TestDownloadFilesFromS3Async()
        {
            // Arrange
            var fileNames = new List<string> { "file1.zip", "file2.zip", "file3.txt" };
            CreateTestFilesInBucket(fileNames);

            // Act
            var downloadedFiles = await S3FileManager.DownloadFilesFromS3Async(_s3Client, _testBucketName);

            // Assert
            Assert.AreEqual(2, downloadedFiles.Count);
            foreach (var fileName in downloadedFiles)
            {
                Assert.IsTrue(fileNames.Contains(Path.GetFileName(fileName)));
            }
        }

        [TestMethod]
        public void TestCombineAndZipFiles()
        {
            // Arrange
            var files = new List<string> { "file1.txt", "file2.txt" };
            string tempDirectory = Path.Combine(Path.GetTempPath(), "test_temp_zip");
            string zipFilePath = Path.Combine(tempDirectory, "test_combined.zip");

            // Act
            S3FileManager.CombineAndZipFiles(files, zipFilePath);

            // Assert
            Assert.IsTrue(File.Exists(zipFilePath));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }

        [TestMethod]
        public async Task TestUploadFileToS3Async()
        {
            // Arrange
            string tempFilePath = Path.GetTempFileName();

            // Act
            await S3FileManager.UploadFileToS3Async(_s3Client, tempFilePath, _testBucketName, _testFolderName);

            // Assert
            var listObjectsRequest = new Amazon.S3.Model.ListObjectsV2Request
            {
                BucketName = _testBucketName,
                Prefix = _testFolderName + "/"
            };
            var response = await _s3Client.ListObjectsV2Async(listObjectsRequest);
            Assert.AreEqual(1, response.S3Objects.Count);

            // Clean up
            File.Delete(tempFilePath);
        }

        private void CreateTestFilesInBucket(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                using (var stream = new MemoryStream())
                {
                    // Create dummy files in memory
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("Test content");
                    }
                    stream.Position = 0;

                    // Upload files to test bucket
                    var request = new Amazon.S3.Model.PutObjectRequest
                    {
                        BucketName = _testBucketName,
                        Key = fileName,
                        InputStream = stream
                    };
                    _s3Client.PutObjectAsync(request).Wait();
                }
            }
        }
    }
}

using Amazon.S3;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class S3FileManagerTests
    {
        private readonly string _testBucketName = "your_test_bucket_name";
        private readonly string _testFolderName = "test_folder";
        private readonly AmazonS3Client _s3Client;

        public S3FileManagerTests()
        {
            // Initialize AWS S3 client with mock credentials or use mocking framework like Moq
            _s3Client = new AmazonS3Client("mock_access_key", "mock_secret_key", Amazon.RegionEndpoint.USEast1);
        }

        [Test]
        public async Task DownloadFilesFromS3Async_ShouldDownloadOnlyZipFiles()
        {
            // Arrange
            var fileNames = new List<string> { "file1.zip", "file2.zip", "file3.txt" };
            CreateTestFilesInBucket(fileNames);

            // Act
            var downloadedFiles = await S3FileManager.DownloadFilesFromS3Async(_s3Client, _testBucketName);

            // Assert
            Assert.AreEqual(2, downloadedFiles.Count);
            foreach (var fileName in downloadedFiles)
            {
                Assert.IsTrue(fileNames.Contains(Path.GetFileName(fileName)));
            }
        }

        [Test]
        public void CombineAndZipFiles_ShouldCreateZipFile()
        {
            // Arrange
            var files = new List<string> { "file1.txt", "file2.txt" };
            string tempDirectory = Path.Combine(Path.GetTempPath(), "test_temp_zip");
            string zipFilePath = Path.Combine(tempDirectory, "test_combined.zip");

            // Act
            S3FileManager.CombineAndZipFiles(files, zipFilePath);

            // Assert
            Assert.IsTrue(File.Exists(zipFilePath));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }

        [Test]
        public async Task UploadFileToS3Async_ShouldUploadFileToBucket()
        {
            // Arrange
            string tempFilePath = Path.GetTempFileName();

            // Act
            await S3FileManager.UploadFileToS3Async(_s3Client, tempFilePath, _testBucketName, _testFolderName);

            // Assert
            var listObjectsRequest = new Amazon.S3.Model.ListObjectsV2Request
            {
                BucketName = _testBucketName,
                Prefix = _testFolderName + "/"
            };
            var response = await _s3Client.ListObjectsV2Async(listObjectsRequest);
            Assert.AreEqual(1, response.S3Objects.Count);

            // Clean up
            File.Delete(tempFilePath);
        }

        private void CreateTestFilesInBucket(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                using (var stream = new MemoryStream())
                {
                    // Create dummy files in memory
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("Test content");
                    }
                    stream.Position = 0;

                    // Upload files to test bucket
                    var request = new Amazon.S3.Model.PutObjectRequest
                    {
                        BucketName = _testBucketName,
                        Key = fileName,
                        InputStream = stream
                    };
                    _s3Client.PutObjectAsync(request).Wait();
                }
            }
        }
    }
}


//////////////Specific files and zip them
///
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string bucketName = "your-bucket-name";
        List<string> keys = new List<string>
        {
            "path/to/file1.txt",
            "path/to/file2.txt",
            // Add more file paths as needed
        };

        using (var client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2)) // Specify the appropriate region
        {
            using (MemoryStream zipStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (string key in keys)
                    {
                        var getObjectRequest = new GetObjectRequest
                        {
                            BucketName = bucketName,
                            Key = key
                        };

                        using (var response = await client.GetObjectAsync(getObjectRequest))
                        using (var fileStream = response.ResponseStream)
                        {
                            var entry = archive.CreateEntry(Path.GetFileName(key));
                            using (var entryStream = entry.Open())
                            {
                                await fileStream.CopyToAsync(entryStream);
                            }
                        }
                    }
                }

                // Save the zip file
                using (FileStream fileStream = new FileStream("downloaded-files.zip", FileMode.Create))
                {
                    zipStream.Seek(0, SeekOrigin.Begin);
                    zipStream.CopyTo(fileStream);
                }
            }
        }

        Console.WriteLine("Files downloaded and zipped successfully.");
    }
}
