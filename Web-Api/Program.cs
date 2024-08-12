using Web_Api.Middlewares;
using Web_Api.Models;
using Web_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Configura CORS
//builder.Services.AddCors(options =>
//{
//	options.AddPolicy("CorsPolicy", builder =>
//	{
//		builder.WithOrigins("https://localhost:7068")  // Origen de tu aplicación Blazor
//			   .AllowAnyMethod()
//			   .AllowAnyHeader();
//	});
//});

builder.Services.AddSqlServer<TareasDbContext>(builder.Configuration.GetConnectionString("urlConnection"));
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
