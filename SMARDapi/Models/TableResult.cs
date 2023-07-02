using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>
/// Result of a table request.
/// </summary>
public class TableResult
{
    internal TableResult(TableResultInternal tableResultInternal)
    {
        if (tableResultInternal == null)
            throw new ArgumentNullException(nameof(tableResultInternal));

        MetaData = new MetaData
        {
            Version = tableResultInternal.MetaData.Version,
            Created = new SmardTimestamp(tableResultInternal.MetaData.Created)
        };

        Series = tableResultInternal.Series[0].Values.Select(value => new SmardValue
        {
            Timestamp = new SmardTimestamp(value.Timestamp),
            Value = value.Versions.FirstOrDefault()?.Value
        }).ToList();
    }

    /// <summary>
    /// Meta data of the result.
    /// </summary>
    public MetaData MetaData { get; set; }

    /// <summary>
    /// List of values for the table data.
    /// </summary>
    public List<SmardValue> Series { get; set; }
}
