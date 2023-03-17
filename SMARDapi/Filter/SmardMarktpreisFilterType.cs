namespace SMARDapi.Filter;

public class SmardMarktpreisFilterType : SmardFilterType
{
    public static readonly SmardMarktpreisFilterType DeutschlandLuxemburg = new("4169");
    public static readonly SmardMarktpreisFilterType AnrainerDELu = new("5078");
    public static readonly SmardMarktpreisFilterType Belgien = new("4996");
    public static readonly SmardMarktpreisFilterType Norwegen2 = new("4997");
    public static readonly SmardMarktpreisFilterType Oesterreich = new("4170");
    public static readonly SmardMarktpreisFilterType Daenemark1 = new("252");
    public static readonly SmardMarktpreisFilterType Daenemark2 = new("253");
    public static readonly SmardMarktpreisFilterType Frankreich = new("254");
    public static readonly SmardMarktpreisFilterType ItalienNord = new("255");
    public static readonly SmardMarktpreisFilterType Niederlande = new("256");
    public static readonly SmardMarktpreisFilterType Polen1 = new("257");
    public static readonly SmardMarktpreisFilterType Polen2 = new("258");
    public static readonly SmardMarktpreisFilterType Schweiz = new("259");
    public static readonly SmardMarktpreisFilterType Slowenien = new("260");
    public static readonly SmardMarktpreisFilterType Tschechien = new("261");
    public static readonly SmardMarktpreisFilterType Ungarn = new("262");

    private SmardMarktpreisFilterType(string value) : base(value)
    {
    }
}