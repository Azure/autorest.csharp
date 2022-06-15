// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Rename;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class BodyParameterUpdater
    {
        public static async Task<Project> Update(Project project)
        {
            // get all the parameter types needed to change
            var modelsToUpdate = GetBodyParameterTypes();
            // rename the parameters that needed to be renamed
            project = await RenameParameterTypesAsync(project, modelsToUpdate);
            // rename the body parameter names
            project = await RenameParameterNamesAsync(project, modelsToUpdate);
            return project;
        }

        private static Parameter? GetBodyParameter(MgmtClientOperation operation)
            => operation.Parameters.FirstOrDefault(p => p.RequestLocation == RequestLocation.Body);
        private static Parameter? GetBodyParameter(RestClientMethod restClientMethod)
            => restClientMethod.Parameters.FirstOrDefault(p => p.RequestLocation == RequestLocation.Body);

        private static Dictionary<CSharpType, string> GetBodyParameterTypes()
        {
            var mgmtTypeProviders = MgmtContext.Library.ArmResources.Cast<MgmtTypeProvider>()
                .Concat(MgmtContext.Library.ResourceCollections)
                .Append(MgmtContext.Library.ExtensionWrapper);

            // iterate all the client operations to get the usage of models in requests and responses
            var usageCounts = new Dictionary<CSharpType, int>();
            foreach (var mgmtTypeProvider in mgmtTypeProviders)
            {
                foreach (var operation in mgmtTypeProvider.AllOperations)
                {
                    // go through the body parameters
                    var bodyParameter = GetBodyParameter(operation);
                    if (bodyParameter != null && !bodyParameter.Type.IsFrameworkType)
                        IncrementCount(usageCounts, bodyParameter.Type);
                    // go through the return type
                    var originalReturnType = operation.OriginalReturnType; // this is the undecerated return type of this operation
                    if (originalReturnType != null && !originalReturnType.IsFrameworkType)
                        IncrementCount(usageCounts, originalReturnType);
                }
            }

            var modelsToUpdate = new Dictionary<CSharpType, string>();
            foreach (var mgmtTypeProvider in mgmtTypeProviders)
            {
                foreach (var operation in mgmtTypeProvider.AllOperations)
                {
                    if (operation.HttpMethod != HttpMethod.Patch && operation.HttpMethod != HttpMethod.Put && operation.HttpMethod != HttpMethod.Post)
                        continue;

                    var bodyParameter = GetBodyParameter(operation);
                    if (bodyParameter == null || bodyParameter.Type.IsFrameworkType)
                        continue;

                    if (!usageCounts.TryGetValue(bodyParameter.Type, out var count) || count != 1)
                        continue;

                    // only change the name of body parameter type when the count is 1
                    // determine this is on a resource/collection, or on an extension
                    // if this is on a resource or collection, we will rename it to PUT: [ResourceName]CreateOrUpdateContent, Patch: [ResourceName]Patch
                    // if this is of other verb, or this is on an extension, we just replace some reserved words to `Content` in its name
                    string newName = "";
                    if (mgmtTypeProvider is MgmtExtensions)
                    {
                        newName = GetNewBodyParameterTypeName(bodyParameter.Type.Name);
                    }
                    else
                    {
                        newName = GetNewBodyParameterTypeName(operation.HttpMethod, mgmtTypeProvider.ResourceName, bodyParameter.Type.Name);
                    }
                    modelsToUpdate.Add(bodyParameter.Type, newName);
                }
            }

            return modelsToUpdate;
        }

        private static void IncrementCount<T>(Dictionary<T, int> usageCounts, T item) where T : notnull
        {
            if (usageCounts.ContainsKey(item))
            {
                usageCounts[item]++;
            }
            else
            {
                usageCounts.Add(item, 1);
            }
        }

        private static async Task<Project> RenameParameterTypesAsync(Project project, Dictionary<CSharpType, string> updatedTypes)
        {
            Compilation compilation;
            foreach ((var typeToRename, var newName) in updatedTypes)
            {
                compilation = await GetCompilationAsync(project);
                var typeSymbolToRename = SymbolFinder.GetTypeSymbol(compilation, typeToRename);

                project = await RenameDocumentAsync(project, typeSymbolToRename, newName);

                compilation = await GetCompilationAsync(project);
                typeSymbolToRename = SymbolFinder.GetTypeSymbol(compilation, typeToRename.Namespace, newName);

                // first rename the containing methods that ends with the old name inside this type
                foreach (var method in typeSymbolToRename.GetMembers().OfType<IMethodSymbol>())
                {
                    if (method.Name.EndsWith(typeToRename.Name))
                    {
                        project = await RenameSymbolAsync(project, method, method.Name.ReplaceLast(typeToRename.Name, newName));
                    }
                }
            }

            return project;
        }

        private static async Task<Project> RenameParameterNamesAsync(Project project, Dictionary<CSharpType, string> updatedTypes)
        {
            var compilation = await GetCompilationAsync(project);
            var mgmtTypeProviders = MgmtContext.Library.ArmResources.Cast<MgmtTypeProvider>()
                .Concat(MgmtContext.Library.ResourceCollections)
                .Append(MgmtContext.Library.ExtensionWrapper)
                .Append(MgmtContext.Library.ArmResourceExtensionsClient)
                .Append(MgmtContext.Library.ManagementGroupExtensionsClient)
                .Append(MgmtContext.Library.ResourceGroupExtensionsClient)
                .Append(MgmtContext.Library.SubscriptionExtensionsClient)
                .Append(MgmtContext.Library.TenantExtensionsClient);

            // iterate all operations to get their body parameter
            foreach (var mgmtTypeProvider in mgmtTypeProviders)
            {
                project = await RenameParameterNamesInTypeProviderAsync(
                    compilation, project, mgmtTypeProvider, updatedTypes,
                    provider => ToDictionary(provider.AllOperations, op => op.Name),
                    GetBodyParameter);
            }

            foreach (var restClient in MgmtContext.Library.RestClients)
            {
                project = await RenameParameterNamesInTypeProviderAsync(
                    compilation, project, restClient, updatedTypes,
                    client => ToDictionary(client.Methods, m => m.Name),
                    GetBodyParameter);
            }

            return project;
        }

        private static async Task<Project> RenameParameterNamesInTypeProviderAsync<TProvider, TMethod>(Compilation compilation, Project project, TProvider typeProvider, Dictionary<CSharpType, string> updatedTypes,
            Func<TProvider, Dictionary<string, List<TMethod>>> methodDictSelector,
            Func<TMethod, Parameter?> bodyParameterSelector) where TProvider : TypeProvider where TMethod : notnull
        {
            var typeSymbol = SymbolFinder.GetNullableTypeSymbol(compilation, typeProvider.Type);
            if (typeSymbol == null) // sometimes we might do not have the generated type provider (it is empty or is removed by remover because it is never used)
                return project;

            // just in case that we have method with the same name
            var methodDict = methodDictSelector(typeProvider);
            foreach (var methodSymbol in typeSymbol.GetMembers().OfType<IMethodSymbol>())
            {
                // skip those methods that are not a RestClientMethod
                if (!methodDict.TryGetValue(NormalizeMethodName(methodSymbol), out var methods))
                    continue;

                foreach (var method in methods)
                {
                    var bodyParameter = bodyParameterSelector(method);
                    if (bodyParameter == null || bodyParameter.Type.IsFrameworkType)
                        continue;

                    var parameterSymbol = GetParameterSymbol(compilation, methodSymbol, GetModifiedTypeSymbol(compilation, bodyParameter.Type, updatedTypes));

                    project = await RenameSymbolAsync(project, parameterSymbol, GetNewParameterName(parameterSymbol));
                }
            }

            return project;
        }

        private static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(IEnumerable<TValue> source, Func<TValue, TKey> keySelector) where TKey : notnull
        {
            var result = new Dictionary<TKey, List<TValue>>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (!result.ContainsKey(key))
                    result.Add(key, new List<TValue>());
                result[key].Add(item);
            }

            return result;
        }

        private static INamedTypeSymbol GetModifiedTypeSymbol(Compilation compilation, CSharpType type, Dictionary<CSharpType, string> updatedTypes)
        {
            if (updatedTypes.TryGetValue(type, out var newName))
            {
                return SymbolFinder.GetTypeSymbol(compilation, type.Namespace, newName);
            }
            else
            {
                return SymbolFinder.GetTypeSymbol(compilation, type);
            }
        }

        private static string NormalizeMethodName(IMethodSymbol method)
            => IsTask(method.ReturnType) ? method.Name.ReplaceLast("Async", "") : method.Name;

        private static bool IsTask(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.Name != "Task")
                return false;
            // get the full namespace value
            var builder = new StringBuilder();
            var @namespace = typeSymbol.ContainingNamespace;
            while (!@namespace.IsGlobalNamespace)
            {
                builder.Append(@namespace.Name).Append(".");
                @namespace = @namespace.ContainingNamespace;
            }
            return builder.ToString() == "Tasks.Threading.System.";
        }

        private static IParameterSymbol GetParameterSymbol(Compilation compilation, IMethodSymbol methodSymbol, INamedTypeSymbol parameterTypeSymbol)
            => methodSymbol.Parameters.First(parameterSymbol => parameterSymbol.Type.Equals(parameterTypeSymbol, SymbolEqualityComparer.Default));

        private static async Task<Project> RenameDocumentAsync(Project project, INamedTypeSymbol typeToRename, string newName)
        {
            var solution = project.Solution;
            var projectId = project.Id;

            // rename the containing document's name, which will automatically rename the containing symbol that matches the name of the document
            var actions = new List<Renamer.RenameDocumentActionSet>();
            foreach (var definition in typeToRename.DeclaringSyntaxReferences)
            {
                var document = project.GetDocument(definition.SyntaxTree);
                Debug.Assert(document != null);

                var newDocumentName = document.Name.ReplaceLast(typeToRename.Name, newName);
                actions.Add(await Renamer.RenameDocumentAsync(document, newDocumentName));
            }

            // apply the changes
            foreach (var action in actions)
            {
                solution = await action.UpdateSolutionAsync(solution, default);
            }

            return solution.GetProject(projectId)!;
        }

        private static async Task<Project> RenameSymbolAsync(Project project, ISymbol symbolToRename, string newName)
        {
            var solution = project.Solution;
            var projectId = project.Id;

            solution = await Renamer.RenameSymbolAsync(solution, symbolToRename, newName, solution.Options);

            return solution.GetProject(projectId)!;
        }

        private static async Task<Compilation> GetCompilationAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync();
            Debug.Assert(compilation != null);
            return compilation;
        }

        private static readonly string Content = "Content";

        private static string GetNewBodyParameterTypeName(HttpMethod method, string resourceName, string oldName) => method switch
        {
            HttpMethod.Put => $"{resourceName}CreateOrUpdateContent",
            HttpMethod.Patch => $"{resourceName}Patch",
            _ => GetNewBodyParameterTypeName(oldName),
        };

        private static string GetNewBodyParameterTypeName(string oldTypeName)
        {
            if (oldTypeName.EndsWith("Parameters", StringComparison.Ordinal))
                return oldTypeName.ReplaceLast("Parameters", Content);
            if (oldTypeName.EndsWith("Request", StringComparison.Ordinal))
                return oldTypeName.ReplaceLast("Request", Content);
            if (oldTypeName.EndsWith("Options", StringComparison.Ordinal))
                return oldTypeName.ReplaceLast("Options", Content);
            if (oldTypeName.EndsWith("Info", StringComparison.Ordinal))
                return oldTypeName.ReplaceLast("Info", Content);
            if (oldTypeName.EndsWith("Input", StringComparison.Ordinal))
                return oldTypeName.ReplaceLast("Input", Content);

            return oldTypeName;
        }

        private static string GetNewParameterName(IParameterSymbol parameterSymbol)
        {
            var typeName = parameterSymbol.Type.Name;
            var parameterName = parameterSymbol.Name;
            if (typeName.EndsWith("Options", StringComparison.Ordinal))
                return "options";

            if (typeName.EndsWith("Info", StringComparison.Ordinal))
                return "info";

            if (typeName.EndsWith("Details", StringComparison.Ordinal))
                return "details";

            if (typeName.EndsWith("Content", StringComparison.Ordinal))
                return "content";

            if (typeName.EndsWith("Patch", StringComparison.Ordinal))
                return "patch";

            if (typeName.EndsWith("Input", StringComparison.Ordinal))
                return "input";

            if (typeName.EndsWith("Data", StringComparison.Ordinal))
                return "data";

            if (parameterName.Equals("parameters", StringComparison.OrdinalIgnoreCase))
                return typeName.FirstCharToLowerCase();

            return parameterName;
        }
    }
}
