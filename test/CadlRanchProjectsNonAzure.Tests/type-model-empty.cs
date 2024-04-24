﻿using System.Threading.Tasks;
using Scm._Type.Model.Empty;
using Scm._Type.Model.Empty.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class TypeModelEmptyTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Type_Model_Empty_putEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).PutEmptyAsync(new EmptyInput());
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Model_Empty_getEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).GetEmptyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Model_Empty_postRoundTripEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).PostRoundTripEmptyAsync(new EmptyInputOutput());
            Assert.AreEqual(200, response.GetRawResponse().Status);
        });
    }
}
