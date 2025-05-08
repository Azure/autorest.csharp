// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using additionalProperties;
using additionalProperties.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class AdditionalPropertiesTest : TestServerTestBase
    {
        [Test]
        public Task AdditionalPropertiesInProperties() => Test(async (host, pipeline) =>
        {
            var response = await GetClient<PetsClient>(pipeline, host).CreateAPInPropertiesAsync(new PetAPInProperties(4)
            {
                Name = "Bunny",
                AdditionalProperties =
                {
                    { "height", 5.61f },
                    { "weight", 599f },
                    { "footsize", 11.5f }
                }
            });

            var value = response.Value;
            Assert.AreEqual(4, value.Id);
            Assert.AreEqual("Bunny", value.Name);
            Assert.AreEqual(5.61f, value.AdditionalProperties["height"]);
            Assert.AreEqual(599f, value.AdditionalProperties["weight"]);
            Assert.AreEqual(11.5f, value.AdditionalProperties["footsize"]);
        });

        [Test]
        public Task AdditionalPropertiesInPropertiesWithAPTypeString() => Test(async (host, pipeline) =>
        {
            PetAPInPropertiesWithAPString parameter = new PetAPInPropertiesWithAPString(5, "westus")
            {
                Name = "Funny",
                AdditionalProperties =
                {
                    { "height", 5.61f },
                    { "weight", 599f },
                    { "footsize", 11.5f }
                },
            };

            var moreAdditionalPropertiesProperty = typeof(PetAPInPropertiesWithAPString)
                .GetProperty("MoreAdditionalProperties", BindingFlags.Instance | BindingFlags.NonPublic);
            IDictionary<string, string> moreAdditionalProperties = moreAdditionalPropertiesProperty.GetValue(parameter) as IDictionary<string, string>;

            moreAdditionalProperties["color"] = "red";
            moreAdditionalProperties["city"] = "Seattle";
            moreAdditionalProperties["food"] = "tikka masala";

            var response = await GetClient<PetsClient>(pipeline, host).CreateAPInPropertiesWithAPStringAsync(parameter);

            var value = response.Value;
            Assert.AreEqual(5, value.Id);
            Assert.AreEqual("Funny", value.Name);
            Assert.AreEqual("westus", value.OdataLocation);
            Assert.AreEqual(5.61f, value.AdditionalProperties["height"]);
            Assert.AreEqual(599f, value.AdditionalProperties["weight"]);
            Assert.AreEqual(11.5f, value.AdditionalProperties["footsize"]);

            var valueMoreAdditonalProperties = moreAdditionalPropertiesProperty.GetValue(value) as Dictionary<string, string>;
            Assert.AreEqual("red", valueMoreAdditonalProperties["color"]);
            Assert.AreEqual("Seattle", valueMoreAdditonalProperties["city"]);
            Assert.AreEqual("tikka masala", valueMoreAdditonalProperties["food"]);
        });

        [Test]
        public Task AdditionalPropertiesSubclass() => Test(async (host, pipeline) =>
        {
            CatAPTrue catAPTrue = new CatAPTrue(1)
            {
                Name = "Lisa",
                Friendly = true,
            };

            catAPTrue.AdditionalProperties["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            catAPTrue.AdditionalProperties["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            var response = await GetClient<PetsClient>(pipeline, host).CreateCatAPTrueAsync(catAPTrue);

            var value = response.Value;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Lisa", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual(true, value.Friendly);
            Assert.AreEqual("2017-12-13T02:29:51Z", value.AdditionalProperties["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)value.AdditionalProperties["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTrue() => Test(async (host, pipeline) =>
        {
            PetAPTrue catAPTrue = new PetAPTrue(1)
            {
                Name = "Puppy",
            };

            catAPTrue.AdditionalProperties["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            catAPTrue.AdditionalProperties["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            var response = await GetClient<PetsClient>(pipeline, host).CreateAPTrueAsync(catAPTrue);

            var value = response.Value;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Puppy", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual("2017-12-13T02:29:51Z", value.AdditionalProperties["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)value.AdditionalProperties["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTypeObject() => Test(async (host, pipeline) =>
        {
            PetAPObject petAPObject = new PetAPObject(1)
            {
                Name = "Puppy",
            };

            petAPObject.AdditionalProperties["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            petAPObject.AdditionalProperties["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            PetAPObject outerAPObject = new PetAPObject(2)
            {
                Name = "Hira"
            };
            outerAPObject.AdditionalProperties["siblings"] = new object[]
            {
                petAPObject
            };
            outerAPObject.AdditionalProperties["picture"] = new byte[] { 255, 255, 255, 255, 254 };

            var response = await GetClient<PetsClient>(pipeline, host).CreateAPObjectAsync(outerAPObject);

            var value = response.Value;

            Assert.AreEqual(2, value.Id);
            Assert.AreEqual("Hira", value.Name);
            Assert.AreEqual(true, value.Status);

            var siblings = (IEnumerable<object>)value.AdditionalProperties["siblings"];
            var sibling = (IDictionary<string, object>)siblings.Single();

            Assert.AreEqual(1, sibling["id"]);
            Assert.AreEqual("Puppy", sibling["name"]);
            Assert.AreEqual("2017-12-13T02:29:51Z", sibling["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)sibling["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTypeString() => Test(async (host, pipeline) =>
        {
            PetAPString petAPObject = new PetAPString(3)
            {
                Name = "Tommy"
            };

            petAPObject.AdditionalProperties["weight"] = "10 kg";
            petAPObject.AdditionalProperties["color"] = "red";
            petAPObject.AdditionalProperties["city"] = "Bombay";

            var response = await GetClient<PetsClient>(pipeline, host).CreateAPStringAsync(petAPObject);
            var value = response.Value;
            Assert.AreEqual(3, value.Id);
            Assert.AreEqual("Tommy", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual("red", value.AdditionalProperties["color"]);
            Assert.AreEqual("10 kg", value.AdditionalProperties["weight"]);
            Assert.AreEqual("Bombay", value.AdditionalProperties["city"]);
        });

        [Test]
        public void InitializeAdditionalPropertiesDuringDeserialization()
        {
            PetAPObject model = ModelReaderWriter.Read<PetAPObject>(BinaryData.FromString("{}"));
            Assert.AreEqual(new Dictionary<string, object>(), model.AdditionalProperties);
        }
    }
}
