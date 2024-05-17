// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using Scm._Type.Property.Optionality;
using Scm._Type.Property.Optionality.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class TypePropertyOptionalTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Type_Property_Optional_BooleanLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().GetAllAsync();
            Assert.AreEqual(true, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_BooleanLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_BooleanLiteral_putAll() => Test(async (host) =>
        {
            BooleanLiteralProperty data = new()
            {
                Property = true
            };
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_BooleanLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutDefaultAsync(new BooleanLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_String_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetAllAsync();
            Assert.AreEqual("hello", response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_String_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_String_putAll() => Test(async (host) =>
        {
            StringProperty data = new()
            {
                Property = "hello"
            };
            var  response = await new OptionalClient(host, null).GetStringClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_String_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().PutDefaultAsync(new StringProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_putAll() => Test(async (host) =>
        {
            BytesProperty data = new()
            {
                Property = BinaryData.FromString("hello, world!")
            };
            var response = await new OptionalClient(host, null).GetBytesClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Bytes_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().PutDefaultAsync(new BytesProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetAllAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_putAll() => Test(async (host) =>
        {
            DatetimeProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-08-26T18:38:00Z")
            };
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Datetime_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutDefaultAsync(new DatetimeProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Duration_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetAllAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Duration_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_Duration_putAll() => Test(async (host) =>
        {
            DurationProperty data = new()
            {
                Property = XmlConvert.ToTimeSpan("P123DT22H14M12.011S")
            };
            var response = await new OptionalClient(host, null).GetDurationClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_Duration_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().PutDefaultAsync(new DurationProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property[0]);
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property[1]);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().GetDefaultAsync();
            Assert.AreEqual(0, response.Value.Property.Count);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_putAll() => Test(async (host) =>
        {
            CollectionsByteProperty data = new();
            data.Property.Add(BinaryData.FromString("hello, world!"));
            data.Property.Add(BinaryData.FromString("hello, world!"));

            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsByte_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutDefaultAsync(new CollectionsByteProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });


        [Test]
        public Task Type_Property_Optional_CollectionsModel_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetAllAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
            Assert.AreEqual(2, result.Property.Count);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetDefaultAsync();
            Assert.AreEqual(0, response.Value.Property.Count);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_putAll() => Test(async (host) =>
        {
            CollectionsModelProperty data = new();
            data.Property.Add(new StringProperty()
            {
                Property = "hello"
            });
            data.Property.Add(new StringProperty()
            {
                Property = "world"
            });

            var response = await new OptionalClient(host, null).GetCollectionsModelClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_CollectionsModel_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().PutDefaultAsync(new CollectionsModelProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetAllAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.OptionalProperty);
            Assert.AreEqual(42, result.RequiredProperty);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_getRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetRequiredOnlyAsync();
            var result = response.Value;
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

            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutAllAsync(content);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_RequiredAndOptional_putRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutRequiredOnlyAsync(new RequiredAndOptionalProperty(42));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_FloatLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetAllAsync();
            Assert.AreEqual(FloatLiteralPropertyProperty._125, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_FloatLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_FloatLiteral_putAll() => Test(async (host) =>
        {
            FloatLiteralProperty data = new()
            {
                Property = new FloatLiteralPropertyProperty(1.25f)
            };
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_FloatLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutDefaultAsync(new FloatLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_IntLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetAllAsync();
            Assert.AreEqual(IntLiteralPropertyProperty._1, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_IntLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_IntLiteral_putAll() => Test(async (host) =>
        {
            IntLiteralProperty data = new()
            {
                Property = 1
            };
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_IntLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutDefaultAsync(new IntLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_StringLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetAllAsync();
            Assert.AreEqual(StringLiteralPropertyProperty.Hello, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_StringLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_StringLiteral_putAll() => Test(async (host) =>
        {
            StringLiteralProperty data = new()
            {
                Property = "hello"
            };
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_StringLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutDefaultAsync(new StringLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionFloatLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromObjectAsJson(2.375), response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionFloatLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionFloatLiteral_putAll() => Test(async (host) =>
        {
            UnionFloatLiteralProperty data = new()
            {
                Property = BinaryData.FromString("2.375")
            };
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionFloatLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutDefaultAsync(new UnionFloatLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionIntLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromObjectAsJson(2), response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionIntLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionIntLiteral_putAll() => Test(async (host) =>
        {
            UnionIntLiteralProperty data = new()
            {
                Property = BinaryData.FromString("2")
            };
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionIntLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutDefaultAsync(new UnionIntLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionStringLiteral_getAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetAllAsync();
            Assert.AreEqual(UnionStringLiteralPropertyProperty.World, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionStringLiteral_getDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [Test]
        public Task Type_Property_Optional_UnionStringLiteral_putAll() => Test(async (host) =>
        {
            UnionStringLiteralProperty data = new()
            {
                Property = UnionStringLiteralPropertyProperty.World,
            };
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Property_Optional_UnionStringLiteral_putDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutDefaultAsync(new UnionStringLiteralProperty());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
