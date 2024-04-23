// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using AutoRest.TestServer.Tests.Infrastructure;
using TypeSpec.Versioning.Latest;
using TypeSpec.Versioning.Latest.Models;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Resource = TypeSpec.Versioning.Latest.Models.Resource;
using System.Threading;

namespace AutoRest.TestServer.Tests
{
    public class DpgVersionTest : TestServerLowLevelTestBase
    {
        [Test]
        public void LatestVersion()
        {
            var allProperties = new HashSet<string>(typeof(ExportedResource).GetProperties().Select(p => p.Name));
            // no "Name" property
            CollectionAssert.AreEquivalent(new HashSet<string>(new string[] { "Id", "ResourceUri", "Type" }), allProperties);

            var versionOpClient = typeof(VersioningOp);

            // no "Create" method, since it's "@removed"
            Assert.False(versionOpClient.GetMethods().Any(m => m.Name == "Create"));

            var exportOperation = versionOpClient.GetMethods().Where(m => m.Name == "Export" && m.ReturnType.BaseType.Name == "Operation" && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(ExportedResource)).FirstOrDefault();
            var exportOperationParameters = exportOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("waitUntil", typeof(WaitUntil)), ("name", typeof(string)), ("projectFileVersion", typeof(string)), ("projectedFileFormat", typeof(string)), ("maxLines", typeof(int?)), ("cancellationToken", typeof(CancellationToken)) }, exportOperationParameters);

            var getResourcesOperation = versionOpClient.GetMethods().Where(m =>
                m.Name == "GetResources" && m.ReturnType.Name.StartsWith("Pageable") && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(Resource)).FirstOrDefault();
            var getResourcesOperationParameters = getResourcesOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("select", typeof(IEnumerable<string>)), ("filter", typeof(string)), ("cancellationToken", typeof(CancellationToken)) },getResourcesOperationParameters);

            var createLongRunningOperation = versionOpClient.GetMethods().Where(m => m.Name == "CreateLongRunning" && m.ReturnType.BaseType.Name == "Operation" && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(Resource)).FirstOrDefault();
            var createLongRunningOperationParameters = createLongRunningOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("waitUntil", typeof(WaitUntil)), ("name", typeof(string)), ("resource", typeof(Resource)), ("cancellationToken", typeof(CancellationToken)) }, createLongRunningOperationParameters);

        }
    }
}
