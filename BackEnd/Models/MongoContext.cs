using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BackEnd.Models;
public class MongoDbContext
{
    private readonly IMongoDatabase database;

    public GridFSBucket PicturesBucket { get; }
    public GridFSBucket ReportsBucket { get; }

    public MongoDbContext(IMongoClient client)
    {
        var databaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE");
        database = client.GetDatabase(databaseName);
        PicturesBucket = new GridFSBucket(database, new GridFSBucketOptions { BucketName = "pictures" });
        ReportsBucket = new GridFSBucket(database, new GridFSBucketOptions { BucketName = "reports" });
    }
}
