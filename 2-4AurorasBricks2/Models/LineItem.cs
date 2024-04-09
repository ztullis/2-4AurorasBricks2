using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2_4AurorasBricks2.Models;

public partial class LineItem
{
    [Key]
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public int Rating { get; set; }
}
