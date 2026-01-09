using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Customer : EntityBase
    {
        public required string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public required string Email { get; set; }
        public int Phone { get; set; }

        //Como um cliente pode ter vários pedidos, criamos uma lista de pedidos.
        public ICollection<Order>? Orders { get; set; }
    }
}
