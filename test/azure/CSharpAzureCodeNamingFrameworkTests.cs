// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure;
using AutoRest.Modeler;
using AutoRest.Swagger;
using Xunit;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Azure.Tests
{
    public class CSharpAzureCodeNamingFrameworkTests
    {
        [Fact]
        public void ConvertsPageResultsToPageTypeTest()
        {
            using (NewContext)
            {
                var input = Path.Combine(Core.Utilities.Extensions.CodeBaseDirectory(typeof(CSharpAzureCodeNamingFrameworkTests)), "Resource", "azure-paging.json");
                var modeler = new SwaggerModeler();
                var codeModel = modeler.Build(SwaggerParser.Parse(File.ReadAllText(input)));
                var plugin = new AutoRest.CSharp.Azure.PluginCsa();
                using (plugin.Activate()) {
                    codeModel = plugin.Serializer.Load(codeModel);
                    codeModel = plugin.Transformer.TransformCodeModel(codeModel);

                    var methods = codeModel.Methods.ToList();
                    Assert.Equal(7, methods.Count);
                    Assert.Equal(1, methods.Count(m => m.Name == "GetSinglePage"));
                    Assert.Equal(0, methods.Count(m => m.Name == "GetSinglePageNext"));
                    Assert.Equal(1, methods.Count(m => m.Name == "PutSinglePage"));
                    Assert.Equal(1, methods.Count(m => m.Name == "PutSinglePageSpecialNext"));

                    Assert.Equal("Page<Product>", methods[0].ReturnType.Body.Name);
                    Assert.Equal("object", methods[1].ReturnType.Body.Name.ToLowerInvariant());
                    Assert.Equal("Page1<Product>", methods[1].Responses.ElementAt(0).Value.Body.Name);
                    Assert.Equal("string",
                        methods[1].Responses.ElementAt(1).Value.Body.Name.ToLowerInvariant());
                    Assert.Equal("object", methods[2].ReturnType.Body.Name.ToLowerInvariant());
                    Assert.Equal("Page1<Product>", methods[2].Responses.ElementAt(0).Value.Body.Name);
                    Assert.Equal("Page1<Product>", methods[2].Responses.ElementAt(1).Value.Body.Name);
                    Assert.Equal("object", methods[3].ReturnType.Body.Name.ToLowerInvariant());
                    Assert.Equal("Page1<Product>", methods[3].Responses.ElementAt(0).Value.Body.Name);
                    Assert.Equal("Page1<ProductChild>", methods[3].Responses.ElementAt(1).Value.Body.Name);
                    Assert.Equal(5, codeModel.ModelTypes.Count);
                    Assert.False(
                        codeModel.ModelTypes.Any(t => t.Name.EqualsIgnoreCase("ProducResult")));
                    Assert.False(
                        codeModel.ModelTypes.Any(t => t.Name.EqualsIgnoreCase("ProducResult2")));
                    Assert.False(
                        codeModel.ModelTypes.Any(t => t.Name.EqualsIgnoreCase("ProducResult3")));
                }
            }
        }
    }
}
