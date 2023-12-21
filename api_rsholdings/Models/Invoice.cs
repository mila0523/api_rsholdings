using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class Invoice
{
    public string InvoiceNum { get; set; } = null!;

    public string? ClientId { get; set; }

    public string? InvoiceDate { get; set; }

    public string? PricesUsed { get; set; }

    public decimal? InvoiceTotal { get; set; }

    public string? PaymentStatus { get; set; }

    public string? DeliveryStatus { get; set; }

    public virtual Client? Client { get; set; }
}
