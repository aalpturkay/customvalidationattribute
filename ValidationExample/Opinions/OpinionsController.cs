using Microsoft.AspNetCore.Mvc;
using ValidationExample.Repository;

namespace ValidationExample.Opinions;

[ApiController]
[Route("[controller]")]
public class OpinionsController: ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OpinionsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOpinionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("request not validated.");
        }
        
        var op = new Opinion
        {
            Content = dto.Opinion
        };

        _context.Opinions.Add(op);
        await _context.SaveChangesAsync();
        
        return Ok(op);
    }
}