using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApi.Infrastructure.Data;

namespace BookingApi.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> BookRoom([FromBody] BookRoomDto dto)
    {
        // Проверка: есть ли уже бронь на эту комнату?
        var existing = await _context.Bookings.FirstOrDefaultAsync(b => b.RoomId == dto.RoomId);
        if (existing != null)
            return BadRequest("Room already booked");

        var booking = new Domain.Booking
        {
            RoomId = dto.RoomId,
            UserId = dto.UserId
        };
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return Ok(booking);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null) return NotFound();
        return Ok(booking);
    }
}

public class BookRoomDto
{
    public int RoomId { get; set; }
    public string UserId { get; set; } = string.Empty;
}