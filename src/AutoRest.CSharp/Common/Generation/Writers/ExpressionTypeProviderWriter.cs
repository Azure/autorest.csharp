// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ExpressionTypeProviderWriter
    {
        private readonly ExpressionTypeProvider _provider;
        private readonly CodeWriter _writer;

        public ExpressionTypeProviderWriter(ExpressionTypeProvider provider)
        {
            _provider = provider;
            _writer = new CodeWriter();
        }

        public virtual void Write()
        {
            foreach (var @using in _provider.Usings)
            {
                _writer.UseNamespace(@using);
            }

            using (_writer.Namespace(_provider.Declaration.Namespace))
            {
                _writer.Append($"{_provider.Declaration.Accessibility} partial class {_provider.Type:D}")
                    .AppendRawIf(" : ", _provider.Inherits != null || _provider.Implements.Any())
                    .AppendIf($"{_provider.Inherits},", _provider.Inherits != null);

                foreach (var implement in _provider.Implements)
                {
                    _writer.Append($"{implement:D},");
                }
                _writer.RemoveTrailingComma();

                using (_writer.Scope())
                {
                    WriteConstructors();

                    WriteMethods();
                }
            }
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
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
