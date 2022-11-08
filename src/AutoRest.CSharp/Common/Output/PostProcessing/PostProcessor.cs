using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Mgmt.AutoRest.PostProcess;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.Common.Output.PostProcessing;

internal abstract class PostProcessor
{
    protected Project project;

    public PostProcessor(Project project)
    {
        this.project = project;
    }

    protected virtual async Task<HashSet<BaseTypeDeclarationSyntax>> GetModels(bool publicOnly = true)
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

    public async Task<Project> InternalizeAsync()
    {
        // first get all the declared models
        var definitions = await GetModels(true);
        // get the root nodes
        var rootNodes = await GetRootNodes(true);
        // traverse all the root and recursively add all the things we met
        var publicModels = TraverseAllPublicModelsAsync(rootNodes);

        await foreach (var model in publicModels)
        {
            definitions.Remove(model);
        }

        // get the models we need to mark internal
        foreach (var model in definitions)
        {
            MarkInternal(model);
        }

        return project;
    }

    //public async Task<Project> RemoveAsync()
    //{
    //    // find all the declarations, including non-public declared
    //    var definitions = await GetModels(false);
    //    // build reference map
    //    var referenceMap = await BuildReferenceMap(definitions);
    //    // get root nodes
    //    var rootNodes = await GetRootNodes(false);
    //    // traverse the map to determine the declarations that we are about to remove, starting from root nodes
    //    var referencedDefinitions = TraverseAllModelsAsync(rootNodes, referenceMap);
    //    // remove those declarations one by one
    //    foreach (var model in referencedDefinitions)
    //    {
    //        definitions.Remove(model);
    //    }
    //    // remove them one by one
    //    await RemoveModelsAsync(definitions);

    //    return project;
    //}

    private static IEnumerable<BaseTypeDeclarationSyntax> TraverseModelsAsync(IEnumerable<BaseTypeDeclarationSyntax> rootNodes, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> referenceMap)
    {
        var queue = new Queue<BaseTypeDeclarationSyntax>(rootNodes);
        var visited = new HashSet<BaseTypeDeclarationSyntax>();
        while (queue.Count > 0)
        {
            var definition = queue.Dequeue();
            if (visited.Contains(definition))
                continue;
            visited.Add(definition);
            // add this definition to the result
            yield return definition;
            // add every type referenced by this node to the queue
            foreach (var child in GetReferencedTypes(definition, referenceMap))
            {
                queue.Enqueue(child);
            }
        }
    }

    private static IEnumerable<BaseTypeDeclarationSyntax> GetReferencedTypes(BaseTypeDeclarationSyntax definition, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> referenceMap)
    {
        if (referenceMap.TryGetValue(definition, out var references))
        {
            foreach (var reference in references)
            {
                yield return reference;
            }
        }
    }

    /// <summary>
    /// This method returns a dictionary from a declaration of a type, to the declarations that are referenced in this declaration
    /// </summary>
    /// <param name="definitions"></param>
    /// <returns></returns>
    protected virtual async Task<Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>> BuildPublicReferenceMap(IEnumerable<BaseTypeDeclarationSyntax> definitions)
    {
        var compilation = await project.GetCompilationAsync();
        if (compilation == null)
            return new Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>();

        var references = new Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>();
        var visited = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
        foreach (var definition in definitions)
        {
            var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
            var symbol = semanticModel.GetDeclaredSymbol(definition);
            if (symbol == null)
                continue;

            // add the class and all its partial classes to the map
            // this will make all the partial classes are referencing each other in the reference map
            // when we make the travesal over the reference map, we will not only remove one of the partial class, instead we will either keep all the partial classes (if at least one of them has references), or remove all of them (if none of them has references)
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var node = await reference.GetSyntaxAsync();
                AddToReferenceMap(definition, node as BaseTypeDeclarationSyntax, references);
            }
            await ProcessSymbol(project, symbol, definition, references, visited);
        }

