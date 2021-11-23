// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using LRO_LowLevel;
using System.Linq;

namespace AutoRest.TestServer.Tests
{
    public class LRO_LowLevelTests
    {
        [TestCase("DoSomethingSlroAsync")]
        [TestCase("DoSomethingSlro")]
        [TestCase("PageableSlroAsync")]
        [TestCase("PageableSlro")]
        public void ValidateSLROMethods(string methodName)
        {
            var client = typeof(LROServiceClient);
            var method = client.GetMethod(methodName);
            Assert.False(method.Name.StartsWith("Start"));

            var waitForCompletionParam = method.GetParameters().Where(P => P.Name == "waitForCompletion").First();
            Assert.NotNull(waitForCompletionParam);
            Assert.AreEqual(waitForCompletionParam.ParameterType, typeof(bool));
            Assert.AreEqual(waitForCompletionParam.IsOptional, true);
            Assert.AreEqual(waitForCompletionParam.DefaultValue, true);
        }

        [TestCase("StartDoSomethingLROAsync")]
        [TestCase("StartDoSomethingLRO")]
        [TestCase("StartPageableLROAsync")]
        [TestCase("StartPageableLRO")]
        public void ValidateLROMethods(string methodName)
        {
            var client = typeof(LROServiceClient);
            var method = client.GetMethod(methodName);
            Assert.True(method.Name.StartsWith("Start"));

            var waitForCompletionParam = method.GetParameters().Where(P => P.Name == "waitForCompletion").First();
            Assert.NotNull(waitForCompletionParam);
            Assert.AreEqual(waitForCompletionParam.ParameterType, typeof(bool));
            Assert.AreEqual(waitForCompletionParam.IsOptional, true);
            Assert.AreEqual(waitForCompletionParam.DefaultValue, false);
        }
    }
}
