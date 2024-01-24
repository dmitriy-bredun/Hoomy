using SDK.Repositories;

WebApplicationOptions options = new() { Args = args };

var builder = WebApplication.CreateBuilder(options);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IElectricitySnapsRepository, ElectricitySnapsRepositoryInFile>();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();