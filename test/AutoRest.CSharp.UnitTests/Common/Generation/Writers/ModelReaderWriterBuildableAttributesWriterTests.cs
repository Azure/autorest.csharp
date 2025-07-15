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
    public class ModelReaderWriterBuildableAttributesWriterTests
    {
        private ModelReaderWriterBuildableAttributesWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new ModelReaderWriterBuildableAttributesWriter();
        }

        [Test]
        public void CollectBuildableTypes_EmptyModels_ReturnsEmpty()
        {
            var models = new List<TypeProvider>();
            
            var result = _writer.CollectBuildableTypes(models);
            
            Assert.IsEmpty(result);
        }

        [Test]
        public void WriteModelReaderWriterBuildableAttributes_EmptyTypes_WritesNothing()
        {
            var buildableTypes = new List<CSharpType>();
            var codeWriter = new CodeWriter();
            
            _writer.WriteModelReaderWriterBuildableAttributes(codeWriter, buildableTypes);
            
            Assert.IsEmpty(codeWriter.ToString());
        }

        [Test]
        public void WriteModelReaderWriterBuildableAttributes_WithTypes_WritesAttributes()
        {
            var buildableTypes = new List<CSharpType>
            {
                new CSharpType(typeof(string), "TestNamespace", "TestModel")
            };
            var codeWriter = new CodeWriter();
            
            _writer.WriteModelReaderWriterBuildableAttributes(codeWriter, buildableTypes);
            
            var result = codeWriter.ToString();
            Assert.Contains("using System.ClientModel.Primitives;", result);
            Assert.Contains("[assembly: ModelReaderWriterBuildableAttribute(typeof(TestModel))]", result);
        }
    }
}