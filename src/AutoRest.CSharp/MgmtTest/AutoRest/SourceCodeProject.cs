// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class SourceCodeProject
    {
        private Project sourceCodeProject;
        public SourceCodeProject(string sourceCodePath)
        {
            if (Uri.IsWellFormedUriString(sourceCodePath, UriKind.RelativeOrAbsolute))
            {
                Uri uri = new Uri(sourceCodePath);
                sourceCodePath = uri.LocalPath;
            }
            else
            {
                sourceCodePath = Path.GetFullPath(sourceCodePath);
            }

            sourceCodeProject = CreateGeneratedCodeProject();
            foreach (string sourceFile in Directory.GetFiles(sourceCodePath, "*.cs", SearchOption.AllDirectories))
            {
                //// Ignore existing generated code
                //if (sourceFile.StartsWith(outputDirectory))
                //{
                //    continue;
                //}
                sourceCodeProject = sourceCodeProject.AddDocument(sourceFile, File.ReadAllText(sourceFile), Array.Empty<string>(), sourceFile).Project;
            }

            Compilation = sourceCodeProject.GetCompilationAsync().GetAwaiter().GetResult()!;
            Debug.Assert(Compilation != null);
        }

        public Compilation Compilation { get; }

        private static Project CreateGeneratedCodeProject()
        {
            var workspace = new AdhocWorkspace();
            Project generatedCodeProject = workspace.AddProject("SourceCode", LanguageNames.CSharp);

            var corlibLocation = typeof(object).Assembly.Location;
            var references = new List<MetadataReference>();

            references.Add(MetadataReference.CreateFromFile(corlibLocation));

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(tpl));
            }

            generatedCodeProject = generatedCodeProject
                .AddMetadataReferences(references)
                .WithCompilationOptions(new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Disable));
            return generatedCodeProject;
        }
    }
}
