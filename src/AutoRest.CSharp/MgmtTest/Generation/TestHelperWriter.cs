// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.MgmtTest.Generation
{
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
            _writer.UseNamespace("System");
            _writer.UseNamespace("System.Threading.Tasks");
            _writer.UseNamespace($"{_context.DefaultNamespace}.Models");
            _writer.UseNamespace("Azure.ResourceManager.Resources");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test Extension for {_context.DefaultNamespace}");
                _writer.Append($"public static partial class {TypeNameOfThis:D}");
                using (_writer.Scope())
                {
                    foreach (var resourceCollection in _context.Library.ResourceCollections)
                    {
                        var collectionWriter = new ResourceCollectionTestWriter(_writer, resourceCollection, _context);
                        if (resourceCollection.CreateOperation is not null)
                        {
                            collectionWriter.WriteExampleInstanceMethod(resourceCollection.CreateOperation, true);
                        }
                        //// disable since can't successed in stateful mock test. enable this if use stateless mock test
                        //if (resourceCollection.GetOperation is not null)
                        //{
                        //    collectionWriter.WriteExampleInstanceMethod(resourceCollection.GetOperation, true);
                        //}
                        foreach (var clientOperation in resourceCollection.ClientOperations)
                        {
                            collectionWriter.WriteExampleInstanceMethod(clientOperation, true);
                        }
                    }

                    WriteCreateResourceGroupMethod();
                    WriteReplaceWith();
                }
            }
        }

        public void WriteCreateResourceGroupMethod()
        {
            _writer.UseNamespace("Azure.ResourceManager");
            using (_writer.Scope($"public static async Task<ResourceGroup> CreateResourceGroupAsync(string resourceGroupName, ArmClient client)"))
            {
                _writer.Line($"var defaultSubscription = await client.GetDefaultSubscriptionAsync();");
                using (_writer.Scope($"var rgop = await defaultSubscription.GetResourceGroups().CreateOrUpdateAsync", start: "(", end: ")", newLine: false))
                {
                    _writer.Line($"resourceGroupName,");
                    _writer.Line($"new ResourceGroupData(defaultSubscription.ToString()) {{ Tags = {{ {{ \"test\", \"env\" }} }} }}");
                }
                _writer.Line($";");
                _writer.Append($"return rgop.Value;");
            }
            _writer.Line();
        }

        public void WriteReplaceWith()
        {
            _writer.UseNamespace("System.Collections.Generic");
            using (_writer.Scope($"public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)"))
            {
                _writer.Line($"dest.Clear();");
                using (_writer.Scope($"foreach (var kv in src)"))
                {
                    _writer.Line($"dest.Add(kv);");
                }
                _writer.Line($"return dest;");
            }
            _writer.Line();
        }
    }
}
