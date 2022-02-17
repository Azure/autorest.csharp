// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure;
using NUnit.Framework;
using ProtocolMethodsInRestClient;

namespace AutoRest.TestServer.Tests
{
    internal class ProtocolMethodsInRestClientTests
    {
        [TestCase("Delete", true)]
        [TestCase("Create", true)]
        [TestCase("Get", false)]
        public void ProtocolMethodGeneratedInRestClient(string methodName, bool isProtocolMethodGenerated)
        {
            var methods = typeof(TestServiceRestClient).GetMethods();
            Assert.IsNotNull(methods);

            var restClientMethods = methods.Where(m => m.Name.Equals(methodName));
            if (isProtocolMethodGenerated)
            {
                Assert.AreEqual(2, restClientMethods.Count());

                var isProtocolMethodExists = false;
                foreach (var method in restClientMethods)
                {
                    if (method.GetParameters().Any(p => p.ParameterType.Equals(typeof(RequestContext))))
                    {
                        isProtocolMethodExists = true;
                    }
                }

                Assert.IsTrue(isProtocolMethodExists);
            }
            else
            {
                Assert.AreEqual(1, restClientMethods.Count());
                Assert.IsFalse(isProtocolMethodGenerated);
                var parameters = restClientMethods.FirstOrDefault().GetParameters();
                Assert.IsFalse(parameters.Any(p => p.GetType().Equals(typeof(RequestContext))));
            }
        }

    }
}
