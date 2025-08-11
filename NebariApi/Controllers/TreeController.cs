using Microsoft.AspNetCore.Mvc;
using NebariApi.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ITreeService _service;

    public ProductsController(ITreeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tree>>> Get() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Tree>> Get(int id)
    {
        var tree = await _service.GetByIdAsync(id);
        return tree is null ? NotFound() : Ok(tree);
    }
}