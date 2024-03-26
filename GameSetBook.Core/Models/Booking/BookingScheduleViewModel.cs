﻿namespace GameSetBook.Core.Models.Booking
{
    public class BookingScheduleViewModel
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Hour { get; set; }
        public int CourtId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}