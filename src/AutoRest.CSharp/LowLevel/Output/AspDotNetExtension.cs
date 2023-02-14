// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Extensions;

namespace AutoRest.CSharp.LowLevel.Output
{
    internal class AspDotNetExtension : TypeProvider
    {
        private const string AspDotNetExtensionNamespace = "Microsoft.Extensions.Azure";

        internal string FullName => $"{Type.Namespace}.{Type.Name}";

        private IReadOnlyList<LowLevelClient> _clients;

        public AspDotNetExtension(IReadOnlyList<LowLevelClient> clients, string clientNamespace, SourceInputModel? sourceInputModel) : base(AspDotNetExtensionNamespace, sourceInputModel)
        {
            DefaultName = $"{ClientBuilder.GetClientPrefix(Configuration.LibraryName, clientNamespace)}ClientBuilderExtensions";
            _clients = clients;
        }

        public FormattableString Description => $"Extension methods to add clients to client builder";

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        private Dictionary<MethodSignature, (IEnumerable<FormattableString> Parameters, IEnumerable<FormattableString> ParameterValues)>? _extensionMethodsNew;
        public IReadOnlyDictionary<MethodSignature, (IEnumerable<FormattableString> Parameters, IEnumerable<FormattableString> ParameterValues)> ExtesnsionMethodsNew => _extensionMethodsNew ??= EnsureExtensionMethodsNew();

        private Dictionary<MethodSignature, (IEnumerable<FormattableString> Parameters, IEnumerable<FormattableString> ParameterValues)> EnsureExtensionMethodsNew()
        {
            var result = new Dictionary<MethodSignature, (IEnumerable<FormattableString> Parameters, IEnumerable<FormattableString> ParameterValues)>();
            foreach (var client in _clients)
            {
                var returnType = new CSharpType(typeof(IAzureClientBuilder<,>), client.Type, client.ClientOptions.Type);
                foreach (var ctor in client.PrimaryConstructors)
                {
                    var signatureParameters = new List<Parameter>() { FactoryBuilderParameter };
                    var parameterDeclarations = new List<FormattableString>();
                    var parameterValues = new List<FormattableString>();
                    var includeCredential = false;
                    foreach (var parameter in ctor.Parameters)
                    {
                        if (parameter.Type.EqualsIgnoreNullable(client.ClientOptions.Type))
                        {
                            // do not put the ClientOptions on the signature
                            var options = new CodeWriterDeclaration("options");
                            parameterDeclarations.Insert(0, $"{options:D}"); // options are always the first in the callback signature
                            parameterValues.Add($"{options:I}");
                        }
                        else if (parameter.Type.EqualsIgnoreNullable(typeof(TokenCredential)))
                        {
                            // do not put the TokenCredential on the signature
                            includeCredential = true;
                            var cred = new CodeWriterDeclaration("cred");
                            parameterDeclarations.Add($"{cred:D}");
                            parameterValues.Add($"{cred:I}");
                        }
                        else
                        {
                            // for other parameters, we do not put it on the declarations because they are on the method signature
                            signatureParameters.Add(parameter);
                            parameterValues.Add($"{parameter.Name:I}");
                        }
                    }

                    var parameterFs = signatureParameters.Select(parameter => (FormattableString)$"<paramref name=\"{parameter.Name}\"/>").ToArray();
                    var summary = parameterFs.Any()
                        ? $"Registers a <see cref=\"{client.Type}\"/> instance with the provided {parameterFs.Join(", ", " and ")}"
                        : $"Registers a <see cref=\"{client.Type}\"/> instance";
                    var constrait = includeCredential
                        ? (FormattableString)$"{typeof(IAzureClientFactoryBuilderWithCredential)}"
                        : $"{typeof(IAzureClientFactoryBuilder)}";
                    var signature = new MethodSignature(
                        $"Add{client.Declaration.Name}",
                        summary,
                        null,
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        returnType,
                        null,
                        signatureParameters,
                        GenericArguments: new[] { TBuilderType },
                        GenericParameterConstraints: new Dictionary<CSharpType, FormattableString>()
                        {
                            [TBuilderType] = constrait
                        });
                    result.Add(signature, (parameterDeclarations, parameterValues));
                }
            }

            return result;
        }

        private Parameter? _factoryBuilderParameter;
        public Parameter FactoryBuilderParameter => _factoryBuilderParameter ??= new Parameter(
            "builder",
            null,
            TBuilderType,
            null,
            ValidationType.None,
            null);

        private Parameter? _configurationParameter;
        public Parameter ConfigurationParameter => _configurationParameter ??= new Parameter(
            "configuration",
            null,
            TConfigurationType,
            null,
            ValidationType.None,
            null);

        private static CSharpType? _builderType;
        private static CSharpType? _configurationType;
        // these two properties are getting the open generic parameter type of `TBuilder` and `TConfiguration` so that we could use them on the generated generic method
        // since there is no method to manually construct this kind of open generic argument types.
        private static CSharpType TBuilderType => _builderType ??= typeof(Template<,>).GetGenericArguments()[0];
        private static CSharpType TConfigurationType => _configurationType ??= typeof(Template<,>).GetGenericArguments()[1];

        private class Template<TBuilder, TConfiguration> { }
    }
}
