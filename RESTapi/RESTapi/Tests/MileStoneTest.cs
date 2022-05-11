using System.Net;
using NUnit.Framework;
using RESTapi.ApiTesting;
using RESTapi.Clients;
using RESTapi.Fakers;
using RESTapi.Services;
using TestRail_Example.Models;

namespace RESTapi.Tests;

public class MileStoneTest : BaseTest
{
    private Milestone _milestone = null!;
    private Project _project = null!;

    [OneTimeSetUp]
    public void Add_Project()
    {
        _project = new ProjectFaker();
        var actualProject = ProjectService?.AddProject(_project);
        _project = actualProject!.Result;
    }

    [Test]
    [Order(1)]
    public void Add_Milestone()
    {
        _milestone = new MilestoneFaker();
        _milestone.ProjectId = _project.Id;
        var actualMilestone = MilestoneService?.AddMilestone(_milestone).Result;
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastResponse!.StatusCode);
            Assert.AreEqual(_milestone.Name, actualMilestone?.Name);
            Assert.AreEqual(_milestone.Description, actualMilestone?.Description);
            Assert.AreEqual(_milestone.IsStarted, actualMilestone?.IsStarted);
        });
        _milestone = actualMilestone!;
    }

    [Test]
    [Order(2)]
    public void Get_Milestone()
    {
        var actualMilestone = MilestoneService?.GetMilestone(_milestone.Id.ToString()).Result;
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastResponse?.StatusCode);
            Assert.AreEqual(_milestone.Id, actualMilestone?.Id);
            Assert.AreEqual(_milestone.Name, actualMilestone?.Name);
        });
    }

    [Test]
    [Order(3)]
    public void Update_Milestone()
    {
        Milestone updatedMilestone = new MilestoneFaker();
        updatedMilestone.Id = _milestone.Id;
        updatedMilestone.ProjectId = _project.Id;
        var actualMilestone = MilestoneService?.UpdateMilestone(updatedMilestone).Result;
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastResponse?.StatusCode);
            Assert.AreEqual(updatedMilestone.Id, actualMilestone?.Id);
            Assert.AreEqual(updatedMilestone.ProjectId, actualMilestone?.ProjectId);
            Assert.AreEqual(updatedMilestone.Name, actualMilestone?.Name);
            Assert.AreEqual(updatedMilestone.Description, actualMilestone?.Description);
        });
        _milestone = updatedMilestone;
    }

    [Test]
    [Order(4)]
    public void Delete_And_Get_Milestones()
    {
        var actualListOfMilestones = MilestoneService?.GetMilestones(_project.Id.ToString()).Result;
        Assert.AreEqual(1, actualListOfMilestones?.MilestonesList?.Length);
        var deleteStatus = MilestoneService?.DeleteMilestone(_milestone.Id.ToString());
        Assert.AreEqual(HttpStatusCode.OK, deleteStatus);
        actualListOfMilestones = MilestoneService?.GetMilestones(_project.Id.ToString()).Result;
        Assert.AreEqual(0, actualListOfMilestones?.MilestonesList?.Length);
    }

    [OneTimeTearDown]
    public void Delete_Project()
    {
        ProjectService?.DeleteProject(_project.Id.ToString());
    }
}
