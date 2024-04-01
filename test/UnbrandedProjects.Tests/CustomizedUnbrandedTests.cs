// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CustomizedTypeSpec.Models;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace CustomizedTypeSpec.Tests
{
    public class CustomizedUnbrandedTests
    {
        [Test]
        public void VerifyCodeGenMember()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("CustomizedTypeSpec.Models.SuperRoundTripModel").GetProperty("RequiredSuperInt"));
        }

        [Test]
        public void VerifyCodeGenSerialization()
        {
            SuperRoundTripModel model = new SuperRoundTripModel
            (
                "requiredSuperString",
                1
            );

            BinaryData binaryData = ModelReaderWriter.Write(model);
            string jsonString = binaryData.ToString();
            Assert.IsTrue(jsonString.Contains("requiredSuperString"));
            Assert.IsFalse(jsonString.Contains("requiredString"));
        }

        [Test]
        public void VerifyCodeGenType()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("CustomizedTypeSpec.Models.SuperRoundTripModel"));
            Assert.Null(this.GetType().Assembly.GetType("CustomizedTypeSpec.Models.RoundTripModel"));
        }

        [Test]
        public void VerifyCodeGenModel()
        {
            Assert.NotNull(this.GetType().Assembly.GetType("CustomizedTypeSpec.Models.SuperFriend"));
        }

        [Test]
        public void VerifyCodeGenSuppress()
        {
            var t = GetType().Assembly.GetType("CustomizedTypeSpec.Models.ModelWithFormat");

            Type[] parameterTypes = { typeof(Uri), typeof(Guid), typeof(string), typeof(IDictionary<string, BinaryData>)};
            var constructor = t.GetConstructor(parameterTypes);
            Assert.NotNull(constructor);

            Type[] parameterTypes1 = { typeof(Uri), typeof(Guid) };
            var constructor1 = t.GetConstructor(parameterTypes1);
            Assert.Null(constructor1);
        }
    }
}
