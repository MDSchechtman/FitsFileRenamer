using FitsFileRenamer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitsFileRenamer.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase {
    private readonly ILogger<FilesController> _logger;
    private readonly IFitsService _fitsService;

    public FilesController(ILogger<FilesController> logger, IFitsService fitsService) {
        _logger = logger;
        _fitsService = fitsService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery(Name = "path")]string path) {
        var dtos = _fitsService.OpenDirectory(path);
        return Ok(dtos);
    }
}