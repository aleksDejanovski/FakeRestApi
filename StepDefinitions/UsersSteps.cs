using FakeRestApiTest.Models;
using FakeRestApiTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.StepDefinitions
{
    public class UsersSteps : GeneralSteps
    {

        private readonly ScenarioContext scenarioContext;
        public UsersSteps(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public ScenarioContext ScenarioContext { get; }

        UsersServices UsersServices => new UsersServices(specFlowOutputHelper, scenarioContext);

        [When(@"I call the get all users endpoint")]
        public async Task WhenICallTheGetAllUsersEndpoint()
        {
            response = await UsersServices.GetAllUsers();
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [When(@"I call the Get users/\{id} endpoint using id as (.*)")]
        public async Task WhenICallTheGetUsersIdEndpointUsingIdAs(int id)
        {
            response = await UsersServices.GetCurrentUser(id);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [Then(@"The response password property has value ""([^""]*)""")]
        public async Task ThenTheResponsePasswordPropertyHasValue(string value)
        {
            response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<UsersResponseModel>();
            json.Password.Should().Be(value);
        }



    }
}
