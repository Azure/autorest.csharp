// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
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

        public FieldDeclaration ClientDiagnosticsField { get; }
        public FieldDeclaration PipelineField { get; }

        private readonly FieldDeclaration? _keyAuthField;
        private readonly FieldDeclaration? _tokenAuthField;
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;

        public IReadOnlyList<FieldDeclaration> CredentialFields { get; }

        public ClientFields(BuildContext<LowLevelOutputLibrary> context, IEnumerable<Parameter> parameters)
        {
            ClientDiagnosticsField = new(Internal | ReadOnly, typeof(ClientDiagnostics), "_" + KnownParameters.ClientDiagnostics.Name);
            PipelineField = new(Private | ReadOnly, typeof(HttpPipeline), "_" + KnownParameters.Pipeline.Name);

            var parameterNamesToFields = new Dictionary<string, FieldDeclaration>
            {
                [KnownParameters.Pipeline.Name] = PipelineField,
                [KnownParameters.ClientDiagnostics.Name] = ClientDiagnosticsField
            };

            var fields = new List<FieldDeclaration>();
            var credentialFields = new List<FieldDeclaration>();
            var properties = new List<FieldDeclaration>();
            foreach (var scheme in context.CodeModel.Security.Schemes)
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        AuthorizationHeaderConstant = new(Private | Const, typeof(string), "AuthorizationHeader", $"{azureKeySecurityScheme.HeaderName:L}");
                        _keyAuthField = new(Private | ReadOnly, KnownParameters.KeyAuth.Type.WithNullable(true), "_" + KnownParameters.KeyAuth.Name);

                        fields.Add(AuthorizationHeaderConstant);
                        fields.Add(_keyAuthField);
                        credentialFields.Add(_keyAuthField);
                        parameterNamesToFields[KnownParameters.KeyAuth.Name] = _keyAuthField;
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        ScopesConstant = new(Private | Static | ReadOnly, typeof(string[]), "AuthorizationScopes", $"new string[]{{ {aadTokenSecurityScheme.Scopes.GetLiteralsFormattable()} }}");
                        _tokenAuthField = new(Private | ReadOnly, KnownParameters.TokenAuth.Type.WithNullable(true), "_" + KnownParameters.TokenAuth.Name);

                        fields.Add(ScopesConstant);
                        fields.Add(_tokenAuthField);
                        credentialFields.Add(_tokenAuthField);
                        parameterNamesToFields[KnownParameters.TokenAuth.Name] = _tokenAuthField;
                        break;
                }
            }

            fields.Add(PipelineField);
            fields.Add(ClientDiagnosticsField);

            foreach (Parameter parameter in parameters)
            {
                var field = parameter.IsResourceIdentifier
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
            _fields = fields;
            _parameterNamesToFields = parameterNamesToFields;
            CredentialFields = credentialFields;
        }

        public FieldDeclaration? GetFieldByParameter(string parameterName, CSharpType parameterType)
            => parameterName switch
            {
                "credential" when _keyAuthField != null && parameterType.EqualsIgnoreNullable(_keyAuthField.Type) => _keyAuthField,
                "credential" when _tokenAuthField != null && parameterType.EqualsIgnoreNullable(_tokenAuthField.Type) => _tokenAuthField,
                var name => _parameterNamesToFields.TryGetValue(name, out var field) ? field : null
            };

        public FieldDeclaration? GetFieldByParameter(Parameter parameter)
            => GetFieldByParameter(parameter.Name, parameter.Type);

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _fields.GetEnumerator();
        public int Count => _fields.Count;
    }
}
