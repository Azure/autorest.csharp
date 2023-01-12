//// Copyright (c) Microsoft Corporation. All rights reserved.
//// Licensed under the MIT License.

//using System.Linq;
//using System.Reflection;
//using System.Threading;
//using Azure;
//using ConvenienceInitialInCadl;
//using ConvenienceInCadl;
//using NUnit.Framework;

//namespace AutoRest.TestServer.Tests
//{
//    public class ConvenienceMethodTests
//    {
//        [Test]
//        public void InitialProtocolScenario()
//        {
//            var protocolInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialProtocol");
//            Assert.AreEqual(true, protocolInInitial.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInInitial.GetParameters().Last().ParameterType);
//            var convenienceInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialProtocolValue");
//            Assert.IsNull(convenienceInInitial);

//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialProtocol");
//            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialProtocolValue");
//            Assert.AreEqual(typeof(CancellationToken), convenienceInUpdate.GetParameters().Last().ParameterType);
//        }

//        [Test]
//        public void InitialConvenienceWithOptionalScenario()
//        {
//            var protocolInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceWithOptional");
//            var convenienceInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceWithOptionalValue");
//            Assert.AreEqual(true, protocolInInitial.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInInitial.GetParameters().Last().ParameterType);
//            Assert.AreEqual(typeof(CancellationToken), convenienceInInitial.GetParameters().Last().ParameterType);

//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceWithOptional");
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceWithOptionalValue");
//            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
//            Assert.AreEqual(typeof(CancellationToken), convenienceInUpdate.GetParameters().Last().ParameterType);
//        }

//        [Test]
//        public void InitialConvenienceWithRequiredScenario()
//        {
//            var protocolInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceWithRequired", new[] { typeof(RequestContext) });
//            var convenienceInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceWithRequired", new[] { typeof(CancellationToken) });
//            Assert.AreEqual(false, protocolInInitial.GetParameters().Last().IsOptional);
//            Assert.IsNotNull(convenienceInInitial);

//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceWithRequired", new[] { typeof(RequestContext) });
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceWithRequired", new[] { typeof(CancellationToken) });
//            Assert.AreEqual(false, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.IsNotNull(convenienceInUpdate);
//        }

//        [Test]
//        public void InitialConvenienceShouldNotGenerateScenario()
//        {
//            var protocolInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceShouldNotGenerate");
//            Assert.AreEqual(true, protocolInInitial.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInInitial.GetParameters().Last().ParameterType);
//            var convenienceInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialConvenienceShouldNotGenerateValue");
//            Assert.IsNull(convenienceInInitial);

//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceShouldNotGenerate");
//            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialConvenienceShouldNotGenerateValue");
//            Assert.IsNull(convenienceInUpdate);
//        }

//        [Test]
//        public void InitialProtocolShouldNotGenerateConvenienceScenario()
//        {
//            var protocolInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialProtocolShouldNotGenerateConvenience");
//            Assert.AreEqual(true, protocolInInitial.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInInitial.GetParameters().Last().ParameterType);
//            var convenienceInInitial = typeof(ConvenienceInitialInCadlClient).GetMethod("InitialProtocolShouldNotGenerateConvenienceValue");
//            Assert.IsNull(convenienceInInitial);

//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialProtocolShouldNotGenerateConvenience");
//            Assert.AreEqual(true, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.AreEqual(typeof(RequestContext), protocolInUpdate.GetParameters().Last().ParameterType);
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("InitialProtocolShouldNotGenerateConvenienceValue");
//            Assert.IsNull(convenienceInUpdate);
//        }

//        [Test]
//        public void UpdateConvenienceScenario()
//        {
//            var protocolInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("UpdateConvenience", new[] { typeof(RequestContext) });
//            var convenienceInUpdate = typeof(ConvenienceUpdateInCadlClient).GetMethod("UpdateConvenience", new[] { typeof(CancellationToken) });
//            Assert.AreEqual(false, protocolInUpdate.GetParameters().Last().IsOptional);
//            Assert.IsNotNull(convenienceInUpdate);
//        }
//    }
//}
