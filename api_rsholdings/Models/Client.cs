using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class Client
{
    public string ClientId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? RegistrationNum { get; set; }

    public string? VatNum { get; set; }

    public virtual ICollection<ClientPayment> ClientPayments { get; set; } = new List<ClientPayment>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
