namespace SMARDapi.Models;

/// <summary>
/// Represents metadata for SMARD (Strommarktdaten) data.
/// </summary>
public sealed class MetaData
{
    /// <summary>
    /// Gets or sets the version of the request.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Gets or sets the creation timestamp of the request.
    /// </summary>
    public SmardTimestamp Created { get; set; }

    /// <summary>
    /// Returns a string representation of the metadata.
    /// </summary>
    /// <returns>A string representation of the metadata, including the version and creation timestamp.</returns>
    public override string ToString()
    {
        return $"{Version} - {Created}";
    }
}
