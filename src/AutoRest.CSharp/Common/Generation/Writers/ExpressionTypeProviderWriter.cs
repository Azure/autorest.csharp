// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ExpressionTypeProviderWriter
    {
        private readonly ExpressionTypeProvider _provider;
        private readonly CodeWriter _writer;

        public ExpressionTypeProviderWriter(CodeWriter writer, ExpressionTypeProvider provider)
        {
            _provider = provider;
            _writer = writer;
        }

        public virtual void Write()
        {
            foreach (var @using in _provider.Usings)
            {
                _writer.UseNamespace(@using);
            }

            if (_provider.DeclaringTypeProvider == null)
            {
                using (_writer.Namespace(_provider.Declaration.Namespace))
                {
                    WriteType();
                }
            }
            else
            {
                WriteType();
            }
        }

        private void WriteType()
        {
            if (_provider.IsEnum)
            {
                WriteEnum();
            }
            else
            {
                WriteClassOrStruct();
            }
        }

        private void WriteClassOrStruct()
        {
            _writer.WriteTypeModifiers(_provider.DeclarationModifiers);
            if (_provider.IsStruct)
            {
                _writer.AppendRaw(" struct ");
            }
            else
            {
                _writer.AppendRaw(" class ");
            }
            _writer.Append($"{_provider.Type:D}")
                .AppendRawIf(" : ", _provider.Inherits != null || _provider.Implements.Any())
                .AppendIf($"{_provider.Inherits},", _provider.Inherits != null);

            foreach (var implement in _provider.Implements)
            {
                _writer.Append($"{implement:D},");
            }
            _writer.RemoveTrailingComma();

            if (_provider.WhereClause is not null)
            {
                _provider.WhereClause.Write(_writer);
            }

            using (_writer.Scope())
            {
                WriteFields();

                WriteConstructors();

                WriteProperties();

                WriteMethods();

                WriteNestedTypes();
            }
        }

        private void WriteEnum()
        {
            _writer.WriteTypeModifiers(_provider.DeclarationModifiers);
            _writer.Append($" enum {_provider.Type:D}")
                .AppendRawIf(" : ", _provider.Inherits != null)
                .AppendIf($"{_provider.Inherits}", _provider.Inherits != null);

            using (_writer.Scope())
            {
                foreach (var field in _provider.Fields)
                {
                    _writer.Append($"{field.Declaration:D}");
                    if (field.InitializationValue != null)
                    {
                        _writer.AppendRaw(" = ");
                        field.InitializationValue.Write(_writer);
                    }
                    _writer.LineRaw(",");
                }
                _writer.RemoveTrailingComma();
            }
        }

        protected virtual void WriteProperties()
        {
            foreach (var property in _provider.Properties)
            {
                _writer.WriteProperty(property);
                _writer.Line();
            }
        }

        protected virtual void WriteFields()
        {
            foreach (var field in _provider.Fields)
            {
                _writer.WriteField(field, declareInCurrentScope: true);
            }
            _writer.Line();
        }

        protected virtual void WriteConstructors()
        {
            foreach (var ctor in _provider.Constructors)
            {
                _writer.WriteMethod(ctor);
            }
        }

        protected virtual void WriteMethods()
        {
            foreach (var method in _provider.Methods)
            {
                _writer.WriteMethod(method);
            }

            _writer.Line();
        }

        protected virtual void WriteNestedTypes()
        {
            foreach (var nested in _provider.NestedTypes)
            {
                var nestedWriter = new ExpressionTypeProviderWriter(_writer, nested);
                nestedWriter.Write();
                _writer.Line();
            }
        }
    }
}
