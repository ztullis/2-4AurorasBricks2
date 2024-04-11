using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_4AurorasBricks2.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public int NumParts { get; set; }

    public int Price { get; set; }

    public string ImgLink { get; set; } = null!;

    public string PrimaryColor { get; set; } = null!;

    public string SecondaryColor { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;
    public string? Rec1 { get; set; }
    public string? Rec2 { get; set; }
    public string? Rec3 { get; set; }
    public string? Rec4 { get; set; }
    public string? Rec5 { get; set; }
}