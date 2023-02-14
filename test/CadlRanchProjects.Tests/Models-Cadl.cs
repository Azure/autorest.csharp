// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using ModelsInCadl;
using NUnit.Framework;
using Azure;
using ModelsInCadl.Models;
using System.Net;
using System.Collections.Generic;
using System;

namespace CadlRanchProjects.Tests
{
    /// <summary>
    /// End-to-end test cases for `lro-basic-cadl` test project.
    /// </summary>
    public class ModelsCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task InputToRoundTripPrimitive() => Test(async (host) =>
        {
            InputModel input = new("test", 1, new BaseModel(), new int[] { }, new string[] { }, new CollectionItem[] { }, new Dictionary<string, RecordItem>(), new float?[] { 12.3f });
            RoundTripPrimitiveModel result = await new ModelsInCadlClient(host).InputToRoundTripPrimitiveAsync(input);

            Assert.AreEqual("test", result.RequiredString);
            Assert.AreEqual(123, result.RequiredInt);
            Assert.AreEqual(123456, result.RequiredInt64);
            Assert.AreEqual(1234567, result.RequiredSafeInt);
            Assert.AreEqual(12.3f, result.RequiredFloat);
            Assert.AreEqual(123.456, result.RequiredDouble);
            Assert.True(result.RequiredBoolean);
            Assert.AreEqual(DateTimeOffset.Parse("2023-02-14Z02:08:47"), result.RequiredDateTimeOffset);
            Assert.AreEqual(new TimeSpan(1, 2, 59, 59), result.RequiredTimeSpan);
            CollectionAssert.AreEqual(new float?[] { null, 12.3f }, result.RequiredCollectionWithNullableFloatElement);
        });

        [Test]
        public Task InputToRoundTripOptional() => Test(async (host) =>
        {
            RoundTripOptionalModel input = new()
            {
                OptionalPlainDate = DateTimeOffset.Parse("2023-02-14Z02:08:47"),
                OptionalPlainTime = new TimeSpan(1, 2, 59, 59),
            };
            RoundTripOptionalModel result = await new ModelsInCadlClient(host).InputToRoundTripOptionalAsync(input);

            CollectionAssert.AreEqual(new int?[] { null, 123 }, result.OptionalCollectionWithNullableIntElement);
        });

        [Test]
        public Task InputToRoundTripReadOnly() => Test(async (host) =>
        {
            InputModel input = new("test", 2, new DerivedModel(new CollectionItem[] { }), new int[] { 1, 2 }, new string[] { "a" }, new CollectionItem[] { }, new Dictionary<string, RecordItem>(), new float?[] {});
            RoundTripReadOnlyModel result = await new ModelsInCadlClient(host).InputToRoundTripReadOnlyAsync(input);

            Assert.AreEqual("test", result.RequiredReadonlyString);
            Assert.AreEqual(12, result.RequiredReadonlyInt);
            Assert.AreEqual(11, result.OptionalReadonlyInt);
            Assert.IsEmpty(result.RequiredReadonlyModel.RequiredCollection);
            Assert.AreEqual(FixedStringEnum.One, result.RequiredReadonlyFixedStringEnum);
            Assert.AreEqual("3", result.RequiredReadonlyExtensibleEnum.ToString());
            Assert.AreEqual(FixedStringEnum.Two, result.OptionalReadonlyFixedStringEnum);
            Assert.AreEqual(ExtensibleEnum.One, result.OptionalReadonlyExtensibleEnum);
            Assert.AreEqual(1, result.RequiredReadonlyStringList.Count);
            Assert.AreEqual("abc", result.RequiredReadonlyStringList[0]);
            Assert.IsEmpty(result.RequiredReadonlyIntList);
            Assert.IsEmpty(result.RequiredReadOnlyModelCollection);
            Assert.AreEqual(1, result.RequiredReadOnlyIntRecord.Count);
            Assert.AreEqual(1, result.RequiredReadOnlyIntRecord["test"]);
            Assert.AreEqual(1, result.RequiredStringRecord.Count);
            Assert.AreEqual("1", result.RequiredStringRecord["test"]);
            Assert.IsEmpty(result.RequiredReadOnlyModelRecord);
            Assert.IsEmpty(result.OptionalReadonlyStringList);
            Assert.IsEmpty(result.OptionalReadOnlyModelCollection);
            Assert.IsEmpty(result.OptionalReadOnlyStringRecord);
            Assert.AreEqual(1, result.OptionalModelRecord.Count);
            Assert.IsEmpty(result.OptionalModelRecord["test"].RequiredCollection);
            CollectionAssert.AreEqual(new int?[] { null, 123 }, result.RequiredCollectionWithNullableIntElement);
            CollectionAssert.AreEqual(new bool?[] { null, false, true }, result.OptionalCollectionWithNullableBooleanElement);
        });
    }
}
