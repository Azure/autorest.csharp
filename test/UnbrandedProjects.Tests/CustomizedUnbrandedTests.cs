// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using CustomizedTypeSpec.Models;
//namespace AutoRest.TestServer.Tests.Infrastructure
//{
namespace UnbrandedProjects.Tests
{
    public class CustomizedUnbrandedTests
    {
        [Test]
        public void VerifyCodeGenMember()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("SuperRoundTripModel").GetProperty("RequiredSuperString"));
        }

        [Test]
        public void VerifyCodeGenSerialization()
        {
            SuperRoundTripModel model = new SuperRoundTripModel
            (
                "requiredSuperString",
                1,
                new List<StringFixedEnum?> { StringFixedEnum.One, StringFixedEnum.Two },
                new Dictionary<string, StringExtensibleEnum?> { { "1", StringExtensibleEnum.One }, { "2", StringExtensibleEnum.Two } },
                new Thing
                {
                    Name = "requiredModel",
                    OptionalLiteralBool = true
                },
                BinaryData.FromObjectAsJson(1),
                new Dictionary<string, BinaryData> { { "1", BinaryData.FromObjectAsJson(1) }, { "2", BinaryData.FromObjectAsJson(2) } },
                new ModelWithRequiredNullableProperties
                {
                    RequiredNullablePrimitive = 1,
                    RequiredExtensibleEnum = StringExtensibleEnum.One,
                    RequiredFixedEnum = StringFixedEnum.Two
                }
            );

            BinaryData x = ModelReaderWriter.Write(model);
            var stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream);
            var options = new ModelReaderWriterOptions("J");
            ((IJsonModel<SuperRoundTripModel>)model).Write(writer, options);


            writer.Flush();
            stream.Position = 0;
            string jsonString = Encoding.UTF8.GetString(stream.ToArray());

            //var jsonString = JsonSerializer.Serialize(model);
            //BinaryData x = ModelReaderWriter.Write(model);
            ////var y = Convert.ToBase64String(x);
            Assert.IsTrue(jsonString.Contains("requiredSuperModel"));
            Assert.IsFalse(jsonString.Contains("requiredModel"));
        }

        [Test]
        public void VerifyCodeGenType()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("SuperRoundTripModel"));
        }

        [Test]
        public void VerifyCodeGenModel()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("SuperFriend"));
        }

        //[Test]
        //public void VerifyCodeGenSuppress()
        //{
        //    Assert.AreEqual("RoundTripModel6", typeof(RoundTripModel6).Name);
        //}
    }
}
