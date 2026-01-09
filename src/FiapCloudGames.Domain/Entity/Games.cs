using System;
using System.Collections.Generic;
using Domain.Entity;

namespace Domain.Entity
{
    public class Games : EntityBase
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
        public required int CategoryId { get; set; }
        public DateTime? ReleaseDate { get; set; }

        // Como um jogo pode estar em vários pedidos, criamos uma lista de pedidos.
        public ICollection<Order>? Orders { get; set; }
        public Category? Category { get; set; }
    }
}
