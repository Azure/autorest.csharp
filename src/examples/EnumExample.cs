namespace Azure.Storage.Blobs.Models
{
    public enum ArchiveStatus
    {
        RehydratePendingToHot,
        RehydratePendingToCool
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.ArchiveStatus value)
            {
                return value switch
                {
                    Azure.Storage.Blobs.Models.ArchiveStatus.RehydratePendingToHot => "rehydrate-pending-to-hot",
                    Azure.Storage.Blobs.Models.ArchiveStatus.RehydratePendingToCool => "rehydrate-pending-to-cool",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ArchiveStatus value.")
                };
            }

            public static Azure.Storage.Blobs.Models.ArchiveStatus ParseArchiveStatus(string value)
            {
                return value switch
                {
                    "rehydrate-pending-to-hot" => Azure.Storage.Blobs.Models.ArchiveStatus.RehydratePendingToHot,
                    "rehydrate-pending-to-cool" => Azure.Storage.Blobs.Models.ArchiveStatus.RehydratePendingToCool,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ArchiveStatus value.")
                };
            }
        }
    }
}