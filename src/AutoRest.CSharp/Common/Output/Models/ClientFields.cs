// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core.Pipeline;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal class ClientFields : IReadOnlyCollection<FieldDeclaration>
    {
        public FieldDeclaration? AuthorizationHeaderConstant { get; }
        public FieldDeclaration? ScopesConstant { get; }

        public FieldDeclaration ClientDiagnosticsProperty { get; }
        public FieldDeclaration PipelineField { get; }

        private readonly FieldDeclaration? _keyAuthField;
        private readonly FieldDeclaration? _tokenAuthField;
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;
        private static readonly FormattableString ClientDiagnosticsDescription = $"The ClientDiagnostics is used to provide tracing support for the client library.";

        public IReadOnlyList<FieldDeclaration> CredentialFields { get; }

        public static ClientFields CreateForClient(IEnumerable<Parameter> parameters, BuildContext context) => new(parameters, context);

        public static ClientFields CreateForRestClient(IEnumerable<Parameter> parameters) => new(parameters, null);

        private ClientFields(IEnumerable<Parameter> parameters, BuildContext? context)
        {
            ClientDiagnosticsProperty = new(ClientDiagnosticsDescription, Internal | ReadOnly, typeof(ClientDiagnostics), KnownParameters.ClientDiagnostics.Name.FirstCharToUpperCase(), writeAsProperty: true);
            PipelineField = new(Private | ReadOnly, typeof(HttpPipeline), "_" + KnownParameters.Pipeline.Name);

            var parameterNamesToFields = new Dictionary<string, FieldDeclaration>();
            var fields = new List<FieldDeclaration>();
            var credentialFields = new List<FieldDeclaration>();
            var properties = new List<FieldDeclaration>();

            if (context != null)
            {
                parameterNamesToFields[KnownParameters.Pipeline.Name] = PipelineField;
                parameterNamesToFields[KnownParameters.ClientDiagnostics.Name] = ClientDiagnosticsProperty;

                foreach (var scheme in context.CodeModel.Security.Schemes)
                {
                    switch (scheme)
                    {
                        case AzureKeySecurityScheme azureKeySecurityScheme:
                            AuthorizationHeaderConstant = new(Private | Const, typeof(string), "AuthorizationHeader", $"{azureKeySecurityScheme.HeaderName:L}");
                            _keyAuthField = new(Private | ReadOnly, KnownParameters.KeyAuth.Type.WithNullable(false), "_" + KnownParameters.KeyAuth.Name);

                            fields.Add(AuthorizationHeaderConstant);
                            fields.Add(_keyAuthField);
                            credentialFields.Add(_keyAuthField);
                            parameterNamesToFields[KnownParameters.KeyAuth.Name] = _keyAuthField;
                            break;
                        case AADTokenSecurityScheme aadTokenSecurityScheme:
                            ScopesConstant = new(Private | Static | ReadOnly, typeof(string[]), "AuthorizationScopes", $"new string[]{{ {aadTokenSecurityScheme.Scopes.GetLiteralsFormattable()} }}");
                            _tokenAuthField = new(Private | ReadOnly, KnownParameters.TokenAuth.Type.WithNullable(false), "_" + KnownParameters.TokenAuth.Name);

                            fields.Add(ScopesConstant);
                            fields.Add(_tokenAuthField);
                            credentialFields.Add(_tokenAuthField);
                            parameterNamesToFields[KnownParameters.TokenAuth.Name] = _tokenAuthField;
                            break;
                    }
                }

                fields.Add(PipelineField);
            }

            foreach (Parameter parameter in parameters)
            {
                var field = parameter == KnownParameters.ClientDiagnostics ? ClientDiagnosticsProperty : parameter == KnownParameters.Pipeline ? PipelineField : parameter.IsResourceIdentifier
                        ? new FieldDeclaration($"{parameter.Description}", Public | ReadOnly, parameter.Type, parameter.Name.FirstCharToUpperCase(), writeAsProperty: true)
                        : new FieldDeclaration(Private | ReadOnly, parameter.Type, "_" + parameter.Name);

                if (field.WriteAsProperty)
                {
                    properties.Add(field);
                }
                else
                {
                    fields.Add(field);
                }
                parameterNamesToFields.Add(parameter.Name, field);
            }

            fields.AddRange(properties);
            if (context != null)
            {
                fields.Add(ClientDiagnosticsProperty);
            }

            _fields = fields;
            _parameterNamesToFields = parameterNamesToFields;
            CredentialFields = credentialFields;
        }

        public FieldDeclaration? GetFieldByParameter(string parameterName, CSharpType parameterType)
            => parameterName switch
            {
                "credential" when _keyAuthField != null && parameterType.EqualsIgnoreNullable(_keyAuthField.Type) => _keyAuthField,
                "credential" when _tokenAuthField != null && parameterType.EqualsIgnoreNullable(_tokenAuthField.Type) => _tokenAuthField,
                var name => _parameterNamesToFields.TryGetValue(name, out var field) ? parameterType.Equals(field.Type) ? field : null : null
            };

        public FieldDeclaration? GetFieldByParameter(Parameter parameter)
            => GetFieldByParameter(parameter.Name, parameter.Type);

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _fields.GetEnumerator();
        public int Count => _fields.Count;
    }
}
