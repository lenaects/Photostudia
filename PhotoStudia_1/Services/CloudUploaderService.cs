using Minio;
using Minio.DataModel;
using System.Text;
using System.Net;
using Minio.DataModel.Args;
namespace PhotoStudia_1.Services
{
    public class CloudUploaderService
    {
        private const string BucketName = "photostudio-images"; 
        private const string Endpoint = "hb.ru-msk.vkcs.cloud";
        private const string AccessKey = "hjzdT65eS5maXLeSTqWQki";
        private const string SecretKey = "gQMhkhM11Qj9oGB15kGrkSxReSzBGnFYjNWwWizNGwb8";

        private readonly MinioClient _minio;

        public CloudUploaderService()
        {
            _minio = (MinioClient?)new MinioClient()
                .WithEndpoint(Endpoint)
                .WithCredentials(AccessKey, SecretKey)
                .Build();
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string fileNameWithFolder, string contentType)
        {
            var args = new PutObjectArgs()
                .WithBucket("photostudio-images") 
                .WithObject(fileNameWithFolder)
                .WithStreamData(imageStream)
                .WithObjectSize(imageStream.Length)
                .WithContentType(contentType)
                .WithHeaders(new Dictionary<string, string>
                {
            { "x-amz-acl", "public-read" } 
                });

            await _minio.PutObjectAsync(args);

            return $"https://photostudio-images.hb.ru-msk.vkcloud-storage.ru/{fileNameWithFolder}";
        }
    }
}

