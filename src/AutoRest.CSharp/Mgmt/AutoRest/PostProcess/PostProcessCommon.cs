// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.AutoRest.Plugins;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class PostProcessCommon
    {
        /// <summary>
        /// Get all the models (including Clients) defined in this generated project.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="publicOnly"></param>
        /// <returns></returns>
        public static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetModels(Project project, bool publicOnly)
        {
            var classVisitor = new DefinitionVisitor(publicOnly);

            foreach (var document in project.Documents)
            {
                if (!GeneratedCodeWorkspace.IsSharedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        /// <summary>
        /// Get the "root node" in this generated project.
        /// A root node is defined as the type defined in a root document (file).
        /// A root document (file) consists of three different types:
        /// 1. the file is `IsMgmtRootDocument` - it is generated and under the root directory or `Extensions` of our generated output folder. This includes all the resource classes, collection classes, data classes and all the extension clients
        /// 2. the file is declaring a `ReferenceType`, a special type with some specific attributes
        /// 3. the file is customized code (not generated and not shared)
        /// </summary>
        /// <param name="project"></param>
        /// <param name="publicOnly"></param>
        /// <param name="modelsToKeep"></param>
        /// <returns></returns>
        public static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetRootNodes(Project project, bool publicOnly, ImmutableHashSet<string>? modelsToKeep = null)
        {
            modelsToKeep ??= ImmutableHashSet<string>.Empty;
            var classVisitor = new DefinitionVisitor(publicOnly);
            foreach (var document in project.Documents)
            {
                var root = await document.GetSyntaxRootAsync();
                // we add a declaration as root node when
                // 1. the file is under `Generated` or `Generated/Extensions` which is handled by `IsMgmtRootDocument`
                // 2. the declaration has a ReferenceType or similar attribute on it which is handled by `IsReferenceType`
                // 3. the file is customized code (not generated and not shared) which is handled by `IsCustomDocument`
                if (IsMgmtRootDocument(document) || IsReferenceType(root) || GeneratedCodeWorkspace.IsCustomDocument(document) || ShouldKeepModel(root, modelsToKeep))
                {
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        public static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetClients(Project project)
        {
            var classVisitor = new DefinitionVisitor(false);
            foreach (var document in project.Documents)
            {
                var root = await document.GetSyntaxRootAsync();
                if (IsMgmtRootDocument(document) && GeneratedCodeWorkspace.IsGeneratedDocument(document))
                {
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        private static bool IsMgmtRootDocument(Document document) => GeneratedCodeWorkspace.IsGeneratedDocument(document) && Path.GetDirectoryName(document.Name) is "Extensions" or "";

        private static HashSet<string> _referenceAttributes = new HashSet<string> { "ReferenceType", "PropertyReferenceType", "TypeReferenceType" };

        private static bool IsReferenceType(SyntaxNode? root)
        {
            if (root is null)
                return false;

            var childNodes = root.DescendantNodes();
            var typeNode = childNodes.OfType<TypeDeclarationSyntax>().FirstOrDefault();
            if (typeNode is null)
            {
                return false;
            }

            var attributeLists = GetAttributeLists(typeNode);
            if (attributeLists is null || attributeLists.Value.Count == 0)
                return false;

            foreach (var attributeList in attributeLists.Value)
            {
                if (_referenceAttributes.Contains(attributeList.Attributes[0].Name.ToString()))
                    return true;
            }

            return false;
        }

        private static SyntaxList<AttributeListSyntax>? GetAttributeLists(SyntaxNode node)
        {
            if (node is StructDeclarationSyntax structDeclaration)
                return structDeclaration.AttributeLists;

            if (node is ClassDeclarationSyntax classDeclaration)
                return classDeclaration.AttributeLists;

            return null;
        }

        private static bool ShouldKeepModel(SyntaxNode? root, ImmutableHashSet<string> modelsToKeep)
        {
            if (root is null)
                return false;

            // use `BaseTypeDeclarationSyntax` to also include enums because `EnumDeclarationSyntax` extends `BaseTypeDeclarationSyntax`
            // `ClassDeclarationSyntax` and `StructDeclarationSyntax` both inherit `TypeDeclarationSyntax`
            var typeNodes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
            // there is possibility that we have multiple types defined in the same document (for instance, custom code)
            return typeNodes.Any(t => modelsToKeep.Contains(t.Identifier.Text));
        }
    }
}
