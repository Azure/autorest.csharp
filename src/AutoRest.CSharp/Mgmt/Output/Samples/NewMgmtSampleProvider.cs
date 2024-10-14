// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Extensions;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Mgmt.Output.Samples
{
    internal class NewMgmtSampleProvider : ExpressionTypeProvider
    {
        protected readonly MgmtTypeProvider _client;

        public NewMgmtSampleProvider(string defaultNamespace, MgmtTypeProvider client, SourceInputModel? sourceInputModel) : base($"{defaultNamespace}.Samples", sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial;
            DefaultName = $"Sample_{client.Type.Name}";
            _client = client;
        }

        public bool IsEmpty => !Methods.Any();

        protected override string DefaultName { get; }

        protected override IEnumerable<string> BuildUsings()
        {
            yield return "Azure.Identity"; // we need this using because we might need to call `new DefaultAzureCredential` from `Azure.Identity` package, but Azure.Identity package is not a dependency of the generator project.
        }

        private Method BuildSampleMethod(MgmtOperationSample sample, bool isAsync)
        {
            var signature = sample.GetMethodSignature(false);

            return new Method(signature, BuildSampleMethodBody(sample, isAsync));
        }

        private MethodBodyStatement BuildSampleMethodBody(MgmtOperationSample sample, bool isAsync)
        {
            var statements = new List<MethodBodyStatement>()
            {
                new SingleLineCommentStatement($"Generated from example definition: {sample.ExampleFilepath}"),
                new SingleLineCommentStatement($"this example is just showing the usage of \"{sample.OperationId}\" operation, for the dependent resource, they will have to be created separately."),
                EmptyLine,
                new SingleLineCommentStatement("get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line"),
                Declare(typeof(TokenCredential), "cred", new FormattableStringToExpression($"new DefaultAzureCredential()"), out var cred), // this project does not use Azure.Identity as a dependency, therefore this is the only way to write this.
                new SingleLineCommentStatement("authenticate your client"),
                Declare(typeof(ArmClient), "client", New.Instance(typeof(ArmClient), cred), out var client),
                EmptyLine,
                sample.Carrier switch
                {
                    Resource resource => BuildSampleOperationForResource(client, resource, sample),
                    _ => throw new InvalidOperationException("This should never happen")
                },
            };

            return statements;
        }

        private MethodBodyStatement BuildSampleOperationForResource(ValueExpression client, Resource resource, MgmtOperationSample sample)
        {
            var resourceName = GetResourceName(resource);
            var statements = new List<MethodBodyStatement>()
            {
                new SingleLineCommentStatement($"this example assumes you already have this {resourceName} created on azure"),
                new SingleLineCommentStatement($"for more information of creating {resourceName}, please refer to the document of {resourceName}"),
                BuildGetResourceStatement(resource, sample, client)
            };

            return statements;
        }

        private MethodBodyStatement BuildGetResourceStatement(MgmtTypeProvider carrierResource, OperationExample example, ValueExpression client)
            => carrierResource switch
            {
                ResourceCollection => throw new InvalidOperationException($"ResourceCollection is not supported here"),
                Resource parentResource => BuildGetResourceStatementFromResource(parentResource, example, client),
                //MgmtExtension parentExtension => WriteGetResourceStatementFromExtension(parentExtension, example, client),
                _ => throw new InvalidOperationException($"Unknown parent {carrierResource.GetType()}"),
            };

        private MethodBodyStatement BuildGetResourceStatementFromResource(Resource carrierResource, OperationExample example, ValueExpression client)
        {
            // Can't use CSharpType.Equals(typeof(...)) because the CSharpType.Equals(Type) would assume itself is a FrameworkType, but here it's generated when IsArmCore=true
            if (Configuration.MgmtConfiguration.IsArmCore && carrierResource.Type.Name == nameof(TenantResource))
            {
                //return BuildGetResourceStatementFromTenantResource(carrierResource, example, client);
                throw new InvalidOperationException("WIP");
            }
            else
            {
                var statements = new List<MethodBodyStatement>();
                // get resource identifier
                var createId = BuildCreateResourceIdentifier(carrierResource, example, out var id);
                statements.Add(createId);
                // WIP here
                return statements;
            }
        }

        private string GetResourceName(MgmtTypeProvider provider) => provider switch
        {
            Resource resource => resource.Type.Name,
            MgmtExtension extension => extension.ArmCoreType.Name,
            _ => throw new InvalidOperationException("Should never happen")
        };

        private MethodBodyStatement BuildCreateResourceIdentifier(Resource resource, OperationExample example, out TypedValueExpression id)
        {
            var resourcePath = resource.RequestPath;
            var scopePath = resourcePath.GetScopePath();
            if (scopePath.IsRawParameterizedScope())
            {
                throw new NotImplementedException();
            }
            else
            {
                return BuildCreateResourceIdentifierForUsualPath(example, resource, out id);
            }
            //var idParts = example.ComposeResourceIdentifierParts();
            //var statement = Declare(typeof(ResourceIdentifier), "id", new InvokeStaticMethodExpression(resource.Type, resource.CreateResourceIdentifierMethod.Signature.Name, idParts), out id);
            //return statement;
        }

        private MethodBodyStatement BuildCreateResourceIdentifierForUsualPath(OperationExample example, Resource resource, out TypedValueExpression id)
        {
            var statements = new List<MethodBodyStatement>();
            // try to figure out ref segments from requestPath according the ones from resource Path
            // Dont match the path side-by-side because
            // 1. there is a case that the parameter names are different
            // 2. the path structure may be different totally when customized,
            //    i.e. in ResourceManager, parent of /subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features/{featureName}
            //         is configured to /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
            var myRefs = example.RequestPath.Where(s => s.IsReference);
            var resourceRefCount = resource.RequestPath.Where(s => s.IsReference).Count();
            var references = new List<ValueExpression>(resourceRefCount);
            foreach (var reference in myRefs.Take(resourceRefCount))
            {
                var exampleValue = example.FindInputExampleValueFromReference(reference.Reference);
                var referenceStatement = Declare(reference.Type, reference.ReferenceName, exampleValue != null ? ExampleValueSnippets.GetExpression(reference.Type, exampleValue) : Default, out var referenceVar);
                statements.Add(referenceStatement);
                references.Add(referenceVar);
            }

            var idStatement = Declare(typeof(ResourceIdentifier), "id", new InvokeStaticMethodExpression(resource.Type, resource.CreateResourceIdentifierMethod.Signature.Name, references), out id);
            statements.Add(idStatement);

            return statements;
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var sample in _client.AllOperations.SelectMany(o => o.Samples))
            {
                yield return BuildSampleMethod(sample, true);
            }
        }
    }
}
