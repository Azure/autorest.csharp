// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using _Type.Property.Optional;
using _Type.Property.Optional.Models;

namespace CadlRanchProjects.Tests
{
    public class TypePropertyOptionalTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Property_Optional_String_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetStringClient().GetAllAsync(new RequestContext());
            Assert.AreEqual("hello", ((StringProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_String_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetStringClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(null, ((StringProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_String_putAll() => Test(async (host) =>
        {
            StringProperty data = new()
            {
                Property = "hello"
            };
            Response response = await new OptionalClient(host, null).GetStringClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_String_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetStringClient().PutDefaultAsync(new StringProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetBytesClient().GetAllAsync(new RequestContext());
            Assert.AreEqual(BinaryData.FromString("hello, world!").ToString(), ((BytesProperty)response).Property.ToString());
        });

        [Test]
        public Task Type_Property_Optional_Bytes_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetBytesClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(null, ((BytesProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_putAll() => Test(async (host) =>
        {
            BytesProperty data = new()
            {
                Property = BinaryData.FromString("hello, world!")
            };
            Response response = await new OptionalClient(host, null).GetBytesClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetBytesClient().PutDefaultAsync(new BytesProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDatetimeClient().GetAllAsync(new RequestContext());
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), ((DatetimeProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDatetimeClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(null, ((DatetimeProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_putAll() => Test(async (host) =>
        {
            DatetimeProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-08-26T18:38:00Z")
            };
            Response response = await new OptionalClient(host, null).GetDatetimeClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDatetimeClient().PutDefaultAsync(new DatetimeProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Duration_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDurationClient().GetAllAsync(new RequestContext());
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), ((DurationProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_Duration_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDurationClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(null, ((DurationProperty)response).Property);
        });

        [Test]
        public Task Type_Property_Optional_Duration_putAll() => Test(async (host) =>
        {
            DurationProperty data = new()
            {
                Property = XmlConvert.ToTimeSpan("P123DT22H14M12.011S")
            };
            Response response = await new OptionalClient(host, null).GetDurationClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_Duration_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetDurationClient().PutDefaultAsync(new DatetimeProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsByteClient().GetAllAsync(new RequestContext());
            Assert.AreEqual(BinaryData.FromString("hello, world!").ToString(), ((CollectionsByteProperty)response).Property[0].ToString());
            Assert.AreEqual(BinaryData.FromString("hello, world!").ToString(), ((CollectionsByteProperty)response).Property[1].ToString());
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsByteClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(0, ((CollectionsByteProperty)response).Property.Count);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_putAll() => Test(async (host) =>
        {
            CollectionsByteProperty data = new();
            data.Property.Add(BinaryData.FromString("hello, world!"));
            data.Property.Add(BinaryData.FromString("hello, world!"));

            Response response = await new OptionalClient(host, null).GetCollectionsByteClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsByteClient().PutDefaultAsync(new CollectionsByteProperty());
            Assert.AreEqual(204, response.Status);
        });


        [Test]
        public Task Type_Property_Optional_CollectionsModel_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsModelClient().GetAllAsync(new RequestContext());
            var result = ((CollectionsModelProperty)response);
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_getDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsModelClient().GetDefaultAsync(new RequestContext());
            Assert.AreEqual(0, ((CollectionsModelProperty)response).Property.Count);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_putAll() => Test(async (host) =>
        {
            CollectionsModelProperty data = new();
            data.Property.Add(new StringProperty("hello", default));
            data.Property.Add(new StringProperty("world", default));

            Response response = await new OptionalClient(host, null).GetCollectionsModelClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_putDefault() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetCollectionsModelClient().PutDefaultAsync(new CollectionsModelProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_getAll() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetAllAsync(new RequestContext());
            var result = ((RequiredAndOptionalProperty)response);
            Assert.AreEqual("hello", result.OptionalProperty);
            Assert.AreEqual(42, result.RequiredProperty);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_getRequiredOnly() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetRequiredOnlyAsync(new RequestContext());
            var result = ((RequiredAndOptionalProperty)response);
            Assert.AreEqual(null, result.OptionalProperty);
            Assert.AreEqual(42, result.RequiredProperty);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_putAll() => Test(async (host) =>
        {
            var content = new RequiredAndOptionalProperty(42)
            {
                OptionalProperty = "hello"
            };

            Response response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutAllAsync(content);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_putRequiredOnly() => Test(async (host) =>
        {
            Response response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutRequiredOnlyAsync(new RequiredAndOptionalProperty(42));
            Assert.AreEqual(204, response.Status);
        });
    }
}
