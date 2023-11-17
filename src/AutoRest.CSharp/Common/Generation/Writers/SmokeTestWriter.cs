// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.LowLevel.Output.Samples;
using AutoRest.CSharp.Output.Models;
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
                    _writer.Line($"[{typeof(TestAttribute)}]");
                    using (_writer.Scope($"public void SmokeTest()"))
                    {
                        var exampleMethod = _client.ClientMethods.Where(m => m.Samples.Count() > 0).First().Samples.First();
                        var clientVariableStatements = new List<MethodBodyStatement>();
                        var newClientStatement = _sampleProvider.BuildGetClientStatement(exampleMethod, exampleMethod.ClientInvocationChain, clientVariableStatements, out var clientVar);
                        _writer.WriteMethodBodyStatement(clientVariableStatements);
                        _writer.WriteMethodBodyStatement(newClientStatement);
                        _writer.WriteMethodBodyStatement(new InvokeStaticMethodStatement(typeof(Assert), nameof(Assert.IsNotNull), clientVar));
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
