using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class FruitTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public double? Price { get; set; }
}
