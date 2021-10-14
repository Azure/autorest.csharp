// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using NUnit.Framework;
using RequestOptionsRequired_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class RequestOptionsRequiredTests
    {
        [Test]
        public void RequiredRequestOptionsNoRequestBodyResponseBody()
        {
            var client = typeof(RequestOptionsRequiredClient);
            var method = client.GetMethod("NoRequestBodyResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(5, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(int));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestOptions));
            Assert.AreEqual(parameters[1].IsOptional, false);
            Assert.AreEqual(parameters[2].ParameterType, typeof(int?));
            Assert.AreEqual(parameters[2].IsOptional, true);
            Assert.AreEqual(parameters[3].ParameterType, typeof(int));
            Assert.AreEqual(parameters[3].IsOptional, true);
            Assert.AreEqual(parameters[4].ParameterType, typeof(string));
            Assert.AreEqual(parameters[4].IsOptional, true);
        }

        [Test]
        public void OptionalRequestOptionsDeleteNoRequestBodyResponseBody()
        {
            var client = typeof(RequestOptionsRequiredClient);
            var method = client.GetMethod("DeleteNoRequestBodyResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(string));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestOptions));
            Assert.AreEqual(parameters[1].IsOptional, true);
        }

        [Test]
        public void OptionalRequestOptionsRequestBodyResponseBody()
        {
            var client = typeof(RequestOptionsRequiredClient);
            var method = client.GetMethod("RequestBodyResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(RequestContent));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestOptions));
            Assert.AreEqual(parameters[1].IsOptional, true);
        }

        [Test]
        public void OptionalRequestOptionsNoRequestBodyNoResponseBody()
        {
            var client = typeof(RequestOptionsRequiredClient);
            var method = client.GetMethod("NoRequestBodyNoResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(1, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(RequestOptions));
            Assert.AreEqual(parameters[0].IsOptional, true);
        }

        [Test]
        public void OptionalRequestOptionsRequestBodyNoResponseBody()
        {
            var client = typeof(RequestOptionsRequiredClient);
            var method = client.GetMethod("RequestBodyNoResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(RequestContent));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestOptions));
            Assert.AreEqual(parameters[1].IsOptional, true);
        }
    }
}
