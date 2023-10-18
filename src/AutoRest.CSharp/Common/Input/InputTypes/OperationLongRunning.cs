// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Linq;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input;

internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse)
{
    public OperationLongRunning() : this(FinalStateVia: OperationFinalStateVia.Location, FinalResponse: new OperationResponse()) { }

    /// <summary>
    /// Meaninngful return type of the long running operation.
    /// </summary>
    public InputType? ReturnType
    {
        get
        {
            if (FinalResponse.BodyType is null)
                return null;

            if (FinalResponse.ResultPath is null)
                return FinalResponse.BodyType;

            var rawResponseType = (InputModelType)FinalResponse.BodyType;
            return rawResponseType.Properties.FirstOrDefault(p => p.SerializedName == FinalResponse.ResultPath)!.Type;
        }
    }
}
