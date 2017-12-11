// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AzureReport
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AutoRestReportServiceForAzure.
    /// </summary>
    public static partial class AutoRestReportServiceForAzureExtensions
    {
            /// <summary>
            /// Get test coverage report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='qualifier'>
            /// If specified, qualifies the generated report further (e.g. '2.7' vs '3.5'
            /// in for Python). The only effect is, that generators that run all tests
            /// several times, can distinguish the generated reports.
            /// </param>
            public static IDictionary<string, int?> GetReport(this IAutoRestReportServiceForAzure operations, string qualifier = default(string))
            {
                return operations.GetReportAsync(qualifier).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get test coverage report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='qualifier'>
            /// If specified, qualifies the generated report further (e.g. '2.7' vs '3.5'
            /// in for Python). The only effect is, that generators that run all tests
            /// several times, can distinguish the generated reports.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IDictionary<string, int?>> GetReportAsync(this IAutoRestReportServiceForAzure operations, string qualifier = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetReportWithHttpMessagesAsync(qualifier, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
