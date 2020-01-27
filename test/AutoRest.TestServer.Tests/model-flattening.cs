// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using model_flattening;
using model_flattening.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ModelFlatteningTests : TestServerTestBase
    {
        public ModelFlatteningTests(TestServerVersion version) : base(version, "model-flatten") { }

        [Test]
        public Task GetModelFlattenArray() => Test(async (host, pipeline) =>
        {
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).GetArrayAsync();
            Assert.AreEqual("1", result.Value.ElementAt(0).Id);
            Assert.AreEqual("Building 44", result.Value.ElementAt(0).Location);
            Assert.AreEqual("Resource1", result.Value.ElementAt(0).Name);
            Assert.AreEqual("Succeeded", result.Value.ElementAt(0).ProvisioningState);
            Assert.AreEqual(FlattenedProductPropertiesProvisioningStateValues.OK, result.Value.ElementAt(0).ProvisioningStateValues);
            Assert.AreEqual("Product1", result.Value.ElementAt(0).PName);
            Assert.AreEqual("Flat", result.Value.ElementAt(0).TypePropertiesType);
            Assert.AreEqual("value1", result.Value.ElementAt(0).Tags["tag1"]);
            Assert.AreEqual("value3", result.Value.ElementAt(0).Tags["tag2"]);
            Assert.AreEqual("Microsoft.Web/sites", result.Value.ElementAt(0).Type);
            Assert.AreEqual("2", result.Value.ElementAt(1).Id);
            Assert.AreEqual("Resource2", result.Value.ElementAt(1).Name);
            Assert.AreEqual("Building 44", result.Value.ElementAt(1).Location);
            Assert.AreEqual("3", result.Value.ElementAt(2).Id);
            Assert.AreEqual("Resource3", result.Value.ElementAt(2).Name);
        });

        [Test]
        public Task GetModelFlattenDictionary() => Test(async (host, pipeline) =>
        {
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).GetDictionaryAsync();
            Assert.AreEqual("1", result.Value["Product1"].Id);
            Assert.AreEqual("Building 44", result.Value["Product1"].Location);
            Assert.AreEqual("Resource1", result.Value["Product1"].Name);
            Assert.AreEqual("Succeeded", result.Value["Product1"].ProvisioningState);
            Assert.AreEqual(FlattenedProductPropertiesProvisioningStateValues.OK, result.Value["Product1"].ProvisioningStateValues);
            Assert.AreEqual("Product1", result.Value["Product1"].PName);
            Assert.AreEqual("Flat", result.Value["Product1"].TypePropertiesType);
            Assert.AreEqual("value1", result.Value["Product1"].Tags["tag1"]);
            Assert.AreEqual("value3", result.Value["Product1"].Tags["tag2"]);
            Assert.AreEqual("Microsoft.Web/sites", result.Value["Product1"].Type);
            Assert.AreEqual("2", result.Value["Product2"].Id);
            Assert.AreEqual("Resource2", result.Value["Product2"].Name);
            Assert.AreEqual("Building 44", result.Value["Product2"].Location);
            Assert.AreEqual("3", result.Value["Product3"].Id);
            Assert.AreEqual("Resource3", result.Value["Product3"].Name);
        });

        [Test]
        public Task GetModelFlattenResourceCollection() => Test(async (host, pipeline) =>
        {
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).GetResourceCollectionAsync();
            Assert.AreEqual("1", result.Value.Dictionaryofresources["Product1"].Id);
            Assert.AreEqual("Building 44", result.Value.Dictionaryofresources["Product1"].Location);
            Assert.AreEqual("Resource1", result.Value.Dictionaryofresources["Product1"].Name);
            Assert.AreEqual("Succeeded", result.Value.Dictionaryofresources["Product1"].ProvisioningState);
            Assert.AreEqual(FlattenedProductPropertiesProvisioningStateValues.OK, result.Value.Dictionaryofresources["Product1"].ProvisioningStateValues);
            Assert.AreEqual("Product1", result.Value.Dictionaryofresources["Product1"].PName);
            Assert.AreEqual("Flat", result.Value.Dictionaryofresources["Product1"].TypePropertiesType);
            Assert.AreEqual("value1", result.Value.Dictionaryofresources["Product1"].Tags["tag1"]);
            Assert.AreEqual("value3", result.Value.Dictionaryofresources["Product1"].Tags["tag2"]);
            Assert.AreEqual("Microsoft.Web/sites", result.Value.Dictionaryofresources["Product1"].Type);
            Assert.AreEqual("2", result.Value.Dictionaryofresources["Product2"].Id);
            Assert.AreEqual("Resource2", result.Value.Dictionaryofresources["Product2"].Name);
            Assert.AreEqual("Building 44", result.Value.Dictionaryofresources["Product2"].Location);
            Assert.AreEqual("3", result.Value.Dictionaryofresources["Product3"].Id);
            Assert.AreEqual("Resource3", result.Value.Dictionaryofresources["Product3"].Name);

            Assert.AreEqual("4", result.Value.Arrayofresources.ElementAt(0).Id);
            Assert.AreEqual("Building 44", result.Value.Arrayofresources.ElementAt(0).Location);
            Assert.AreEqual("Resource4", result.Value.Arrayofresources.ElementAt(0).Name);
            Assert.AreEqual("Succeeded", result.Value.Arrayofresources.ElementAt(0).ProvisioningState);
            Assert.AreEqual(FlattenedProductPropertiesProvisioningStateValues.OK, result.Value.Arrayofresources.ElementAt(0).ProvisioningStateValues);
            Assert.AreEqual("Product4", result.Value.Arrayofresources.ElementAt(0).PName);
            Assert.AreEqual("Flat", result.Value.Arrayofresources.ElementAt(0).TypePropertiesType);
            Assert.AreEqual("value1", result.Value.Arrayofresources.ElementAt(0).Tags["tag1"]);
            Assert.AreEqual("value3", result.Value.Arrayofresources.ElementAt(0).Tags["tag2"]);
            Assert.AreEqual("Microsoft.Web/sites", result.Value.Arrayofresources.ElementAt(0).Type);
            Assert.AreEqual("5", result.Value.Arrayofresources.ElementAt(1).Id);
            Assert.AreEqual("Resource5", result.Value.Arrayofresources.ElementAt(1).Name);
            Assert.AreEqual("Building 44", result.Value.Arrayofresources.ElementAt(1).Location);
            Assert.AreEqual("6", result.Value.Arrayofresources.ElementAt(2).Id);
            Assert.AreEqual("Resource6", result.Value.Arrayofresources.ElementAt(2).Name);

            Assert.AreEqual("7", result.Value.Productresource.Id);
            Assert.AreEqual("Resource7", result.Value.Productresource.Name);
            Assert.AreEqual("Building 44", result.Value.Productresource.Location);
        });

        [Test]
        public Task PostModelFlattenCustomParameter() => Test(async (host, pipeline) =>
        {
            var value = new SimpleProduct
            {
                ProductId = "123",
                Description = "product description",
                MaxProductDisplayName = "max name",
                Capacity = "Large",
                OdataValue = "http://foo"
            };
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).PostFlattenedSimpleProductAsync(value);
            Assert.AreEqual("123", result.Value.ProductId);
            Assert.AreEqual("product description", result.Value.Description);
            Assert.AreEqual("max name", result.Value.MaxProductDisplayName);
            Assert.AreEqual("Large", result.Value.Capacity);
            Assert.AreEqual("http://foo", result.Value.OdataValue);
        });

        [Test]
        public Task PutModelFlattenArray() => TestStatus(async (host, pipeline) =>
        {
            var value = new[]
            {
                new Resource
                {
                    Location = "West US",
                    Tags = new Dictionary<string, string>
                    {
                        { "tag1", "value1" },
                        { "tag2", "value3" }
                    }
                },
                new Resource
                {
                    Location = "Building 44"
                }
            };
            return await new AllOperations(ClientDiagnostics, pipeline, host).PutArrayAsync(value);
        });

        [Test]
        [Ignore("Flattening bug in M4: https://github.com/Azure/autorest.modelerfour/issues/140")]
        public Task PutModelFlattenCustomBase() => Test(async (host, pipeline) =>
        {
            var value = new SimpleProduct
            {
                ProductId = "123",
                Description = "product description",
                MaxProductDisplayName = "max name",
                Capacity = "Large",
                OdataValue = "http://foo",
                //GenericValue = "https://generic"
            };
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).PutSimpleProductAsync(value);
            Assert.AreEqual("123", result.Value.ProductId);
            Assert.AreEqual("product description", result.Value.Description);
            Assert.AreEqual("max name", result.Value.MaxProductDisplayName);
            Assert.AreEqual("Large", result.Value.Capacity);
            Assert.AreEqual("http://foo", result.Value.OdataValue);
            //Assert.AreEqual("https://generic", result.Value.GenericValue);
        });

        [Test]
        public Task PutModelFlattenCustomGroupedParameter() => Test(async (host, pipeline) =>
        {
            var value = new SimpleProduct
            {
                ProductId = "123",
                Description = "product description",
                MaxProductDisplayName = "max name",
                Capacity = "Large",
                OdataValue = "http://foo"
            };
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).PutSimpleProductWithGroupingAsync("groupproduct", value);
            Assert.AreEqual("123", result.Value.ProductId);
            Assert.AreEqual("product description", result.Value.Description);
            Assert.AreEqual("max name", result.Value.MaxProductDisplayName);
            Assert.AreEqual("Large", result.Value.Capacity);
            Assert.AreEqual("http://foo", result.Value.OdataValue);
        });

        [Test]
        public Task PutModelFlattenDictionary() => TestStatus(async (host, pipeline) =>
        {
            var value = new Dictionary<string, FlattenedProduct>
            {
                { "Resource1", new FlattenedProduct
                    {
                        Location = "West US",
                        Tags = new Dictionary<string, string>
                        {
                            { "tag1", "value1" },
                            { "tag2", "value3" }
                        },
                        PName = "Product1",
                        TypePropertiesType = "Flat"
                    }
                },
                { "Resource2", new FlattenedProduct
                    {
                        Location = "Building 44",
                        PName = "Product2",
                        TypePropertiesType = "Flat"
                    }
                }
            };
            return await new AllOperations(ClientDiagnostics, pipeline, host).PutDictionaryAsync(value);
        });

        [Test]
        public Task PutModelFlattenResourceCollection() => TestStatus(async (host, pipeline) =>
        {
            var value = new ResourceCollection
            {
                Arrayofresources = new[]
                {
                    new FlattenedProduct
                    {
                        Location = "West US",
                        Tags = new Dictionary<string, string>
                        {
                            { "tag1", "value1" },
                            { "tag2", "value3" }
                        },
                        PName = "Product1",
                        TypePropertiesType = "Flat"
                    },
                    new FlattenedProduct
                    {
                        Location = "East US",
                        PName = "Product2",
                        TypePropertiesType = "Flat"
                    }
                },
                Dictionaryofresources = new Dictionary<string, FlattenedProduct>
                {
                    { "Resource1", new FlattenedProduct
                        {
                            Location = "West US",
                            Tags = new Dictionary<string, string>
                            {
                                { "tag1", "value1" },
                                { "tag2", "value3" }
                            },
                            PName = "Product1",
                            TypePropertiesType = "Flat"
                        }
                    },
                    { "Resource2", new FlattenedProduct
                        {
                            Location = "Building 44",
                            PName = "Product2",
                            TypePropertiesType = "Flat"
                        }
                    }
                },
                Productresource = new FlattenedProduct
                {
                    Location = "India",
                    PName = "Azure",
                    TypePropertiesType = "Flat"
                }
            };
            return await new AllOperations(ClientDiagnostics, pipeline, host).PutResourceCollectionAsync(value);
        });
    }
}
