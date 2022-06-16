// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
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

            foreach (var testCase in This.MockTestCases)
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

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
