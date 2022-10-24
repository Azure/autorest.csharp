// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class UnknownPolymorphicResourceWriter : ResourceWriter
    {
        private BaseResource.UnknownPolymorphicResource This { get; }
        protected internal UnknownPolymorphicResourceWriter(BaseResource.UnknownPolymorphicResource resource) : base(resource)
        {
            This = resource;
        }

        protected override void InitializeCustomMethodWriters()
        {
            foreach ((var operation, var coreOperation) in This.CommonOperations)
            {
                _customMethods.Add($"Write{operation.Name}Body", WriteRedirectMethodBody);
                _customMethods.Add($"Write{coreOperation.Name}Body", WriteNotImplementedMethodBody);
            }
        }

        protected override void WriteStaticMethods()
        {
        }

        private void WriteNotImplementedMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            _writer.LineIf($"await {typeof(Task)}.Run(() => _ = 1);", isAsync);
            _writer.Line($"throw new {typeof(NotImplementedException)}();");
        }
    }
}
