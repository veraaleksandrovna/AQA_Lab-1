using System.Net;
using System.Threading.Tasks;
using RESTapi.Models;
using TestRail_Example.Models;

namespace RESTapi.Services;

public interface IMilestoneService
{
    Task<Milestone> GetMilestone(string milestoneId);
    Task<Milestones> GetMilestones(string projectId);
    Task<Milestone> AddMilestone(Milestone milestone);
    Task<Milestone> UpdateMilestone(Milestone milestone);
    HttpStatusCode DeleteMilestone(string milestoneId);
}
