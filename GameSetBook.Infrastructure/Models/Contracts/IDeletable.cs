﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Infrastructure.Models.Contracts
{
    /// <summary>
    /// Entity which can be deleted
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// is the record deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Deleted on date
        /// </summary>
        public DateTime? DeletedOn { get; set; }
    }
}
