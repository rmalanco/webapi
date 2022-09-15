using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

// Verbos HTTP:

// Get -> para visualizar registros
// Post -> para registrar un nuevo registro
// Delete -> para eliminar un registro
// Put -> para actualizar un registro
// Patch -> para actualizar un registro parcialmente

[ApiController]
[Route("[controller]")]

public class helloWorldController : ControllerBase
{
    IHelloWorldService _helloWorldService;

    private readonly ILogger<helloWorldController> _logger;

    TareasContext dbcontext;

    public helloWorldController(ILogger<helloWorldController> logger, IHelloWorldService helloWorldService, TareasContext db)
    {
        _logger = logger;
        _helloWorldService = helloWorldService;
        dbcontext = db;
    }

    [HttpGet]
    [Route("createdb")]
    public ActionResult Get()
    {
        _logger.LogInformation("Retornando mensaje de hello world");
        return Ok(_helloWorldService.GetHelloWorld());
    }

    [HttpGet]

    public ActionResult createDB()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}