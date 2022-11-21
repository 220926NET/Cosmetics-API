﻿using System;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Review1 { get; set; } = null!;
        public int Rating { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}