using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using BackEnd.Models;
using System.IO;
using MongoDB.Driver;

namespace BackEnd.Repositories;

public class MongoRepository : IMongoRepository
{
    private readonly MongoDbContext mongocontext;

    public MongoRepository(MongoDbContext mongocontext)
    {
        this.mongocontext = mongocontext;
    }

    public async Task<ObjectId> UploadPictureAsync(string fileName, Stream stream, string contentType)
    {
        return await mongocontext.PicturesBucket.UploadFromStreamAsync(fileName, stream,
            new GridFSUploadOptions
            {
                Metadata = new MongoDB.Bson.BsonDocument { { "ContentType", contentType } }
            });
    }

    public async Task<ObjectId> UploadReportAsync(string fileName, Stream stream, string contentType)
    {
        return await mongocontext.ReportsBucket.UploadFromStreamAsync(fileName, stream,
            new GridFSUploadOptions
            {
                Metadata = new MongoDB.Bson.BsonDocument { { "ContentType", contentType } }
            });
    }

    public async Task<(byte[] Data, string FileName, string ContentType)?> DownloadReportAsync(string id)
    {
        var fileId = ObjectId.Parse(id);
        var fileInfo = await mongocontext.ReportsBucket.Find(Builders<GridFSFileInfo>.Filter.Eq("_id", fileId))
                                                    .FirstOrDefaultAsync();
        if (fileInfo == null) return null;

        using var ms = new MemoryStream();
        await mongocontext.ReportsBucket.DownloadToStreamAsync(fileId, ms);
        return (ms.ToArray(), fileInfo.Filename, fileInfo.Metadata?["ContentType"]?.AsString ?? "application/octet-stream");
    }

    public async Task<string?> GetPictureBase64Async(string id)
    {
        var fileId = ObjectId.Parse(id);
        using var ms = new MemoryStream();
        await mongocontext.PicturesBucket.DownloadToStreamAsync(fileId, ms);
        var bytes = ms.ToArray();
        return Convert.ToBase64String(bytes);
    }
}

