using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class Product
{
    public string PrdCode { get; set; } = null!;

    public string? ProductName { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? WaterpreneurPrice { get; set; }

    public decimal? WholesalePrice { get; set; }

    public string? PackSize { get; set; }

    public string? PalletSize { get; set; }

    public string? ImgUrl { get; set; }

    public int? StockLevels { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
