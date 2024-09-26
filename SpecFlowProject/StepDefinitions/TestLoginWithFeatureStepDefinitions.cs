using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class TestLoginWithFeatureStepDefinitions
    {
        [When(@"User enters the ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserEntersTheAnd(string user, string pass)
        {
            Console.WriteLine(user+" :"+pass);
        }

        [Then(@"user selected city and country infomation")]
        public void ThenUserSelectedCityAndCountryInfomation(Table table)
        {
            foreach (var row in table.Rows)
            {
                string city = row["city"];
                string country = row["country"];

                Console.WriteLine(city + "  " + country);
            }
        }
    }
}
