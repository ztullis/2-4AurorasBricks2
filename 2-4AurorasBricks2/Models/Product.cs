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
    public string? Rec_1 { get; set; }
    public string? Rec_2 { get; set; }
    public string? Rec_3 { get; set; }
    public string? Rec_4 { get; set; }
    public string? Rec_5 { get; set; }
    public string? Pop_rec_1 { get; set; }
    public string? Pop_rec_2 { get; set; }
    public string? Pop_rec_3 { get; set; }
    public string? Pop_rec_4 { get; set; }
    public string? Pop_rec_5 { get; set; }
}