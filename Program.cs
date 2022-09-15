using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // se agrega el servicio de swagger

/* 

    swagger: Se utiliza 
    para documentar y probar los servicios web
    la ruta de acceso es: /swagger/index.html

*/
builder.Services.AddSqlServer<TareasContext>("Data Source=localhost\\SQLEXPRESS;Initial Catalog=TareasDB;User Id=sa;Password=12345678");
// builder.Services.AddScoped<IHelloWorldService, helloWorldService>(); 
builder.Services.AddScoped<IHelloWorldService>(p => new helloWorldService());
builder.Services.AddScoped<ICategoriaService, categoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
