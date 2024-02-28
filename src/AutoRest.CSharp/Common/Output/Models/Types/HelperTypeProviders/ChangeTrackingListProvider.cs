// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class ChangeTrackingListProvider : ExpressionTypeProvider
    {
        public ChangeTrackingListProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
        }

        protected override string DefaultName => "ChangeTrackingList";

        protected override string DefaultAccessibility => "internal";
    }
}
