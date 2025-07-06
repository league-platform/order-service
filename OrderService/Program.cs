using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using OrderService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
