using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Genevill_MVC_Portfolio.Models
{
    public class BugReportViewModel
    {
#nullable enable
        public List<BugTracker>? BugTrackers { get; set; }
        public SelectList? Assignees { get; set; }
        public string? AssigneeSearch { get; set; }
        public string? SearchString { get; set; }
#nullable disable
    }
}
