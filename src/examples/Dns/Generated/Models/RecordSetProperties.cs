// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class RecordSetProperties
    {
        private Dictionary<string, string>? _metadata;
        private List<ARecord>? _aRecords;
        private List<AaaaRecord>? _aAAARecords;
        private List<MxRecord>? _mXRecords;
        private List<NsRecord>? _nSRecords;
        private List<PtrRecord>? _pTRRecords;
        private List<SrvRecord>? _sRVRecords;
        private List<TxtRecord>? _tXTRecords;
        private List<CaaRecord>? _caaRecords;

        public IDictionary<string, string> Metadata => LazyInitializer.EnsureInitialized(ref _metadata);
        public int? TTL { get; set; }
        public string? Fqdn { get; set; }
        public string? ProvisioningState { get; set; }
        public SubResource? TargetResource { get; set; }
        public ICollection<ARecord> ARecords => LazyInitializer.EnsureInitialized(ref _aRecords);
        public ICollection<AaaaRecord> AAAARecords => LazyInitializer.EnsureInitialized(ref _aAAARecords);
        public ICollection<MxRecord> MXRecords => LazyInitializer.EnsureInitialized(ref _mXRecords);
        public ICollection<NsRecord> NSRecords => LazyInitializer.EnsureInitialized(ref _nSRecords);
        public ICollection<PtrRecord> PTRRecords => LazyInitializer.EnsureInitialized(ref _pTRRecords);
        public ICollection<SrvRecord> SRVRecords => LazyInitializer.EnsureInitialized(ref _sRVRecords);
        public ICollection<TxtRecord> TXTRecords => LazyInitializer.EnsureInitialized(ref _tXTRecords);
        public CnameRecord? CNAMERecord { get; set; }
        public SoaRecord? SOARecord { get; set; }
        public ICollection<CaaRecord> CaaRecords => LazyInitializer.EnsureInitialized(ref _caaRecords);
    }
}
