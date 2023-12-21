using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class InvoiceItem
{
    public int ItemId { get; set; }

    public string? InvoiceNum { get; set; }

    public string PrdCode { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Product PrdCodeNavigation { get; set; } = null!;
}
