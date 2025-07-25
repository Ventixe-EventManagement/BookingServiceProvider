﻿using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

/// <summary>
/// Service responsible for handling booking-related business logic.
/// </summary>
public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;


    //Creates a new booking using the provided request data.
    public async Task<BookingResult> CreateBooking(CreateBookingRequest request)
    {
        try
        {
            // Convert request to BookingEntity
            var booking = BookingFactory.FromRequest(request);

            // Attempt to persist the booking
            var result = await _bookingRepository.AddAsync(booking);

            // Return appropriate result
            if (!result.Succeeded)
                return BookingResult.CreateFailure(result.Error ?? "Could not create booking", result.StatusCode);

            return BookingResult.CreateSuccess(201);
        }
        catch (Exception ex)
        {
            return BookingResult.CreateFailure($"Unexpected error: {ex.Message}", 500);
        }
    }

    //Retrieves all bookings made by a specific user.
    public async Task<BookingResult<IEnumerable<BookingEntity>>> GetBookingsForUserAsync(Guid userId)
    {
        try
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            return BookingResult<IEnumerable<BookingEntity>>.CreateSuccess(bookings);
        }
        catch (Exception ex)
        {
            return BookingResult<IEnumerable<BookingEntity>>.CreateFailure($"Unexpected error: {ex.Message}", 500);
        }
    }

    // Deletes a booking by ID.
    public async Task<BookingResult> DeleteBookingAsync(Guid id)
    {
        var booking = await _bookingRepository.GetOneAsync(x => x.Id == id);
        if (booking == null)
            return BookingResult.CreateFailure("Booking not found", 404);

        var result = await _bookingRepository.DeleteAsync(booking);
        return result.Succeeded
            ? BookingResult.CreateSuccess(204)
            : BookingResult.CreateFailure(result.Error ?? "Could not delete booking", result.StatusCode);
    }

    // Updates an existing booking with new data.
    public async Task<BookingResult> UpdateBookingAsync(Guid id, UpdateBookingRequest request)
    {
        var booking = await _bookingRepository.GetOneAsync(x => x.Id == id);
        if (booking == null)
            return BookingResult.CreateFailure("Booking not found", 404);

        booking.TicketQuantity = request.TicketQuantity;
        booking.PackageId = request.PackageId;

        var result = await _bookingRepository.UpdateAsync(booking);
        return result.Succeeded
            ? BookingResult.CreateSuccess(204)
            : BookingResult.CreateFailure(result.Error ?? "Could not update booking", result.StatusCode);
    }
}
