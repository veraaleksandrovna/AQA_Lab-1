using NLog;
using NUnit.Framework;
using RESTapi.Clients;
using RESTapi.Services;

namespace RESTapi.Tests;

public class BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService? ProjectService;
    protected MilestoneService? MilestoneService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }
}
