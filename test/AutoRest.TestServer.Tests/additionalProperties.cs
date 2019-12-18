// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using additionalProperties;
using additionalProperties.Models.V100;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class AdditionalPropertiesTest : TestServerTestBase
    {
        public AdditionalPropertiesTest(TestServerVersion version) : base(version, "additionalProperties") { }

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task AdditionalPropertiesInProperties() => Test(async (host, pipeline) =>
        {
            var response = await PetsOperations.CreateAPInPropertiesAsync(ClientDiagnostics, pipeline, new PetAPInProperties()
            {
                Id = 4,
                Name = "Bunny",
                AdditionalProperties = new Dictionary<string, float>()
                {
                    { "height", 5.61f },
                    { "weight", 599f },
                    { "footsize", 11.5f }
                }
            }, host);

            var value = response.Value;
            Assert.AreEqual(4, value.Id);
            Assert.AreEqual("Bunny", value.Name);
            Assert.AreEqual(5.61f, value.AdditionalProperties["height"]);
            Assert.AreEqual(599f, value.AdditionalProperties["weight"]);
            Assert.AreEqual(11.5f, value.AdditionalProperties["footsize"]);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task AdditionalPropertiesInPropertiesWithAPTypeString() => Test(async (host, pipeline) =>
        {
            PetAPInPropertiesWithAPString parameter = new PetAPInPropertiesWithAPString()
            {
                Id = 5,
                Name = "Funny",
                OdataLocation = "westus",
                AdditionalProperties = new Dictionary<string, float>()
                {
                    { "height", 5.61f },
                    { "weight", 599f },
                    { "footsize", 11.5f }
                },
            };

            parameter["color"] = "red";
            parameter["city"] = "Seattle";
            parameter["food"] = "tikka masala";

            var response = await PetsOperations.CreateAPInPropertiesWithAPStringAsync(ClientDiagnostics, pipeline, parameter, host);

            var value = response.Value;
            Assert.AreEqual(5, value.Id);
            Assert.AreEqual("Funny", value.Name);
            Assert.AreEqual("westus", value.OdataLocation);
            Assert.AreEqual(5.61f, value.AdditionalProperties["height"]);
            Assert.AreEqual(599f, value.AdditionalProperties["weight"]);
            Assert.AreEqual(11.5f, value.AdditionalProperties["footsize"]);

            Assert.AreEqual("red", value["color"]);
            Assert.AreEqual("Seattle", value["city"]);
            Assert.AreEqual("tikka masala", value["food"]);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task AdditionalPropertiesSubclass() => Test(async (host, pipeline) =>
        {
            CatAPTrue catApTrue = new CatAPTrue()
            {
                Id = 1,
                Name = "Lisa",
                Friendly = true,
            };

            catApTrue["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            catApTrue["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            var response = await PetsOperations.CreateCatAPTrueAsync(ClientDiagnostics, pipeline, catApTrue, host);

            var value = response.Value;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Lisa", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual(true, value.Friendly);
            Assert.AreEqual("2017-12-13T02:29:51Z", value["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)value["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTrue() => Test(async (host, pipeline) =>
        {
            PetAPTrue catApTrue = new PetAPTrue()
            {
                Id = 1,
                Name = "Puppy",
            };

            catApTrue["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            catApTrue["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            var response = await PetsOperations.CreateAPTrueAsync(ClientDiagnostics, pipeline, catApTrue, host);

            var value = response.Value;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Puppy", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual("2017-12-13T02:29:51Z", value["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)value["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTypeObject() => Test(async (host, pipeline) =>
        {
            PetAPObject petApObject = new PetAPObject()
            {
                Id = 1,
                Name = "Puppy",
            };

            petApObject["birthdate"] = DateTimeOffset.Parse("2017-12-13T02:29:51Z");
            petApObject["complexProperty"] = new Dictionary<string, object>()
            {
                {"color", "Red"}
            };

            PetAPObject outerApObject = new PetAPObject()
            {
                Id = 2,
                Name = "Hira"
            };
            outerApObject["siblings"] = new object[]
            {
                petApObject
            };
            outerApObject["picture"] = new byte[] { 255, 255, 255, 255, 254 };

            var response = await PetsOperations.CreateAPObjectAsync(ClientDiagnostics, pipeline, outerApObject, host);

            var value = response.Value;

            Assert.AreEqual(2, value.Id);
            Assert.AreEqual("Hira", value.Name);
            Assert.AreEqual(true, value.Status);

            var siblings = (IEnumerable<object>)value["siblings"];
            var sibling = (IDictionary<string, object>)siblings.Single();

            Assert.AreEqual(1, sibling["id"]);
            Assert.AreEqual("Puppy", sibling["name"]);
            Assert.AreEqual("2017-12-13T02:29:51Z", sibling["birthdate"]);
            Assert.AreEqual("Red", ((Dictionary<string, object>)sibling["complexProperty"])["color"]);
        });

        [Test]
        public Task AdditionalPropertiesTypeString() => Test(async (host, pipeline) =>
        {
            PetAPString petApObject = new PetAPString()
            {
                Id = 3,
                Name = "Tommy"
            };

            petApObject["weight"] = "10 kg";
            petApObject["color"] = "red";
            petApObject["city"] = "Bombay";

            var response = await PetsOperations.CreateAPStringAsync(ClientDiagnostics, pipeline, petApObject, host);
            var value = response.Value;
            Assert.AreEqual(3, value.Id);
            Assert.AreEqual("Tommy", value.Name);
            Assert.AreEqual(true, value.Status);
            Assert.AreEqual("red", value["color"]);
            Assert.AreEqual("10 kg", value["weight"]);
            Assert.AreEqual("Bombay", value["city"]);
        });
    }
}
