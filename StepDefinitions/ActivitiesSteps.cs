using FakeRestApiTest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

    }
}
