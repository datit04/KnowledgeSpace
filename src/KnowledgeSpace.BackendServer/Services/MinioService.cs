using Minio;
using Minio.DataModel.Args;

namespace KnowledgeSpace.BackendServer.Services
{
	public class MinioService
	{
		private readonly IMinioClient _minio;
		private readonly string _bucketName = "avatars";

		public MinioService()
		{
			_minio = new MinioClient()
				.WithEndpoint("localhost:9000")
				.WithCredentials("minioadmin", "minioadmin")
				.WithSSL(false)
				.Build();
		}

		public async Task<string> UploadAvatarAsync(Stream stream, string fileName, string contentType)
		{
			var objectName = $"avatars/{Guid.NewGuid()}_{Path.GetFileName(fileName)}";

			var args = new PutObjectArgs()
				.WithBucket(_bucketName)
				.WithObject(objectName)
				.WithStreamData(stream)
				.WithObjectSize(stream.Length)
				.WithContentType(contentType);

			await _minio.PutObjectAsync(args);

			return $"http://localhost:9000/{_bucketName}/{objectName}";
		}
	}
}