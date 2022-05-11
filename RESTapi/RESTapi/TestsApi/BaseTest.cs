using NLog;
using NUnit.Framework;
using RESTapi.Clients;
using RESTapi.Services;

namespace RESTapi.TestsApi;

public class BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService? ProjectService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
    }
}
