using System.Security.Claims;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Ensures all endpoints in this controller require authentication
public class BookingController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    /// <summary>
    /// Creates a new booking for the currently authenticated user.
    /// </summary>

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid booking data.");

        // Extract user ID from the JWT token
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized("Invalid user ID in token.");

        request.UserId = userId;

        var result = await _bookingService.CreateBooking(request);

        return result.Success
            ? StatusCode(result.StatusCode)
            : StatusCode(result.StatusCode, result.Error);
    }

    /// <summary>
    /// Retrieves all bookings made by the currently authenticated user.
    /// </summary>
    [HttpGet("mine")]
    public async Task<IActionResult> GetMine()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized("Missing or invalid user ID.");

        var result = await _bookingService.GetBookingsForUserAsync(userId);

        return result.Success
            ? Ok(result.Result)
            : StatusCode(result.StatusCode, result.Error);
    }
}
