// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private readonly Lazy<IReadOnlyList<LowLevelClient>> _restClients;
        private readonly Lazy<IReadOnlyDictionary<string, IReadOnlyList<MethodSignatureBase>>> _restClientInitExamplePaths;

        public IReadOnlyList<LowLevelClient> RestClients => _restClients.Value;
        public IReadOnlyDictionary<string, IReadOnlyList<MethodSignatureBase>> RestClientInitExamplePaths => _restClientInitExamplePaths.Value;
        public ClientOptionsTypeProvider ClientOptions { get; }

        public LowLevelOutputLibrary(BuildContext<LowLevelOutputLibrary> context, Func<IReadOnlyList<LowLevelClient>> restClientsFactory, ClientOptionsTypeProvider clientOptions)
        {
            _context = context;
            _restClients = new Lazy<IReadOnlyList<LowLevelClient>>(restClientsFactory);
            _restClientInitExamplePaths = new Lazy<IReadOnlyDictionary<string, IReadOnlyList<MethodSignatureBase>>>(GetRestClientInitExamplePaths);
            ClientOptions = clientOptions;
        }

        /// <summary>
        /// Calculate the method invocation chains fo examples on how to get a client, like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// </summary>
        /// <returns> A dictionary indexed by client type name. Each value is a list of the method invocation to get a specific client. </returns>
        private IReadOnlyDictionary<string, IReadOnlyList<MethodSignatureBase>> GetRestClientInitExamplePaths()
        {
            var paths = new Dictionary<string, IReadOnlyList<MethodSignatureBase>>();

            foreach (var client in RestClients.Where(r => !r.IsSubClient))
            {
                // use the secondary constructor with minimal parameters
                var path = new List<MethodSignatureBase> { client.SecondaryConstructors.Where(c => c.Modifiers == MethodSignatureModifiers.Public).OrderBy(c => c.Parameters.Count).First() };
                paths.Add(client.Type.Name, path);
                GetSubRestClientInitExamplePaths(client.SubClients, client.SubClientFactoryMethods, path, paths);
            }
            return paths;
        }

        private void GetSubRestClientInitExamplePaths(IReadOnlyList<LowLevelClient> subClients, IReadOnlyList<LowLevelSubClientFactoryMethod> subClientFactoryMethods, List<MethodSignatureBase> parentPath, Dictionary<string, IReadOnlyList<MethodSignatureBase>> paths)
        {
            foreach (var client in subClients)
            {
                foreach (var factoryMethod in subClientFactoryMethods)
                {
                    if (client.Type.Name == factoryMethod.ClientTypeName)
                    {
                        var path = new List<MethodSignatureBase>(parentPath);
                        path.Add(factoryMethod.Signature);
                        paths.Add(client.Type.Name, path);
                        GetSubRestClientInitExamplePaths(client.SubClients, client.SubClientFactoryMethods, path, paths);
                    }
                }
            }
        }

        public override CSharpType FindTypeForSchema(Schema schema)
            => schema.Type switch
            {
                AllSchemaTypes.Choice => _context.TypeFactory.CreateType(((ChoiceSchema)schema).ChoiceType, false),
                AllSchemaTypes.SealedChoice => _context.TypeFactory.CreateType(((SealedChoiceSchema)schema).ChoiceType, false),
                // This is technically invalid behavior, we are hitting this in generating responses we throw away.
                // https://github.com/Azure/autorest.csharp/issues/1108
                // throw new InvalidOperationException($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
                _ => new CSharpType(typeof(object))
            };

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
