﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Core.Models.Club
{
    public class ClubViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CityName { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public decimal Prcie { get; set; }

        public int WorkingTimeStart { get; set; }
        public int WorkingTimeEnd { get; set; }

        public int NumberofCourts { get; set; }

        //public double Rating { get; set; }
    }
}
