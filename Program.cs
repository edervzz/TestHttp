// See https://aka.ms/new-console-template for more information
using NBomber;
using NBomber.Contracts;
using NBomber.CSharp;

using TestHttp;

var step = Step.Create("Account Creation HttpRequest", timeout: TimeSpan.FromSeconds(20), execute: async context =>
{

    var response = await Block.CallAsync("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJzaWQiOiJiMTkzYmVkZS1mODIwLTRlMTQtYTQ5Mi03MmQ0NDg1YjJmNDciLCJzdWIiOiJWQUdHQEZJSU5TT0ZULk1YIiwiaXNzIjoiZmlpbnNvZnQuY29tIiwiYXVkIjoiT3JpZ2luYWNpb24uY29tIiwianRpIjoiNGFlM2YwZjItYTNkNC00NjQwLTllNTItNTFiYTNhNTgwMDQ1Iiwicm9sZSI6WyJmNTdjYTI1MS0wZGU1LTQ4ZjUtODk0OS0yMzJkMmVlZTI2OGMiLCI3ZWMzZTVkNC1lN2FiLTRlNmMtYmE2OS01M2EyMTQ1YWE1ODgiXSwibmJmIjoxNjU4Nzg5NTA2LCJleHAiOjE2NTg4NzU5MDYsImlhdCI6MTY1ODc4OTUwNn0.Ms95LoL4uGEMDIjhZOmImDr9jcSJSjsxv0BiKew_e98");

    return response.IsSuccessStatusCode
            ? Response.Ok()
            : Response.Fail(statusCode: ((int)response.StatusCode));
});


var s1 = ScenarioBuilder.CreateScenario("Call Account Creation - 1", step)
    .WithLoadSimulations(new[] {
        LoadSimulation.NewKeepConstant(5, TimeSpan.FromSeconds(60))
    });

NBomberRunner
    .RegisterScenarios(s1)
    .Run();
