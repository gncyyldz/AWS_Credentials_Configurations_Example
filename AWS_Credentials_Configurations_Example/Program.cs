using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();

var app = builder.Build();

app.MapGet("/", async (IAmazonS3 s3Client) =>
{
    var data = await s3Client.ListBucketsAsync();
    var buckets = data.Buckets.Select(b => b.BucketName);
    return buckets;
});

app.Run();
