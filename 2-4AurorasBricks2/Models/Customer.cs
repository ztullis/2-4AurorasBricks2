using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2_4AurorasBricks2.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string CountryOfResidence { get; set; } = null!;

    public string? Gender { get; set; }

    public decimal Age { get; set; }
}
