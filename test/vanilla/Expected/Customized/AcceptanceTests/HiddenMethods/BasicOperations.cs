namespace Fixtures.AcceptanceTestsHiddenMethods
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BasicOperations operations.
    /// </summary>
    public partial class BasicOperations : IServiceOperations<AutoRestComplexTestService>, IBasicOperations
    {
        public async Task PutValidAsync(string name, string color, int? id = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await PutValidWithHttpMessagesAsync(new Basic(id, name, color), customHeaders, cancellationToken);
        }
    }
}