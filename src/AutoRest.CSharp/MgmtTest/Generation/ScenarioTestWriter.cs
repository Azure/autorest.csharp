// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Common.Generation.Writers;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource test.
    /// </summary>
    internal class ScenarioTestWriter: ClientWriter
    {
        protected TestDefinitionModel testDef;
        protected CodeWriter writer;
        protected string TestNamespace => MgmtContext.Context.DefaultNamespace + ".Tests.Scenario";
        public string TypeName => System.IO.Path.GetFileNameWithoutExtension(testDef.FilePath).ToCleanName();
        protected string TestBaseName => $"ManagementRecordedTestBase<{MgmtContext.Context.DefaultLibraryName}TestEnvironment>";

        public ScenarioTestWriter(CodeWriter writer, TestDefinitionModel testDef)
        {
            this.testDef = testDef;
            this.writer = writer;
        }

        public void WriteScenarioTest()
        {
            WriteUsings(writer);

            using (writer.Namespace(TestNamespace))
            {
                writer.WriteXmlDocumentationSummary($"Test generated from Api Scenario {testDef.FilePath}");
                writer.Append($"public partial class {TypeName:D} : ");
                writer.Line($"{TestBaseName}");
                using (writer.Scope())
                {
                    WriteTesterCtors();

                    WritePrepareMethod();
                    WriteCleanUpMethod();

                    foreach (var scenario in testDef.Scenarios)
                    {
                        WriteScenarioMethod(scenario);
                    }
                }
            }
        }

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace("System");
            writer.UseNamespace("System.Threading.Tasks");
            writer.UseNamespace("System.Net");
            writer.UseNamespace("System.Collections.Generic");
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WritePrepareMethod() {

        }

        protected void WriteCleanUpMethod()
        {

        }

        protected void FindResourceOrCollectionFromOperation(Operation operation, out Resource? resource, out ResourceCollection? collection, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation)
        {
            resource = null;
            collection = null;
            clientOperation = null;
            restOperation = null;
            foreach (var r in MgmtContext.Library.ArmResources) {
                foreach (var co in r.AllOperations) {
                    foreach (var ro in co) {
                        if (ro.Operation == operation) {
                            resource = r;
                            clientOperation = co;
                            restOperation = ro;
                            return;
                        }
                    }
                }
            }
            foreach (var c in MgmtContext.Library.ResourceCollections) {
                foreach (var co in c.AllOperations) {
                    foreach (var ro in co) {
                        if (ro.Operation == operation) {
                            collection = c;
                            clientOperation = co;
                            restOperation = ro;
                            return;
                        }
                    }
                }
            }
        }

        protected bool IsCollectionOperation(Operation operation, out ResourceCollection? collection, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation)
        {
            collection = null;
            clientOperation = null;
            restOperation = null;
            foreach (var c in MgmtContext.Library.ResourceCollections)
            {
                foreach (var co in c.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            collection = c;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected bool IsResourceOperation(Operation operation, out Resource? resource, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation)
        {
            resource = null;
            clientOperation = null;
            restOperation = null;
            foreach (var r in MgmtContext.Library.ArmResources)
            {
                foreach (var co in r.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            resource = r;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected bool IsSubscriptionOperation(Operation operation, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation)
        {
            clientOperation = null;
            restOperation = null;
            foreach (var co in MgmtContext.Library.SubscriptionExtensions.ClientOperations)
            {
                foreach (var ro in co)
                {
                    if (ro.Operation == operation)
                    {
                        clientOperation = co;
                        restOperation = ro;
                        return true;
                    }
                }
            }
            return false;
        }


        protected IEnumerable<string> GetAllScenarioDefinedVariables(Scenario? scenario, TestStep step)
        {
            HashSet<string> scenarioDefinedVariables = testDef.GetAllVariableNames();
            if (scenario is not null)
            {
                scenarioDefinedVariables.UnionWith(scenario.GetAllVariableNames());
            }
            scenarioDefinedVariables.UnionWith(step.GetAllVariableNames());
            return scenarioDefinedVariables;
        }

        protected void WriteStep(Scenario? scenario, TestStep step)
        {
            writer.Line($"// Step: {step.Step}");
            var existedVariables = testDef.GetAllVariableNames();
            if (scenario is not null)
            {
                existedVariables.UnionWith(scenario.GetAllVariableNames());
            }
            using (new CodeWriterOavVariableScope(writer, step, existedVariables))
            {
                WriteVariableInitializations(step, existedVariables);
                IEnumerable<string> scenarioDefinedVariables = this.GetAllScenarioDefinedVariables(scenario, step);
                if (step.Type == TestStep.StepType_RestCall && step.ExampleModel is not null)
                {
                    if (IsResourceOperation(step.ExampleModel.Operation, out Resource? resource, out MgmtClientOperation? clientOperation, out MgmtRestOperation? restOperation))
                    {
                        ResourceTestWriter testWriter = new ResourceTestWriter(writer, resource!, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(resource!, clientOperation!, restOperation!, step.ExampleModel, true, resource!.DeleteOperation == clientOperation);
                    }
                    else if (IsCollectionOperation(step.ExampleModel.Operation, out ResourceCollection? collection, out clientOperation, out restOperation))
                    {
                        ResourceCollectionTestWriter testWriter = new ResourceCollectionTestWriter(writer, collection!, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(collection!, clientOperation!, restOperation!, step.ExampleModel, true, collection!.CreateOperation == clientOperation);
                    }
                    else if (IsSubscriptionOperation(step.ExampleModel.Operation, out clientOperation, out restOperation))
                    {
                        MgmtExtensionTestWriter testWriter = new MgmtExtensionTestWriter(writer, MgmtContext.Library.SubscriptionExtensions, scenarioDefinedVariables);
                        testWriter.WriteOperationInvocation(clientOperation!, restOperation!, step.ExampleModel, true, false);
                    }
                    else
                    {
                        writer.Line($"// Operation is not implemented for this Step!");
                    }
                }
                else if (step.Type == TestStep.StepType_ArmTemplateDeployment && step.ArmTemplatePayload is not null)
                {
                    var templatePayload = new CodeWriterDeclaration("templatePayload");
                    writer.Line($"var {templatePayload:D} = {Newtonsoft.Json.JsonConvert.SerializeObject(step.ArmTemplatePayload).RefScenariDefinedVariables(scenarioDefinedVariables)};");
                    var deploymentOperation = new CodeWriterDeclaration("deploymentOperation");
                    using (writer.Scope($"var {deploymentOperation:D} = await resourceGroup.GetDeployments().CreateOrUpdateAsync(true, {step.Step:L}, new Resources.Models.DeploymentInput(new Resources.Models.DeploymentProperties(Resources.Models.DeploymentMode.Complete)", "{", "}));"))
                    {
                        writer.Append($"Template = {typeof(System.Text.Json.JsonDocument)}.Parse({templatePayload}).RootElement");
                        writer.Line($",");
                    }

                    var outputs = new CodeWriterDeclaration("deployOutputs");
                    using (writer.Scope($"if ({deploymentOperation}.Value.Data.Properties.Outputs is Dictionary<string, object> {outputs:D})"))
                    {
                        foreach (var variableName in step.OutputVariableNames ?? new List<string>())
                        {
                            var element = new CodeWriterDeclaration("outputVariable");
                            using (writer.Scope($"if ({outputs}.ContainsKey(\"{variableName}\") && {outputs}[\"{variableName}\"] is Dictionary<string, object> {element:D})"))
                            {
                                writer.Line($"{variableName} = {element}[\"value\"].ToString();");
                            }
                        }
                    }
                }
            }
            writer.Line();
        }

        protected void WriteScenarioMethod(Scenario scenario)
        {
            writer.Line($"[RecordedTest]");
            using (writer.Scope($"public async Task {(scenario.ScenarioName ?? scenario.Description).ToCleanName()}()"))
            {
                writer.Line($"// API Scenario: {scenario.Description}");

                var existedVariables = testDef.GetAllVariableNames();
                using (new CodeWriterOavVariableScope(writer, scenario, existedVariables))
                {
                    WriteVariableInitializations(scenario, existedVariables);
                    writer.Line($"resourceGroupName = Recording.GenerateAssetName(resourceGroupName);");
                    writer.Line($"resourceGroup = (await GetArmClient().GetSubscription(new ResourceIdentifier($\"/subscriptions/{{subscriptionId}}\")).GetResourceGroups().CreateOrUpdateAsync(true, resourceGroupName, new ResourceGroupData(new AzureLocation(location)))).Value;");

                    foreach (var step in scenario.Steps)
                    {
                        using (writer.Scope())
                        {
                            WriteStep(scenario, step);
                        }
                        writer.Line();
                    }
                }
            }
            writer.Line();
        }

        protected void WriteVariableInitializations(OavVariableScope ovs, IEnumerable<string> existedVarialbes)
        {
            IEnumerable<string> requiredVariables = ovs.RequiredVariables ?? new List<string>();
            Dictionary<string, string> requiredVariableDefault = ovs.RequiredVariablesDefault ?? new Dictionary<string, string>();
            var variables = ovs.Variables ?? new Dictionary<string, object?>();

            if (ovs is TestDefinitionModel)
            foreach (var requiredVariable in requiredVariables)
            {
                if (!existedVarialbes.Contains(requiredVariable))
                {
                    writer.Append($"string {new CodeWriterDeclaration(requiredVariable):D} = Environment.GetEnvironmentVariable(\"{requiredVariable.ToSnakeCase().ToUpper()}\")");
                }
                else
                {
                    writer.Append($"{requiredVariable} = Environment.GetEnvironmentVariable(\"{requiredVariable.ToSnakeCase().ToUpper()}\")");
                }
                if (requiredVariableDefault.ContainsKey(requiredVariable))
                {
                    writer.Append($" ?? {requiredVariableDefault[requiredVariable]:L}");
                }
                writer.Line($";");
            }

            foreach (var variable in variables.Keys)
            {
                var defaultValue = ovs.GetVariableDefaultValue(variable).RefScenariDefinedVariables(existedVarialbes);
                if (!requiredVariables.Contains(variable) && !existedVarialbes.Contains(variable))
                {
                    writer.Line($"string {new CodeWriterDeclaration(variable):D} = {defaultValue};");
                }
                else
                {
                    writer.Line($"{variable} = {defaultValue};");
                }
            }

            if (ovs is not TestDefinitionModel && variables.Count()>0)
            {
                writer.Append($"Console.WriteLine($\"{(ovs is Scenario? "Scenario": "Step")} variables: ");
                foreach (var variable in variables.Keys)
                {
                    writer.Append($"{variable} -> $\\\"{{{variable}}}\\\", ");
                }
                writer.Line($"\");");
            }
            writer.Line();
        }

        protected void WriteTesterCtors()
        {
            // write protected default constructor
            if (testDef.Scope == TestDefinitionModel.Scope_ResourceGroup)
            {
                writer.Line($"{typeof(ResourceGroup)} resourceGroup;");
            }

            if (!(testDef.RequiredVariables?.Contains("resourceGroupName") is true))
            {
                testDef.RequiredVariables?.Add("resourceGroupName");
            }
            WriteVariableInitializations(testDef, Enumerable.Empty<string>());

            using (writer.Scope($"public {TypeName}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
            }
            writer.Line();
        }
    }
}
