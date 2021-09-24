// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using System.Text.Json;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource container.
    /// A resource container should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class TestHelperWriter
    {
        private CodeWriter _writer;
        private CodeWriter _tagsWriter = new CodeWriter();
        private BuildContext<MgmtOutputLibrary> _context;

        protected string TestNamespace => _context.DefaultNamespace + ".Tests";
        protected string TypeNameOfThis => "TestHelper";

        public TestHelperWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _context = context;
        }

        public void WriteMockExtension()
        {
            _writer.UseNamespace("System.Threading.Tasks");
            _writer.UseNamespace(_context.DefaultNamespace);
            _writer.UseNamespace($"{_context.DefaultNamespace}.Models");
            _writer.UseNamespace("NUnit.Framework");
            _writer.UseNamespace("Azure.Core.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.Resources");
            _writer.UseNamespace("Azure.ResourceManager.Compute.Tests.Helpers");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test Extension for {_context.DefaultNamespace}");
                _writer.Append($"public static partial class {TypeNameOfThis:D}");
                using (_writer.Scope())
                {

                    foreach (var resourceContainer in _context.Library.ResourceContainers)
                    {
                        var containerWriter = new ResourceContainerTestWriter(_writer, resourceContainer, _context);
                        if (resourceContainer.CreateMethod is not null)
                        {
                            containerWriter.WriteExampleInstanceMethod(resourceContainer.CreateMethod, _context, true, "CreateOrUpdate");
                            containerWriter.WriteExampleInstanceMethod(resourceContainer.CreateMethod, _context, false, "CreateOrUpdate");
                        }
                        if (resourceContainer.GetMethod is not null)
                        {
                            containerWriter.WriteExampleInstanceMethod(resourceContainer.GetMethod.RestClientMethod, _context, true, "Get");
                            containerWriter.WriteExampleInstanceMethod(resourceContainer.GetMethod.RestClientMethod, _context, false, "Get");
                        }
                    }

                    WriteCreateResourceGroupMethod();
                }
            }
        }

        public void WriteCreateResourceGroupMethod()
        {
            using (_writer.Scope($"public static async Task<ResourceGroup> CreateResourceGroupAsync(string resourceGroupName, ArmClient client)"))
            {
                using (_writer.Scope($"return await client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync", start: "(", end: ")", newLine: false))
                {
                    _writer.Line($"resourceGroupName,");
                    _writer.Line($"new ResourceGroupData(client.DefaultSubscription.ToString()) {{ Tags = {{ {{ \"test\", \"env\" }} }} }}");
                }
                _writer.Append($";");
            }
            _writer.Line();
            using (_writer.Scope($"public static ResourceGroup CreateResourceGroup(string resourceGroupName, ArmClient client)"))
            {
                using (_writer.Scope($"return client.DefaultSubscription.GetResourceGroups().CreateOrUpdate", start: "(", end: ")", newLine: false))
                {
                    _writer.Line($"resourceGroupName,");
                    _writer.Line($"new ResourceGroupData(client.DefaultSubscription.ToString()) {{ Tags = {{ {{ \"test\", \"env\" }} }} }}");
                }
                _writer.Append($";");
            }
        }
    }
}
