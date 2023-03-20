﻿using Domain.Data.Entities.Base;

namespace Domain.Data.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
