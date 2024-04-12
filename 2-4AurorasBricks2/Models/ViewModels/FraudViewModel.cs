using _2_4AurorasBricks2.Models;
using System.ComponentModel.DataAnnotations;

public class FraudViewModel
{
    public Order Order { get; set; }

    [Required]
    public decimal Age { get; set; }

    [Required]
    public string CountryOfResidence { get; set; }

    [Required]
    public string Gender { get; set; }

    // You can add any additional fields needed for the prediction here
}