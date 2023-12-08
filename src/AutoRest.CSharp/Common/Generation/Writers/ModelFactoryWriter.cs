// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ModelFactoryWriter
    {
        protected CodeWriter _writer;
        private ModelFactoryTypeProvider This { get; }

        public ModelFactoryWriter(ModelFactoryTypeProvider modelFactoryProvider) : this(new CodeWriter(), modelFactoryProvider)
        {
        }

        public ModelFactoryWriter(CodeWriter writer, ModelFactoryTypeProvider modelFactoryProvider)
        {
            _writer = writer;
            This = modelFactoryProvider;
        }

        public void Write()
        {
            using (_writer.Namespace(This.Type.Namespace))
            {
                _writer.WriteXmlDocumentationSummary(This.Description);
                using (_writer.Scope($"{This.Declaration.Accessibility} static partial class {This.Type:D}"))
                {
                    foreach (var method in This.OutputMethods)
                    {
                        _writer.WriteMethodDocumentation(method.Signature);
                        _writer.WriteMethod(method);
                    }

                    foreach (OverloadMethodSignature overloadMethod in This.SignatureType!.OverloadMethods)
                    {
                        _writer.WriteOverloadMethod(overloadMethod);
                        _writer.Line();
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
