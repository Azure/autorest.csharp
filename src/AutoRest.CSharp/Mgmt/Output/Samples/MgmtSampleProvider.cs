﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Samples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Mgmt.Output.Samples
{
    internal class MgmtSampleProvider : ExpressionTypeProvider
    {
        private const string _createResourceIdentifierMethodName = "CreateResourceIdentifier";
        protected readonly MgmtTypeProvider _client;

        private readonly HashSet<string> _skippedOperations;

        public MgmtSampleProvider(string defaultNamespace, MgmtTypeProvider client, SourceInputModel? sourceInputModel) : base($"{defaultNamespace}.Samples", sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial;
            DefaultName = $"Sample_{client.Type.Name}";
            _client = client;
            _skippedOperations = new HashSet<string>(Configuration.MgmtTestConfiguration?.SkippedOperations ?? []);
        }

        public bool IsEmpty => !Methods.Any();

        protected override string DefaultName { get; }

        protected override IEnumerable<string> BuildUsings()
        {
            yield return "Azure.Identity"; // we need this using because we might need to call `new DefaultAzureCredential` from `Azure.Identity` package, but Azure.Identity package is not a dependency of the generator project.
        }

        private Method BuildSample(MgmtOperationSample sample, bool isAsync)
        {
            var signature = sample.GetMethodSignature(false);

            return new Method(signature, BuildSampleBody(sample, isAsync));
        }

        private MethodBodyStatement BuildSampleBody(MgmtOperationSample example, bool isAsync)
        {
            var statements = new List<MethodBodyStatement>()
            {
                new SingleLineCommentStatement($"Generated from example definition: {example.ExampleFilepath}"),
                new SingleLineCommentStatement($"this example is just showing the usage of \"{example.OperationId}\" operation, for the dependent resources, they will have to be created separately."),
                EmptyLine,
                new SingleLineCommentStatement("get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line"),
                Declare(typeof(TokenCredential), "cred", new FormattableStringToExpression($"new DefaultAzureCredential()"), out var cred), // this project does not use Azure.Identity as a dependency, therefore this is the only way to write this.
                new SingleLineCommentStatement("authenticate your client"),
                Declare(typeof(ArmClient), "client", New.Instance(typeof(ArmClient), cred), out var client),
                EmptyLine,
                BuildSampleMethodInvocation(example, client, out var result),
                EmptyLine,
                BuildResultHandlingStatement(result)
            };

            return statements;
        }

        private MethodBodyStatement BuildResultHandlingStatement(TypedValueExpression? result)
        {
            if (result == null)
            {
                return InvokeConsoleWriteLine(Literal("Succeeded"));
            }
            else
            {
                if (result.Type.IsNullable)
                {
                    return new IfElseStatement(
                        Equal(result, Null),
                        InvokeConsoleWriteLine(Literal("Succeeded with null as result")),
                        BuildNotNullResultHandlingStatement(result));
                }
                else
                {
                    return BuildNotNullResultHandlingStatement(result);
                }
            }
        }

        private static MethodBodyStatement BuildNotNullResultHandlingStatement(TypedValueExpression result)
        {
            if (result.Type is { IsFrameworkType: false, Implementation: Resource resource })
            {
                return BuildResourceResultHandling(result, resource);
            }
            else if (result.Type is { IsFrameworkType: false, Implementation: ResourceData resourceData })
            {
                return BuildResourceDataResultHandling(result, resourceData);
            }
            else
            {
                return BuildOtherResultHandling(result);
            }

            static MethodBodyStatement BuildResourceResultHandling(TypedValueExpression result, Resource resource)
            {
                return new MethodBodyStatement[]
                {
                    new SingleLineCommentStatement((FormattableString)$"the variable {result} is a resource, you could call other operations on this instance as well"),
                    new SingleLineCommentStatement("but just for demo, we get its data from this resource instance"),
                    Declare(resource.ResourceData.Type, "resourceData", result.Property("Data"), out var resourceData),
                    BuildResourceDataResultHandling(resourceData, resource.ResourceData)
                };
            }

            static MethodBodyStatement BuildResourceDataResultHandling(TypedValueExpression result, ResourceData resourceData)
            {
                return new MethodBodyStatement[]
                {
                    new SingleLineCommentStatement("for demo we just print out the id"),
                    InvokeConsoleWriteLine(new FormattableStringExpression("Succeeded on id: {0}", result.Property("Id")))
                };
            }

            static MethodBodyStatement BuildOtherResultHandling(TypedValueExpression result)
            {
                return InvokeConsoleWriteLine(new FormattableStringExpression("Succeeded: {0}", result));
            }
        }

        private MethodBodyStatement BuildSampleMethodInvocation(MgmtOperationSample example, ValueExpression client, out TypedValueExpression? result)
            => example.Carrier switch
            {
                ResourceCollection collection => BuildSampleMethodBodyForResourceCollection(example, client, collection, out result),
                Resource resource => BuildSampleMethodBodyForResource(example, client, resource, out result),
                MgmtExtension extension => BuildSampleMethodBodyForExtension(example, client, extension, out result),
                _ => throw new InvalidOperationException("This should never happen")
            };

        private MethodBodyStatement BuildSampleMethodBodyForExtension(MgmtOperationSample example, ValueExpression client, MgmtExtension extension, out TypedValueExpression? result)
        {
            var resourceName = GetResourceName(extension);
            return new MethodBodyStatement[]
            {
                // get extension resource instance
                BuildGetResourceStatementFromExtension(extension, example, client, out var instance),
                EmptyLine,
                BuildSampleOperationStatement(example, instance, out result)
            };
        }

        private MethodBodyStatement BuildSampleMethodBodyForResource(MgmtOperationSample example, ValueExpression client, Resource resource, out TypedValueExpression? result)
        {
            var statements = new List<MethodBodyStatement>()
            {
                BuildGetResourceStatement(resource, example, client, out var instance),
                EmptyLine,
                BuildSampleOperationStatement(example, instance, out result),
            };

            return statements;
        }

        private MethodBodyStatement BuildSampleMethodBodyForResourceCollection(MgmtOperationSample example, ValueExpression client, ResourceCollection collection, out TypedValueExpression? result)
        {
            return new MethodBodyStatement[]
            {
                BuildGetCollectionStatement(collection, example, client, out var instance),
                EmptyLine,
                BuildSampleOperationStatement(example, instance, out result),
            };
        }

        private MethodBodyStatement BuildSampleOperationStatement(MgmtOperationSample example, ValueExpression instance, out TypedValueExpression? result)
        {
            if (example.IsLro)
            {
                return BuildSampleOperationStatementForLro(example, instance, out result);
            }
            else if (example.IsPageable)
            {
                result = null; // pageable operations do not return a result to handle
                return BuildSampleOperationStatementForPageable(example, instance);
            }

            return BuildSampleOperationStatementForNormal(example, instance, out result);
        }

        private MethodBodyStatement BuildSampleOperationStatementForLro(MgmtOperationSample example, ValueExpression instance, out TypedValueExpression? result)
        {
            var statements = new List<MethodBodyStatement>
            {
                new SingleLineCommentStatement("invoke the operation")
            };

            // collect all the parameters
            var (parameterDeclaration, parameterArguments) = BuildOperationInvocationParameters(example);
            statements.Add(parameterDeclaration);
            var operationInvocationExpression = BuildOperationInvocation(instance, example.Operation, parameterArguments);
            var lroType = example.Operation.ReturnType;
            if (lroType.IsGenericType)
            {
                statements.Add(
                    Declare(lroType, "lro", operationInvocationExpression, out var lro)
                    );
                var resultVar = new VariableReference(lroType.Arguments[0], "result");
                statements.Add(
                    Declare(resultVar, lro.Property("Value"))
                    );
                result = resultVar;
            }
            else
            {
                statements.Add(new InvokeInstanceMethodStatement(operationInvocationExpression));
                result = null;
            }
            return statements;
        }

        private MethodBodyStatement BuildSampleOperationStatementForPageable(MgmtOperationSample example, ValueExpression instance)
        {
            var statements = new List<MethodBodyStatement>
            {
                new SingleLineCommentStatement("invoke the operation and iterate over the result")
            };

            // collect the parameters
            var (parameterDeclaration, parameterArguments) = BuildOperationInvocationParameters(example);
            statements.Add(parameterDeclaration);
            var operationInvocationExpression = BuildOperationInvocation(instance, example.Operation, parameterArguments);
            statements.Add(
                new ForeachStatement(example.Operation.ReturnType, "item", operationInvocationExpression, true, out var item)
                {
                    BuildResultHandlingStatement(item)
                }
                );

            return statements;
        }

        private MethodBodyStatement BuildSampleOperationStatementForNormal(MgmtOperationSample example, ValueExpression instance, out TypedValueExpression? result)
        {
            var statements = new List<MethodBodyStatement>
            {
                new SingleLineCommentStatement("invoke the operation")
            };

            // collect all the parameters
            var (parameterDeclaration, parameterArguments) = BuildOperationInvocationParameters(example);
            statements.Add(parameterDeclaration);
            var operationInvocationExpression = BuildOperationInvocation(instance, example.Operation, parameterArguments);
            var returnType = example.Operation.ReturnType;
            if (returnType.IsGenericType)
            {
                // if the type is NullableResponse, there is no implicit convert, so we have to explicitly unwrap it
                if (returnType.IsFrameworkType && returnType.FrameworkType == typeof(NullableResponse<>))
                {
                    var unwrappedReturnType = returnType.Arguments[0].WithNullable(true);
                    statements.Add(
                        Declare(returnType, Configuration.ApiTypes.ResponseParameterName, operationInvocationExpression, out var valueResponse)
                        );
                    var resultVar = new VariableReference(unwrappedReturnType, "result");
                    statements.Add(
                        Declare(resultVar, new TernaryConditionalOperator(valueResponse.Property(nameof(NullableResponse<object>.HasValue)), valueResponse.Property(nameof(NullableResponse<object>.Value)), Null))
                        );
                    result = resultVar;
                }
                else
                {
                    // an operation with a response
                    var unwrappedReturnType = returnType.Arguments[0];
                    // if the type inside Response<T> is a generic type, somehow the implicit convert Response<T> => T does not work, we have to explicitly unwrap it
                    if (unwrappedReturnType.IsGenericType)
                    {
                        statements.Add(
                            Declare(returnType, Configuration.ApiTypes.ResponseParameterName, operationInvocationExpression, out var valueResponse)
                            );
                        // unwrap the response
                        var resultVar = new VariableReference(unwrappedReturnType, "result");
                        statements.Add(
                            Declare(resultVar, valueResponse.Property(nameof(Response<object>.Value)))
                            );
                        result = resultVar;
                    }
                    else // if it is a type provider type, we could rely on the implicit convert Response<T> => T
                    {
                        var resultVar = new VariableReference(unwrappedReturnType, "result");
                        statements.Add(
                            Declare(resultVar, operationInvocationExpression)
                            );
                        result = resultVar;
                    }
                }
            }
            else
            {
                // an operation without a response
                statements.Add(
                    new InvokeInstanceMethodStatement(operationInvocationExpression)
                    );
                result = null;
            }

            return statements;
        }

        private (MethodBodyStatement ParameterDeclarations, IReadOnlyList<ValueExpression> Arguments) BuildOperationInvocationParameters(MgmtOperationSample example)
        {
            var statements = new List<MethodBodyStatement>();
            var methodParameters = example.Operation.MethodParameters;
            var arguments = new List<ValueExpression>(methodParameters.Count);
            foreach (var parameter in methodParameters)
            {
                if (example.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    // if we could get an example value out of the map, we just use it.
                    var expression = ExampleValueSnippets.GetExpression(parameterValue, parameter.SerializationFormat);

                    // some parameters are always inline
                    if (_inlineParameters.Contains(parameter))
                    {
                        arguments.Add(expression);
                    }
                    else
                    {
                        statements.Add(Declare(parameter.Type, parameter.Name, expression, out var p));
                        if (parameter.IsOptionalInSignature)
                        {
                            arguments.Add(new PositionalParameterReference(parameter.Name, p));
                        }
                        else
                        {
                            arguments.Add(p);
                        }
                    }
                }
                else if (parameter.IsPropertyBag)
                {
                    // get the model for the bag
                    var bag = parameter.Type.Implementation as ModelTypeProvider;
                    // property bag should always be a ModelTypeProvider, but just in case
                    if (bag == null)
                    {
                        arguments.Add(Null);
                        continue;
                    }
                    // build property bag assignment
                    var ctor = bag.InitializationConstructor;
                    var visitedProperties = new HashSet<ObjectTypeProperty>();
                    var ctorArguments = new List<ValueExpression>();
                    Dictionary<string, ValueExpression>? initializationProperties = null;
                    foreach (var p in ctor.Signature.Parameters)
                    {
                        var prop = ctor.FindPropertyInitializedByParameter(p);
                        if (prop != null)
                        {
                            visitedProperties.Add(prop);
                        }
                        if (example.PropertyBagParamValueMapping.TryGetValue(p.Name, out var value))
                        {
                            statements.Add(Declare(p.Type, p.Name, ExampleValueSnippets.GetExpression(value, p.SerializationFormat), out var pVar));
                            ctorArguments.Add(pVar);
                        }
                        else
                        {
                            ctorArguments.Add(Default.CastTo(p.Type));
                        }
                    }
                    // get the optional properties
                    foreach (var prop in bag.Properties)
                    {
                        if (visitedProperties.Contains(prop))
                        {
                            continue;
                        }
                        if (example.PropertyBagParamValueMapping.TryGetValue(prop.Declaration.Name.ToVariableName(), out var value))
                        {
                            initializationProperties ??= new Dictionary<string, ValueExpression>();
                            initializationProperties.Add(prop.Declaration.Name, ExampleValueSnippets.GetExpression(value, prop.SerializationFormat));
                        }
                    }
                    statements.Add(Declare(parameter.Type, parameter.Name, New.Instance(ctor.Signature, ctorArguments, initializationProperties), out var options));
                    arguments.Add(options);
                }
            }

            return (statements, arguments);
        }

        private InvokeInstanceMethodExpression BuildOperationInvocation(ValueExpression instance, MgmtClientOperation operation, IReadOnlyList<ValueExpression> parameterArguments, bool isAsync = true)
        {
            return new InvokeInstanceMethodExpression(instance, GetMethodName(operation.Name, isAsync), parameterArguments, TypeArguments: null, CallAsAsync: isAsync && !operation.IsPagingOperation, AddConfigureAwaitFalse: false);
        }

        private MethodBodyStatement BuildGetCollectionWithoutParent(ValueExpression client, ResourceCollection collection, out TypedValueExpression instance)
        {
            // Can't use CSharpType.Equals(typeof(...)) because the CSharpType.Equals(Type) would assume itself is a FrameworkType, but here it's generated when IsArmCore=true
            if (Configuration.MgmtConfiguration.IsArmCore && collection.Type.Name == nameof(TenantCollection))
            {
                return Declare(collection.Type, "collection", client.Invoke("GetTenants"), out instance);
            }
            else
            {
                // TODO: add support when we found any other case
                throw new NotSupportedException("Unsupported type to get collection without parent: " + collection.Type.Name);
            }
        }

        private MethodBodyStatement BuildGetCollectionStatement(ResourceCollection collection, MgmtOperationSample example, ValueExpression client, out TypedValueExpression instance)
        {
            var parent = example.Parent;

            if (parent == null)
            {
                return BuildGetCollectionWithoutParent(client, collection, out instance);
            }

            var parentName = GetResourceName(parent);
            var statements = new List<MethodBodyStatement>();

            var resourceName = collection.Resource.ResourceName;
            statements.Add(
                BuildGetResourceStatement(parent, example, client, out var parentVar)
                );

            // write get collection
            statements.Add(EmptyLine);
            statements.Add(
                new SingleLineCommentStatement($"get the collection of this {collection.Resource.Type.Name}")
                );
            var getResourceCollectionMethodName = $"Get{resourceName.ResourceNameToPlural()}";
            var arguments = new List<ValueExpression>();

            // if the extension is on ArmResource, we need an extra "scope" parameter before its actual parameters
            if (parent is MgmtExtension extension && extension.ArmCoreType == typeof(ArmResource))
            {
                statements.Add(
                    BuildCreateScopeResourceIdentifier(example, example.RequestPath.GetScopePath(), out var scopeId)
                    );
                arguments.Add(New.Instance(typeof(ResourceIdentifier), scopeId));
            }

            foreach (var extraParameter in collection.ExtraConstructorParameters)
            {
                if (example.ParameterValueMapping.TryGetValue(extraParameter.Name, out var exampleParameterValue))
                {
                    statements.Add(
                        Declare(extraParameter.Type, extraParameter.Name, ExampleValueSnippets.GetExpression(exampleParameterValue, extraParameter.SerializationFormat), out var arg)
                        );
                    arguments.Add(arg);
                }
            }

            // call the method to get the collection instance
            statements.Add(
                Declare(collection.Type, "collection", parentVar.Invoke(getResourceCollectionMethodName, arguments), out instance)
                );

            return statements;
        }

        private MethodBodyStatement BuildGetResourceStatement(MgmtTypeProvider carrierResource, OperationExample example, ValueExpression client, out TypedValueExpression instance)
            => carrierResource switch
            {
                ResourceCollection => throw new InvalidOperationException($"ResourceCollection is not supported here"),
                Resource parentResource => BuildGetResourceStatementFromResource(parentResource, example, client, out instance),
                MgmtExtension parentExtension => BuildGetResourceStatementFromExtension(parentExtension, example, client, out instance),
                _ => throw new InvalidOperationException($"Unknown parent {carrierResource.GetType()}"),
            };

        private MethodBodyStatement BuildGetResourceStatementFromResource(Resource resource, OperationExample example, ValueExpression client, out TypedValueExpression resourceVar)
        {
            // Can't use CSharpType.Equals(typeof(...)) because the CSharpType.Equals(Type) would assume itself is a FrameworkType, but here it's generated when IsArmCore=true
            if (Configuration.MgmtConfiguration.IsArmCore && resource.Type.Name == nameof(TenantResource))
            {
                return BuildGetResourceStatementFromTenantResource(resource, example, client, out resourceVar);
            }
            else
            {
                var resourceName = GetResourceName(resource);
                return new MethodBodyStatement[]
                {
                    new SingleLineCommentStatement($"this example assumes you already have this {resourceName} created on azure"),
                    new SingleLineCommentStatement($"for more information of creating {resourceName}, please refer to the document of {resourceName}"),
                    BuildCreateResourceIdentifier(resource.RequestPath, resource.Type, example, out var id),
                    Declare(resource.Type, resource.ResourceName.ToVariableName(), client.Invoke($"Get{resourceName}", id), out resourceVar)
                };
            }
        }

        private MethodBodyStatement BuildGetResourceStatementFromExtension(MgmtExtension extension, OperationExample example, ValueExpression client, out TypedValueExpression resourceVar)
        {
            if (extension.ArmCoreType == typeof(TenantResource))
            {
                return BuildGetResourceStatementFromTenantResource(extension, example, client, out resourceVar);
            }
            else if (extension.ArmCoreType == typeof(ArmResource) || extension.ArmCoreType == typeof(ArmClient))
            {
                return BuildGetResourceStatementFromArmResourceOrArmClient(example, client, out resourceVar);
            }
            else
            {
                return BuildGetResourceStatementForOther(extension, example, client, out resourceVar);
            }
        }

        private MethodBodyStatement BuildGetResourceStatementFromTenantResource(MgmtTypeProvider resource, OperationExample example, ValueExpression client, out TypedValueExpression resourceVar)
        {
            return Declare(typeof(TenantResource), resource.ResourceName.ToVariableName(), client.Invoke("GetTenants").Invoke("GetAllAsync").Invoke("GetAsyncEnumerator").Property("Current"), out resourceVar);
        }

        private MethodBodyStatement BuildGetResourceStatementFromArmResourceOrArmClient(OperationExample example, ValueExpression client, out TypedValueExpression resourceVar)
        {
            if (client is TypedValueExpression typedClient)
            {
                resourceVar = typedClient;
            }
            else
            {
                resourceVar = new TypedValueExpression(typeof(ArmClient), client);
            }
            return EmptyStatement;
        }

        private MethodBodyStatement BuildGetResourceStatementForOther(MgmtExtension extension, OperationExample example, ValueExpression client, out TypedValueExpression resourceVar)
        {
            var resourceName = GetResourceName(extension);
            return new MethodBodyStatement[]
            {
                new SingleLineCommentStatement($"this example assumes you already have this {resourceName} created on azure"),
                new SingleLineCommentStatement($"for more information of creating {resourceName}, please refer to the document of {resourceName}"),
                BuildCreateResourceIdentifier(extension.ContextualPath, extension.ArmCoreType, example, out var id),
                Declare(extension.ArmCoreType, extension.ResourceName.ToVariableName(), client.Invoke($"Get{resourceName}", id), out resourceVar)
            };
        }

        private string GetResourceName(MgmtTypeProvider provider) => provider switch
        {
            Resource resource => resource.Type.Name,
            MgmtExtension extension => extension.ArmCoreType.Name,
            _ => throw new InvalidOperationException("Should never happen")
        };

        private MethodBodyStatement BuildCreateResourceIdentifier(RequestPath resourcePath, CSharpType typeOfResource, OperationExample example, out TypedValueExpression id)
        {
            var scopePath = resourcePath.GetScopePath();
            if (scopePath.IsRawParameterizedScope())
            {
                return BuildCreateResourceIdentifierForScopePath(example, resourcePath, typeOfResource, out id);
            }
            else
            {
                return BuildCreateResourceIdentifierForUsualPath(example, resourcePath, typeOfResource, out id);
            }
        }

        private MethodBodyStatement BuildCreateResourceIdentifierForUsualPath(OperationExample example, RequestPath resourcePath, CSharpType typeOfResource, out TypedValueExpression id)
        {
            var statements = new List<MethodBodyStatement>();
            // try to figure out ref segments from requestPath according the ones from resource Path
            // Dont match the path side-by-side because
            // 1. there is a case that the parameter names are different
            // 2. the path structure may be different totally when customized,
            //    i.e. in ResourceManager, parent of /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}
            //         is configured to /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
            var myRefs = example.RequestPath.Where(s => s.IsReference);
            var resourceRefCount = resourcePath.Where(s => s.IsReference).Count();
            var references = new List<ValueExpression>(resourceRefCount);
            foreach (var reference in myRefs.Take(resourceRefCount))
            {
                var exampleValue = example.FindInputExampleValueFromReference(reference.Reference);
                var referenceStatement = Declare(reference.Type, reference.ReferenceName, ExampleValueSnippets.GetExpression(reference.Type, exampleValue), out var referenceVar);
                statements.Add(referenceStatement);
                references.Add(referenceVar);
            }

            var idStatement = Declare(typeof(ResourceIdentifier), $"{typeOfResource.Name}Id".ToVariableName(), new InvokeStaticMethodExpression(typeOfResource, _createResourceIdentifierMethodName, references), out id);
            statements.Add(idStatement);

            return statements;
        }

        private MethodBodyStatement BuildCreateScopeResourceIdentifier(OperationExample example, RequestPath operationScopePath, out TypedValueExpression scopeId)
        {
            var statements = new List<MethodBodyStatement>();
            var scopeValues = new List<TypedValueExpression>();
            foreach (var reference in operationScopePath.Where(segment => segment.IsReference))
            {
                var exampleValue = example.FindInputExampleValueFromReference(reference.Reference);
                var scopeRefStatement = Declare(reference.Type, reference.ReferenceName, ExampleValueSnippets.GetExpression(reference.Type, exampleValue), out var scopeRefVar);
                statements.Add(scopeRefStatement);
                scopeValues.Add(scopeRefVar);
            }

            if (operationScopePath.Count == 1)
            {
                // the scope in the id is an explicit scope, such as a request path defined like: `/{scope}/providers/Microsoft.Something/roleDefinitions/{name}` therefore we do not have do anything special for it
                //idArguments.AddRange(scopeValues);
                scopeId = scopeValues[0];
            }
            else
            {
                // this scope is an implicit scope, such as a request path defined like: `/subscriptions/{subsId}/providers/Microsoft.Something/roleDefinitions/{name}` but we changed this in our generator to make it a scope resource
                var scopeDeclarationStatement = Declare(typeof(string), "scope", new FormattableStringExpression(operationScopePath, scopeValues), out var scope);
                statements.Add(scopeDeclarationStatement);
                scopeId = scope;
            }

            return statements;
        }

        private MethodBodyStatement BuildCreateResourceIdentifierForScopePath(OperationExample example, RequestPath resourcePath, CSharpType typeOfResource, out TypedValueExpression id)
        {
            var statements = new List<MethodBodyStatement>();
            var operationScopePath = example.RequestPath.GetScopePath();
            var resourceScopePath = resourcePath.GetScopePath();
            var trimmedPath = resourcePath.TrimScope();
            var operationTrimeedPath = example.RequestPath.TrimScope();

            var scopeValues = new List<ValueExpression>();
            foreach (var reference in operationScopePath.Where(segment => segment.IsReference))
            {
                var exampleValue = example.FindInputExampleValueFromReference(reference.Reference);
                var scopeRefStatement = Declare(reference.Type, reference.ReferenceName, ExampleValueSnippets.GetExpression(reference.Type, exampleValue), out var scopeRefVar);
                statements.Add(scopeRefStatement);
                scopeValues.Add(scopeRefVar);
            }

            var idArguments = new List<ValueExpression>();
            if (operationScopePath.Count == 1)
            {
                // the scope in the id is an explicit scope, such as a request path defined like: `/{scope}/providers/Microsoft.Something/roleDefinitions/{name}` therefore we do not have do anything special for it
                idArguments.AddRange(scopeValues);
            }
            else
            {
                // this scope is an implicit scope, such as a request path defined like: `/subscriptions/{subsId}/providers/Microsoft.Something/roleDefinitions/{name}` but we changed this in our generator to make it a scope resource
                var scopeDeclarationStatement = Declare(typeof(string), "scope", new FormattableStringExpression(operationScopePath, scopeValues), out var scope);
                statements.Add(scopeDeclarationStatement);
                idArguments.Add(scope);
            }

            foreach (var reference in operationTrimeedPath.Take(trimmedPath.Count).Where(segment => segment.IsReference))
            {
                var exampleValue = example.FindInputExampleValueFromReference(reference.Reference);
                var refStatement = Declare(reference.Type, reference.ReferenceName, ExampleValueSnippets.GetExpression(reference.Type, exampleValue), out var idPartVar);
                statements.Add(refStatement);
                idArguments.Add(idPartVar);
            }

            var idStatement = Declare(typeof(ResourceIdentifier), $"{typeOfResource.Name}Id".ToVariableName(), new InvokeStaticMethodExpression(typeOfResource, _createResourceIdentifierMethodName, idArguments), out id);
            statements.Add(idStatement);

            return statements;
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var operation in _client.AllOperations)
            {
                if (operation.Any(o => _skippedOperations.Contains(o.OperationId)))
                {
                    continue;
                }
                foreach (var sample in operation.Samples)
                {
                    yield return BuildSample(sample, true);
                }
            }
        }

        private static readonly HashSet<Parameter> _inlineParameters = [KnownParameters.WaitForCompletion, KnownParameters.CancellationTokenParameter];

        private string GetMethodName(string methodName, bool isAsync = true)
        {
            return isAsync ? $"{methodName}Async" : methodName;
        }
    }
}
