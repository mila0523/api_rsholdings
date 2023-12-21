using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class ClientPayment
{
    public int PaymentId { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public string ClientId { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
