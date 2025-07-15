// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using NUnit.Framework;

namespace AutoRest.CSharp.Tests.Common.Generation.Writers
{
    public class ModelReaderWriterBuildableAttributesIntegrationTests
    {
        [Test]
        public void ValidateGeneratedAttributesFile()
        {
            // Create a mock model that would have IPersistableModel
            var writer = new ModelReaderWriterBuildableAttributesWriter();
            var types = new List<CSharpType>
            {
                new CSharpType(typeof(object), "TestNamespace", "TestModel1"),
                new CSharpType(typeof(object), "TestNamespace", "TestModel2")
            };
            
            var codeWriter = new CodeWriter();
            writer.WriteModelReaderWriterBuildableAttributes(codeWriter, types);
            
            var result = codeWriter.ToString();
            
            // Verify the output contains the expected elements
            Assert.Contains("using System.ClientModel.Primitives;", result);
            Assert.Contains("[assembly: ModelReaderWriterBuildableAttribute(typeof(TestModel1))]", result);
            Assert.Contains("[assembly: ModelReaderWriterBuildableAttribute(typeof(TestModel2))]", result);
            
            // Verify ordering (should be alphabetical)
            var model1Index = result.IndexOf("TestModel1");
            var model2Index = result.IndexOf("TestModel2");
            Assert.Less(model1Index, model2Index, "Types should be ordered alphabetically");
        }
        
        [Test]
        public void ValidateDeduplication()
        {
            var writer = new ModelReaderWriterBuildableAttributesWriter();
            var types = new List<CSharpType>
            {
                new CSharpType(typeof(object), "TestNamespace", "TestModel1"),
                new CSharpType(typeof(object), "TestNamespace", "TestModel1"), // duplicate
                new CSharpType(typeof(object), "TestNamespace", "TestModel2")
            };
            
            var codeWriter = new CodeWriter();
            writer.WriteModelReaderWriterBuildableAttributes(codeWriter, types);
            
            var result = codeWriter.ToString();
            
            // Count occurrences of TestModel1 - should only appear once
            var count = result.Split(new[] { "TestModel1" }, StringSplitOptions.None).Length - 1;
            Assert.AreEqual(1, count, "Duplicate types should be deduplicated");
        }
    }
}