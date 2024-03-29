﻿namespace GameSetBook.Core.Models.Club
{
    public class ClubInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logourl {  get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CityName {  get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public double Rating { get; set; }
    }   
}
