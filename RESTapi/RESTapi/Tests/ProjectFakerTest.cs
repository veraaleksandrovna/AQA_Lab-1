using System.Diagnostics;
using Bogus;
using NLog;
using NUnit.Framework;
using RESTapi.Fakers;
using RESTapi.ApiTesting;

namespace RESTapi.Tests;

public class ProjectFakerTest : BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project = null!;
    private static Faker<Project> Project => new ProjectFaker();
    
    [Test]
    [Order(1)]
    public void AddProjectTest()
    {
        _project = Project.Generate();

        _project = ProjectService!.AddProject(_project).Result;
        _logger.Info(_project.ToString());
    }

    [Test]
    [Order(2)]
    public void GetProjectTest()
    {
        _logger.Info(ProjectService?.GetProject(_project.Id.ToString()).Result.ToString());
    }
    
    [Test]
    [Order(3)]
    public void DeleteProjectTest()
    {
        Debug.Assert(ProjectService != null, nameof(ProjectService) + " != null");
        _logger.Info(ProjectService.DeleteProject(_project.Id.ToString()));
    }
}
