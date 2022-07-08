// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using System.Text.RegularExpressions;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal abstract class MgmtMockTestBaseWriter<TProvider> where TProvider : MgmtTypeProvider
    {
        protected CodeWriter _writer;
        protected MgmtMockTestProvider<TProvider> This { get; }

        protected bool generatingSample = false;
        protected List<string> parameterVariables = new List<string>();

        public MgmtMockTestBaseWriter(CodeWriter writer, MgmtMockTestProvider<TProvider> typeProvider)
        {
            _writer = writer;
            This = typeProvider;
        }

        public virtual void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteImplementations();
                }
            }
        }

        public virtual void WriteSample(MockTestCase testCase)
        {
            generatingSample = true;
            Regex pattern = new Regex(@".*(Azure.ResourceManager.\w+)/.*");
            Match match = pattern.Match(Configuration.OutputFolder);
            if (match.Success)
            {
                _writer.additionalComments.Add($"// Need to install {match.Groups[1].Value} v1.0.0 to execute below sample code");
            }
            _writer.addUsingRegion = true;
            _writer.UseNamespace("Azure.ResourceManager");
            _writer.UseNamespace("System");
            _writer.UseNamespace("Azure.Identity");
            _writer.UseNamespace("System.Threading.Tasks");

            _writer.Line($"#region Parameter decalarations");
            _writer.Line($"// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.");
            _writer.Line($"ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());");
            //RequestPath requestPath = testCase.Carrier switch
            //{
            //    ResourceCollection parentCollection => parentCollection.RequestPath,
            //    Resource parentResource => parentResource.RequestPath,
            //    MgmtExtensions parentExtension => parentExtension.ContextualPath,
            //    _ => throw new InvalidOperationException($"Unknown parent {testCase.Carrier.GetType()}"),
            //};
            RequestPath requestPath = testCase.RequestPath;
            foreach (var fs in testCase.ComposeResourceIdentifierParameterValues(requestPath, true))
            {
                var s = $"{fs}";
                // s = s.Substring(1, s.Length - 2);
                if (s == "subscriptionId")
                {
                    _writer.Line($"var subscriptionId = Environment.GetEnvironmentVariable(\"SUBSCRIPTION_ID\") ?? \"00000000-0000-0000-0000-000000000000\";");
                }
                else
                {
                    object? rawValue = null;
                    string? description = null;
                    foreach (var param in testCase.Example.AllParameters)
                    {
                        if (param.Parameter.Language.Default.SerializedName == s)
                        {
                            rawValue = param.ExampleValue.RawValue;
                            description = param.Parameter.Summary ?? param.Parameter.Language.Default.Description;
                        }
                    }
                    _writer.Append($"var {s} = ");
                    _writer.AppendRawValue(rawValue?.GetType() ?? typeof(object), rawValue);
                    if (description is not null)
                    {
                        _writer.Line($";  // {description}");
                    }
                    else
                    {
                        _writer.Line($";");
                    }
                    parameterVariables.Add(s);
                }
            }
            _writer.Line($"#endregion");
            _writer.Line($"");
            _writer.Line($"#region API invocation");
            _writer.Line($"// api-version: {testCase.RestOperation.Operation.ApiVersions.FirstOrDefault().Version}");
            _writer.Line($"// x-ms-original-file: {testCase.Example.OriginalFile}");
            WriteTestMethodBody(testCase);
            _writer.Line($"#endregion");
            generatingSample = false;
        }

        protected void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary(This.Description);
            _writer.Append($"{This.Accessibility} partial class {This.Type.Name}");
            if (This.BaseType != null)
            {
                _writer.Append($" : ");
                _writer.Append($"{This.BaseType:D}");
            }
            _writer.Line();
        }

        protected internal virtual void WriteImplementations()
        {
            WriteCtors();

            WriteTestMethods();
        }

        protected virtual void WriteCtors()
        {
            if (This.Ctor is not null)
            {
                using (_writer.WriteMethodDeclaration(This.Ctor))
                {
                    _writer.Line($"{typeof(ServicePointManager)}.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;");
                    _writer.Line($"{typeof(Environment)}.SetEnvironmentVariable(\"RESOURCE_MANAGER_URL\", $\"https://localhost:8443\");");
                }
                _writer.Line();
            }
        }

        protected virtual void WriteTestMethods()
        {
            var testCaseDict = new Dictionary<MgmtClientOperation, List<MockTestCase>>();
            foreach (var testCase in This.MockTestCases)
            {
                testCaseDict.AddInList(testCase.ClientOperation, testCase);
            }

            foreach (var testCase in This.MockTestCases.OrderBy(testCase => testCase.ClientOperation.Name))
            {
                WriteTestMethod(testCase, testCaseDict[testCase.ClientOperation].Count > 1);
                _writer.Line();
            }
        }

        protected virtual void WriteTestMethod(MockTestCase testCase, bool hasSuffix)
        {
            WriteTestAttribute();
            // TODO -- find a way to determine when we need to add the suffix
            using (_writer.WriteMethodDeclaration(testCase.GetMethodSignature(hasSuffix)))
            {
                WriteTestMethodBody(testCase);
            }
        }

        protected virtual void WriteTestMethodBody(MockTestCase testCase)
        {
        }

        protected void WriteTestAttribute()
        {
            _writer.Line($"[RecordedTest]");

            string? ignoreReason = Configuration.MgmtConfiguration.TestModeler?.IgnoreReason;
            if (ignoreReason is not null)
            {
                _writer.UseNamespace("NUnit.Framework");
                _writer.Line($"[typeofIgnore(\"{ignoreReason}\")]");
            }
        }

        protected string CreateMethodName(string methodName, bool async = true)
        {
            return async ? $"{methodName}Async" : methodName;
        }

        protected CodeWriterDeclaration WriteGetResource(MgmtTypeProvider carrierResource, MockTestCase testCase)
            => carrierResource switch
            {
                ResourceCollection => throw new InvalidOperationException($"ResourceCollection is not supported here"),
                Resource parentResource => WriteGetResource(parentResource, testCase),
                MgmtExtensions parentExtension => WriteGetExtension(parentExtension, testCase),
                _ => throw new InvalidOperationException($"Unknown parent {carrierResource.GetType()}"),
            };

        protected CodeWriterDeclaration WriteGetResource(Resource carrierResource, MockTestCase testCase)
        {
            var idVar = new CodeWriterDeclaration($"{carrierResource.Type.Name}Id".ToVariableName());
            _writer.Append($"var {idVar:D} = {carrierResource.Type}.CreateResourceIdentifier(");
            foreach (var value in testCase.ComposeResourceIdentifierParameterValues(carrierResource.RequestPath, generatingSample))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
            var resourceVar = new CodeWriterDeclaration(carrierResource.Type.Name.ToVariableName());
            _writer.Line($"var {resourceVar:D} = GetArmClient().Get{carrierResource.Type.Name}({idVar});");

            return resourceVar;
        }

        protected CodeWriterDeclaration WriteGetExtension(MgmtExtensions parentExtension, MockTestCase testCase) => parentExtension.ArmCoreType switch
        {
            _ when parentExtension.ArmCoreType == typeof(TenantResource) => WriteGetTenantResource(parentExtension, testCase),
            _ when parentExtension.ArmCoreType == typeof(ArmResource) => WriteGetArmResource(parentExtension, testCase),
            _ => WriteGetOtherExtension(parentExtension, testCase)
        };

        private CodeWriterDeclaration WriteGetTenantResource(MgmtExtensions parentExtension, MockTestCase testCase)
        {
            var resourceVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            _writer.UseNamespace("System.Linq");
            _writer.Line($"var {resourceVar:D} = GetArmClient().GetTenants().First();");
            return resourceVar;
        }

        private CodeWriterDeclaration WriteGetArmResource(MgmtExtensions parentExtension, MockTestCase testCase)
        {
            var resourceVar = new CodeWriterDeclaration("resource");
            // everytime we go into this branch, this resource must be a scope resource
            var idVar = new CodeWriterDeclaration($"resourceId");
            // this is the path of the scope of this operation
            var scopePath = testCase.RequestPath.GetScopePath();
            _writer.Append($"var {idVar:D} = new {typeof(ResourceIdentifier)}(");
            // we do not know exactly which resource the scope is, therefore we need to use the string.Format method to include those parameter values and construct a valid resource id of the scope
            _writer.Append($"{typeof(string)}.Format(\"");
            int refIndex = 0;
            foreach (var segment in scopePath)
            {
                _writer.AppendRaw("/");
                if (segment.IsConstant)
                    _writer.AppendRaw(segment.ConstantValue);
                else
                    _writer.Append($"{{{refIndex++}}}");
            }
            _writer.AppendRaw("\", ");
            foreach (var value in testCase.ComposeResourceIdentifierParameterValues(scopePath, generatingSample))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw("));");
            _writer.Line($"var {resourceVar:D} = GetArmClient().GetGenericResource({idVar});");
            return resourceVar;
        }

        private CodeWriterDeclaration WriteGetOtherExtension(MgmtExtensions parentExtension, MockTestCase testCase)
        {
            var resourceVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            var idVar = new CodeWriterDeclaration($"{parentExtension.ArmCoreType.Name}Id".ToVariableName());
            _writer.Append($"var {idVar:D} = {parentExtension.ArmCoreType}.CreateResourceIdentifier(");
            foreach (var value in testCase.ComposeResourceIdentifierParameterValues(parentExtension.ContextualPath, generatingSample))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");
            _writer.Line($"var {resourceVar:D} = GetArmClient().Get{parentExtension.ArmCoreType.Name}({idVar});");
            return resourceVar;
        }

        protected void WriteTestOperation(CodeWriterDeclaration declaration, MockTestCase testCase)
        {
            // we will always use the Async version of methods
            if (testCase.ClientOperation.IsPagingOperation)
            {
                _writer.Append($"{(generatingSample ? $"" : $"await ")}foreach (var _ in ");
                WriteTestMethodInvocation(declaration, testCase);
                using (_writer.Scope($")"))
                {
                    if (generatingSample && !testCase.ClientOperation.ReturnType.IsFrameworkType && testCase.ClientOperation.ReturnType.Implementation is Resource)
                    {
                        _writer.UseNamespace("System.Text.Json");
                        _writer.Line($"Console.WriteLine($\"ResourceId: {{_.Data.Id}}\");");
                        _writer.Line($"Console.WriteLine($\"Full Resource content: {{JsonSerializer.Serialize(_.Data)}}\");");
                    }
                }
            }
            else
            {
                CodeWriterDeclaration operation = new CodeWriterDeclaration("operation");
                if (generatingSample)
                {
                    _writer.Append($"var {operation:D} = ");
                }
                else
                {
                    _writer.Append($"await ");
                }
                WriteTestMethodInvocation(declaration, testCase);
                _writer.LineRaw(";");
                _writer.Line();
                if (generatingSample)
                {
                    if (testCase.ClientOperation.ReturnType.Name == "ArmOperation")
                    {
                        _writer.UseNamespace("System.Text.Json");
                        if (testCase.ClientOperation.ReturnType.Arguments.Length > 0 && testCase.ClientOperation.ReturnType.Arguments[0].Implementation is Resource)
                        {
                            _writer.Line($"Console.WriteLine($\"Succeed on ResourceId: {{{operation}.Value.Data.Id}}\");");
                            _writer.Line($"Console.WriteLine($\"Full Resource content: {{JsonSerializer.Serialize({operation}.Value.Data)}}\");");
                        }
                        else
                        {
                            _writer.Line($"Console.WriteLine($\"Response: {{JsonSerializer.Serialize({operation}.Value)}}\");");
                        }
                    }
                    else if (testCase.ClientOperation.ReturnType.Name == "Response" && testCase.ClientOperation.ReturnType.Arguments.Length > 0)
                    {
                        if (testCase.ClientOperation.ReturnType.Arguments[0].IsFrameworkType)
                        {
                            _writer.Line($"Console.WriteLine($\"Succeed with return: {{{operation}.Value}}\");");
                        }
                        else if (testCase.ClientOperation.ReturnType.Arguments[0].Implementation is Resource)
                        {
                            _writer.UseNamespace("System.Text.Json");
                            _writer.Line($"Console.WriteLine($\"Succeed on ResourceId: {{{operation}.Value.Data.Id}}\");");
                            _writer.Line($"Console.WriteLine($\"Full Resource content: {{JsonSerializer.Serialize({operation}.Value.Data)}}\");");
                        }
                        else
                        {
                            _writer.UseNamespace("System.Text.Json");
                            _writer.Line($"Console.WriteLine($\"Response: {{JsonSerializer.Serialize({operation}.Value)}}\");");
                        }
                    }
                    else
                    {
                        _writer.Line($"Console.WriteLine(\"Succeed.\");");
                    }
                }
            }
        }

        protected void WriteTestMethodInvocation(CodeWriterDeclaration declaration, MockTestCase testCase)
        {
            var clientOperation = testCase.ClientOperation;
            var methodName = CreateMethodName(clientOperation.Name, !generatingSample);
            _writer.Append($"{declaration}.{methodName}(");
            foreach (var parameter in clientOperation.MethodParameters)
            {
                if (testCase.ParameterSerializedNames.TryGetValue(parameter.Name, out var parameterVariable) && parameterVariables.Contains(parameterVariable))
                {
                    _writer.Append($"{parameterVariable},");
                }
                else if (testCase.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    _writer.AppendExampleParameterValue(parameter, parameterValue);
                    _writer.AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")");
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
