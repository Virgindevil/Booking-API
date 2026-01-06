using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApi.Infrastructure.Data;

namespace BookingApi.Api.Controllers;

[ApiController]
[Route("api/admin/rooms")]
public class AdminRoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminRoomsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] RoomDto dto)
    {
        var room = new Domain.Room
        {
            Class = dto.Class,
            Price = dto.Price,
            Description = dto.Description
        };
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return Ok(room);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

public class RoomDto
{
    public string Class { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}