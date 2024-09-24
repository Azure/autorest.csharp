// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using TypeSpec.Versioning.Specific;
using TypeSpec.Versioning.Specific.Models;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Resource = TypeSpec.Versioning.Specific.Models.Resource;
using System.Threading;
using System.Reflection;

namespace AutoRest.TestServer.Tests
{
    public class DpgSpecificVersionTest
    {
        [Test]
        public void SpecificVersion()
        {
            var allProperties = new HashSet<string>(typeof(ExportedResource).GetProperties().Select(p => p.Name));
            // no "Name" and "Type" property
            CollectionAssert.AreEquivalent(new HashSet<string>(new string[] { "Id", "ResourceUri" }), allProperties);

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
            Assert.AreEqual(new (string, Type)[] { ("waitUntil", typeof(WaitUntil)), ("name", typeof(string)), ("projectFileVersion", typeof(string)), ("cancellationToken", typeof(CancellationToken)) }, exportOperationParameters);

            var getResourcesOperation = versionOpClient.GetMethods().Where(m =>
                m.Name == "GetResources" && m.ReturnType.Name.StartsWith("Pageable") && m.ReturnType.GenericTypeArguments.Length == 1 &&
                m.ReturnType.GenericTypeArguments[0] == typeof(Resource)).FirstOrDefault();
            var getResourcesOperationParameters = getResourcesOperation.GetParameters().Select(p => (p.Name, p.ParameterType)).ToArray();
            Assert.AreEqual(new (string, Type)[] { ("select", typeof(IEnumerable<string>)), ("expand", typeof(string)), ("cancellationToken", typeof(CancellationToken)) }, getResourcesOperationParameters);

            // 1 versions are defined
            var enumType = typeof(SpecificClientOptions.ServiceVersion);
            Assert.AreEqual(new string[] { "V2022_09_01" }, enumType.GetEnumNames());
            var optionsType = typeof(SpecificClientOptions);
            var field = optionsType.GetField("LatestVersion", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.AreEqual(SpecificClientOptions.ServiceVersion.V2022_09_01, field.GetValue(null));
        }
    }
}
