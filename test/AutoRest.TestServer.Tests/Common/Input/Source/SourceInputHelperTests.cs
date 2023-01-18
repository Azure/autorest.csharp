// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input.Source;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Utilities.Tests
{
    public class SourceInputHelperTests
    {
        private Compilation _compilation;

        private INamedTypeSymbol _nullableIntSymbol;
        private INamedTypeSymbol _listSymbol;
        private INamedTypeSymbol _modelSymbol;

        [OneTimeSetUp]
        public void InitAsync()
        {
            var tree = CSharpSyntaxTree.ParseText(@"
using System.Collections.Generic;

namespace SourceInputHelperTests
{
    public class SourceInputMetadata
    {
        public class MetadataModel
        {
        }
        public void Method(int? nullableInt, List<int> genericList, MetadataModel metadataModel)
        {
        }
    }
}");
            var corlibLocation = typeof(object).Assembly.Location;
            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(corlibLocation)
            };
            _compilation = CSharpCompilation.Create("TestCode", syntaxTrees: new[] { tree }, references: references);

            var members = _compilation.GetTypeByMetadataName("SourceInputHelperTests.SourceInputMetadata").GetMembers();
            foreach (var member in members)
            {
                if (member is IMethodSymbol method && method.Name == "Method")
                {
                    foreach (var parameter in method.Parameters)
                    {
                        switch (parameter.Name)
                        {
                            case "nullableInt":
                                _nullableIntSymbol = (INamedTypeSymbol)parameter.Type;
                                break;
                            case "genericList":
                                _listSymbol = (INamedTypeSymbol)parameter.Type;
                                break;
                            case "metadataModel":
                                _modelSymbol = (INamedTypeSymbol)parameter.Type;
                                break;
                        }
                    }
                }
            }

            Configuration.Initialize("Generated", "", "", new string[] { }, false, false, true, false, false, false, false, false, false, false, Configuration.UnreferencedTypesHandlingOption.RemoveOrInternalize, ".", null, new string[] { }, new List<string>(), null, null);
        }

        [Test]
        public void IsEqualType_PrimitiveTypes()
        {
            // System.Int32
            INamedTypeSymbol intSymbol = _compilation.GetTypeByMetadataName("System.Int32");
            CSharpType intType = new CSharpType(typeof(int));
            Assert.IsTrue(SourceInputHelper.IsEqualType(intSymbol, intType));

            Assert.IsFalse(SourceInputHelper.IsEqualType(_nullableIntSymbol, intType));

            CSharpType nullableIntType = new CSharpType(typeof(int), true);
            Assert.IsTrue(SourceInputHelper.IsEqualType(_nullableIntSymbol, nullableIntType));

            Assert.IsFalse(SourceInputHelper.IsEqualType(intSymbol, nullableIntType));

            // System.String
            INamedTypeSymbol stringSymbol = _compilation.GetTypeByMetadataName("System.String");
            CSharpType stringType = new CSharpType(typeof(string));
            Assert.IsTrue(SourceInputHelper.IsEqualType(stringSymbol, stringType));

            // System.Collections.Generic.List
            CSharpType listType = new CSharpType(typeof(List<int>));
            Assert.IsTrue(SourceInputHelper.IsEqualType(_listSymbol, listType));

            // Mix
            Assert.IsFalse(SourceInputHelper.IsEqualType(intSymbol, stringType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(intSymbol, listType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(stringSymbol, intType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(_listSymbol, intType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(_listSymbol, nullableIntType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(stringSymbol, nullableIntType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(_nullableIntSymbol, stringType));
            Assert.IsFalse(SourceInputHelper.IsEqualType(_nullableIntSymbol, listType));
        }

        [Test]
        public void IsEqualType_ModelTypes()
        {
            // Different namespace
            var input = new InputModelType("MetadataModel", "", null, null, null, InputModelTypeUsage.RoundTrip, null, null, null, null, null);
            CSharpType modelType = new CSharpType(new ModelTypeProvider(input, "", null));
            Assert.IsFalse(SourceInputHelper.IsEqualType(_modelSymbol, modelType));

            // Same namespace
            input = new InputModelType("MetadataModel", "SourceInputHelperTests", null, null, null, InputModelTypeUsage.RoundTrip, null, null, null, null, null);
            modelType = new CSharpType(new ModelTypeProvider(input, "SourceInputHelperTests", null));
            Assert.IsTrue(SourceInputHelper.IsEqualType(_modelSymbol, modelType));
        }
    }
}
