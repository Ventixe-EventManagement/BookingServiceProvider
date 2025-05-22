using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid booking data.");

        var result = await _bookingService.CreateBooking(request);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        return StatusCode(201);
    }
}