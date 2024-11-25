﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FakestoreEcommerceTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Logowanie na klienta")]
    public partial class LogowanieNaKlientaFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "LoginProcess.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pl"), "Features", "Logowanie na klienta", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
  #line hidden
#line 6
    testRunner.Given("znajduje się na stronie FakeStore", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 7
    testRunner.When("wybieram \"Moje konto\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 8
    testRunner.Then("Wyłączam link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logowanie na klienta")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("test@admin.pl", "testhaslo12345!", null)]
        [NUnit.Framework.TestCaseAttribute("example@domain.com", "examplepass123!", null)]
        public void LogowanieNaKlienta(string email, string haslo, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("haslo", haslo);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logowanie na klienta", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
  this.FeatureBackground();
#line hidden
#line 12
    testRunner.Given("znajduje się na podstronie \"Moje konto\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 13
    testRunner.Then(string.Format("Wybieram pole do logowania i wprowadzam \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
#line 14
    testRunner.And(string.Format("Wybieram pole z hasłem i wprowadzam \"{0}\"", haslo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Oraz ");
#line hidden
#line 15
    testRunner.And("wybieram \"Zaloguj się\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 16
    testRunner.Then("Znajduję się w edycji mojego konta i mam zakładkę \"Kokpit\".", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
