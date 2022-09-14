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

// builder.Services.AddScoped<IHelloWorldService, helloWorldService>(); // se inyecta la dependencia con el metodo "AddScoped" y se le pasa como parametro la interfaz y la clase que se va a inyectar
builder.Services.AddScoped<IHelloWorldService>(p => new helloWorldService()); // se inyecta la dependencia con el metodo "AddScoped" y se le pasa como parametro la interfaz y la clase que se va a inyectar

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
