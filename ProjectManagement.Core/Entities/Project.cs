using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectManager { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public decimal TotalPrice { get; set; }
        public ProjectStatus Status { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2
    }
}