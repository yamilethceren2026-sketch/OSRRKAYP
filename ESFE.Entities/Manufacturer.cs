using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<MusicalInstrument> MusicalInstruments { get; set; } = new List<MusicalInstrument>();
}
