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
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models;
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
                var id = new VariableReference(typeof(ResourceIdentifier), "id");
                // WIP here
                return EmptyLine;
            }
        }

        private string GetResourceName(MgmtTypeProvider provider) => provider switch
        {
            Resource resource => resource.Type.Name,
            MgmtExtension extension => extension.ArmCoreType.Name,
            _ => throw new InvalidOperationException("Should never happen")
        };

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var sample in _client.AllOperations.SelectMany(o => o.Samples))
            {
                yield return BuildSampleMethod(sample, true);
            }
        }
    }
}
