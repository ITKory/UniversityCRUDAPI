using System;
using System.Collections.Generic;

namespace University;

public partial class Person
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Snils { get; set; }

    public decimal? Points { get; set; }

    public virtual ICollection<DistanceLearning> DistanceLearnings { get; } = new List<DistanceLearning>();

    public virtual ICollection<FullTimeStudent> FullTimeStudents { get; } = new List<FullTimeStudent>();
}
