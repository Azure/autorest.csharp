// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class LongRunningInterimOperation
    {
        public LongRunningInterimOperation(CSharpType returnType, string methodName)
        {
            var rpName = MgmtContext.Context.DefaultNamespace.Split('.').Last();
            ReturnType = returnType;
            BaseClassType = new CSharpType(typeof(ArmOperation<>), returnType);
            IOperationSourceType = new CSharpType(typeof(IOperationSource<>), returnType);
            StateLockType = new CSharpType(typeof(AsyncLockWithValue<>), returnType);
            ValueTaskType = new CSharpType(typeof(ValueTask<>), returnType);
            ResponseType = new CSharpType(typeof(Response<>), returnType);
            OperationType = $"{rpName}ArmOperation<{returnType}>";
            TypeName = $"{rpName}{methodName}Operation";
        }

        public CSharpType ReturnType { get; }

        public CSharpType BaseClassType { get; }

        public CSharpType IOperationSourceType { get; }

        public CSharpType StateLockType { get; }

        public CSharpType ValueTaskType { get; }

        public CSharpType ResponseType { get; }

        public string OperationType { get; }

        public string TypeName { get; }
    }
}
