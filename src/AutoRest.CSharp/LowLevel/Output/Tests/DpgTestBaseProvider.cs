// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.TestFramework;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgTestBaseProvider : TypeProvider
    {
        private static readonly Parameter IsAsyncParameter = new("isAsync", null, typeof(bool), null, ValidationType.None, null);

        private readonly IEnumerable<LowLevelClient> _clients;

        public DpgTestBaseProvider(string defaultNamespace, IEnumerable<LowLevelClient> clients, DpgTestEnvironmentProvider dpgTestEnvironment, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            TestEnvironment = dpgTestEnvironment;
            DefaultNamespace = $"{defaultNamespace}.Tests";
            DefaultName = $"{ClientBuilder.GetRPName(defaultNamespace)}TestBase";
            _clients = clients;
            BaseType = new CSharpType(typeof(RecordedTestBase<>), TestEnvironment.Type);
        }

        public CSharpType BaseType { get; }

        public DpgTestEnvironmentProvider TestEnvironment { get; }

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public IEnumerable<ConstructorSignature> Constructors
        {
            get
            {
                yield return new ConstructorSignature(
                    Name: DefaultName,
                    Summary: null,
                    Description: null,
                    Modifiers: MethodSignatureModifiers.Public,
                    Parameters: new[] { IsAsyncParameter },
                    Initializer: new ConstructorInitializer(
                        IsBase: true,
                        Arguments: new FormattableString[] { $"{IsAsyncParameter.Name:I}" })
                    );
            }
        }

        private Dictionary<LowLevelClient, MethodSignature>? _createClientMethods;

        public Dictionary<LowLevelClient, MethodSignature> CreateClientMethods => _createClientMethods ??= EnsureCreateClientMethods();

        private Dictionary<LowLevelClient, MethodSignature> EnsureCreateClientMethods()
        {
            var result = new Dictionary<LowLevelClient, MethodSignature>();
            foreach (var client in _clients)
            {
                if (client.IsSubClient)
                    continue;

                var ctor = client.GetEffectiveCtorWithClientOptions();

                if (ctor == null)
                    continue;

                result.Add(client, new MethodSignature(
                    Name: $"Create{client.Type.Name}",
                    Summary: null,
                    Description: null,
                    Modifiers: MethodSignatureModifiers.Protected,
                    ReturnType: client.Type,
                    ReturnDescription: null,
                    Parameters: ctor.Parameters.Where(p => !p.Type.EqualsIgnoreNullable(client.ClientOptions.Type)).ToArray()
                ));
            }

            return result;
        }
    }
}
