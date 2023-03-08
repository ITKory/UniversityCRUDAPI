using System;
using System.Collections.Generic;

namespace University;

public partial class CompetitionType
{
    public int Id { get; set; }

    public string? TypeOfCompetition { get; set; }

    public virtual ICollection<DistanceLearning> DistanceLearnings { get; } = new List<DistanceLearning>();

    public virtual ICollection<FullTimeStudent> FullTimeStudents { get; } = new List<FullTimeStudent>();
}
