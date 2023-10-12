// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class OperationItem : TransformableItem
    {
        public OperationItem(MgmtRestOperation operation, TransformSection transformSection)
            : base(operation.OperationId, transformSection)
        {
            this.OperationId = operation.OperationId;
            this.IsLongRunningOperation = operation.IsLongRunningOperation;
            this.IsPageableOperation = operation.IsPagingOperation;
        }

        public string OperationId { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        public bool IsLongRunningOperation { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        public bool IsPageableOperation { get; set; }
    }
}
