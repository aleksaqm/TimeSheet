﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
