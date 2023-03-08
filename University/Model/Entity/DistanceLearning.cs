    using System;
using System.Collections.Generic;

namespace University;

public partial class DistanceLearning
{
    public int Id { get; set; }

    public bool? Original { get; set; }

    public bool? Approval { get; set; }

    public int? CompetitionTypeId { get; set; }

    public decimal? Achievements { get; set; }

    public decimal? PersonId { get; set; }

    public virtual CompetitionType? CompetitionType { get; set; }

    public virtual Person? Person { get; set; }
}
