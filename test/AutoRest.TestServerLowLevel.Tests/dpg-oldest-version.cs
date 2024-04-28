// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using TypeSpec.Versioning.Oldest;
using TypeSpec.Versioning.Oldest.Models;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Resource = TypeSpec.Versioning.Oldest.Models.Resource;
using System.Threading;

namespace AutoRest.TestServer.Tests
{
    public class DpgOldestVersionTest
    {
        [Test]
        public void OldestVersion()
        {
            var allProperties = new HashSet<string>(typeof(ExportedResource).GetProperties().Select(p => p.Name));
            // TODO: add "Type" after https://github.com/microsoft/typespec/issues/3239 is fixed
            CollectionAssert.AreEquivalent(new HashSet<string>(new string[] { "Id", "ResourceUri", "Name" }), allProperties);

            var versionOpClient = typeof(VersioningOp);

            // no "CreateLongRunning" method, since it's "@added(ApiVersions.v2022_12_01_preview)"
            Assert.False(versionOpClient.GetMethods().Any(m => m.Name == "CreateLongRunning"));

            var createOperation = versionOpClient.GetMethods().Where(m => m.Name == "Create" && m.ReturnType.Name.StartsWith("Response") && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(Resource)).FirstOrDefault();
            var createOperationParameters = createOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("name", typeof(string)), ("resource", typeof(Resource)), ("cancellationToken", typeof(CancellationToken)) }, createOperationParameters);

            var exportOperation = versionOpClient.GetMethods().Where(m => m.Name == "Export" && m.ReturnType.BaseType.Name == "Operation" && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(ExportedResource)).FirstOrDefault();
            var exportOperationParameters = exportOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("waitUntil", typeof(WaitUntil)), ("name", typeof(string)), ("projectFileVersion", typeof(string)), ("removedQueryParam", typeof(string)), ("cancellationToken", typeof(CancellationToken)) }, exportOperationParameters);

            var getResourcesOperation = versionOpClient.GetMethods().Where(m =>
                m.Name == "GetResources" && m.ReturnType.Name.StartsWith("Pageable") && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(Resource)).FirstOrDefault();
            var getResourcesOperationParameters = getResourcesOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("select", typeof(IEnumerable<string>)), ("expand", typeof(string)), ("cancellationToken", typeof(CancellationToken)) },getResourcesOperationParameters);
        }
    }
}
