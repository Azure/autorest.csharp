// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using property_types;
using Models.Property.Types;
using System.Collections.Generic;

namespace CadlRanchProjects.Tests
{
    public class property_types : CadlRanchTestBase
    {
        [Test]
        public Task Models_Property_Types_Boolean_get() => Test(async (host) =>
        {
            Response response = await new BooleanClient(host, null).GetAsync();
            Assert.AreEqual(true, BooleanProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Boolean_put() => Test(async (host) =>
        {
            Response response = await new BooleanClient(host, null).PutAsync(new BooleanProperty(true).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_String_get() => Test(async (host) =>
        {
            Response response = await new StringClient(host, null).GetAsync();
            Assert.AreEqual("hello", StringProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_String_put() => Test(async (host) =>
        {
            Response response = await new StringClient(host, null).PutAsync(new StringProperty("hello").ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Bytes_get() => Test(async (host) =>
        {
            Response response = await new BytesClient(host, null).GetAsync();
            Assert.AreEqual(BinaryData.FromString("\"aGVsbG8sIHdvcmxkIQ==\"").ToString(), BytesProperty.FromResponse(response).Property.ToString());
        });

        [Test]
        public Task Models_Property_Types_Bytes_put() => Test(async (host) =>
        {
            Response response = await new BytesClient(host, null).PutAsync(new BytesProperty(BinaryData.FromString("\"aGVsbG8sIHdvcmxkIQ==\"")).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Int_get() => Test(async (host) =>
        {
            Response response = await new IntClient(host, null).GetAsync();
            Assert.AreEqual(42, IntProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Int_put() => Test(async (host) =>
        {
            Response response = await new IntClient(host, null).PutAsync(new IntProperty(42).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Float_get() => Test(async (host) =>
        {
            Response response = await new FloatClient(host, null).GetAsync();
            Assert.AreEqual(42.42f, FloatProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Float_put() => Test(async (host) =>
        {
            Response response = await new FloatClient(host, null).PutAsync(new FloatProperty((float)42.42).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Datetime_get() => Test(async (host) =>
        {
            Response response = await new DatetimeClient(host, null).GetAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), DatetimeProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Datetime_put() => Test(async (host) =>
        {
            Response response = await new DatetimeClient(host, null).PutAsync(new DatetimeProperty(DateTimeOffset.Parse("2022-08-26T18:38:00Z")).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Duration_get() => Test(async (host) =>
        {
            Response response = await new DurationClient(host, null).GetAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), DurationProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Duration_put() => Test(async (host) =>
        {
            Response response = await new DurationClient(host, null).PutAsync(new DurationProperty(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Enum_get() => Test(async (host) =>
        {
            Response response = await new EnumClient(host, null).GetAsync();
            Assert.AreEqual(InnerEnum.ValueOne, EnumProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_Enum_put() => Test(async (host) =>
        {
            Response response = await new EnumClient(host, null).PutAsync(new EnumProperty(InnerEnum.ValueOne).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_ExtensibleEnum_get() => Test(async (host) =>
        {
            Response response = await new ExtensibleEnumClient(host, null).GetAsync();
            Assert.AreEqual(new InnerExtensibleEnum("UnknownValue"), ExtensibleEnumProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_ExtensibleEnum_put() => Test(async (host) =>
        {
            Response response = await new ExtensibleEnumClient(host, null).PutAsync(new ExtensibleEnumProperty(new InnerExtensibleEnum("UnknownValue")).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_Model_get() => Test(async (host) =>
        {
            Response response = await new ModelClient(host, null).GetAsync();
            Assert.AreEqual("hello", ModelProperty.FromResponse(response).Property.Property);
        });

        [Test]
        public Task Models_Property_Types_Model_put() => Test(async (host) =>
        {
            Response response = await new ModelClient(host, null).PutAsync(new ModelProperty(new InnerModel("hello")).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_CollectionsString_get() => Test(async (host) =>
        {
            Response response = await new CollectionsStringClient(host, null).GetAsync();
            CollectionAssert.AreEqual(new[] { "hello", "world" }, CollectionsStringProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_CollectionsString_put() => Test(async (host) =>
        {
            Response response = await new CollectionsStringClient(host, null).PutAsync(new CollectionsStringProperty(new[] { "hello", "world" }).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_CollectionsInt_get() => Test(async (host) =>
        {
            Response response = await new CollectionsIntClient(host, null).GetAsync();
            CollectionAssert.AreEqual(new[] { 1, 2 }, CollectionsIntProperty.FromResponse(response).Property);
        });

        [Test]
        public Task Models_Property_Types_CollectionsInt_put() => Test(async (host) =>
        {
            Response response = await new CollectionsIntClient(host, null).PutAsync(new CollectionsIntProperty(new[] { 1, 2 }).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_CollectionsModel_get() => Test(async (host) =>
        {
            Response response = await new CollectionsModelClient(host, null).GetAsync();
            var result = CollectionsModelProperty.FromResponse(response);
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
        });

        [Test]
        public Task Models_Property_Types_CollectionsModel_put() => Test(async (host) =>
        {
            Response response = await new CollectionsModelClient(host, null).PutAsync(new CollectionsModelProperty(new[] { new InnerModel("hello"), new InnerModel("world") }).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Models_Property_Types_DictionaryString_get() => Test(async (host) =>
        {
            Response response = await new DictionaryStringClient(host, null).GetAsync();
            var result = DictionaryStringProperty.FromResponse(response);
            Assert.AreEqual("hello", result.Property["k1"]);
            Assert.AreEqual("world", result.Property["k2"]);
        });

        [Test]
        public Task Models_Property_Types_DictionaryString_put() => Test(async (host) =>
        {
            Response response = await new DictionaryStringClient(host, null).PutAsync(new DictionaryStringProperty(new Dictionary<string, string> { ["k1"] = "hello", ["k2"] = "world" }).ToRequestContent());
            Assert.AreEqual(204, response.Status);
        });
    }
}
