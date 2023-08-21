// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure;
using ConfidentLevelsInTsp;
using ConfidentLevelsInTsp.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ConfidentLevelsTypeSpecTests
    {
        [TestCase(typeof(ModelWithUnionProperty), false)]
        [TestCase(typeof(AnotherModelWithUnionProperty), false)]
        [TestCase(typeof(NonConfidentModelWithSelfReference), false)]
        [TestCase(typeof(NonConfidentModelWithIndirectSelfReference), false)]
        [TestCase(typeof(IndirectSelfReferenceModel), false)]
        [TestCase(typeof(ModelWithIntegerLiteralTypeProperty), false)]
        [TestCase(typeof(ModelWithFloatLiteralTypeProperty), false)]
        [TestCase(typeof(PollutedPet), false)]
        [TestCase(typeof(UnpollutedCat), false)]
        [TestCase(typeof(PollutedDog), false)]
        [TestCase(typeof(Pet), true)]
        [TestCase(typeof(Cat), true)]
        [TestCase(typeof(Dog), true)]
        public void LowConfidentModelsShouldBeInternal(Type model, bool isPublic)
        {
            Assert.AreEqual(isPublic, model.IsPublic, $"model {model}.IsPublic should not {isPublic}");
        }

        [TestCase(typeof(ConfidentLevelsInTspClient), "UnionInRequestProperty", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "UnionInResponseProperty", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "UnionWithSelfReference", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "UnionWithInderict", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "literalOfInteger", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "literalOfFloat", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "ConfidentOperationWithDiscriminator", true)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "PollutedBaseMethod", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "pollutedDerivedMethod", false)]
        [TestCase(typeof(ConfidentLevelsInTspClient), "unpollutedDerivedMethod", false)]
        public void LowConfidentOperationsShouldBeInternal(Type clientType, string methodName, bool isPublic)
        {
            var methods = clientType.GetMethods().Where(m => m.Name == methodName || m.Name == $"{methodName}Async");
            foreach (var method in methods)
            {
                // ignore the method if it is a protocol method
                var lastParameter = method.GetParameters().Last();
                if (lastParameter.ParameterType.Equals(typeof(RequestContext)))
                    continue;

                Assert.AreEqual(isPublic, method.IsPublic, $"Method {method}.IsPublic should be {isPublic}");
            }
        }

        [TestCase(typeof(ModelWithUnionProperty), "UnionProperty")]
        [TestCase(typeof(AnotherModelWithUnionProperty), "UnionProperty")]
        [TestCase(typeof(NonConfidentModelWithSelfReference), "UnionProperty")]
        [TestCase(typeof(IndirectSelfReferenceModel), "UnionProperty")]
        [TestCase(typeof(PollutedDog), "Color")]
        public void TypeOfUnionPropertyShouldBeGeneratedAsObject(Type model, string propertyName)
        {
            var property = model.GetProperty(propertyName);

            Assert.AreEqual(typeof(object), property.PropertyType, $"Type of property {property} in model {model} should always be object");
        }
    }
}
