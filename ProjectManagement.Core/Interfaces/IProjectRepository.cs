using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<string> GenerateProjectNumberAsync();
        Task<IEnumerable<Project>> GetProjectsWithCustomersAsync();
    }
}
