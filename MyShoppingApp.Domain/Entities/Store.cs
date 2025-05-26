using System;
using System.Collections.Generic;

namespace MyShoppingApp.Domain.Entities;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Address Address { get; set; } = new Address();
    public string Website { get; set; } = string.Empty;
    public List<string> Aisles { get; set; } = new List<string>();
    public Guid? GroupId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
} 