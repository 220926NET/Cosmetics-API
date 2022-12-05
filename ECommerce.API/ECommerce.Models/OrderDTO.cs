// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace Models
{
    public class OrderDTO

    {
        public int Id { get; set; }
        public int Quantity { get; set; }
       

        public OrderDTO() { }

        public OrderDTO(int id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }
    }
}
