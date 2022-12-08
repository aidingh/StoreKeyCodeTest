using StoreKeyCodeTestAidin.Repositories;
using StoreKeyCodeTestAidin.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ComboCampaignsService, ComboCampaignsService>();
builder.Services.AddScoped<VolumeCampaignsService, VolumeCampaignsService>();
builder.Services.AddScoped<ProductRepository, ProductRepository>();

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