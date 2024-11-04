using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.StepDefinitions
{
    [Binding]
    public class GeneralSteps
    {
        protected HttpClient httpClient;

        protected HttpResponseMessage response;
        protected string responseBody;
        public ISpecFlowOutputHelper specFlowOutputHelper;
        protected ScenarioContext _scenarioContext;
        protected readonly string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1";
        public GeneralSteps(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
            httpClient = new HttpClient();
            this.specFlowOutputHelper = specFlowOutputHelper;
            _scenarioContext = scenarioContext;


        }

      


    }
}
