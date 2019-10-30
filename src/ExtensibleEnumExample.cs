private readonly string _value;

public BlobErrorCode(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }

public static Azure.Storage.Blobs.Models.BlobErrorCode AccountAlreadyExists { get; } = new BlobErrorCode(@"AccountAlreadyExists");
public static Azure.Storage.Blobs.Models.BlobErrorCode AccountBeingCreated { get; } = new BlobErrorCode(@"AccountBeingCreated");
public static Azure.Storage.Blobs.Models.BlobErrorCode AccountIsDisabled { get; } = new BlobErrorCode(@"AccountIsDisabled");
public static Azure.Storage.Blobs.Models.BlobErrorCode AuthenticationFailed { get; } = new BlobErrorCode(@"AuthenticationFailed");
public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationFailure { get; } = new BlobErrorCode(@"AuthorizationFailure");

public static bool operator ==(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) => left.Equals(right);

public static bool operator !=(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) => !left.Equals(right);

public static implicit operator BlobErrorCode(string value) => new Azure.Storage.Blobs.Models.BlobErrorCode(value);

[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public override bool Equals(object obj) => obj is Azure.Storage.Blobs.Models.BlobErrorCode other && Equals(other);

public bool Equals(Azure.Storage.Blobs.Models.BlobErrorCode other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public override int GetHashCode() => _value?.GetHashCode() ?? 0;

public override string ToString() => _value;





public readonly struct EncryptionAlgorithm : IEquatable<EncryptionAlgorithm>
{
    internal const string Rsa15Value = "RSA1_5";
    internal const string RsaOaepValue = "RSA-OAEP";
    internal const string RsaOaep256Value = "RSA-OAEP-256";
    private readonly string _value;

    public EncryptionAlgorithm(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static EncryptionAlgorithm Rsa15 { get; } = new EncryptionAlgorithm(Rsa15Value);
    public static EncryptionAlgorithm RsaOaep { get; } = new EncryptionAlgorithm(RsaOaepValue);
    public static EncryptionAlgorithm RsaOaep256 { get; } = new EncryptionAlgorithm(RsaOaep256Value);

    public static bool operator ==(EncryptionAlgorithm left, EncryptionAlgorithm right) => left.Equals(right);
    public static bool operator !=(EncryptionAlgorithm left, EncryptionAlgorithm right) => !left.Equals(right);
    public static implicit operator EncryptionAlgorithm(string value) => new EncryptionAlgorithm(value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is EncryptionAlgorithm other && Equals(other);
    public bool Equals(EncryptionAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    public override string ToString() => _value;
}