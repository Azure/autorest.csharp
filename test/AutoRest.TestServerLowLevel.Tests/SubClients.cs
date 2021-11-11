// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using SubClients_LowLevel;
using SingleTopLevelClientWithOperations_LowLevel;
using SingleTopLevelClientWithoutOperations_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class SubClientTests
    {
        [Test]
        public void SubClientPublicMethods()
        {
            TypeAsserts.HasPublicInstanceMethod(typeof(RootClient), $"Get{nameof(Parameter)}Client");
        }

        [Test]
        public void TopLevelClientWithOperationPublicMethods()
        {
            TypeAsserts.TypeOnlyDeclaresThesePublicMethods(typeof(TopLevelClientWithOperationClient), "Operation", "OperationAsync", $"Get{nameof(Client1)}Client", $"Get{nameof(Client2)}Client");
        }

        [Test]
        public void TopLevelClientWithoutOperationPublicMethods()
        {
            TypeAsserts.TypeOnlyDeclaresThesePublicMethods(typeof(TopLevelClientWithoutOperationClient), $"Get{nameof(Client3)}Client", $"Get{nameof(Client4)}Client", $"Get{nameof(Client5)}Client");
        }
    }
}
