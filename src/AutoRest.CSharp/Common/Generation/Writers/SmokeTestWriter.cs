// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Samples;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using NUnit.Framework;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class SmokeTestWriter
    {
        private readonly CodeWriter _writer;
        private readonly DpgClient _client;
        private readonly DpgClientSampleProvider _sampleProvider;

        public SmokeTestWriter(DpgClient client, DpgClientSampleProvider sampleProvider)
        {
            _writer = new CodeWriter();
            _client = client;
            _sampleProvider = sampleProvider;
        }

        public void Write()
        {
            using (_writer.Namespace($"{_client.Type.Namespace}.Tests"))
            {
                using (_writer.Scope($"public partial class {_client.Type.Name}Tests"))
                {
                    var exampleMethod = _client.OperationMethods.First(m => m.Samples.Count > 0).Samples.First();
                    var clientVariableStatements = new List<MethodBodyStatement>();
                    var newClientStatement = _sampleProvider.BuildGetClientStatement(_client.Type, exampleMethod, exampleMethod.ClientInvocationChain, clientVariableStatements, out var clientVar);

                    var method = new Method
                    (
                        new MethodSignature("SmokeTest", null, null, MethodSignatureModifiers.Public, null, null, Array.Empty<Parameter>(), new[] { new CSharpAttribute(typeof(TestAttribute)) }),
                        new[]
                        {
                            clientVariableStatements,
                            newClientStatement,
                            new InvokeStaticMethodStatement(typeof(Assert), nameof(Assert.IsNotNull), clientVar)
                        }
                    );

                    _writer.WriteMethod(method);
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
