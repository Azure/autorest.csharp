// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Common.Generation.Writers;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource test.
    /// </summary>
    internal class ScenarioTestWriter: ClientWriter
    {
        private TestDefinitionModel _testDef;
        private CodeWriter _writer;
        protected string TestNamespace => MgmtContext.Context.DefaultNamespace + ".Tests.Scenario";
        public string TypeName => System.IO.Path.GetFileNameWithoutExtension(_testDef.FilePath).ToCleanName();
        protected string TestBaseName => $"ManagementRecordedTestBase<{MgmtContext.Context.DefaultLibraryName}TestEnvironment>";

        public ScenarioTestWriter(CodeWriter writer, TestDefinitionModel testDef)
        {
            this._testDef = testDef;
            this._writer = writer;
        }

        public void WriteScenarioTest()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test generated from Api Scenario {_testDef.FilePath}");
                _writer.Append($"public partial class {TypeName:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();

                    WritePrepareMethod();
                    WriteCleanUpMethod();

                    foreach (var scenario in _testDef.Scenarios)
                    {
                        WriteScenarioMethod(scenario);
                    }
                }
            }
        }

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WritePrepareMethod()
        {
            // TODO: generate prepare step
        }

        protected void WriteCleanUpMethod()
        {
            // TODO: generate cleanUp step
        }

        protected IEnumerable<string> GetAllScenarioDefinedVariables(Scenario? scenario, TestStep step)
        {
            HashSet<string> scenarioDefinedVariables = _testDef.GetAllVariableNames();
            if (scenario is not null)
            {
                scenarioDefinedVariables.UnionWith(scenario.GetAllVariableNames());
            }
            scenarioDefinedVariables.UnionWith(step.GetAllVariableNames());
            return scenarioDefinedVariables;
        }

        protected void WriteStep(Scenario? scenario, TestStep step)
        {
            _writer.Line($"// Step: {step.Step}");
            var existedVariables = _testDef.GetAllVariableNames();
            if (scenario is not null)
            {
                existedVariables.UnionWith(scenario.GetAllVariableNames());
            }
            using (new CodeWriterOavVariableScope(_writer, step, existedVariables))
            {
                WriteVariableInitializations(step, existedVariables);
                IEnumerable<string> scenarioDefinedVariables = this.GetAllScenarioDefinedVariables(scenario, step);
                if (step.Type == TestStepType.RestCall && step.ExampleModel is not null)
                {
                    if (step.ExampleModel.Operation.IsResourceOperation(out Resource? resource, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation))
                    {
                        ResourceTestWriter testWriter = new ResourceTestWriter(_writer, resource!, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(resource!, clientOperation!, restOperation!, step.ExampleModel, true, resource!.DeleteOperation == clientOperation);
                    }
                    else if (step.ExampleModel.Operation.IsCollectionOperation(out ResourceCollection? collection, out clientOperation, out restOperation))
                    {
                        ResourceCollectionTestWriter testWriter = new ResourceCollectionTestWriter(_writer, collection!, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(collection!, clientOperation!, restOperation!, step.ExampleModel, true, collection!.CreateOperation == clientOperation);
                    }
                    else if (step.ExampleModel.Operation.IsSubscriptionOperation(out clientOperation, out restOperation))
                    {
                        MgmtExtensionTestWriter testWriter = new MgmtExtensionTestWriter(_writer, MgmtContext.Library.SubscriptionExtensions, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(clientOperation!, restOperation!, step.ExampleModel, true, false);
                    }
                    else
                    {
                        _writer.Line($"// Operation is not implemented for this Step!");
                    }
                }
                else if (step.Type == TestStepType.ArmTemplateDeployment && step.ArmTemplatePayload is not null)
                {
                    var templatePayload = new CodeWriterDeclaration("templatePayload");
                    _writer.Line($"var {templatePayload:D} = {Newtonsoft.Json.JsonConvert.SerializeObject(step.ArmTemplatePayload).RefScenarioDefinedVariables(scenarioDefinedVariables)};");
                    // writer.Line($"var {templatePayload:D} = {System.Text.Json.JsonDocument.ParseValue(new System.Text.Json.Utf8JsonReader( step.ArmTemplatePayload)).RefScenarioDefinedVariables(scenarioDefinedVariables)};");
                    var deploymentOperation = new CodeWriterDeclaration("deploymentOperation");
                    using (_writer.Scope($"var {deploymentOperation:D} = await resourceGroup.GetDeployments().CreateOrUpdateAsync(true, {step.Step:L}, new Resources.Models.DeploymentInput(new Resources.Models.DeploymentProperties(Resources.Models.DeploymentMode.Complete)", "{", "}));"))
                    {
                        _writer.Append($"Template = {typeof(System.Text.Json.JsonDocument)}.Parse({templatePayload}).RootElement");
                        _writer.Line($",");
                    }

                    var outputs = new CodeWriterDeclaration("deployOutputs");
                    using (_writer.Scope($"if ({deploymentOperation}.Value.Data.Properties.Outputs is Dictionary<string, object> {outputs:D})"))
                    {
                        foreach (var variableName in step.OutputVariableNames)
                        {
                            var element = new CodeWriterDeclaration("outputVariable");
                            using (_writer.Scope($"if ({outputs}.ContainsKey(\"{variableName}\") && {outputs}[\"{variableName}\"] is Dictionary<string, object> {element:D})"))
                            {
                                _writer.Line($"{variableName} = {element}[\"value\"].ToString();");
                            }
                        }
                    }
                }
            }
            _writer.Line();
        }

        protected void WriteScenarioMethod(Scenario scenario)
        {
            _writer.Line($"[RecordedTest]");
            using (_writer.Scope($"public async {typeof(Task)} {(scenario.ScenarioName ?? scenario.Description).ToCleanName()}()"))
            {
                _writer.Line($"// API Scenario: {scenario.Description}");

                var existedVariables = _testDef.GetAllVariableNames();
                using (new CodeWriterOavVariableScope(_writer, scenario, existedVariables))
                {
                    WriteVariableInitializations(scenario, existedVariables);
                    _writer.Line($"resourceGroupName = Recording.GenerateAssetName(resourceGroupName);");
                    _writer.Line($"resourceGroup = (await GetArmClient().GetSubscription(new {typeof(ResourceIdentifier)}($\"/subscriptions/{{subscriptionId}}\")).GetResourceGroups().CreateOrUpdateAsync(true, resourceGroupName, new {typeof(ResourceGroupData)}(new {typeof(AzureLocation)}(location)))).Value;");

                    foreach (var step in scenario.Steps)
                    {
                        using (_writer.Scope())
                        {
                            WriteStep(scenario, step);
                        }
                        _writer.Line();
                    }
                }
            }
            _writer.Line();
        }

        protected void WriteVariableInitializations(OavVariableScope ovs, IEnumerable<string> existedVarialbes)
        {
            IEnumerable<string> requiredVariables = ovs.RequiredVariables;
            IReadOnlyDictionary<string, string> requiredVariableDefault = ovs.RequiredVariablesDefault;
            var variables = ovs.Variables;

            if (ovs is TestDefinitionModel)
            foreach (var requiredVariable in requiredVariables)
            {
                if (!existedVarialbes.Contains(requiredVariable))
                {
                    _writer.Append($"string {new CodeWriterDeclaration(requiredVariable):D} = {typeof(Environment)}.GetEnvironmentVariable(\"{requiredVariable.ToSnakeCase().ToUpper()}\")");
                }
                else
                {
                    _writer.Append($"{requiredVariable} = {typeof(Environment)}.GetEnvironmentVariable(\"{requiredVariable.ToSnakeCase().ToUpper()}\")");
                }
                if (requiredVariableDefault.ContainsKey(requiredVariable))
                {
                    _writer.Append($" ?? {requiredVariableDefault[requiredVariable]:L}");
                }
                _writer.Line($";");
            }

            foreach (var variable in variables.Keys)
            {
                var defaultValue = ovs.GetVariableDefaultValue(variable).RefScenarioDefinedVariables(existedVarialbes);
                if (!requiredVariables.Contains(variable) && !existedVarialbes.Contains(variable))
                {
                    _writer.Line($"string {new CodeWriterDeclaration(variable):D} = {defaultValue};");
                }
                else
                {
                    _writer.Line($"{variable} = {defaultValue};");
                }
            }

            if (ovs is not TestDefinitionModel && variables.Count>0)
            {
                _writer.Append($"{typeof(Console)}.WriteLine($\"{(ovs is Scenario ? "Scenario": "Step")} variables: ");
                foreach (var variable in variables.Keys)
                {
                    _writer.Append($"{variable} -> $\\\"{{{variable}}}\\\", ");
                }
                _writer.Line($"\");");
            }
            _writer.Line();
        }

        protected void WriteTesterCtors()
        {
            // write protected default constructor
            if (_testDef.Scope == TestDefinitionScope.ResourceGroup)
            {
                _writer.Line($"{typeof(ResourceGroup)} resourceGroup;");
            }

            if (!_testDef.RequiredVariables.Contains("resourceGroupName"))
            {
                _testDef.RequiredVariables.Add("resourceGroupName");
            }
            WriteVariableInitializations(_testDef, Enumerable.Empty<string>());

            using (_writer.Scope($"public {TypeName}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
            }
            _writer.Line();
        }
    }
}
