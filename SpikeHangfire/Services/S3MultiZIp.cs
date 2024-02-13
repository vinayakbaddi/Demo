using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SpikeHangfire.Services
{
    public class S3MultiZIp
    {
    }


class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize AWS S3 client
            AmazonS3Client s3Client = new AmazonS3Client("your_access_key", "your_secret_key", Amazon.RegionEndpoint.YOUR_REGION);

            // List all folders (keys) in your S3 bucket
            List<string> folders = await ListFoldersAsync(s3Client, "your_bucket_name");

            // Download and upload files in parallel
            await Task.WhenAll(folders.Select(folder => ProcessFolderAsync(s3Client, "your_bucket_name", folder)));

            Console.WriteLine("All folders processed successfully.");
        }

        static async Task<List<string>> ListFoldersAsync(AmazonS3Client s3Client, string bucketName)
        {
            List<string> folders = new List<string>();

            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Delimiter = "/"
            };

            ListObjectsV2Response response;
            do
            {
                response = await s3Client.ListObjectsV2Async(request);

                foreach (var commonPrefix in response.CommonPrefixes)
                {
                    folders.Add(commonPrefix.TrimEnd('/')); // Remove trailing slash
                }

                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            return folders;
        }

        static async Task ProcessFolderAsync(AmazonS3Client s3Client, string bucketName, string folder)
        {
            // Download files from folder
            List<string> downloadedFiles = await DownloadFilesFromFolderAsync(s3Client, bucketName, folder);

            // Upload files back to S3
            await UploadFilesToFolderAsync(s3Client, bucketName, folder, downloadedFiles);
        }

        static async Task<List<string>> DownloadFilesFromFolderAsync(AmazonS3Client s3Client, string bucketName, string folder)
        {
            List<string> downloadedFiles = new List<string>();

            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = folder + "/"
            };

            ListObjectsV2Response response;
            do
            {
                response = await s3Client.ListObjectsV2Async(request);

                foreach (var obj in response.S3Objects)
                {
                    string downloadFilePath = Path.Combine(Path.GetTempPath(), obj.Key.Replace('/', '\\'));
                    await s3Client.DownloadToFilePathAsync(bucketName, obj.Key, downloadFilePath, null);
                    downloadedFiles.Add(downloadFilePath);
                }

                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            return downloadedFiles;
        }

        static async Task UploadFilesToFolderAsync(AmazonS3Client s3Client, string bucketName, string folder, List<string> files)
        {
            foreach (var file in files)
            {
                string key = folder + "/" + Path.GetFileName(file).Replace('\\', '/');
                await s3Client.UploadObjectFromFilePathAsync(bucketName, key, file, null);
            }
        }
    }

}