        return references;
    }

    private async IAsyncEnumerable<BaseTypeDeclarationSyntax> TraverseAllPublicModelsAsync(HashSet<BaseTypeDeclarationSyntax> rootNodes)
    {
        var compilation = await project.GetCompilationAsync();
        if (compilation == null)
            yield break;

        var queue = new Queue<BaseTypeDeclarationSyntax>(rootNodes);
        // traverse all the models starting from the root nodes
        var visited = new HashSet<BaseTypeDeclarationSyntax>();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (visited.Contains(node))
                continue;
            visited.Add(node);
            // add this node to the public list
            yield return node;
            // add every type referenced by this node to the queue
            await foreach (var child in GetReferencedTypes(compilation, project, node))
            {
                queue.Enqueue(child);
            }
        }
    }

    private async IAsyncEnumerable<BaseTypeDeclarationSyntax> GetReferencedTypes(Compilation compilation, Project project, SyntaxNode root)
    {
        var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);
        var publicMemberVisitor = new MemberVisitor(true);
        publicMemberVisitor.Visit(root);
        foreach (var member in publicMemberVisitor.PublicMembers)
        {
            var symbol = semanticModel.GetDeclaredSymbol(member);
            if (symbol == null)
                continue;
            var list = new HashSet<BaseTypeDeclarationSyntax>();
            await ProcessSymbol(project, symbol, list);
            foreach (var node in list)
            {
                yield return node;
            }
        }
    }

    protected virtual async Task ProcessSymbol(Project project, ISymbol? symbol, HashSet<BaseTypeDeclarationSyntax> result)
    {
        if (symbol == null || symbol.DeclaredAccessibility != Accessibility.Public)
            return;
        switch (symbol)
        {
            case INamedTypeSymbol typeSymbol:
                foreach (var reference in typeSymbol.DeclaringSyntaxReferences)
                {
                    var node = await reference.GetSyntaxAsync();
                    // short cut the recursive execution if this has already been in the result
                    if (result.Contains(node))
                        return;
                    Debug.Assert(node is BaseTypeDeclarationSyntax);
                    var declaration = (BaseTypeDeclarationSyntax)node;
                    result.Add(declaration);
                    if (HasDiscriminator(declaration, out var identifierCandidates))
                    {
                        // first find all the derived types from this type
                        foreach (var derivedTypeSymbol in await SymbolFinder.FindDerivedClassesAsync(typeSymbol, project.Solution))
                        {
                            if (identifierCandidates.Contains(derivedTypeSymbol.Name))
                            {
                                await ProcessSymbol(project, derivedTypeSymbol, result);
                            }
                        }
                    }
                }
                await ProcessSymbol(project, typeSymbol.BaseType, result);
                foreach (var typeArgument in typeSymbol.TypeArguments)
                {
                    await ProcessSymbol(project, typeArgument, result);
                }
                break;
            case IMethodSymbol methodSymbol:
                await ProcessSymbol(project, methodSymbol.ReturnType, result);
                foreach (var parameter in methodSymbol.Parameters)
                {
                    await ProcessSymbol(project, parameter.Type, result);
                }
                break;
            case IPropertySymbol propertySymbol:
                await ProcessSymbol(project, propertySymbol.Type, result);
                break;
            default:
                throw new InvalidOperationException($"Not implemented for symbol {symbol.GetType()}");
        }
    }

    private void MarkInternal(BaseTypeDeclarationSyntax declarationNode)
    {
        var newNode = ChangeModifier(declarationNode, SyntaxKind.PublicKeyword, SyntaxKind.InternalKeyword);
        var tree = declarationNode.SyntaxTree;
        var document = project.GetDocument(tree)!;
        var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
        document = document.WithSyntaxRoot(newRoot);
        project = document.Project;
    }

    private static BaseTypeDeclarationSyntax ChangeModifier(BaseTypeDeclarationSyntax memberDeclaration, SyntaxKind from, SyntaxKind to)
    {
        var originalTokenInList = memberDeclaration.Modifiers.First(token => token.IsKind(from));
        var newToken = SyntaxFactory.Token(originalTokenInList.LeadingTrivia, to, originalTokenInList.TrailingTrivia);
        var newModifiers = memberDeclaration.Modifiers.Replace(originalTokenInList, newToken);
        return memberDeclaration.WithModifiers(newModifiers);
    }

    protected abstract Task<HashSet<BaseTypeDeclarationSyntax>> GetRootNodes(bool publicOnly = true);

    protected abstract bool HasDiscriminator(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out HashSet<string> identifiers);
}
