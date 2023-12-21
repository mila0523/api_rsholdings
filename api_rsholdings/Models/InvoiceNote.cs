using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class InvoiceNote
{
    public int NoteId { get; set; }

    public string? InvoiceNum { get; set; }

    public string? Description { get; set; }
}
