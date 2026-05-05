using System;
using System.Collections.Generic;

namespace OSRRKAYP.Entities;

public partial class MusicalInstrument
{
    public long Id { get; set; }

    public int ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? PublicPrice { get; set; }

    public int? CurrentInventory { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
