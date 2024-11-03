using FakeRestApiTest.Models;
using FakeRestApiTest.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.StepDefinitions
{
    [Binding]
    public class ActivitiesSteps : GeneralSteps
    {
        private string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1";
        private readonly ScenarioContext scenarioContext;

        public ScenarioContext ScenarioContext { get; }

        public ActivitiesSteps(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        ActivityServices ActivityServices => new ActivityServices(specFlowOutputHelper, scenarioContext);


        [When(@"I call the endpoint get all activities")]
        public async Task WhenICallTheEndpointGetAllActivities()
        {
            var response = await ActivityServices.GetAllActivities();
            ScenarioContext.Set<HttpResponseMessage>(response,"response");
        }

        [Then(@"The response code is HTTP (.*)")]
        public void ThenTheResponseCodeIsHTTP(int code)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            response.StatusCode.Should().Be((HttpStatusCode)code);
        }


        [When(@"I call the endpoint get activity and use (.*) as id")]
        public async Task WhenICallTheEndpointGetActivityAndUseAsId(int activityId)
        {
            response = await ActivityServices.GetSpecificActivity(activityId);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [Then(@"The response contains ""([^""]*)""")]
        public async Task ThenTheResponseContains(string content)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var responseBody2 = await response.Content.ReadAsStringAsync();
            Assert.Contains(content, responseBody2);
        }

        [Then(@"The property title has value ""([^""]*)""")]
        public async Task ThenThePropertyTitleHasValue(string value)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<ActivityResponseModel>();
            json.Title.Should().Be(value);
        }

        [Then(@"The property title does not have value ""([^""]*)""")]
        public async Task ThePropertyTitleDoesNotHaveValue(string value)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<ActivityResponseModel>();
            json.Title.Should().NotBe(value);
        }

        [When(@"I send POST request to the /Activities endpoint using id as (.*) and title as ""([^""]*)""")]
        public async Task WhenISendPOSTRequestToTheActivitiesEndpointUsingIdAsAndTitleAs(int id, string title)
        {
            ActivityResponseModel data = new ActivityResponseModel();
            data.Id = id;
            data.Title = title;
            data.Completed = false;
            data.DueDate = "2024-11-03T09:08:29.801Z";
            JObject body = JObject.FromObject(data);
            var response = await ActivityServices.CreateActivity(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");

        }

        [When(@"I send POST request to the /Activities endpoint using id as ""([^""]*)"" only as a body")]
        public async Task WhenISendPOSTRequestToTheActivitiesEndpointUsingIdAsOnlyAsABody(int id)
        {
            ActivityResponseModel data = new ActivityResponseModel();
            data.Id = id;
            data.DueDate = "2024-11-03T09:08:29.801Z";
            JObject body = JObject.FromObject(data);
            var response = await ActivityServices.CreateActivity(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [Then(@"The response id has a value of (.*)")]
        public async Task ThenTheResponseIdHasAValueOf(int responseId)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<ActivityResponseModel>();
            json.Id.Should().Be(responseId);
        }

        [When(@"I send PUT request to the Activities/\{id} endpoint using id as (.*) and title as ""([^""]*)"" and completed as (.*)")]
        public async Task WhenISendPUTRequestToTheActivitiesIdEndpointUsingIdAsAndTitleAsAndCompletedAsFalse(int id, string title, bool condition)
        {
            ActivityResponseModel data = new ActivityResponseModel();
            data.Id = id;
            data.Title = title;
            data.Completed = condition;
            data.DueDate = "2024-11-03T09:08:29.801Z";
            JObject body = JObject.FromObject(data);
            var response = await ActivityServices.UpdateActivity(body, id);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");

        }
        





    }
}
