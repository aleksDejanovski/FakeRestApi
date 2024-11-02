using FakeRestApiTest.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.Services
{
    public class ActivityServices : GeneralSteps
    {
        private readonly string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1";
        public ActivityServices(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
        }

        public async Task<HttpResponseMessage> GetAllActivities()
        {
            return await httpClient.GetAsync($"{baseUrl}/Activities");
        }


    }
}
