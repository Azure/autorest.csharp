// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using Moq;
using NUnit.Framework;
using static AutoRest.CSharp.Input.Configuration;

namespace AutoRest.CSharp.Input
{
    public class CSharpProjConfigurationTests
    {
        private static readonly JsonElement TestJsonElement = JsonDocument.Parse("{}").RootElement;
        private static string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static Mock<IPluginCommunication> MockAutoRest(string? outputFolder, string? projectFolder, bool? azureArm, JsonElement? mgmtTestConfig, string? libraryName, string? ns, bool? skipCSProjPackageReference, bool? generation1ConvenienceClient)
        {
            var mockAutoRest = new Mock<IPluginCommunication>();
            mockAutoRest.Setup(p => p.GetValue<string>(Options.OutputFolder)).Returns(Task.FromResult(outputFolder));
            mockAutoRest.Setup(p => p.GetValue<string>(Options.ProjectFolder)).Returns(Task.FromResult(projectFolder));
            mockAutoRest.Setup(p => p.GetValue<bool?>(Options.AzureArm)).Returns(Task.FromResult(azureArm));
            mockAutoRest.Setup(p => p.GetValue<JsonElement?>(MgmtTestConfiguration.TestGenOptionsRoot)).Returns(Task.FromResult(mgmtTestConfig));
            mockAutoRest.Setup(p => p.GetValue<string?>(Options.LibraryName)).Returns(Task.FromResult(libraryName));
            mockAutoRest.Setup(p => p.GetValue<string?>(Options.Namespace)).Returns(Task.FromResult(ns));
            mockAutoRest.Setup(p => p.GetValue<bool?>(Options.SkipCSProjPackageReference)).Returns(Task.FromResult(skipCSProjPackageReference));
            mockAutoRest.Setup(p => p.GetValue<bool?>(Options.Generation1ConvenienceClient)).Returns(Task.FromResult(generation1ConvenienceClient));
            return mockAutoRest;
        }

        [Test]
        public void NormalCase()
        {
            Mock<IPluginCommunication> mockAutoRest = MockAutoRest("output-folder", "project-folder", true, TestJsonElement, "config-test", "test.autorest", true, true);

            var config = CSharpProjConfiguration.Initialize(mockAutoRest.Object, "test", "csharpgen.test");

            Assert.AreEqual(new CSharpProjConfiguration(
                AbsoluteProjectFolder: Path.Combine(AssemblyPath, "output-folder", "project-folder"),
                AzureArm: true,
                IsMgmtTestProject: true,
                LibraryName: "config-test",
                Namespace: "test.autorest",
                SkipCSProjPackageReference: true,
                RelativeProjectFolder: "project-folder",
                Generation1ConvenienceClient: true
                ), config);
        }

        [Test]
        public void ProjectFolderIsAbsolute()
        {
            var mockAutoRest = MockAutoRest("output-folder", Path.Combine(AssemblyPath, "project-folder"), false, TestJsonElement, "config-test", "test.autorest", false, false);

            var config = CSharpProjConfiguration.Initialize(mockAutoRest.Object, "test", "csharpgen.test");

            Assert.AreEqual(new CSharpProjConfiguration(
                AbsoluteProjectFolder: Path.Combine(AssemblyPath, "project-folder"),
                AzureArm: false,
                IsMgmtTestProject: true,
                LibraryName: "config-test",
                Namespace: "test.autorest",
                SkipCSProjPackageReference: false,
                RelativeProjectFolder: Path.GetRelativePath("output-foler", "project-folder"),
                Generation1ConvenienceClient: false
                ), config);
        }

        [Test]
        public void OptionsNotDefined()
        {
            var mockAutoRest = MockAutoRest("output-folder", "project-folder", null, null, null, null, null, null);

            var config = CSharpProjConfiguration.Initialize(mockAutoRest.Object, "test", "csharpgen.test");

            Assert.AreEqual(new CSharpProjConfiguration(
                AbsoluteProjectFolder: Path.Combine(AssemblyPath, "output-folder", "project-folder"),
                AzureArm: false,
                IsMgmtTestProject: false,
                LibraryName: "test",
                Namespace: "csharpgen.test",
                SkipCSProjPackageReference: false,
                RelativeProjectFolder: "project-folder",
                Generation1ConvenienceClient: false
                ), config);
        }
    }
}
