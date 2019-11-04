// INPUT

public partial class BlobAnalyticsLogging
{
    public string Version { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }
    public bool Write { get; set; }
    public Azure.Storage.Blobs.Models.BlobRetentionPolicy RetentionPolicy { get; set; }
}


// OUTPUT ONLY

public partial class AccountInfo
{
    public Azure.Storage.Blobs.Models.SkuName SkuName { get; internal set; }
    public Azure.Storage.Blobs.Models.AccountKind AccountKind { get; internal set; }

    internal AccountInfo() { }
}

public static partial class BlobsModelFactory
{
    public static AccountInfo AccountInfo(Azure.Storage.Blobs.Models.SkuName skuName, Azure.Storage.Blobs.Models.AccountKind accountKind)
    {
        return new AccountInfo()
        {
            SkuName = skuName,
            AccountKind = accountKind,
        };
    }
}