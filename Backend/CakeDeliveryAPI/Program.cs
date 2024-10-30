using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // React App URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger/OpenAPI config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS Policy for the React app
app.UseCors("AllowReactApp");

// Enable static files to serve images from wwwroot
app.UseStaticFiles(); // Serves files in wwwroot by default

// Optionally, map /uploads specifically
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.WebRootPath, "uploads")),
    RequestPath = "/uploads"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
