// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class Credential {
        public CredentialKind Kind { get; }
        private SecurityScheme? _schemeData;
        public T GetSchemeData<T>() where T : SecurityScheme => (T)_schemeData!;

        private Credential(SecurityScheme? scheme)
        {
            _schemeData = scheme;
            switch (_schemeData)
            {
                case AADTokenSecurityScheme:
                    Kind = CredentialKind.Token;
                    break;
                case AzureKeySecurityScheme:
                    Kind = CredentialKind.Key;
                    break;
                case null:
                    Kind = CredentialKind.None;
                    break;
                default:
                    throw new NotImplementedException ($"Unknown credential kind {_schemeData.GetType()}");
            }
        }

        internal static List<Credential> Create(BuildContext<LowLevelOutputLibrary> context)
        {
            var credentials = context.CodeModel.Security.Schemes.Select(s => new Credential(s)).ToList();

            if (credentials.Count == 0)
            {
                credentials.Add (new Credential(null));
            }

            return credentials;
        }
    }
}