using AlliedTestApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.RegisterServices();
var app = builder.Build();

app.UseHttpsRedirection();
app.DataSeed();
app.RegisterEndpointDefinitions();
app.UseCors("AllowSpecificOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();