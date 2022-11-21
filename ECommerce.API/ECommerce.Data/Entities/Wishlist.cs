using System;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public partial class Wishlist
    {
        public Wishlist()
        {
            WishlistDetails = new HashSet<WishlistDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<WishlistDetail> WishlistDetails { get; set; }
    }
}
