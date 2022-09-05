// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using property_types;
using Types;

namespace CadlRanchProjects.Tests
{
    public class property_types : TestServerLowLevelTestBase
    {
        [Test]
        public Task Models_Property_Types_Boolean_get() => Test(async (host) =>
        {
            Response<BooleanProperty> response = await new BooleanClient(host, null).GetValueAsync();
            Assert.AreEqual(true, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Boolean_put() => Test(async (host) =>
        {
            Response response = await new BooleanClient(host, null).PutAsync(new BooleanProperty(true));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_String_get() => Test(async (host) =>
        {
            Response<StringProperty> response = await new StringClient(host, null).GetValueAsync();
            Assert.AreEqual("hello", response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_String_put() => Test(async (host) =>
        {
            Response response = await new StringClient(host, null).PutAsync(new StringProperty("hello"));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Bytes_get() => Test(async (host) =>
        {
            Response<BytesProperty> response = await new BytesClient(host, null).GetValueAsync();
            var property = JsonData.FromBytes(response.Value.Property.ToMemory());
            Assert.AreEqual("aGVsbG8sIHdvcmxkIQ==", (string)property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Bytes_put() => Test(async (host) =>
        {
            Response response = await new BytesClient(host, null).PutAsync(new BytesProperty(BinaryData.FromString("aGVsbG8sIHdvcmxkIQ==")));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Int_get() => Test(async (host) =>
        {
            Response<IntProperty> response = await new IntClient(host, null).GetValueAsync();
            Assert.AreEqual(42, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Int_put() => Test(async (host) =>
        {
            Response response = await new IntClient(host, null).PutAsync(new IntProperty(42));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Float_get() => Test(async (host) =>
        {
            Response<FloatProperty> response = await new FloatClient(host, null).GetValueAsync();
            Assert.AreEqual(42.42f, (float)response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Float_put() => Test(async (host) =>
        {
            Response response = await new FloatClient(host, null).PutAsync(new FloatProperty((float)42.42));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Datetime_get() => Test(async (host) =>
        {
            Response<DatetimeProperty> response = await new DatetimeClient(host, null).GetValueAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Datetime_put() => Test(async (host) =>
        {
            Response response = await new DatetimeClient(host, null).PutAsync(new DatetimeProperty(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Duration_get() => Test(async (host) =>
        {
            Response<DurationProperty> response = await new DurationClient(host, null).GetValueAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Duration_put() => Test(async (host) =>
        {
            Response response = await new DurationClient(host, null).PutAsync(new DurationProperty(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Enum_get() => Test(async (host) =>
        {
            Response<EnumProperty> response = await new EnumClient(host, null).GetValueAsync();
            Assert.AreEqual(InnerEnum.ValueOne, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Enum_put() => Test(async (host) =>
        {
            Response response = await new EnumClient(host, null).PutAsync(new EnumProperty(InnerEnum.ValueOne));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_ExtensibleEnum_get() => Test(async (host) =>
        {
            Response<ExtensibleEnumProperty> response = await new ExtensibleEnumClient(host, null).GetValueAsync();
            Assert.AreEqual(InnerEnum.ValueOne, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_ExtensibleEnum_put() => Test(async (host) =>
        {
            Response response = await new ExtensibleEnumClient(host, null).PutAsync(new ExtensibleEnumProperty(InnerEnum.ValueOne));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Model_get() => Test(async (host) =>
        {
            Response<ModelProperty> response = await new ModelClient(host, null).GetValueAsync();
            Assert.AreEqual("hello", response.Value.Property.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_Model_put() => Test(async (host) =>
        {
            Response response = await new ModelClient(host, null).PutAsync(new ModelProperty(new InnerModel("hello")));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsString_get() => Test(async (host) =>
        {
            Response<CollectionsStringProperty> response = await new CollectionsStringClient(host, null).GetValueAsync();
            CollectionAssert.AreEqual(new[] { "hello", "world" }, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsString_put() => Test(async (host) =>
        {
            Response response = await new CollectionsStringClient(host, null).PutAsync(new CollectionsStringProperty(new[] { "hello", "world" }));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsInt_get() => Test(async (host) =>
        {
            Response<CollectionsIntProperty> response = await new CollectionsIntClient(host, null).GetValueAsync();
            CollectionAssert.AreEqual(new[] { 1, 2 }, response.Value.Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsInt_put() => Test(async (host) =>
        {
            Response response = await new CollectionsIntClient(host, null).PutAsync(new CollectionsIntProperty(new[] { 1, 2 }));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsModel_get() => Test(async (host) =>
        {
            Response<CollectionsModelProperty> response = await new CollectionsModelClient(host, null).GetValueAsync();
            Assert.AreEqual("hello", response.Value.Property[0].Property);
            Assert.AreEqual("world", response.Value.Property[1].Property);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task Models_Property_Types_CollectionsModel_put() => Test(async (host) =>
        {
            Response response = await new CollectionsModelClient(host, null).PutAsync(new CollectionsModelProperty(new[] { new InnerModel("hello"), new InnerModel("world") }));
            Assert.AreEqual(204, response.Status);
        }, new[] { TestServerType.CadlRanch });
    }
}
