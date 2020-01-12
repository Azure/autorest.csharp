// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Plugins
{
    internal class WorkspaceFactory
    {
        public static string SharedFolder = "shared";

        private static readonly string SharedSourceDirectory = Path.Combine(Path.GetDirectoryName(typeof(WorkspaceFactory).Assembly.Location)!, "Azure.Core.Shared");
        private static readonly string[] SharedFolders = { SharedFolder };

        public static Project CreateGeneratedCodeProject()
        {
            var workspace = new AdhocWorkspace();
            // TODO: This is not the right way to construct the workspace but it works
            Project generatedCodeProject = workspace.AddProject("GeneratedCode", LanguageNames.CSharp);

            var corlibLocation = typeof(object).Assembly.Location;

            generatedCodeProject = generatedCodeProject.AddMetadataReference(MetadataReference.CreateFromFile(corlibLocation));

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                generatedCodeProject = generatedCodeProject.AddMetadataReference(MetadataReference.CreateFromFile(tpl));
            }

            generatedCodeProject = generatedCodeProject.WithCompilationOptions(new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Annotations));

            foreach (string sharedSourceFile in Directory.GetFiles(SharedSourceDirectory, "*.cs"))
            {
                generatedCodeProject = generatedCodeProject.AddDocument(sharedSourceFile, File.ReadAllText(sharedSourceFile), SharedFolders, sharedSourceFile).Project;
            }

            return generatedCodeProject;
        }
    }
}
