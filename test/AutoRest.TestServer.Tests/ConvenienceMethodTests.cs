// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using Azure;
using ConvenienceInCadl;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ConvenienceMethodTests
    {
        [Test]
        public void ProtocolScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("Protocol");
            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ProtocolValue");
            Assert.AreEqual(typeof(CancellationToken), convenienceInUpdate.GetParameters().Last().ParameterType);
        }

        [Test]
        public void ConvenienceWithOptionalScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceWithOptional");
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceWithOptionalValue");
            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
            Assert.AreEqual(typeof(CancellationToken), convenienceInUpdate.GetParameters().Last().ParameterType);
        }

        [Test]
        public void ConvenienceWithRequiredScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceWithRequired", new[] { typeof(RequestContext) });
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceWithRequired", new[] { typeof(CancellationToken) });
            Assert.AreEqual(false, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.IsNotNull(convenienceInUpdate);
        }

        [Test]
        public void ConvenienceShouldNotGenerateScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceShouldNotGenerate");
            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ConvenienceShouldNotGenerateValue");
            Assert.IsNull(convenienceInUpdate);
        }

        [Test]
        public void ProtocolShouldNotGenerateConvenienceScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ProtocolShouldNotGenerateConvenience");
            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("ProtocolShouldNotGenerateConvenienceValue");
            Assert.IsNull(convenienceInUpdate);
        }

        [Test]
        public void UpdateConvenienceScenario()
        {
            var protocolInUpdate = typeof(ConvenienceInCadlClient).GetMethod("UpdateConvenience", new[] { typeof(RequestContext) });
            var convenienceInUpdate = typeof(ConvenienceInCadlClient).GetMethod("UpdateConvenience", new[] { typeof(CancellationToken) });
            Assert.AreEqual(false, protocolInUpdate.GetParameters().Last().IsOptional);
            Assert.IsNotNull(convenienceInUpdate);
        }
    }
}
