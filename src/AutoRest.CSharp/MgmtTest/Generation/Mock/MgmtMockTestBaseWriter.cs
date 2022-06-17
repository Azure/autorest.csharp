// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal abstract class MgmtMockTestBaseWriter
    {
        protected CodeWriter _writer;
        private MgmtTestTypeProvider This { get; }

        public MgmtMockTestBaseWriter(CodeWriter writer, MgmtTestTypeProvider typeProvider)
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

        protected abstract void WriteTestMethodBody(MockTestCase testCase);

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

        protected CodeWriterDeclaration WriteGetResource(MgmtTypeProvider parent, MockTestCase testCase)
            => parent switch
            {
                Resource parentResource => WriteGetResource(parentResource, testCase),
                MgmtExtensions parentExtension => WriteGetExtension(parentExtension, testCase),
                _ => throw new InvalidOperationException($"Unknown parent {parent.GetType()}"),
            };

        protected CodeWriterDeclaration WriteGetResource(Resource parentResource, MockTestCase testCase)
        {
            var idVar = new CodeWriterDeclaration($"{parentResource.Type.Name}Id".ToVariableName());
            _writer.Append($"var {idVar:D} = {parentResource.Type}.CreateResourceIdentifier(");
            foreach (var value in testCase.ComposeResourceIdentifierParameterValues(parentResource.RequestPath))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
            var resourceVar = new CodeWriterDeclaration(parentResource.Type.Name.ToVariableName());
            _writer.Line($"var {resourceVar:D} = GetArmClient().Get{parentResource.Type.Name}({idVar});");

            return resourceVar;
        }

        protected CodeWriterDeclaration WriteGetExtension(MgmtExtensions parentExtension, MockTestCase testCase)
        {
            var resourceVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            if (parentExtension == MgmtContext.Library.TenantExtensions)
            {
                _writer.UseNamespace("System.Linq");
                _writer.Line($"var {resourceVar:D} = GetArmClient().GetTenants().First();");
            }
            else
            {
                var idVar = new CodeWriterDeclaration($"{parentExtension.ArmCoreType.Name}Id".ToVariableName());
                _writer.Append($"var {idVar:D} = {parentExtension.ArmCoreType}.CreateResourceIdentifier(");
                foreach (var value in testCase.ComposeResourceIdentifierParameterValues(parentExtension.ContextualPath))
                {
                    _writer.Append(value).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.LineRaw(");");
                _writer.Line($"var {resourceVar:D} = GetArmClient().Get{parentExtension.ArmCoreType.Name}({idVar});");
            }

            return resourceVar;
        }

        protected void WriteTestOperation(CodeWriterDeclaration declaration, MockTestCase testCase)
        {
            // we will always use the Async version of methods
            if (testCase.ClientOperation.IsPagingOperation)
            {
                _writer.Append($"await foreach (var _ in ");
                WriteTestMethodInvocation(declaration, testCase);
                using (_writer.Scope($")"))
                { }
            }
            else
            {
                _writer.Append($"await ");
                WriteTestMethodInvocation(declaration, testCase);
                _writer.LineRaw(";");
            }
        }

        protected void WriteTestMethodInvocation(CodeWriterDeclaration declaration, MockTestCase testCase)
        {
            var clientOperation = testCase.ClientOperation;
            var methodName = CreateMethodName(clientOperation.Name);
            _writer.Append($"{declaration}.{methodName}(");
            foreach (var parameter in clientOperation.MethodParameters)
            {
                if (testCase.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
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
